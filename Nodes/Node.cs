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
    public abstract class Node : Snowflake
    {
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
        /// The estimated size of this node.
        /// Updated on draw, but can be updated manually with UpdateNodeSize().
        /// </summary>
        public Vector2 Size { get; private set; } = null;

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

            //Get all the attributes on the main class itself.
            object[] classAttribs = this.GetType().GetCustomAttributes(typeof(NodeField), true);
            foreach (var attrib in classAttribs)
            {
                var field = (NodeField)attrib;
                field.SetOwner(this);
                Fields.Add(field);
            }

            //Get a list of all properties on the class.
            var properties = this.GetType().GetProperties();
            foreach (var prop in properties)
            {
                //Get the attribute from this property (if it's there).
                object[] attributes = prop.GetCustomAttributes(typeof(NodeField), true);
                if (attributes.Length == 0) { continue; }

                //Save this to the list.
                var field = (NodeField)attributes[0];
                field.SetOwner(this);
                Fields.Add(field);
            }
        }

        /// <summary>
        /// Draws the node onto the given control, with the provided graphics object.
        /// </summary>
        public void Draw(NodeGraphControl control, Graphics graphics)
        {
            //Set antialiasing on.
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //Update our size.
            UpdateNodeSize(control, graphics);

            //Based on the expected size of the node, shift the start position to the top left.
            Vector2 curPos = new Vector2(Location.X - Size.X / 2f, Location.Y - Size.Y / 2f);

            //Get the size of the title text, accounting for zoom.
            Brush brush = new SolidBrush(Colour);
            Vector2 titleSize = control.GetStringAsUnits(graphics, Title, control.NodeTitleFont);

            //Find and draw the title.
            Vector2 titleBottomRight = new Vector2(curPos.X + Size.X, curPos.Y + titleSize.Y); //+ control.GlobalPadding);
            Rectangle titleRect = control.GetPixelRectangle(curPos, titleBottomRight);
            graphics.FillPath(brush, RoundedPaths.RoundedRect(titleRect, control.NodeRoundingRadius * control.Zoom, true, false));

            //Draw title (with global padding).
            brush = new SolidBrush(TitleColour);
            graphics.DrawString(Title, control.NodeTitleFont, brush, control.ToPixelPointF(curPos.X + control.GlobalPadding, curPos.Y)); // + control.GlobalPadding));

            //Draw the main body rectangle.
            curPos.Y += titleSize.Y;
            Color backgroundColour = Color.FromArgb(control.NodeBackgroundOpacity, control.NodeBackgroundColour);
            brush = new SolidBrush(backgroundColour);
            var mainRect = control.GetPixelRectangle(curPos, new Vector2(curPos.X + Size.X, curPos.Y - titleSize.Y + Size.Y));
            var mainPath = RoundedPaths.RoundedRect(mainRect, control.NodeRoundingRadius, false, true);
            graphics.FillPath(brush, mainPath);
            curPos.X += control.GlobalPadding;
            curPos.Y += control.TitlePadding;

            //Start drawing all fields on the node.
            Vector2 curInputPos = curPos;
            Vector2 curOutputPos = new Vector2(curPos.X + Size.X - control.GlobalPadding * 2, curPos.Y);
            foreach (var field in Fields)
            {
                //Input or output? Switch current position.
                if (field.Type == FieldType.Input)
                {
                    curPos = curInputPos;
                }
                else
                {
                    curPos = curOutputPos;
                }

                //Draw the connector (with colouring).
                Vector2 fieldSize = field.GetDimensions(control, graphics);
                Vector2 connectorSize = field.GetConnectorDimensions();

                //Correct for the width of the node if we're drawing output.
                float connectorX = field.Type == FieldType.Output ? curPos.X - connectorSize.X : curPos.X;
                Vector2 nodeTopLeft = new Vector2(connectorX, curPos.Y + ((fieldSize.Y - connectorSize.Y) / 2f));
                Vector2 nodeBottomRight = new Vector2(nodeTopLeft.X + connectorSize.X, nodeTopLeft.Y + connectorSize.Y);
                field.DrawConnector(control, graphics, nodeTopLeft, nodeBottomRight);

                //Update the connector location within the field.
                field.ConnectorLocation = new Vector2(nodeTopLeft.X + connectorSize.X / 2f, nodeTopLeft.Y + connectorSize.Y / 2f);

                //Calculate the top left of the field based on side in preparation for drawing field.
                Vector2 fieldPos;
                if (field.Type == FieldType.Input)
                {
                    fieldPos = new Vector2(nodeBottomRight.X + control.NodeConnectorPadding, curPos.Y);
                }
                else
                {
                    fieldPos = new Vector2(curPos.X - connectorSize.X - control.NodeConnectorPadding - fieldSize.X, curPos.Y);
                }

                //Draw field.
                field.Draw(control, graphics, fieldPos);

                //Increment to next current position.
                curPos.Y += fieldSize.Y + control.FieldPadding;
            }
        }

        /// <summary>
        /// Returns the size of the node in grid units depending on the control/graphics.
        /// </summary>
        public void UpdateNodeSize(NodeGraphControl control, Graphics graphics)
        {
            //Try and figure out the size of the entire node.
            Vector2 finalSize = new Vector2();

            //Global padding in all directions.
            finalSize.X += control.GlobalPadding * 2;
            finalSize.Y += control.GlobalPadding * 2;

            //Size of the title (accounting for zoom).
            Vector2 titleSize = control.GetStringAsUnits(graphics, Title, control.NodeTitleFont);
            finalSize.X += titleSize.X;
            finalSize.Y += titleSize.Y;

            //Add padding for between title and fields.
            finalSize.Y += control.TitlePadding;

            //Loop over all fields and process.
            Vector2 input = new Vector2(), output = new Vector2();
            foreach (var field in Fields)
            {
                //Get the current side, dimensions of fields.
                Vector2 curSide = field.Type == FieldType.Input ? input : output;
                Vector2 fieldDims = field.GetDimensions(control, graphics);
                Vector2 connectorDims = field.GetConnectorDimensions();

                //If this field is an input/output, and bigger than one previously processed,
                //expand the expected width of either side.
                if (field.Type == FieldType.Input && input.X < fieldDims.X + connectorDims.X) 
                {
                    curSide.X = fieldDims.X + connectorDims.X;
                }
                else if (field.Type == FieldType.Output && output.X < fieldDims.X + connectorDims.X)
                {
                    curSide.X = fieldDims.X + connectorDims.X;
                }

                //Increment height (+ padding).
                curSide.Y += Math.Max(fieldDims.Y, connectorDims.Y) + control.FieldPadding;
            }

            //Add the field height.
            finalSize.Y += Math.Max(input.Y, output.Y);

            //Combine the field widths (+ padding).
            float totalFieldWidth = 0;
            if (input.X > 0)
                totalFieldWidth += input.X + control.NodeConnectorPadding;
            if (output.X > 0)
                totalFieldWidth += output.X + control.NodeConnectorPadding;
            if (input.X > 0 && output.X > 0)
                totalFieldWidth += control.FieldPadding;
            if (finalSize.X < totalFieldWidth) { finalSize.X = totalFieldWidth + control.GlobalPadding * 2; }

            //Return final dimensions.
            Size = finalSize;
        }

        /// <summary>
        /// Returns whether this node contains the given pixel point.
        /// </summary>
        public bool ContainsPoint(NodeGraphControl control, Point point)
        {
            Vector2 topLeft = new Vector2(Location.X - Size.X / 2f, Location.Y - Size.Y / 2f);
            Vector2 bottomRight = new Vector2(topLeft.X + Size.X, topLeft.Y + Size.Y);
            return control.GetPixelRectangle(topLeft, bottomRight).Contains(point);
        }
    }
}
