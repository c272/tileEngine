using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tileEngine.SDK.Map;

namespace tileEngine.SDK.Components
{
    /// <summary>
    /// Represents a simple box collider within tileEngine.
    /// </summary>
    public class BoxColliderComponent : ColliderComponent
    {
        /// <summary>
        /// The size of the box collider, in grid units.
        /// </summary>
        public Vector2 Size { get; set; }

        /// <summary>
        /// Represents the top left point of the collider relative to the GameObject.
        /// </summary>
        public Vector2 Location { get; set; } = Vector2.Zero;

        /// <summary>
        /// Draws this collider as a debugging tool, if enabled.
        /// </summary>
        public override void Draw(GameObject gameObject, SpriteBatch spriteBatch)
        {
            if (!DrawColliders)
                return;

            Vector2 screenPos = gameObject.Scene.ToScreenPointF(gameObject.Position + Location);
            spriteBatch.Draw(Scene.PointTexture, screenPos, null, Color.Red * 0.7f, 0f, Vector2.Zero, Size * gameObject.Scene.Zoom, SpriteEffects.None, 0f);
        }

        /// <summary>
        /// Checks if this box collider is colliding with any collision hull elements.
        /// </summary>
        public override CollisionData Colliding(GameObject gameObject, TileLayer layer)
        {
            //Get the starting location of the collider.
            Vector2 startLocation = gameObject.Position + Location;
            Point startTile = gameObject.Scene.GridToTileLocation(startLocation);
            Point bottomRightTile = gameObject.Scene.GridToTileLocation(startLocation + Size);

            //Check all points within the box.
            List<Point> colliding = new List<Point>();
            List<Point> eventsTriggered = new List<Point>();
            for (int y = startTile.Y; y <= bottomRightTile.Y; y++)
            {
                for (int x = startTile.X; x <= bottomRightTile.X; x++)
                {
                    var tile = new Point(x, y);
                    if (CollidingWith(gameObject, layer, tile, true))
                        colliding.Add(tile);

                    //If we're overlapping an event tile from collide, add it.
                    if (layer.Events.ContainsKey(tile) 
                        && layer.Events[tile].Trigger == EventTriggerType.GameObjectCollide
                        && gameObject.TriggersEvents)
                    {
                        eventsTriggered.Add(tile);
                    }
                }
            }

            //Form and return collision data.
            return new CollisionData()
            {
                CollidingTiles = colliding,
                TriggeringEvents = eventsTriggered
            };
        }

        /// <summary>
        /// Helper override for method overload.
        /// </summary>
        public override bool CollidingWith(GameObject gameObject, TileLayer layer, Point tile)
        {
            return CollidingWith(gameObject, layer, tile, false);
        }

        /// <summary>
        /// Returns whether this collider is colliding with a specific tile location.
        /// </summary>
        /// <param name="gameObject">The game object that is colliding or not.</param>
        /// <param name="layer">The layer to check collisions on.</param>
        /// <param name="tile">The tile coordinate to check at.</param>
        public bool CollidingWith(GameObject gameObject, TileLayer layer, Point tile, bool boundsPreChecked = false)
        {
            //No collider.
            if (!layer.CollisionHull.ContainsKey(tile))
                return false;

            //Within our bounds?
            if (!boundsPreChecked)
            {
                Vector2 startLocation = gameObject.Position + Location;
                Point startTile = gameObject.Scene.GridToTileLocation(startLocation);
                Point bottomRightTile = gameObject.Scene.GridToTileLocation(startLocation + Size);
                if (tile.X < startTile.X || tile.X > bottomRightTile.X
                    || tile.Y < startTile.Y || tile.Y > bottomRightTile.Y)
                {
                    return false;
                }
            }

            //Calculate the direction we're approaching the tile.
            EntryDirection approachDir = EntryDirection.None;
            if (gameObject.Position.X < tile.X)
                approachDir |= EntryDirection.Left;
            if (gameObject.Position.X > tile.X + 1)
                approachDir |= EntryDirection.Right;
            if (gameObject.Position.Y < tile.Y)
                approachDir |= EntryDirection.Top;
            if (gameObject.Position.Y > tile.Y + 1)
                approachDir |= EntryDirection.Bottom;

            //Found the collider! If the entry direction is invalid, we're colliding.
            EntryDirection entryDirs = layer.CollisionHull[tile];
            if ((int)(approachDir & ~entryDirs) > 0)
                return true;
            return false;
        }
    }
}
