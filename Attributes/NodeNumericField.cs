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
    
    public class NodeNumericField : NodeField
    {
        //The width of this numeric field (grid units).
        public int Width { get; set; } = 30;

        //The height of this numeric field (grid units).
        public int Height { get; set; } = 10;

        //The padding between the text and the input box (grid units).
        public int NamePadding { get; set; } = 5;


        //Create the numeric input for this numeric field.
        NumericUpDown numericInput = new NumericUpDown()
        {
            MinimumSize = new Size(0, 0)
        };

        /// <summary>
        /// Constructor for the numeric field.
        /// Simply passes down base arguments, nothing fancy.
        /// </summary>
        public NodeNumericField(string name, FieldType type) : base(name, type, typeof(float), Color.Green) { }

        /// <summary>
        /// Draws the numeric field to the control, at the provided position.
        /// </summary>
        public override void Draw(NodeGraphControl control, Graphics graphics, Vector2 position)
        {
            //Add the numeric input to this node graph if it's not there already.
            if (!control.Controls.Contains(numericInput))
                control.Controls.Add(numericInput);

            //Draw the name (left).
            Brush brush = new SolidBrush(control.NodeTextColour);
            SizeF nameDims = graphics.MeasureString(Name, control.NodeTextFont);
            graphics.DrawString(Name, control.NodeTextFont, brush, control.ToPixelPointF(position));

            //Calculate the size of the input box. If it's small enough, invisible it.
            numericInput.Size = new Size((int)(Width * control.Zoom), (int)(Height * control.Zoom));
            if (numericInput.Size.Width < 1 || numericInput.Size.Height < 1)
            {
                numericInput.Visible = false;
                return;
            }

            //Position the input box (right).
            numericInput.Visible = true;
            numericInput.Font = control.NodeTextFont;
            numericInput.Location = control.ToPixelPoint(position.X + NamePadding + nameDims.Width / control.Zoom, position.Y);
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

            //Return expected size.
            return new Vector2(nameDims.Width + NamePadding + numericSize.Width, nameDims.Height > numericSize.Height ? nameDims.Height : numericSize.Height);
        }
    }
}
