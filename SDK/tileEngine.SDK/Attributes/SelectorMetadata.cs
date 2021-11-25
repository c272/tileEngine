using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tileEngine.SDK.Attributes
{
    /// <summary>
    /// Represents metadata about a given class used for displaying information in a selector.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class SelectorMetadata : Attribute
    {
        /// <summary>
        /// The human-readable name of this selector item.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The categories that this selector item falls into.
        /// </summary>
        public string[] Categories { get; set; } = new string[0];

        /// <summary>
        /// A brief description of this selector item's purpose/usage.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The name of the icon.
        /// </summary>
        public string IconName { get; set; }


        /// <summary>
        /// Creates selector metadata from the given name, and optionally a description/categories.
        /// </summary>
        public SelectorMetadata(string name)
        {
            Name = name;
        }
    }
}
