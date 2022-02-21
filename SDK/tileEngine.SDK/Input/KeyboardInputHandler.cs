using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tileEngine.SDK.Input
{
    /// <summary>
    /// Represents a generic input handler for keyboard & mouse events.
    /// </summary>
    public class KeyboardInputHandler : InputHandler
    {
        /// <summary>
        /// Represents the single key bindings from direct keyboard inputs to generic inputs.
        /// </summary>
        public Dictionary<KeyBindingData, string> Bindings { get; private set; } = new Dictionary<KeyBindingData, string>();

        /// <summary>
        /// Represents axis bindings from direct keyboard inputs to generic inputs.
        /// </summary>
        public Dictionary<AxisBindingData, string> AxisBindings { get; private set; } = new Dictionary<AxisBindingData, string>();

        /// <summary>
        /// Adds a new keyboard binding to the input handler.
        /// </summary>
        /// <param name="key">The key to bind to a generic input.</param>
        /// <param name="name">The name of the generic input being bound to.</param>
        /// <param name="requiresCtrl">Whether the key must be pressed with CTRL to fire the binding.</param>
        /// <param name="requiresShift">Whether the key must be pressed with shift to fire the binding.</param>
        public KeyBindingData AddBinding(Keys key, string name, bool requiresCtrl = false, bool requiresShift = false, Action callback = null)
        {
            //Craft binding data.
            var bindingData = new KeyBindingData()
            {
                Key = key,
                CTRLRequired = requiresCtrl,
                ShiftRequired = requiresShift,
                Callback = callback
            };

            //Check for duplicates.
            if (Bindings.ContainsKey(bindingData))
                throw new Exception($"Identical binding for key '{key}' already added.");
            Bindings.Add(bindingData, name);
            return bindingData;
        }

        /// <summary>
        /// Adds a new axis key binding to the input handler.
        /// This allows a combination of keys to be considered as a two-way axis system, with a key per direction.
        /// Opposite axes being fired at the same time will be considered as neutral (0).
        /// Axes are 1.0 and -1.0 when active.
        /// </summary>
        /// <param name="axisXPositive">The key which causes a value of 1.0 in the X axis.</param>
        /// <param name="axisXNegative">The key which causes a value of -1.0 in the X axis.</param>
        /// <param name="axisYPositive">The key which causes a value of 1.0 in the Y axis.</param>
        /// <param name="axisYNegative">The key which causes a value of -1.0 in the Y axis.</param>
        /// <param name="name">The name of the produced generic input binding.</param>
        /// <returns>Binding data for the created axis.</returns>
        public AxisBindingData AddAxisBinding(Keys axisXPositive, Keys axisXNegative, Keys axisYPositive, Keys axisYNegative, string name)
        {
            //Craft binding data.
            var bindingData = new AxisBindingData()
            {
                AxisXPositive = axisXPositive,
                AxisXNegative = axisXNegative,
                AxisYPositive = axisYPositive,
                AxisYNegative = axisYNegative
            };

            //Add if not duplicate.
            if (AxisBindings.ContainsKey(bindingData))
                throw new Exception($"Identical binding for axis '{name}' already added.");
            AxisBindings.Add(bindingData, name);
            return bindingData;
        }

        /// <summary>
        /// Removes the given keyboard binding from the input handler.
        /// </summary>
        public void RemoveBinding(KeyBindingData binding)
        {
            if (!Bindings.ContainsKey(binding))
                return;

            //Remove from current state, then binding list.
            if (CurrentState.ContainsKey(Bindings[binding]))
                CurrentState.Remove(Bindings[binding]);
            Bindings.Remove(binding);
        }

        /// <summary>
        /// Removes the given keyboard axis binding from the input handler.
        /// </summary>
        public void RemoveBinding(AxisBindingData binding)
        {
            if (!AxisBindings.ContainsKey(binding))
                return;

            //Remove from current state, then binding list.
            if (CurrentState.ContainsKey(AxisBindings[binding]))
                CurrentState.Remove(AxisBindings[binding]);
            AxisBindings.Remove(binding);
        }

        /// <summary>
        /// Updates the state of the input handler based on a new keyboard state.
        /// </summary>
        public void Update(KeyboardState state)
        {
            //Poll all single key bindings.
            UpdateKeyBindings(state);

            //Poll all axis bindings.
            UpdateAxisBindings(state);
        }

        /// <summary>
        /// Updates all axis bindings for this keyboard input handler.
        /// </summary>
        private void UpdateAxisBindings(KeyboardState state)
        {
            for (int i=0; i<AxisBindings.Count; i++)
            {
                var binding = AxisBindings.ElementAt(i);

                //Calculate the vector value for this axis binding.
                Vector2 axisValue = new Vector2();
                axisValue.X += state.IsKeyDown(binding.Key.AxisXPositive) ? 1 : 0;
                axisValue.X -= state.IsKeyDown(binding.Key.AxisXNegative) ? 1 : 0;
                axisValue.Y += state.IsKeyDown(binding.Key.AxisYPositive) ? 1 : 0;
                axisValue.Y -= state.IsKeyDown(binding.Key.AxisYNegative) ? 1 : 0;

                //Get the generic input for this binding.
                //If none, make one.
                if (!CurrentState.ContainsKey(binding.Value))
                {
                    var input = new GenericInput()
                    {
                        BindingData = binding,
                        Source = nameof(KeyboardInputHandler),
                        Value = axisValue
                    };
                    CurrentState.Add(binding.Value, input);
                }
                else 
                { 
                    CurrentState[binding.Value].Value = axisValue;
                }
            }
        }

        /// <summary>
        /// Updates all single key bindings for this keyboard input handler.
        /// </summary>
        private void UpdateKeyBindings(KeyboardState state)
        {
            //Remove any stale bindings.
            var alreadyActive = new List<KeyBindingData>();
            for (int i = 0; i < CurrentState.Count; i++)
            {
                //Ignore non-keyboard bindings.
                var binding = CurrentState.ElementAt(i);
                if (binding.Value.Source != nameof(KeyboardInputHandler)
                    || !(binding.Value.BindingData is KeyBindingData))
                    continue;

                //Is this binding still valid?
                var keyBind = (KeyBindingData)binding.Value.BindingData;
                if (!BindingActive(keyBind, state))
                {
                    CurrentState.Remove(binding.Key);
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
                        Source = nameof(KeyboardInputHandler),
                    };
                    CurrentState.Add(binding.Value, input);
                    binding.Key.Callback?.Invoke();
                }
            }
        }

        /// <summary>
        /// Resets the input handler of all bindings.
        /// </summary>
        public override void Reset()
        {
            foreach (var binding in Bindings)
            {
                if (CurrentState.ContainsKey(binding.Value))
                    CurrentState.Remove(binding.Value);
            }
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
}
