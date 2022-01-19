using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tileEngine.SDK.Input
{
    /// <summary>
    /// Represents data for a single axis binding.
    /// </summary>
    public struct AxisBindingData : IEquatable<AxisBindingData>
    {
        //The key(s) being bound to each axis.
        public Keys AxisXPositive;
        public Keys AxisXNegative;
        public Keys AxisYPositive;
        public Keys AxisYNegative;

        /// <summary>
        /// Returns whether this key binding data equals another object.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (!(obj is AxisBindingData))
                return false;
            return Equals((AxisBindingData)obj);
        }

        /// <summary>
        /// Returns whether this key binding data equals another key binding data.
        /// </summary>
        public bool Equals(AxisBindingData other)
        {
            return other.AxisXPositive == this.AxisXPositive 
                && other.AxisYPositive == this.AxisYPositive
                && other.AxisXNegative == this.AxisXNegative
                && other.AxisYNegative == this.AxisYNegative;
        }

        /// <summary>
        /// Returns a unique hash code for this key binding.
        /// </summary>
        public override int GetHashCode()
        {
            return ((int)AxisXPositive << 12)
                | ((int)AxisYPositive << 8)
                | ((int)AxisXNegative << 4)
                | (int)AxisYNegative;
        }
    }
}
