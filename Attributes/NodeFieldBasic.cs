using easyCase.Controls;
using easyCase.Utility;
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
    
    public abstract class NodeFieldBasic : NodeField
    {
        //The width of the editor control (grid units).
        public int Width { get; set; } = 30;

        //The height of the editor control (grid units).
        public int Height { get; set; } = 10;

        //The padding between the text and the editor control (grid units).
        public int NamePadding { get; set; } = 1;

        //Whether this field is user-editable or not.
        public bool UserCanEdit { get; set; } = true;

        //Create the numeric input for this numeric field.
        protected Control editorControl = null;

        /// <summary>
        /// Constructor for the numeric field.
        /// Simply passes down base arguments, nothing fancy.
        /// </summary>
        public NodeFieldBasic(string name, FieldType type, Type valueType, Color nodeColour) : base(name, type, valueType, nodeColour) { }

        /// <summary>
        /// Draws the numeric field to the control, at the provided position.
        /// </summary>
        public override void Draw(NodeGraphControl control, Graphics graphics, Vector2 position)
        {
            //Throw an error if the editor control hasn't been initialized.
            if (editorControl == null)
                throw new Exception("NodeFieldBasic: Editor control has not been initialized before draw.");

            //Add the editor control to this node graph if it's not there already.
            if (!control.Controls.Contains(editorControl))
                control.Controls.Add(editorControl);

            //Get what size we're expected to be.
            Vector2 size = GetDimensions(control, graphics);

            //Draw the name (left). Make sure it's centered with the editor control.
            Brush brush = new SolidBrush(control.NodeTextColour);
            Vector2 nameDims = control.GetStringAsUnits(graphics, Name, control.NodeTextFont);
            Vector2 namePosition = new Vector2(position.X, position.Y + ((size.Y - nameDims.Y) / 2f));
            graphics.DrawString(Name, control.NodeTextFont, brush, control.ToPixelPointF(namePosition));

            //Is the field connected and an input? If so, get rid of the input box.
            if ((Type == FieldType.Input && ConnectedTo != null) || !UserCanEdit)
            { 
                editorControl.Visible = false;
                return;
            }

            //Let child classes style the control at this point if they want.
            StyleEditorControl(control, graphics);

            //Editable input. Position the input box (right).
            editorControl.Location = control.ToPixelPoint(position.X + NamePadding + nameDims.X, position.Y);
            editorControl.Visible = true;
            editorControl.Font = control.NodeTextFont;
            editorControl.Size = new Size((int)(Width * control.Zoom), (int)(Height * control.Zoom));
        }

        /// <summary>
        /// Returns the expected dimensions of this numeric field.
        /// </summary>
        public override Vector2 GetDimensions(NodeGraphControl control, Graphics graphics)
        {
            //Get dimensions of name + padding + input size.
            Vector2 nameDims = control.GetStringAsUnits(graphics, Name, control.NodeTextFont);
            Size numericSize = new Size((int)(Width), (int)(Height));

            //If the user can edit the field, return with the box included.
            //If not, return without the editing box.
            if (UserCanEdit)
            {
                return new Vector2(nameDims.X + NamePadding + numericSize.Width, nameDims.Y > numericSize.Height ? nameDims.Y : numericSize.Height);
            }
            else
            {
                return nameDims;
            }
        }

        /// <summary>
        /// Called during draw when the editor control requires styling.
        /// Optionally overridden by child field classes for mid-draw styling support.
        /// </summary>
        protected virtual void StyleEditorControl(NodeGraphControl control, Graphics graphics) { }
    }
}
