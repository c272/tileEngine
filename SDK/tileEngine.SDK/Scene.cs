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
        public Vector2 CameraPosition { get; protected set; } = new Vector2(0, 0);

        /// <summary>
        /// The current zoom of the camera in this scene.
        /// </summary>
        public float Zoom { get; protected set; } = 1f;

        //Cache of textures used for drawing map tiles.
        private Dictionary<int, Texture2D> tileTextureCache = new Dictionary<int, Texture2D>();

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
        /// Draws the scene.
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            //Calculate the top-left most and bottom-right most tile to draw.
            Vector2 topLeft = ToGridLocation(new Point(0, 0));
            Vector2 bottomRight = ToGridLocation(new Point(spriteBatch.GraphicsDevice.PresentationParameters.BackBufferWidth,
                                                           spriteBatch.GraphicsDevice.PresentationParameters.BackBufferHeight));
            Point topLeftTile = new Point((int)topLeft.X, (int)topLeft.Y);
            Point bottomRightTile = new Point((int)bottomRight.X, (int)bottomRight.Y);

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
                        if (!layer.Tiles.ContainsKey(curTile))
                            continue;

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
                        float pixelsPerTile = Zoom * Map.TileTextureSize;
                        Vector2 screenPos = new Vector2(curTile.X * pixelsPerTile, curTile.Y * pixelsPerTile);
                        Rectangle sourceRect = new Rectangle(tileData.Position.X * Map.TileTextureSize,
                                                             tileData.Position.Y * Map.TileTextureSize,
                                                             Map.TileTextureSize, Map.TileTextureSize);
                        float relativeScale = pixelsPerTile / Map.TileTextureSize;

                        spriteBatch.Draw(tileTex, screenPos, sourceRect, Color.White * layer.Opacity, 0f, new Vector2(0,0), 
                                         new Vector2(relativeScale, relativeScale), SpriteEffects.None, 0);
                    }
                }

                //Draw the game objects for this layer.
                var layerObjects = GameObjects.Where(x => x.Layer == layer.ID).ToList();
                for (int i = 0; i < layerObjects.Count; i++)
                {
                    //...
                }
            }
            spriteBatch.End();
        }

        /// <summary>
        /// Called when the scene is first entered.
        /// </summary>
        public virtual void Initialize() { }

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
                GameObjects[i].Components.ForEach(x => x.Update(GameObjects[i], delta));
            }

            //Collision check.
            CheckCollisions();
        }

        /// <summary>
        /// Checks collisions between game objects and the collision hull.
        /// </summary>
        private void CheckCollisions()
        {
            //Loop over game objects, check any attached colliders.
            for (int i=0; i<GameObjects.Count; i++)
            {
                //Get colliders for this object.
                var colliders = GameObjects[i].Components.Where(x => x is ColliderComponent)
                                                         .Select(x => (ColliderComponent)x)
                                                         .ToList();
                if (colliders.Count == 0)
                    continue;

                //Process whether there are colliding tiles.
                foreach (var collider in colliders)
                {
                    //No collisions if layer is invalid.
                    if (GameObjects[i].Layer >= Map.Layers.Count)
                        break;

                    //Attempt to move the GameObject away from any colliding tiles.
                    //Limit to 5 iterations per update loop.
                    int limit = 5;
                    int iteration = 0;
                    do
                    {
                        //If no colliding tiles, break.
                        var collidingTiles = collider.Colliding(GameObjects[i], Map.Layers[GameObjects[i].Layer]);
                        if (collidingTiles.Count == 0)
                            break;

                        //Step GameObject away from first colliding tile.
                        Vector2 vectorToTile = new Vector2(collidingTiles[0].X - GameObjects[i].Position.X,
                                                           collidingTiles[0].Y - GameObjects[i].Position.Y);
                        vectorToTile.Normalize();
                        GameObjects[i].Position -= vectorToTile * 0.1f;
                    }
                    while (iteration < limit);
                }
            }
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
