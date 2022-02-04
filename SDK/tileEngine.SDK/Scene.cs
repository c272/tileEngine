using tileEngine.SDK.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProtoBuf;
using tileEngine.SDK.Map;
using tileEngine.SDK.Diagnostics;
using tileEngine.SDK.Components;
using tileEngine.SDK.Attributes;
using System.Reflection;

namespace tileEngine.SDK
{
    /// <summary>
    /// Represents a single scene within the tileEngine engine.
    /// All scenes must have an accessible zero-parameter constructor for instance creation.
    /// </summary>
    [ProtoContract]
    public abstract class Scene
    {
        /// <summary>
        /// Utility texture, single pixel texture used for drawing solid colours.
        /// </summary>
        public static Texture2D PointTexture { get; private set; } = null;

        /// <summary>
        /// The game objects that are currently a part of this scene.
        /// </summary>
        public List<GameObject> GameObjects { get; private set; } = new List<GameObject>();

        /// <summary>
        /// The tilemap for this scene.
        /// </summary>
        [ProtoMember(1)]
        public TileMap Map { get; private set; } = new TileMap();

        /// <summary>
        /// The current location of the camera in this scene.
        /// Represents the top left of the current view.
        /// </summary>
        public Vector2 CameraPosition { get; set; } = new Vector2(0, 0);

        /// <summary>
        /// The current zoom of the camera in this scene.
        /// </summary>
        public float Zoom { get; protected set; } = 1f;

        //Cache of textures used for drawing map tiles.
        private Dictionary<int, Texture2D> tileTextureCache = new Dictionary<int, Texture2D>();

        //Dictionary of event functions registered for this scene class.
        private Dictionary<string, MethodInfo> eventFunctions = new Dictionary<string, MethodInfo>();

        //Cache of gameObjects currently colliding with event tiles.
        private Dictionary<int, List<Point>> eventCollisionCache = new Dictionary<int, List<Point>>();

        //////////////////
        /// PUBLIC API ///
        //////////////////

        /// <summary>
        /// Adds the provided GameObject to the scene.
        /// If it is already present, the call is ignored.
        /// </summary>
        public void AddObject(GameObject obj)
        {
            //Ignore duplicate adds.
            if (GameObjects.Any(x => x.ID == obj.ID))
                return;
            GameObjects.Add(obj);
            obj._scene = this;
        }

        /// <summary>
        /// Removes the provided GameObject from the scene.
        /// </summary>
        public void RemoveObject(GameObject obj)
        {
            GameObjects.RemoveAll(x => x.ID == obj.ID);
            obj._scene = null;
        }

        /// <summary>
        /// Changes the camera position so that the given point is centered.
        /// </summary>
        public void LookAt(Vector2 point)
        {
            Vector2 adjustedPoint = point;
            adjustedPoint.X -= TileEngine.Instance.GraphicsDevice.Viewport.Width / 2f;
            adjustedPoint.Y -= TileEngine.Instance.GraphicsDevice.Viewport.Height / 2f;
            CameraPosition = adjustedPoint;
        }

        /// <summary>
        /// Called when the scene is first entered.
        /// </summary>
        public virtual void Initialize()
        {
            //Pull the attributes on this class, filter for event functions.
            MethodInfo[] methods = this.GetType().GetMethods();
            foreach (var method in methods)
            {
                //Get the event function attribute for this (if there is one).
                var eventFuncAttrib = method.GetCustomAttribute<EventFunctionAttribute>();
                if (eventFuncAttrib == null)
                    continue;

                //Attempt to add to dictionary.
                if (eventFunctions.ContainsKey(eventFuncAttrib.Name))
                {
                    DiagnosticsHook.LogMessage(1008, $"Event function with duplicate name '{eventFuncAttrib.Name}' found in scene class {this.GetType()}.");
                    return;
                }
                eventFunctions.Add(eventFuncAttrib.Name, method);
            }
        }

        /// <summary>
        /// Draws the scene.
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            //Generate point texture if null.
            if (PointTexture == null)
            {
                PointTexture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
                PointTexture.SetData(new Color[] { Color.White });
            }

            //Calculate the top-left most and bottom-right most tile to draw.
            Vector2 topLeft = CameraPosition;
            Vector2 bottomRight = ToGridLocation(new Point(spriteBatch.GraphicsDevice.PresentationParameters.BackBufferWidth, spriteBatch.GraphicsDevice.PresentationParameters.BackBufferHeight));
            Point topLeftTile = GridToTileLocation(topLeft);
            Point bottomRightTile = GridToTileLocation(bottomRight, true);

            //Begin layer draws.
            spriteBatch.Begin();
            foreach (var layer in Map.Layers)
            {
                //Draw the tiles for this layer.
                for (int y = topLeftTile.Y; y <= bottomRightTile.Y; y++)
                {
                    for (int x = topLeftTile.X; x <= bottomRightTile.X; x++)
                    {
                        //Ignore if there is nothing at this tile.
                        Point curTile = new Point(x, y);
                        DrawTile(layer, curTile, spriteBatch);

                        //If "DrawColliders" is enabled, draw a collider box here (if there is one).
                        if (ColliderComponent.DrawColliders && layer.CollisionHull.ContainsKey(curTile))
                        {
                            Vector2 gridPos = TileToGridLocation(curTile);
                            Vector2 screenPos = ToScreenPointF(gridPos);
                            spriteBatch.Draw(PointTexture, screenPos, null, ColliderComponent.ColliderDrawColour, 0f, Vector2.Zero,
                                             new Vector2(Map.TileTextureSize * Zoom, Map.TileTextureSize * Zoom), SpriteEffects.None, 0);
                        }
                    }
                }

                //Draw any game object components for this layer.
                var layerObjects = GameObjects.Where(x => x.Layer == layer.ID).ToList();
                for (int i = 0; i < layerObjects.Count; i++)
                {
                    layerObjects[i].GetComponents().ForEach(x => x.Draw(layerObjects[i], spriteBatch));
                }
            }

            spriteBatch.End();
        }

        /// <summary>
        /// Draws a given tile on a given layer onto the sprite batch's back buffer.
        /// </summary>
        private void DrawTile(TileLayer layer, Point curTile, SpriteBatch spriteBatch)
        {
            //Ignore if no tile here.
            if (!layer.Tiles.ContainsKey(curTile))
                return;

            //If this tile's texture isn't in cache yet, pull it to cache.
            TileData tileData = layer.Tiles[curTile];
            if (!tileTextureCache.ContainsKey(tileData.TextureID))
            {
                var tex = AssetManager.AttemptLoad<Texture2D>(tileData.TextureID);
                if (tex == null)
                    DiagnosticsHook.LogMessage(21011, $"Failed to load texture ID {tileData.TextureID} for map draw.", DiagnosticsSeverity.Warning);
                tileTextureCache.Add(tileData.TextureID, tex);
            }

            //Get the texture from cache, draw to screen.
            Texture2D tileTex = tileTextureCache[tileData.TextureID];
            Vector2 gridPos = TileToGridLocation(curTile);
            Vector2 screenPos = ToScreenPointF(gridPos);
            Rectangle sourceRect = new Rectangle(tileData.Position.X * Map.TileTextureSize,
                                                 tileData.Position.Y * Map.TileTextureSize,
                                                 Map.TileTextureSize, Map.TileTextureSize);

            spriteBatch.Draw(tileTex, screenPos, sourceRect, Color.White * layer.Opacity, 0f, new Vector2(0, 0),
                             new Vector2(Zoom, Zoom), SpriteEffects.None, 0);
        }

        /// <summary>
        /// Updates the scene object based on the time from the previous update.
        /// </summary>
        public virtual void Update(GameTime delta) 
        { 
            //Update all GameObjects.
            for (int i = 0; i < GameObjects.Count; i++)
            {
                GameObjects[i].Update(delta);

                //Update all this GameObject's components.
                GameObjects[i].GetComponents().ForEach(x => x.Update(GameObjects[i], delta));

                //Collision check for this object.
                CheckCollisions(GameObjects[i]);
            }
        }

        /// <summary>
        /// Checks collisions between game objects and the collision hull.
        /// </summary>
        private void CheckCollisions(GameObject gameObject)
        {
            //No collisions if layer is invalid.
            if (!Map.Layers.Any(x => x.ID == gameObject.Layer))
                return;
            var layer = Map.Layers.Find(x => x.ID == gameObject.Layer);

            //Get colliders for this object.
            var colliders = gameObject.GetComponents().Where(x => x is ColliderComponent)
                                                        .Select(x => (ColliderComponent)x)
                                                        .ToList();
            if (colliders.Count == 0)
                return;

            //Get all other colliders for this layer.
            var layerColliders = GameObjects.Where(x => x.Layer == gameObject.Layer)
                                            .SelectMany(x => x.GetComponents().OfType<ColliderComponent>()).ToList();

            //Process whether there are colliding tiles.
            foreach (var collider in colliders)
            {
                //Attempt to move the GameObject away from any colliding tiles.
                //Limit to 5 iterations per update loop.
                int limit = 5;
                int iteration = 0;
                CollisionData collideData;
                do
                {
                    //If no colliding tiles, & no colliding objects, break.
                    collideData = collider.Colliding(layer, layerColliders);
                    if (collideData.CollidingTiles.Count == 0 && collideData.CollidingColliders.Count == 0)
                        break;

                    //Step GameObject away from first colliding tile.
                    if (collideData.CollidingTiles.Count > 0) 
                    {
                        Vector2 tileGridLoc = TileToGridLocation(collideData.CollidingTiles[0]);
                        Vector2 vectorToTile = new Vector2(tileGridLoc.X + (Map.TileTextureSize / 2f) - gameObject.Position.X,
                                                            tileGridLoc.Y + (Map.TileTextureSize / 2f) - gameObject.Position.Y);
                        vectorToTile.Normalize();
                        do
                        {
                            gameObject.Position -= vectorToTile * 0.01f;
                        }
                        while (collider.CollidingWith(layer, collideData.CollidingTiles[0]));
                    }

                    //Step GameObject away from first colliding other object.
                    if (collideData.CollidingColliders.Count > 0)
                    {
                        Vector2 vectorToOther = collideData.CollidingColliders[0].Center - gameObject.Position;
                        vectorToOther.Normalize();
                        do
                        {
                            gameObject.Position -= vectorToOther * 0.01f;
                        }
                        while (collider.CollidingWith(collideData.CollidingColliders[0]));
                    }

                    iteration++;
                }
                while (iteration < limit);

                //Process triggered events from the collisions.
                ProcessEvents(gameObject, layer, collideData);
            }
        }

        /// <summary>
        /// Processes triggered events for a single GameObject, given the collision data for that object.
        /// </summary>
        private void ProcessEvents(GameObject gameObject, TileLayer layer, CollisionData collideData)
        {
            //Trigger any new events we have entered.
            foreach (var triggering in collideData.TriggeringEvents)
            {
                //If we're already triggering this event, ignore.
                if (eventCollisionCache.ContainsKey(gameObject.ID) &&
                    eventCollisionCache[gameObject.ID].Contains(triggering))
                {
                    continue;
                }

                //Craft event data for this event.
                var eventData = new TileEventData()
                {
                    Location = TileToGridLocation(triggering),
                    TriggeringObject = gameObject,
                    TriggerType = EventTriggerType.GameObjectCollide
                };

                //Check the linked function actually exists.
                var thisEvent = layer.Events[triggering];
                if (!eventFunctions.ContainsKey(thisEvent.LinkedFunction))
                {
                    DiagnosticsHook.LogMessage(1009, $"Event function '{thisEvent.LinkedFunction}' called from map, but not found in assembly.", DiagnosticsSeverity.Warning);
                    continue;
                }

                //Trigger this event!
                try
                {
                    eventFunctions[thisEvent.LinkedFunction].Invoke(this, new object[] { eventData });
                }
                catch (Exception ex)
                {
                    DiagnosticsHook.LogMessage(1010, $"Failed to call event function '{thisEvent.LinkedFunction}': {ex.Message}");
                    return;
                }
            }

            //Refresh event cache for this object.
            eventCollisionCache.Remove(gameObject.ID);
            if (collideData.TriggeringEvents.Count > 0)
                eventCollisionCache.Add(gameObject.ID, collideData.TriggeringEvents);
        }

        /// <summary>
        /// Dispose any active assets in the current scene.
        /// </summary>
        public virtual void Dispose() { }

        /// <summary>
        /// Sets the tile map on this scene to the provided new map.
        /// </summary>
        public void SetTileMap(TileMap map)
        {
            Map = map;
        }

        /////////////////////////
        /// UTILITY FUNCTIONS ///
        /////////////////////////

        /// <summary>
        /// Returns a screen rectangle (float precise) for the given grid space top left and bottom right coordinates.
        /// </summary>
        public RectF GetScreenRectangleF(Vector2 topLeft, Vector2 bottomRight)
        {
            Vector2 tlScreen = ToScreenPointF(topLeft);
            Vector2 brScreen = ToScreenPointF(bottomRight);
            return new RectF(tlScreen.X, tlScreen.Y, brScreen.X - tlScreen.X, brScreen.Y - tlScreen.Y);
        }

        /// <summary>
        /// Returns a screen rectangle (integer) for the given grid space top left and bottom right coordinates.
        /// </summary>
        public Rectangle GetScreenRectangle(Vector2 topLeft, Vector2 bottomRight)
        {
            Point tlScreen = ToScreenPoint(topLeft);
            Point brScreen = ToScreenPoint(bottomRight);
            return new Rectangle(tlScreen, new Point(brScreen.X - tlScreen.X, brScreen.Y - tlScreen.Y));
        }

        /// <summary>
        /// Converts a tile coordinate into a grid location.
        /// </summary>
        public Vector2 TileToGridLocation(Point tileLocation)
        {
            return new Vector2(tileLocation.X * Map.TileTextureSize, tileLocation.Y * Map.TileTextureSize);
        }

        /// <summary>
        /// Converts a given grid location to the appropriate tile coordinate.
        /// By default rounds to the closest tile to the top left of the point given.
        /// </summary>
        /// <param name="roundUp">Whether to round up to the tile to the bottom right of the point.</param>
        public Point GridToTileLocation(Vector2 gridLocation, bool roundUp = false)
        {
            if (roundUp)
                return new Point((int)Math.Ceiling(gridLocation.X / Map.TileTextureSize), (int)Math.Ceiling(gridLocation.Y / Map.TileTextureSize));
            return new Point((int)Math.Floor(gridLocation.X / Map.TileTextureSize), (int)Math.Floor(gridLocation.Y / Map.TileTextureSize));
        }

        /// <summary>
        /// Returns the grid location of a given screen point "p".
        /// </summary>
        public Vector2 ToGridLocation(Point p)
        {
            return ToGridLocation(new Vector2(p.X, p.Y));
        }

        /// <summary>
        /// Returns the grid location of a given screen vector "p".
        /// </summary>
        public Vector2 ToGridLocation(Vector2 p)
        {
            return new Vector2(CameraPosition.X + (p.X / Zoom), CameraPosition.Y + (p.Y / Zoom));
        }

        /// <summary>
        /// Returns the screen point location (integer) of a given grid location "v".
        /// </summary>
        public Point ToScreenPoint(Vector2 v)
        {
            Vector2 screenPoint = ToScreenPointF(v);
            return new Point((int)screenPoint.X, (int)screenPoint.Y);
        }

        /// <summary>
        /// Returns the screen point location of a given grid location "v".
        /// </summary>
        public Vector2 ToScreenPointF(Vector2 v)
        {
            return new Vector2((v.X - CameraPosition.X) * Zoom, (v.Y - CameraPosition.Y) * Zoom);
        }
    }
}
