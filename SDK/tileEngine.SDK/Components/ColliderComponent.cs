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
    /// Represents a component that handles collisions between objects.
    /// Called after each update loop to verify collision on the attached GameObject.
    /// </summary>
    public abstract class ColliderComponent : Component
    {
        /// <summary>
        /// Whether to draw colliders visually as semi-transparent boxes.
        /// Debugging tool, set to false by default.
        /// </summary>
        public static bool DrawColliders { get; set; } = false;

        /// <summary>
        /// Returns a list of points at which the GameObject is colliding with collision hull
        /// squares on the provided tile layer.
        /// </summary>
        public abstract List<Point> Colliding(GameObject gameObject, TileLayer layer);

        /// <summary>
        /// Returns whether this collider is colliding with a specific tile location.
        /// </summary>
        /// <param name="gameObject">The game object that is colliding or not.</param>
        /// <param name="layer">The layer to check collisions on.</param>
        /// <param name="tile">The tile coordinate to check at.</param>
        public abstract bool CollidingWith(GameObject gameObject, TileLayer layer, Point tile);
    }
}
