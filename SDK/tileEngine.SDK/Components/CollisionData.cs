using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace tileEngine.SDK.Components
{
    /// <summary>
    /// Contains data about a single collider's current collisions.
    /// </summary>
    public struct CollisionData
    {
        public List<Point> CollidingTiles;
        public List<Point> TriggeringEvents;
    }
}