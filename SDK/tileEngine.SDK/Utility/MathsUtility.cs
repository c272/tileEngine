using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tileEngine.Utility
{
    /// <summary>
    /// Utility classes for commonly utilised maths-related functions not included in base C# libraries.
    /// </summary>
    public static class MathsUtility
    {
        /// <summary>
        /// Bounds a given floating point value between the other two provided floating point values,
        /// returning the final output of the bounding.
        /// </summary>
        public static float Bound(float toTest, float lower, float upper)
        {
            if (toTest < lower)
                return lower;
            if (toTest > upper)
                return upper;
            return toTest;
        }
    }
}
