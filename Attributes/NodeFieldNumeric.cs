using nodeGame.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nodeGame.Attributes
{
    /// <summary>
    /// Represents a single numeric field on a node.
    /// </summary>
    public class NodeFieldNumeric : NodeFieldBasic
    {
        //The default value of this numeric field.
        public float DefaultValue { get; private set; } = 0;

        //Whether to limit this field to purely integers.
        public bool IntegersOnly { get; set; } = false;

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
            //Default value setup.
            OnPropertyChanged += setDefaultValue;
            numericField.Text = DefaultValue.ToString();

            //Set up editor control, sizing.
            editorControl = numericField;
            Width = 40;
            Height = 20;

            //Event hooks for the textbox (number only validation).
            editorControl.TextChanged += fieldTextChanged;
        }

        //Called when the property is changed, to set the default value.
        private void setDefaultValue(NodeField sender)
        {
            SetPropertyValue(DefaultValue);
        }

        /// <summary>
        /// Styles the numeric input to be in line with the current node theming.
        /// </summary>
        protected override void StyleEditorControl(NodeGraphControl control, Graphics graphics)
        {
            numericField.BackColor = control.NodeBackgroundColour;
            numericField.ForeColor = ValueIsValid() ? control.NodeTextColour : control.NodeErrorColour;
        }

        /// <summary>
        /// Triggered when the user changes the contents of the numeric field text box.
        /// </summary>
        private void fieldTextChanged(object sender, EventArgs e)
        {
            ValueIsValid();
        }

        /// <summary>
        /// Returns whether the currently entered numeric value is valid or not.
        /// </summary>
        public override bool ValueIsValid()
        {
            //If we're connected to another value and we're an input, we're fine.
            if (ConnectedTo != null && Type == FieldType.Input) { return true; }

            //If it's an integer-only field, test as integer instead.
            if (IntegersOnly)
            {
                int newValueInt;
                if (!int.TryParse(editorControl.Text, out newValueInt))
                {
                    return false;
                }
                SetPropertyValue(newValueInt);
                return true;
            }

            //Attempt to get the new value as a float. On fail, return false.
            float newValue;
            if (!float.TryParse(editorControl.Text, out newValue))
            {
                return false;
            }
            SetPropertyValue(newValue);
            return true;
        }
    }
}
