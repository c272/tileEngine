using DarkUI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tileEngine.Controls
{
    /// <summary>
    /// Utility class for smoother programming.
    /// Represents a dropdown item which has a tag of a pre-specified type.
    /// </summary>
    public class TaggedDropdownItem<T> : DarkDropdownItem where T : class
    {
        //The tag on the dropdown item.
        public T Tag { get; set; } = null;
    }
}
