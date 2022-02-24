using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tileEngine.SDK.Utility
{
    /// <summary>
    /// Utility class for converting to and from Microsoft.Xna.Framework.Point and System.Drawing.Point.
    /// </summary>
    public static class PointHelpers
    {
        /// <summary>
        /// Converts the current System.Drawing GDI point to a Microsoft.Xna.Framework point.
        /// </summary>
        public static Microsoft.Xna.Framework.Point ToXnaPoint(this System.Drawing.Point point)
        {
            return new Microsoft.Xna.Framework.Point(point.X, point.Y);
        }

        /// <summary>
        /// Converts the current Microsoft.Xna.Framework point to a System.Drawing GDI point.
        /// </summary>
        public static System.Drawing.Point ToGDIPoint(this Microsoft.Xna.Framework.Point point)
        {
            return new System.Drawing.Point(point.X, point.Y);
        }
    }
}
