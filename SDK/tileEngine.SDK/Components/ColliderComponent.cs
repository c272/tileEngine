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
        /// Returns a list of points at which the GameObject is colliding with collision hull
        /// squares on the provided tile layer.
        /// </summary>
        public abstract List<Point> Colliding(GameObject gameObject, TileLayer layer);
    }
}
