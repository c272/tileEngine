using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nodeGame.Utility
{
    /// <summary>
    /// A simple Vector2 for use in controls.
    /// </summary>
    public class Vector2
    {
        public float X;
        public float Y;

        /// <summary>
        /// Creates a new Vector2.
        /// If no parameters provided, values are initialized at zero.
        /// </summary>
        public Vector2(float x = 0, float y = 0)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Creates a vector from the values contained in the given Point.
        /// </summary>
        public Vector2(Point p)
        {
            X = p.X;
            Y = p.Y;
        }

        /// <summary>
        /// Creates a vector from the values contained in the given PointF.
        /// </summary>
        public Vector2(PointF p)
        {
            X = p.X;
            Y = p.Y;
        }

        /// <summary>
        /// Creates a vector from the values provided in the given PointF.
        /// </summary>
        public Vector2(SizeF s)
        {
            X = s.Width;
            Y = s.Height;
        }

        /// <summary>
        /// Returns the magnitude of this vector as a float.
        /// </summary>
        public float GetMagnitude()
        {
            return (float)Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
        }
    }
}
