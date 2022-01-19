using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tileEngine.SDK.Input
{
    /// <summary>
    /// Represents data for a single key binding.
    /// </summary>
    public struct KeyBindingData : IEquatable<KeyBindingData>
    {
        //The key(s) being bound.
        public Keys Key;

        //Whether this requires the CTRL modifier, shift modifier.
        public bool CTRLRequired;
        public bool ShiftRequired;

        //The callback for when this binding starts.
        public Action Callback;

        /// <summary>
        /// Returns whether this key binding data equals another object.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (!(obj is KeyBindingData))
                return false;
            return Equals((KeyBindingData)obj);
        }

        /// <summary>
        /// Returns whether this key binding data equals another key binding data.
        /// </summary>
        public bool Equals(KeyBindingData other)
        {
            return other.Key == Key &&
                   other.CTRLRequired == CTRLRequired &&
                   other.ShiftRequired == ShiftRequired;
        }

        /// <summary>
        /// Returns a unique hash code for this key binding.
        /// </summary>
        public override int GetHashCode()
        {
            int hashCode = ((int)Key << 2);
            if (CTRLRequired)
                hashCode |= 0b10;
            if (ShiftRequired)
                hashCode |= 0b01;
            return hashCode;
        }
    }
}
