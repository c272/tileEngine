using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyCase.Utility
{
    /// <summary>
    /// Class for generating rounded rectangle paths for System.Drawing GDI.
    /// </summary>
    public static class RoundedPaths
    {
        /// <summary>
        /// Returns a graphics path for a rounded rectangle, optionally rounding only the top/bottom.
        /// </summary>
        /// <param name="rect">The rectangle to round off.</param>
        /// <param name="radius">The radius of the arc rounding it.</param>
        public static GraphicsPath RoundedRect(Rectangle rect, int radius, bool roundTop = true, bool roundBottom = true)
        {
            //todo
            var path = new GraphicsPath();
            path.AddRectangle(rect);
            return path;
        }
    }
}
