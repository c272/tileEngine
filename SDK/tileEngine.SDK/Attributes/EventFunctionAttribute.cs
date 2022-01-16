using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tileEngine.SDK.Attributes
{
    /// <summary>
    /// Represents a function that can be called from an event on the tile map within tileEngine.
    /// Must have parameters according to the EventFunction API (see wiki).
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class EventFunctionAttribute : Attribute
    {
        /// <summary>
        /// The name of the event function.
        /// Must be unique within the scene.
        /// </summary>
        public string Name { get; private set; }

        public EventFunctionAttribute(string name)
        {
            Name = name;
        }
    }
}
