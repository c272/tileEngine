using nodeGame.Controls;
using nodeGame.Utility;
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

        //The radius of the connector.
        public int ConnectorRadius { get; set; } = 10;

        //Create the numeric input for this numeric field.
        protected Control editorControl = null;

        //The name of the property this field is editing.
        public string PropertyName { get; private set; }

        /// <summary>
        /// Constructor for the numeric field.
        /// Simply passes down base arguments, nothing fancy.
        /// </summary>
        public NodeFieldBasic(string name, FieldType type, Type valueType, Color nodeColour) : base(name, type, valueType, nodeColour) 
        {
            //Alter whether the user can edit based on whether this is an output or input.
            //If we're an input, by default turn it on. If we're an output, by default turn it off.
            UserCanEdit = type == FieldType.Input ? true : false;
        }

        /// <summary>
        /// Draws the numeric field to the control, at the provided position.
        /// </summary>
        public override void Draw(NodeGraphControl control, Graphics graphics, Vector2 position)
        {
            //Get what size we're expected to be.
            Vector2 size = GetDimensions(control, graphics);

            //Draw the name (left). Make sure it's centered with the editor control.
            Brush brush = new SolidBrush(control.NodeTextColour);
            Vector2 nameDims = control.GetStringAsUnits(graphics, Name, control.NodeTextFont);
            Vector2 namePosition = new Vector2(position.X, position.Y + ((size.Y - nameDims.Y) / 2f));
            graphics.DrawString(Name, control.NodeTextFont, brush, control.ToPixelPointF(namePosition));

            //If there's no editor control, ignore and return.
            if (editorControl == null) { return; }

            //Add the editor control to this node graph if it's not there already.
            if (!control.Controls.Contains(editorControl))
                control.Controls.Add(editorControl);

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
        /// Draws the connector to the provided locations.
        /// </summary>
        public override void DrawConnector(NodeGraphControl control, Graphics graphics, Vector2 topLeft, Vector2 bottomRight)
        {
            Brush brush = new SolidBrush(NodeColour);
            if (ConnectedTo != null)
            {
                //Draw filled, it's connected to something.
                graphics.FillEllipse(brush, control.GetPixelRectangle(topLeft, bottomRight));
            }
            else
            {
                //Draw with outline only.
                graphics.DrawEllipse(new Pen(brush, Math.Max(GetConnectorDimensions().X / 5f, 1)), control.GetPixelRectangle(topLeft, bottomRight));
            }
        }

        /// <summary>
        /// Checks whether a given point is within the bounds of the connector.
        /// </summary>
        public override bool PointWithinConnector(NodeGraphControl control, Point point)
        {
            //If we don't have a connector location, no points within it.
            if (ConnectorLocation == null) { return false; }

            //Calculate rectangle of connector, provide result.
            Vector2 connectorTopLeft = new Vector2(ConnectorLocation.X - ConnectorRadius / 2f, ConnectorLocation.Y - ConnectorRadius / 2f);
            Vector2 connectorBottomRight = new Vector2(connectorTopLeft.X + ConnectorRadius, connectorTopLeft.Y + ConnectorRadius);
            Rectangle connectorPixelRect = control.GetPixelRectangle(connectorTopLeft, connectorBottomRight);
            return connectorPixelRect.Contains(point);
        }

        /// <summary>
        /// Returns the dimensions of the connector on this field.
        /// </summary>
        public override Vector2 GetConnectorDimensions()
        {
            return new Vector2(ConnectorRadius, ConnectorRadius);
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
