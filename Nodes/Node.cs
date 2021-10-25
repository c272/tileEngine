using easyCase.Attributes;
using easyCase.Controls;
using easyCase.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        /// The colour of the node's title text.
        /// </summary>
        public Color TitleColour { get; protected set; }

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

        /// <summary>
        /// Node constructor, populates the list of fields which the node posesses.
        /// </summary>
        public Node(string title, Color colour, Color titleColour)
        {
            //Set the title and colour.
            Title = title;
            Colour = colour;
            TitleColour = titleColour;

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
        }

        /// <summary>
        /// Draws the node onto the given control, with the provided graphics object.
        /// </summary>
        public void Draw(NodeGraphControl control, Graphics graphics)
        {
            //Set antialiasing on.
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //Based on the expected size of the node, shift the start position to the top left.
            Vector2 size = GetNodeSize(control, graphics);
            Vector2 curPos = new Vector2(Location.X - size.X / 2f, Location.Y - size.Y / 2f);

            //Get the size of the title text, accounting for zoom.
            Brush brush = new SolidBrush(Colour);
            SizeF titleSize = graphics.MeasureString(Title, control.NodeTitleFont);
            titleSize.Width /= control.Zoom;
            titleSize.Height /= control.Zoom;

            //Find and draw the title.
            Vector2 titleBottomRight = new Vector2(curPos.X + size.X, curPos.Y + titleSize.Height + control.GlobalPadding);
            Rectangle titleRect = control.GetPixelRectangle(curPos, titleBottomRight);
            graphics.FillPath(brush, RoundedPaths.RoundedRect(titleRect, control.NodeRoundingRadius, true, false));

            //Draw title (with global padding).
            brush = new SolidBrush(TitleColour);
            graphics.DrawString(Title, control.NodeTitleFont, brush, control.ToPixelPointF(curPos.X + control.GlobalPadding, curPos.Y + control.GlobalPadding));

            //Draw the main body rectangle.
            curPos.Y += titleSize.Height + control.TitlePadding;
            brush = new SolidBrush(control.NodeBackgroundColour);
            var mainRect = control.GetPixelRectangle(curPos, new Vector2(curPos.X + size.X, curPos.Y - titleSize.Height + size.Y));
            var mainPath = RoundedPaths.RoundedRect(mainRect, control.NodeRoundingRadius, false, true);
            graphics.FillPath(brush, mainPath);

            //Draw all the fields for input, then for output.
            curPos.X += control.GlobalPadding;
            curPos.Y += control.TitlePadding;
            foreach (var field in Fields)
            {
                //Draw field.
                field.Draw(control, graphics, curPos);

                //Increment to next current position.
                curPos.Y += field.GetDimensions(control, graphics).Y + control.FieldPadding;
            }
        }

        /// <summary>
        /// Returns the size of the node in grid units depending on the control/graphics.
        /// </summary>
        public Vector2 GetNodeSize(NodeGraphControl control, Graphics graphics)
        {
            //Try and figure out the size of the entire node.
            Vector2 finalSize = new Vector2();

            //Global padding in all directions.
            finalSize.X += control.GlobalPadding * 2;
            finalSize.Y += control.GlobalPadding * 2;

            //Size of the title (accounting for zoom).
            SizeF titleSize = graphics.MeasureString(Title, control.NodeTitleFont);
            titleSize.Width /= control.Zoom;
            titleSize.Height /= control.Zoom;
            finalSize.X += titleSize.Width;
            finalSize.Y += titleSize.Height;

            //Add padding for between title and fields.
            finalSize.Y += control.TitlePadding + control.GlobalPadding;

            //Loop over all fields and process.
            float inputX = 0, outputX = 0;
            foreach (var field in Fields)
            {
                Vector2 fieldDims = field.GetDimensions(control, graphics);

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
            if (finalSize.X < totalFieldWidth) { finalSize.X = totalFieldWidth + control.GlobalPadding * 2; }

            //Return final dimensions.
            Debug.WriteLine("EXPECTED NODE SIZE: " + finalSize.X + " x " + finalSize.Y);
            return finalSize;
        }
    }
}
