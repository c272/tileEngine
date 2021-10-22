using easyCase.Attributes;
using easyCase.Controls;
using easyCase.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyCase.Nodes 
{
    /// <summary>
    /// Represents a single node, placeable within the node graph editor.
    /// </summary>
    public abstract class Node
    {
        /// <summary>
        /// The unique identifying ID of this node instance.
        /// </summary>
        public int ID = Guid.NewGuid().GetHashCode();

        /// <summary>
        /// The title of the node (as seen in-editor).
        /// </summary>
        public string Title { get; protected set; }

        /// <summary>
        /// The colour of the title bar of the node.
        /// </summary>
        public Color Colour { get; protected set; }

        /// <summary>
        /// The location of the node on the node graph.
        /// This represents the center of the node.
        /// </summary>
        public Vector2 Location { get; set; } = new Vector2();

        /// <summary>
        /// A list of fields that this node contains.
        /// </summary>
        public List<NodeField> Fields { get; private set; } = new List<NodeField>();

        //The label used for the title of this node.
        private Label titleLabel = new Label();

        /// <summary>
        /// Node constructor, populates the list of fields which the node posesses.
        /// </summary>
        public Node(string title, Color colour)
        {
            //Set the title and colour.
            Title = title;
            Colour = colour;

            //Get a list of all properties on the class.
            var properties = this.GetType().GetProperties();
            foreach (var prop in properties)
            {
                //Get the attribute from this property (if it's there).
                object[] attributes = prop.GetCustomAttributes(typeof(NodeField), true);
                if (attributes.Length == 0) { continue; }

                //Save this to the list.
                Fields.Add((NodeField)attributes[0]);
            }

            //Set up the title label.
            titleLabel.Text = Title;
        }

        /// <summary>
        /// Draws the node onto the given control, with the provided graphics object.
        /// </summary>
        public void Draw(NodeGraphControl control, Graphics graphics)
        {
            //Based on the expected size of the node, shift the start position to the top left.
            Vector2 size = GetNodeSize(control, graphics);
            Vector2 curPos = new Vector2(Location.X - size.X / 2f, Location.Y - size.Y / 2f);

            //Draw the title bar.
            Brush brush = new SolidBrush(Colour);
            SizeF titleSize = graphics.MeasureString(titleLabel.Text, titleLabel.Font);
            Rectangle titleRect = control.GetPixelRectangle(curPos, new Vector2(curPos.X + size.X, curPos.Y + titleSize.Height));
            graphics.FillRectangle(brush, titleRect);

            //Move the title label into the title bar, resize.
            titleLabel.Location = control.ToPixelCoordinate(curPos.X, curPos.Y);
            titleLabel.Size = titleRect.Size;
            titleLabel.Invalidate();

            //Draw the main body rectangle.
            curPos.Y += titleSize.Height;
            brush = new SolidBrush(control.NodeBackgroundColour);
            graphics.FillRectangle(brush, control.GetPixelRectangle(curPos, new Vector2(curPos.X + size.X, curPos.Y - titleSize.Height + size.Y)));

            //...
        }

        /// <summary>
        /// Returns the size of the node in grid units depending on the control/graphics.
        /// </summary>
        public Vector2 GetNodeSize(NodeGraphControl control, Graphics graphics)
        {
            //Try and figure out the size of the entire node.
            Vector2 finalSize;

            //Size of the title.
            titleLabel.Font = control.NodeTitleFont;
            SizeF titleSize = graphics.MeasureString(Title, titleLabel.Font);
            finalSize = new Vector2(titleSize.Width, titleSize.Height);

            //Add padding for between title and fields.
            finalSize.Y += control.TitlePadding;

            //Loop over all fields and process.
            float inputX = 0, outputX = 0;
            foreach (var field in Fields)
            {
                Vector2 fieldDims = field.GetDimensions(control);

                //If this field is an input/output, and bigger than one previously processed,
                //expand the expected width of either side.
                if (field.Type == FieldType.Input && inputX < fieldDims.X) 
                {
                    inputX = fieldDims.X;
                }
                else if (field.Type == FieldType.Output && outputX < fieldDims.X)
                {
                    outputX = fieldDims.X;
                }

                //Increment height (+ padding).
                finalSize.Y += fieldDims.Y + control.FieldPadding;
            }

            //Combine the field widths (+ padding).
            float totalFieldWidth = inputX + outputX + control.FieldPadding;
            if (finalSize.X < totalFieldWidth) { finalSize.X = totalFieldWidth; }

            //Return final dimensions.
            return finalSize;
        }
    }
}
