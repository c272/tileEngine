using DarkUI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tileEngine.Forms
{
    /// <summary>
    /// A single item in the selector.
    /// </summary>
    public class SelectorItem : DarkListItem
    {
        /// <summary>
        /// The type that is indicated by this selection.
        /// </summary>
        public Type Type;

        /// <summary>
        /// The description of this selector item.
        /// </summary>
        public string Description;

        /// <summary>
        /// The categories for this selector item.
        /// </summary>
        public string[] Categories;
    }
}
