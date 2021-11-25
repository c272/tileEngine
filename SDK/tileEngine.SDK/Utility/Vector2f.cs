using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tileEngine.Utility
{
    /// <summary>
    /// Simple utility Vector2 class for 2D coordinate calculations in forms.
    /// Not to be used in place of MonoGame Vector2.
    /// </summary>
    [ProtoContract]
    public class Vector2f
    {
        [ProtoMember(1)]
        public float X;

        [ProtoMember(2)]
        public float Y;

        /// <summary>
        /// Creates a new Vector2.
        /// If no parameters provided, values are initialized at zero.
        /// </summary>
        public Vector2f(float x = 0, float y = 0)
        {
            X = x;
            Y = y;
        }


        /// <summary>
        /// Creates a vector from the values contained in the given Point.
        /// </summary>
        public Vector2f(Point p)
        {
            X = p.X;
            Y = p.Y;
        }

        /// <summary>
        /// Creates a vector from the values contained in the given PointF.
        /// </summary>
        public Vector2f(PointF p)
        {
            X = p.X;
            Y = p.Y;
        }

        /// <summary>
        /// Creates a vector from the values provided in the given PointF.
        /// </summary>
        public Vector2f(SizeF s)
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

        /// <summary>
        /// Returns whether a given object is equal to this vector.
        /// Returns true when a vector is provided, and that vector has the same X and Y values.
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Vector2f))
                return false;
            Vector2f other = (Vector2f)obj;
            return other.X == X && other.Y == Y;
        }

        /// <summary>
        /// Returns the hash code for this Vector2.
        /// </summary>
        public override int GetHashCode()
        {
            //Variation of the Berstein hash combination, should be unchecked.
            unchecked
            {
                int hash = 17;
                hash = hash * 31 + X.GetHashCode();
                hash = hash * 31 + Y.GetHashCode();
                return hash;
            }
        }

        //Operators for base adding, subtraction.
        public static Vector2f operator +(Vector2f a, Vector2f b) => new Vector2f(a.X + b.X, a.Y + b.Y);
        public static Vector2f operator -(Vector2f a, Vector2f b) => new Vector2f(a.X - b.X, a.Y - b.Y);
    }
}
