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
            path.StartFigure();

            //Add the center rectangle.
            float diameter = radius * 2;
            path.AddRectangle(new RectangleF(rect.Left, rect.Top + radius, rect.Width, rect.Height - diameter));
            
            //Add the top depending on rounding.
            if (roundTop)
            {
                path.AddEllipse(rect.Left, rect.Top, diameter, diameter);
                path.AddEllipse(rect.Right - diameter, rect.Top, diameter, diameter);
                path.AddRectangle(new RectangleF(rect.Left + radius, rect.Top, rect.Width - diameter, radius));
            }
            else
            {
                path.AddRectangle(new RectangleF(rect.Left, rect.Top, rect.Width, radius));
            }

            //Add the bottom depending on rounding.
            if (roundBottom)
            {
                path.AddEllipse(rect.Left, rect.Bottom - diameter, diameter, diameter);
                path.AddEllipse(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter);
                path.AddRectangle(new RectangleF(rect.Left + radius, rect.Bottom - radius, rect.Width - diameter, radius));
            }
            else
            {
                path.AddRectangle(new RectangleF(rect.Left, rect.Bottom - radius, rect.Width, radius));
            }

            //Set to winding to prevent colour over-draw.
            path.FillMode = FillMode.Winding;
            return path;
        }
    }
}
