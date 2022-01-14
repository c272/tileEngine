using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tileEngine.Utility
{
    /// <summary>
    /// Helper methods for dealing with System.Drawing.RectangleF structures.
    /// </summary>
    public static class RectangleFHelpers
    {
        /// <summary>
        /// Converts the rectangle into a set of three points as required by
        /// drawing functions in System.Drawing. Points required are the top left, top right
        /// and bottom left corners of the rectangle to represent a paralellogram.
        /// </summary>
        public static PointF[] ToPoints(this RectangleF rectangle)
        {
            return new PointF[3]
            {
                new PointF(rectangle.Left, rectangle.Top),
                new PointF(rectangle.Right, rectangle.Top),
                new PointF(rectangle.Left, rectangle.Bottom)
            };
        }
    }
}
