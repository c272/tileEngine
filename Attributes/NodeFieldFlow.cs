using easyCase.Controls;
using easyCase.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyCase.Attributes
{
    /// <summary>
    /// Represents a single "logic flow" field (either in, or out) on a node.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class NodeFieldFlow : NodeField
    {
        /// <summary>
        /// The width of the logic flow node (in grid units).
        /// </summary>
        public float Width = 15;

        /// <summary>
        /// The height of the logic flow node (in grid units).
        /// </summary>
        public float Height = 15;

        /// <summary>
        /// Simple passthrough constructor, passing in a name and type.
        /// </summary>
        public NodeFieldFlow(string name, FieldType type) : base(name, type, typeof(NodeFieldFlow), Color.White) { }

        /// <summary>
        /// Draws the logic flow field to the node.
        /// </summary>
        public override void Draw(NodeGraphControl control, Graphics graphics, Vector2 position)
        {
            //Just draw the name, nothing fancy.
            graphics.DrawString(Name, control.NodeTextFont, new SolidBrush(control.NodeTextColour), control.ToPixelPointF(position));
        }

        /// <summary>
        /// Draws the connector for this flow field onto the control.
        /// </summary>
        public override void DrawConnector(NodeGraphControl control, Graphics graphics, Vector2 topLeft, Vector2 bottomRight)
        {
            //Update the node colour to the node text colour.
            NodeColour = control.NodeTextColour;

            //Create the graphics path for the logic flow.
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();

            //From pixel top left, draw arrow.
            PointF pixelTopLeft = control.ToPixelPointF(topLeft);
            Vector2 size = new Vector2(Width * control.Zoom, Height * control.Zoom);
            path.AddLine(pixelTopLeft.X, pixelTopLeft.Y, pixelTopLeft.X + size.X / 3f, pixelTopLeft.Y); //along 1/3
            path.AddLine(pixelTopLeft.X + size.X / 3f, pixelTopLeft.Y, pixelTopLeft.X + size.X, pixelTopLeft.Y + size.Y / 2f); //along 2/3 and down 1/2
            path.AddLine(pixelTopLeft.X + size.X, pixelTopLeft.Y + size.Y / 2f, pixelTopLeft.X + size.X / 3f, pixelTopLeft.Y + size.Y); //down 1/2 and back 2/3
            path.AddLine(pixelTopLeft.X + size.X / 3f, pixelTopLeft.Y + size.Y, pixelTopLeft.X, pixelTopLeft.Y + size.Y); //back 1/3
            path.AddLine(pixelTopLeft.X, pixelTopLeft.Y + size.Y, pixelTopLeft.X, pixelTopLeft.Y); //up 1

            //Draw the path.
            if (ConnectedTo == null)
            {
                graphics.DrawPath(new Pen(NodeColour, (Width + Height) / 20f * control.Zoom), path);
            }
            else
            {
                graphics.FillPath(new SolidBrush(NodeColour), path);
            }
        }

        /// <summary>
        /// Returns the dimensions of this connector (the width and height).
        /// </summary>
        public override Vector2 GetConnectorDimensions()
        {
            return new Vector2(Width, Height);
        }

        /// <summary>
        /// Returns the dimensions of the logic flow field as set by Width & Height.
        /// </summary>
        public override Vector2 GetDimensions(NodeGraphControl control, Graphics graphics)
        {
            //Measure name as string, use. If name is null, then ignore.
            Vector2 finalSize = new Vector2(0, 0);
            if (Name != null)
            {
                finalSize = control.GetStringAsUnits(graphics, Name, control.NodeTextFont);
            }

            return finalSize;
        }

        /// <summary>
        /// Returns whether a given pixel point can be found within the connector.
        /// </summary>
        public override bool PointWithinConnector(NodeGraphControl control, Point point)
        {
            //Don't bother with fancy logic, just use a rectangle check.
            Vector2 topLeft = new Vector2(ConnectorLocation.X - Width / 2f, ConnectorLocation.Y - Height / 2f);
            Rectangle connectorRect = control.GetPixelRectangle(topLeft, new Vector2(topLeft.X + Width, topLeft.Y + Height));
            return connectorRect.Contains(point);
        }
    }
}
