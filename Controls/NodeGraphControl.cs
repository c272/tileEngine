﻿using easyCase.Nodes;
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
        public Vector2 cameraPos = new Vector2(0, 0);

        //A list of nodes currently on the node graph.
        public List<Node> nodes = new List<Node>();

        ///////////////////////////
        /// METHODS & OVERRIDES ///
        ///////////////////////////#
        
        //Default constructor, sets resizing redraw on.
        public NodeGraphControl()
        {
            SetStyle(ControlStyles.ResizeRedraw, true);
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

        /// <summary>
        /// Gets a pixel-space rectangle based on the top left and bottom right of a rectangle in grid space.
        /// </summary>
        public Rectangle GetPixelRectangle(Vector2 topLeft, Vector2 bottomRight)
        {
            Point pixelTopLeft = ToPixelCoordinate(topLeft.X, topLeft.Y);
            Point pixelBottomRight = ToPixelCoordinate(bottomRight.X, bottomRight.Y);
            return new Rectangle(pixelTopLeft, new Size(pixelBottomRight.X - pixelTopLeft.X, pixelBottomRight.Y - pixelTopLeft.X));
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
        public Point ToPixelCoordinate(float x, float y)
        {
            //Get the vector from the camera to this point.
            Vector2 relativeToCamera = new Vector2(x - cameraPos.X, y - cameraPos.Y);

            //Convert this vector into pixel space coordinates, correct for the center of the control.
            Vector2 center = new Vector2(ClientRectangle.X + ClientRectangle.Width / 2f, ClientRectangle.Y + ClientRectangle.Height / 2f);
            Vector2 relativePixels = new Vector2(relativeToCamera.X * zoom, relativeToCamera.Y * zoom);
            return new Point((int)(center.X + relativePixels.X), (int)(center.Y + relativePixels.Y));
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
            foreach (var node in nodes)
            {
                node.Draw(this, e.Graphics);
            }
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
                e.Graphics.DrawLine(pen, ToPixelCoordinate(curPos.X, curPos.Y), ToPixelCoordinate(curPos.X, bottomRight.Y));
                curPos.X += GridStep;
            }

            //Horizontal lines.
            curPos = new Vector2(topLeft.X, topLeft.Y - (topLeft.Y % GridStep));
            while (curPos.Y <= bottomRight.Y)
            {
                e.Graphics.DrawLine(pen, ToPixelCoordinate(curPos.X, curPos.Y), ToPixelCoordinate(bottomRight.X, curPos.Y));
                curPos.Y += GridStep;
            }
        }
    }
}
