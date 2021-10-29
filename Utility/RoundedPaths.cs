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
        private static GraphicsPath GetRoundedRect(Rectangle rect, float radius, bool roundTop = true, bool roundBottom = true)
        {
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
                //Multiply radius by two here to avoid the scenario where the bottom of a circle pokes out when using a large radius
                //and small rectangle region. This should be changed to * 1 if a clip is not being utilised.
                path.AddRectangle(new RectangleF(rect.Left, rect.Bottom - radius, rect.Width, radius * 2));
            }

            //Set to winding to prevent colour over-draw.
            path.FillMode = FillMode.Winding;
            return path;
        }

        /// <summary>
        /// Draws a rounded rectangle with the provided graphics and brush, using the specified parameters.
        /// Uses a rounded rectangle path from GetRoundedRect().
        /// </summary>
        public static void DrawRoundedRect(Graphics graphics, Brush brush, Rectangle rect, float radius, bool roundTop = true, bool roundBottom = true)
        {
            GraphicsPath path = GetRoundedRect(rect, radius, roundTop, roundBottom);

            //Clip to ensure no overdraw outside rectangle bounds.
            Region priorClip = graphics.Clip;
            graphics.SetClip(rect);
            graphics.FillPath(brush, path);
            graphics.Clip = priorClip;
        }
    }
}
