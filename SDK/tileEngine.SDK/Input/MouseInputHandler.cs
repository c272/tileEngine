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
    /// Represents a mouse input handler for tileEngine.
    /// </summary>
    public class MouseInputHandler : InputHandler
    {
        /// <summary>
        /// Binding data for this mouse input handler.
        /// </summary>
        public Dictionary<MouseInputType, string> Bindings { get; private set; } = new Dictionary<MouseInputType, string>();

        /// <summary>
        /// Adds a generic input binding for the given mouse input.
        /// </summary>
        public void AddBinding(MouseInputType input, string name)
        {
            if (Bindings.ContainsKey(input))
                throw new Exception($"This binding ({input}) has already been registered with the mouse input handler.");
            Bindings.Add(input, name);
        }

        /// <summary>
        /// Removes a generic input binding for the given input.
        /// </summary>
        public void RemoveBinding(MouseInputType input)
        {
            //Ignore invalid call.
            if (!Bindings.ContainsKey(input))
                return;

            //Remove from current state, then binding list.
            if (CurrentState.ContainsKey(Bindings[input]))
                CurrentState.Remove(Bindings[input]);
            Bindings.Remove(input);
        }

        /// <summary>
        /// Updates this input handler. Should be called every update tick.
        /// </summary>
        public void Update(MouseState state)
        {
            //Remove/update stale bindings.
            for (int i=0; i<CurrentState.Count; i++)
            {
                //Ignore non-mouse bindings.
                var binding = CurrentState.ElementAt(i);
                if (binding.Value.Source != nameof(MouseInputHandler))
                    continue;

                //If this is the mouse position, update binding.
                if ((MouseInputType)binding.Value.BindingData == MouseInputType.Position)
                {
                    binding.Value.Value = state.Position.ToVector2();
                }

                //If this is the scroll wheel, update binding.
                if ((MouseInputType)binding.Value.BindingData == MouseInputType.ScrollWheel)
                {
                    binding.Value.Value = new Vector2(0, state.ScrollWheelValue);
                }

                //Is the binding not still active? Remove it.
                if (!BindingActive((MouseInputType)binding.Value.BindingData, state))
                    CurrentState.Remove(binding.Key);
            }

            //Add possible new bindings.
            foreach (var binding in Bindings)
            {
                //Ignore, is already a binding.
                if (CurrentState.ContainsKey(binding.Value))
                    continue;

                //If pressed, add as a binding.
                if (BindingActive(binding.Key, state))
                {
                    CurrentState.Add(binding.Value, new GenericInput()
                    {
                        BindingData = binding.Key,
                        Source = nameof(MouseInputHandler)
                    });
                }
            }
        }

        /// <summary>
        /// Returns whether a given binding is currently active on the mouse.
        /// </summary>
        private bool BindingActive(MouseInputType bindingData, MouseState state)
        {
            switch (bindingData)
            {
                //Special case for mouse position.
                case MouseInputType.Position:
                    return true;

                //Standard buttons.
                case MouseInputType.LeftMouse:
                    return state.LeftButton == ButtonState.Pressed;
                case MouseInputType.RightMouse:
                    return state.RightButton == ButtonState.Pressed;
                case MouseInputType.MiddleMouse:
                    return state.MiddleButton == ButtonState.Pressed;

                //Scroll wheel.
                case MouseInputType.ScrollWheel:
                    return state.ScrollWheelValue != 0;

                default:
                    throw new Exception($"Mouse input type '{bindingData}' has binding checking unimplemented.");
            }
        }

        /// <summary>
        /// Resets the mouse input handler, removing all bindings.
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
    }

    /// <summary>
    /// Input types that are bindable with the mouse input handler.
    /// </summary>
    public enum MouseInputType
    {
        Position,
        LeftMouse,
        RightMouse,
        MiddleMouse,
        ScrollWheel
    }
}
