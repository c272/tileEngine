using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tileEngine.SDK.Input
{
    /// <summary>
    /// Represents a generic input handler for keyboard events.
    /// </summary>
    public class KeyboardInputHandler : InputHandler
    {
        /// <summary>
        /// Represents the bindings from direct keyboard inputs to generic inputs.
        /// </summary>
        public Dictionary<KeyBindingData, string> Bindings { get; private set; } = new Dictionary<KeyBindingData, string>();

        /// <summary>
        /// Adds a new keyboard binding to the input handler.
        /// </summary>
        /// <param name="key">The key to bind to a generic input.</param>
        /// <param name="name">The name of the generic input being bound to.</param>
        /// <param name="requiresCtrl">Whether the key must be pressed with CTRL to fire the binding.</param>
        /// <param name="requiresShift">Whether the key must be pressed with shift to fire the binding.</param>
        public KeyBindingData AddBinding(Keys key, string name, bool requiresCtrl = false, bool requiresShift = false)
        {
            //Craft binding data.
            var bindingData = new KeyBindingData()
            {
                Key = key,
                CTRLRequired = requiresCtrl,
                ShiftRequired = requiresShift
            };

            //Check for duplicates.
            if (Bindings.ContainsKey(bindingData))
                throw new Exception($"Identical binding for key '{key}' already added.");
            Bindings.Add(bindingData, name);
            return bindingData;
        }

        /// <summary>
        /// Removes the given keyboard binding from the input handler.
        /// </summary>
        public void RemoveBinding(KeyBindingData binding)
        {
            if (!Bindings.ContainsKey(binding))
                return;
            Bindings.Remove(binding);
        }

        /// <summary>
        /// Updates the state of the input handler based on a new keyboard state.
        /// </summary>
        public void Update(KeyboardState state)
        {
            //Remove any stale bindings.
            var alreadyActive = new List<KeyBindingData>();
            for (int i=0; i<CurrentState.Count; i++)
            {
                //Ignore non-keyboard bindings.
                var binding = CurrentState[i];
                if (binding.Source != nameof(KeyboardInputHandler))
                    continue;

                //Is this binding still valid?
                var keyBind = (KeyBindingData)binding.BindingData;
                if (!BindingActive(keyBind, state))
                {
                    CurrentState.RemoveAt(i);
                    i--;
                    continue;
                }

                //Non-stale, add to list for ignoring later.
                alreadyActive.Add(keyBind);
            }

            //Add any possible new bindings.
            foreach (var binding in Bindings)
            {
                //Ignore already active ones.
                if (alreadyActive.Contains(binding.Key))
                    continue;

                //Active? Then add as new.
                if (BindingActive(binding.Key, state))
                {
                    var input = new GenericInput()
                    {
                        BindingData = binding.Key,
                        Name = binding.Value,
                        Source = nameof(KeyboardInputHandler),
                    };
                    CurrentState.Add(input);
                }    
            }
        }

        /// <summary>
        /// Resets the input handler of all bindings.
        /// </summary>
        public override void Reset()
        {
            Bindings.Clear();
        }

        /// <summary>
        /// Returns whether the given binding is active or not, based on the keyboard state.
        /// </summary>
        private bool BindingActive(KeyBindingData binding, KeyboardState keyboard)
        {
            if (!keyboard.IsKeyDown(binding.Key))
                return false;
            if (binding.CTRLRequired && !keyboard.IsKeyDown(Keys.LeftControl))
                return false;
            if (binding.ShiftRequired && !keyboard.IsKeyDown(Keys.LeftShift))
                return false;
            return true;
        }
    }

    /// <summary>
    /// Represents data for a single key binding.
    /// </summary>
    public struct KeyBindingData : IEquatable<KeyBindingData>
    {
        //The key being bound.
        public Keys Key;

        //Whether this requires the CTRL modifier, shift modifier.
        public bool CTRLRequired;
        public bool ShiftRequired;

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
