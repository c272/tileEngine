using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tileEngine.SDK.Utility
{
    /// <summary>
    /// Utility class to represent a floating point rectangle.
    /// Because apparently this isn't built into MonoGame?
    /// </summary>
    public struct RectF
    {
        public Vector2 Location { get; set; }
        public Vector2 Size { get; set; }

        /// <summary>
        /// Creates a floating point rectangle from the top left coordinate and width/height values.
        /// </summary>
        public RectF(float x, float y, float width, float height)
        {
            Location = new Vector2(x, y);
            Size = new Vector2(width, height);
        }

        /// <summary>
        /// Creates a floating point rectangle from the top left coordinate and a size.
        /// </summary>
        public RectF(Vector2 loc, Vector2 size)
        {
            Location = loc;
            Size = size;
        }
        
        /// <summary>
        /// Returns whether this rectangle's area contains the given point.
        /// </summary>
        public bool Contains(Point point)
        {
            return (point.X > Location.X && point.Y > Location.Y && point.X < Location.X + Size.X && point.Y < Location.Y + Size.Y);
        }

        /// <summary>
        /// Multiplies the size of this rectangle by the given constant.
        /// </summary>
        public static RectF operator *(RectF rect, float value)
        {
            return new RectF(rect.Location, rect.Size * value);
        }
    }
}
