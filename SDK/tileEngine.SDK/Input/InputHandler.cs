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
        public static List<GenericInput> CurrentState { get; private set; } = new List<GenericInput>();

        /// <summary>
        /// Returns whether the given generic event is currently occuring.
        /// </summary>
        public static bool HasEvent(string name) => CurrentState.FindIndex(x => x.Name == name) != -1;

        /// <summary>
        /// Returns generic input event data if the given event is occuring.
        /// Otherwise returns null.
        /// </summary>
        public static GenericInput? GetEvent(string name)
        {
            if (!HasEvent(name))
                return null;
            return CurrentState.First(x => x.Name == name);
        }

        /// <summary>
        /// Clears all bindings associated with the input handler.
        /// </summary>
        public abstract void Reset();
    }
}
