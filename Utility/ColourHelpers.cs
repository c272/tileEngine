using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tileEngine.Utility
{
    /// <summary>
    /// Helper methods for converting between different colour formats in tileEngine.
    /// </summary>
    public static class ColourHelpers
    {
        /// <summary>
        /// Converts the current System.Drawing.Color to an XNA colour instance.
        /// </summary>
        public static Microsoft.Xna.Framework.Color ToXNAColour(this System.Drawing.Color colour)
        {
            return new Microsoft.Xna.Framework.Color(colour.R, colour.G, colour.B, colour.A);
        }

        /// <summary>
        /// Converts the current XNA colour instance into a System.Drawing.Colour.
        /// </summary>
        public static System.Drawing.Color ToSystemColour(this Microsoft.Xna.Framework.Color colour)
        {
            return System.Drawing.Color.FromArgb(colour.A, colour.R, colour.G, colour.B);
        }
    }
}
