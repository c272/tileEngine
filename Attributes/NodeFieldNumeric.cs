using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyCase.Attributes
{
    /// <summary>
    /// Represents a single numeric field on a node.
    /// </summary>
    public class NodeFieldNumeric : NodeFieldBasic
    {
        //The field for editing the underlying value.
        //We use a text box here because NumericUpDown does not allow height resizing (seriously).
        TextBox numericField = new TextBox()
        {
            AutoSize = false,
            TextAlign = HorizontalAlignment.Center
        };

        /// <summary>
        /// Creates a new numeric node field, with the given name and field type.
        /// </summary>
        public NodeFieldNumeric(string name, FieldType type) : base(name, type, typeof(float), Color.Green)
        {
            editorControl = numericField;
            Width = 40;
            Height = 20;
        }
    }
}
