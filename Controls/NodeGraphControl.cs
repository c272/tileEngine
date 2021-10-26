using easyCase.Attributes;
using easyCase.Nodes;
using easyCase.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyCase.Controls
{
    /// <summary>
    /// Represents a visual node graph editor control within the form.
    /// </summary>
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]

    public class NodeGraphControl : Control
    {
        /////////////////////////
        /// PUBLIC PROPERTIES ///
        /////////////////////////

        #region Configuration

        /// <summary>
        /// Property to alter the zoom of the node graph editor.
        /// </summary>
        public float Zoom { 
            get { return zoom; }
            set
            {
                //Bound zoom to 0.01 or above.
                if (value < 0.01)
                    value = 0.01f;

                //Update font size values.
                NodeTitleFont = UpdateFontSize(NodeTitleFont, value, zoom);
                NodeTextFont = UpdateFontSize(NodeTextFont, value, zoom);

                //Update zoom value.
                zoom = value;
                Invalidate();
            }
        }

        private float zoom = 1f;

        /// <summary>
        /// The size of the grid step (in pixels) when at default zoom.
        /// </summary>
        public float GridStep
        {
            get { return gridStep; }
            set
            {
                gridStep = value;
                Invalidate();
            }
        }
        private float gridStep = 10f;

        /// <summary>
        /// The diameter (in grid units) of the connection points
        /// for a single node field.
        /// </summary>
        public float NodeConnectorSize
        {
            get { return nodeConnectorSize; }
            set
            {
                nodeConnectorSize = value;
                Invalidate();
            }
        }
        private float nodeConnectorSize = 3f;

        /// <summary>
        /// The padding following the node connector until the field.
        /// </summary>
        public float NodeConnectorPadding
        {
            get { return nodeConnectorPadding; }
            set
            {
                nodeConnectorPadding = value;
                Invalidate();
            }
        }
        private float nodeConnectorPadding = 2f;

        /// <summary>
        /// The intermediary gap for the bezier curve on each connection.
        /// </summary>
        public int NodeConnectionGap
        {
            get { return nodeConnectionGap; }
            set
            {
                nodeConnectionGap = value;
                Invalidate();
            }
        }
        private int nodeConnectionGap = 3;

        /// <summary>
        /// The size of the padding following the title of the node.
        /// </summary>
        public float TitlePadding
        {
            get { return titlePadding; }
            set
            {
                titlePadding = value;
                Invalidate();
            }
        }
        private float titlePadding = 5;

        /// <summary>
        /// The size of the vertical and horizontal padding between each field on the node.
        /// </summary>
        public float FieldPadding
        {
            get { return fieldPadding; }
            set
            {
                fieldPadding = value;
                Invalidate();
            }
        }
        private float fieldPadding = 5;

        /// <summary>
        /// The size of the padding between the edge of the node and the internal draw.
        /// </summary>
        public float GlobalPadding
        { 
            get { return globalPadding; }
            set
            {
                globalPadding = value;
                Invalidate();
            }
        }
        private float globalPadding = 5;

        /// <summary>
        /// The radius of the circles rounding the corners of each node on the graph.
        /// </summary>
        public int NodeRoundingRadius
        {
            get { return nodeRoundingRadius; }
            set
            {
                nodeRoundingRadius = value;
                Invalidate();
            }
        }
        private int nodeRoundingRadius = 5;

        /// <summary>
        /// The font for title text of nodes.
        /// </summary>
        public Font NodeTitleFont
        {
            get { return nodeTitleFont; }
            set
            {
                nodeTitleFont = value;
                Invalidate();
            }
        }
        private Font nodeTitleFont = SystemFonts.DefaultFont;

        /// <summary>
        /// The font for standard text in nodes.
        /// </summary>
        public Font NodeTextFont
        {
            get { return nodeTextFont; }
            set
            {
                nodeTextFont = value;
                Invalidate();
            }
        }
        private Font nodeTextFont = SystemFonts.DefaultFont;

        /// <summary>
        /// Property to set the text colour of the standard text on the node.
        /// Title text is controlled per-node (for colour matching purposes).
        /// </summary>
        public Color NodeTextColour
        {
            get { return nodeTextColour; }
            set
            {
                nodeTextColour = value;
                Invalidate();
            }
        }
        private Color nodeTextColour = Color.Black;


        /// <summary>
        /// Property to set the background colour of the editor.
        /// </summary>
        public Color BackgroundColour
        {
            get { return bgColour; }
            set
            {
                bgColour = value;
                Invalidate();
            }
        }
        private Color bgColour = Color.White;

        /// <summary>
        /// Property to set the background line colour of the editor.
        /// </summary>
        public Color BackgroundLineColour
        {
            get { return bgLineColour; }
            set
            {
                bgLineColour = value;
                Invalidate();
            }
        }
        private Color bgLineColour = Color.LightGray;

        /// <summary>
        /// Property to set the background line colour of the editor.
        /// </summary>
        public Color NodeBackgroundColour
        {
            get { return nodeBgColour; }
            set
            {
                nodeBgColour = value;
                Invalidate();
            }
        }
        private Color nodeBgColour = Color.Gray;

        #endregion

        //////////////////////////
        /// PRIVATE PROPERTIES ///
        //////////////////////////

        //The current location of the camera (X and Y).
        private Vector2 cameraPos = new Vector2(0, 0);

        //A list of nodes currently on the node graph.
        private List<Node> nodes = new List<Node>();

        //The current state of the NodeGraphControl.
        private NodeGraphState state = NodeGraphState.Default;

        //Tracking variables for mouse drag on the graph.
        private Point lastMouseLocation;

        //The field currently being connected in the ConnectingNode state.
        private NodeField connectingField = null;
        private Node nodeBeingMoved = null;

        ///////////////////////////
        /// METHODS & OVERRIDES ///
        ///////////////////////////

        //Default constructor.
        public NodeGraphControl()
        {
            //Set redraw on, double buffer self.
            SetStyle(ControlStyles.ResizeRedraw, true);
            DoubleBuffered = true;

            //Set up events for user control.
            MouseDown += OnMouseDown;
            MouseUp += OnMouseUp;
            MouseMove += OnMouseMove;
            MouseWheel += OnMouseWheel;
        }

        /// <summary>
        /// Adds a given node to the node graph.
        /// </summary>
        public void AddNode(Node n)
        {
            if (nodes.FindIndex(x => x.ID == n.ID) != -1) { return; }
            nodes.Add(n);
        }

        /// <summary>
        /// Removes a given node from the node graph.
        /// </summary>
        public void RemoveNode(Node n)
        {
            nodes.RemoveAll(x => x.ID == n.ID);
        }

        ///////////////////////
        /// EVENT FUNCTIONS ///
        ///////////////////////
        
        //Triggered when the user spins the mouse wheel.
        private void OnMouseWheel(object sender, MouseEventArgs e)
        {
            //Adjust zoom.
            Zoom += e.Delta / 120 * 0.1f;
        }
        
        //Triggered when the mouse is first pressed down.
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            //Has the user clicked on a connector? (If so, start connecting).
            foreach (var node in nodes)
            {
                foreach (var field in node.Fields)
                {
                    //Are we in the connector?
                    if (!field.PointWithinConnector(this, e.Location)) { continue; }

                    //Click is within the rectangle! If it's connected to something already, disconnect.
                    if (field.ConnectedTo != null)
                        field.ConnectedTo.ConnectedTo = null;
                    field.ConnectedTo = null;

                    //Start the drag.
                    state = NodeGraphState.ConnectingNode;
                    connectingField = field;
                    lastMouseLocation = e.Location;
                    return;
                }
            }

            //Has the user clicked on a node but not on a connector? (If so, start moving the node).
            foreach (var node in nodes)
            {
                if (node.ContainsPoint(this, e.Location))
                {
                    //Start the node drag.
                    state = NodeGraphState.MovingNode;
                    lastMouseLocation = e.Location;
                    nodeBeingMoved = node;
                    return;
                }
            }

            //Start the mouse drag.
            state = NodeGraphState.MovingCamera;
            lastMouseLocation = e.Location;
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            //Get the mouse location delta, adjust for zoom.
            Vector2 delta = new Vector2(lastMouseLocation.X - e.Location.X, lastMouseLocation.Y - e.Location.Y);
            delta.X /= zoom;
            delta.Y /= zoom;

            //If we're currently moving a node, alter the node position by the delta.
            if (state == NodeGraphState.MovingNode)
            {
                nodeBeingMoved.Location.X -= delta.X;
                nodeBeingMoved.Location.Y -= delta.Y;
                Invalidate();
            }

            //If we're currently moving the camera, alter camera based on the delta/zoom.
            if (state == NodeGraphState.MovingCamera)
            {
                //Apply this delta to the camera.
                cameraPos.X += delta.X;
                cameraPos.Y += delta.Y;
                Invalidate();
            }

            //If we're currently connecting a node, invalidate so we can draw the pending line.
            if (state == NodeGraphState.ConnectingNode)
                Invalidate();

            //Update last mouse location.
            lastMouseLocation = e.Location;
        }

        //Triggered when the mouse is released.
        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            //Are we currently connecting a node?
            if (state == NodeGraphState.ConnectingNode)
            {
                ValidateFieldConnection(e);

                //Clear the field currently being connected (drag ended).
                connectingField = null;
                Invalidate();
            }

            //If we were moving a node, clear the node being moved (we're done).
            if (state == NodeGraphState.MovingNode)
                nodeBeingMoved = null;

            //Return to the default state.
            state = NodeGraphState.Default;
        }

        /// <summary>
        /// Checks whether after a connecting drag the two fields hovered over should be connected.
        /// </summary>
        private void ValidateFieldConnection(MouseEventArgs e)
        {
            //Check if we're within a valid node to connect to.
            foreach (var node in nodes)
            {
                foreach (var field in node.Fields)
                {
                    //Ignore if the fields' types do not match, or the field is the one we're connecting from.
                    if (field.ID == connectingField.ID || field.ValueType != connectingField.ValueType) { continue; }

                    //Don't let an output connect to an output, or an input to an input.
                    if (field.Type == connectingField.Type) { continue; }

                    //Don't let an output connect to an input on the same node.
                    if (field.Node.ID == connectingField.Node.ID) { continue; }

                    //Is the mouse within the bounds of this field?
                    if (!field.PointWithinConnector(this, e.Location)) { continue; }

                    //Yes, connect the two fields.
                    field.ConnectedTo = connectingField;
                    connectingField.ConnectedTo = field;
                    break;
                }
            }
        }

        /// <summary>
        /// Paints the node graph to the screen.
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.Clear(BackgroundColour);

            //Draw the background.
            DrawBackground(e);

            //Draw the nodes (and their connections).
            DrawNodes(e);
        }

        /// <summary>
        /// Draws all the nodes currently on the node graph to the screen in order.
        /// </summary>
        private void DrawNodes(PaintEventArgs e)
        {
            //Draw the connections between the nodes.
            List<int> alreadyConnected = new List<int>();
            foreach (var node in nodes)
            {
                foreach (var field in node.Fields)
                {
                    //Ignore field if it's not got a connector location yet.
                    if (field.ConnectorLocation == null) { continue; }

                    //Ignore fields with no connection, or if we've connected it already.
                    if (field.ConnectedTo == null || alreadyConnected.Contains(field.ID)) { continue; }

                    //Draw bezier curve to connecting field.
                    Point endPoint = ToPixelPoint(field.ConnectedTo.ConnectorLocation);
                    DrawConnection(e, field, endPoint, field.ConnectedTo.Type);

                    //List field as connected.
                    alreadyConnected.Add(field.ID);
                    alreadyConnected.Add(field.ConnectedTo.ID);
                }
            }

            //Draw all the nodes in order.
            foreach (var node in nodes)
            {
                node.Draw(this, e.Graphics);
            }

            //If we're currently in the "connecting node" state, also draw the pending connection.
            if (state == NodeGraphState.ConnectingNode)
            {
                DrawConnection(e, connectingField, lastMouseLocation, FieldType.Input);
            }
        }

        /// <summary>
        /// Draws a connection between the two given points, provided the type of each field on either side.
        /// </summary>
        /// <param name="e">The graphics object to draw with.</param>
        /// <param name="startField">The field to start the drawing from.</param>
        /// <param name="endPoint">The point to end the drawing at.</param>
        /// <param name="endType">The type (direction) of the end offset, Output = Right, Input = Left</param>
        private void DrawConnection(PaintEventArgs e, NodeField startField, Point endPoint, FieldType endType)
        {
            //Get the distance between the nodes.
            Point fieldPoint = ToPixelPoint(startField.ConnectorLocation);
            Vector2 fieldToEnd = new Vector2(fieldPoint.X - endPoint.X, fieldPoint.Y - endPoint.Y);
            float distance = fieldToEnd.GetMagnitude();

            //Calculate the strength modifier to the curve.
            float modifier = 1f;
            if (distance < NodeConnectionGap * 2)
            {
                modifier = distance / (float)(NodeConnectionGap * 2f);
            }

            //Calculate intermediary points.
            int connectionGap = (int)(NodeConnectionGap * modifier);
            int startOffset = startField.Type == FieldType.Output ? connectionGap : -connectionGap;
            int endOffset = endType == FieldType.Output ? connectionGap : -connectionGap;

            Point startIntermediate = ToPixelPoint(startField.ConnectorLocation.X + startOffset, startField.ConnectorLocation.Y);
            Point endIntermediate = new Point(endPoint.X + endOffset, endPoint.Y);

            //Draw the bezier.
            e.Graphics.DrawBezier(new Pen(startField.NodeColour, 3), ToPixelPoint(startField.ConnectorLocation), startIntermediate, endIntermediate, endPoint);
        }

        /// <summary>
        /// Draws the background of the node graph editor using a PaintEventArgs.
        /// </summary>
        private void DrawBackground(PaintEventArgs e)
        {
            //First, draw the background colour.
            Brush brush = new SolidBrush(BackgroundColour);
            e.Graphics.FillRectangle(brush, ClientRectangle);

            //Now to draw the grid (at the correct zoom level).
            brush = new SolidBrush(BackgroundLineColour);
            Pen pen = new Pen(brush);
            pen.Width = 2;
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

            //Round up to the nearest grid step.
            Vector2 topLeft = ToGridCoordinate(ClientRectangle.X, ClientRectangle.Y);
            Vector2 bottomRight = ToGridCoordinate(ClientRectangle.X + ClientRectangle.Width, ClientRectangle.Y + ClientRectangle.Height);

            //Vertical lines.
            Vector2 curPos = new Vector2(topLeft.X - (topLeft.X % GridStep), topLeft.Y);
            while (curPos.X <= bottomRight.X)
            {
                e.Graphics.DrawLine(pen, ToPixelPointF(curPos), ToPixelPointF(curPos.X, bottomRight.Y));
                curPos.X += GridStep;
            }

            //Horizontal lines.
            curPos = new Vector2(topLeft.X, topLeft.Y - (topLeft.Y % GridStep));
            while (curPos.Y <= bottomRight.Y)
            {
                e.Graphics.DrawLine(pen, ToPixelPointF(curPos), ToPixelPointF(bottomRight.X, curPos.Y));
                curPos.Y += GridStep;
            }
        }

        //////////////////////////////////////
        /// UTILITY FUNCTIONS (CONVERSION) ///
        //////////////////////////////////////

        /// <summary>
        /// Gets a pixel-space rectangle based on the top left and bottom right of a rectangle in grid space.
        /// </summary>
        public Rectangle GetPixelRectangle(Vector2 topLeft, Vector2 bottomRight)
        {
            Point pixelTopLeft = ToPixelPoint(topLeft);
            Point pixelBottomRight = ToPixelPoint(bottomRight);
            return new Rectangle(pixelTopLeft, new Size(pixelBottomRight.X - pixelTopLeft.X, pixelBottomRight.Y - pixelTopLeft.Y));
        }

        /// <summary>
        /// Converts an existing pixel-space coordinate into a grid space coordinate.
        /// </summary>
        public Vector2 ToGridCoordinate(float x, float y)
        {
            //The amount of grid coordinates traversed per pixel.
            float pixelValue = 1 / zoom;

            //Calculate how far away we are (in pixels) from the center, as a vector.
            Vector2 center = new Vector2(ClientRectangle.X + ClientRectangle.Width / 2f, ClientRectangle.Y + ClientRectangle.Height / 2f);
            Vector2 relativeToCenter = new Vector2(x - center.X, y - center.Y);

            //Convert this vector into grid space coordinates, then apply the vector to the camera position.
            return new Vector2(cameraPos.X + relativeToCenter.X * pixelValue, cameraPos.Y + relativeToCenter.Y * pixelValue);
        }

        /// <summary>
        /// Converts an existing grid-space coordinate into a client rectangle pixel coordinate.
        /// </summary>
        public Point ToPixelPoint(Vector2 point) { return ToPixelPoint(point.X, point.Y); }

        /// <summary>
        /// Converts an existing grid-space coordinate into a single client rectangle pixel point.
        /// </summary>
        public Point ToPixelPoint(float x, float y)
        {
            PointF floatVer = ToPixelPointF(x, y);
            return new Point((int)floatVer.X, (int)floatVer.Y);
        }

        /// <summary>
        /// Converts an existing grid-space coordinate into a client rectangle pixel coordinate.
        /// </summary>
        public PointF ToPixelPointF(Vector2 point) { return ToPixelPointF(point.X, point.Y); }

        /// <summary>
        /// Converts an existing grid-space coordinate into a client rectangle pixel coordinate.
        /// </summary>
        public PointF ToPixelPointF(float x, float y)
        {
            //Get the vector from the camera to this point.
            Vector2 relativeToCamera = new Vector2(x - cameraPos.X, y - cameraPos.Y);

            //Convert this vector into pixel space coordinates, correct for the center of the control.
            Vector2 center = new Vector2(ClientRectangle.X + ClientRectangle.Width / 2f, ClientRectangle.Y + ClientRectangle.Height / 2f);
            Vector2 relativePixels = new Vector2(relativeToCamera.X * zoom, relativeToCamera.Y * zoom);
            return new PointF(center.X + relativePixels.X, center.Y + relativePixels.Y);
        }

        /////////////////////////////////
        /// PRIVATE UTILITY FUNCTIONS ///
        /////////////////////////////////

        //Updates the size of all fonts when "zoom" is changed.
        private Font UpdateFontSize(Font font, float newZoom, float zoom)
        {
            return new Font(font.FontFamily, font.SizeInPoints * (newZoom / zoom));
        }
    }
}
