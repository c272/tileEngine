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
        public int NamePadding { get; set; } = 5;

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

            //Draw the name (left).
            Brush brush = new SolidBrush(control.NodeTextColour);
            SizeF nameDims = graphics.MeasureString(Name, control.NodeTextFont);
            graphics.DrawString(Name, control.NodeTextFont, brush, control.ToPixelPointF(position));

            //Is the field connected and an input? If so, get rid of the input box.
            if ((Type == FieldType.Input && ConnectedTo != null) || !UserCanEdit)
            { 
                editorControl.Visible = false;
                return;
            }

            //Editable input. Position the input box (right).
            editorControl.Size = new Size((int)(Width * control.Zoom), (int)(Height * control.Zoom));
            editorControl.Visible = true;
            editorControl.Font = control.NodeTextFont;
            editorControl.Location = control.ToPixelPoint(position.X + NamePadding + nameDims.Width / control.Zoom, position.Y);
        }

        /// <summary>
        /// Returns the expected dimensions of this numeric field.
        /// </summary>
        public override Vector2 GetDimensions(NodeGraphControl control, Graphics graphics)
        {
            //Get dimensions of name + padding + input size.
            SizeF nameDims = graphics.MeasureString(Name, control.NodeTextFont);
            nameDims.Width /= control.Zoom;
            nameDims.Height /= control.Zoom;
            Size numericSize = new Size((int)(Width), (int)(Height));

            //If the user can edit the field, return with the box included.
            //If not, return without the editing box.
            if (UserCanEdit)
            {
                return new Vector2(nameDims.Width + NamePadding + numericSize.Width, nameDims.Height > numericSize.Height ? nameDims.Height : numericSize.Height);
            }
            else
            {
                return new Vector2(nameDims.Width, nameDims.Height);
            }
        }
    }
}
