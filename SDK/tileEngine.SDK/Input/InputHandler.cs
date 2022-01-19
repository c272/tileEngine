using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tileEngine.SDK.Input
{
    /// <summary>
    /// Handles and creates generic input events from a single input source.
    /// </summary>
    public abstract class InputHandler
    {
        /// <summary>
        /// A list of currently occuring generic input events.
        /// </summary>
        public static Dictionary<string, GenericInput> CurrentState { get; private set; } = new Dictionary<string, GenericInput>();

        /// <summary>
        /// Returns whether the given generic event is currently occuring.
        /// </summary>
        public static bool HasEvent(string name) => CurrentState.ContainsKey(name);

        /// <summary>
        /// Returns generic input event data if the given event is occuring.
        /// Otherwise returns null.
        /// </summary>
        public static GenericInput GetEvent(string name)
        {
            if (!HasEvent(name))
                return null;
            return CurrentState[name];
        }

        /// <summary>
        /// Clears all bindings associated with the input handler.
        /// </summary>
        public abstract void Reset();
    }
}
