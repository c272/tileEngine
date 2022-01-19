using Microsoft.Xna.Framework;
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

        public override List<Point> Colliding(GameObject gameObject, TileLayer layer)
        {
            //Check all points within the box.
            List<Point> colliding = new List<Point>();
            for (int y = (int)Location.Y; y<Math.Ceiling(Location.Y + Size.Y); y++)
            {
                for (int x = (int)Location.X; x < Math.Ceiling(Location.X + Size.X); x++)
                {
                    //No collider.
                    var tile = new Point(x, y);
                    if (!layer.CollisionHull.ContainsKey(tile))
                        continue;

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
                        colliding.Add(tile);
                }
            }

            return colliding;
        }
    }
}
