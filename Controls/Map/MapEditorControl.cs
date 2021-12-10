using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tileEngine.Utility;

namespace tileEngine.Controls
{
    /// <summary>
    /// Represents a single map editor control within tileEngine.
    /// </summary>
    public class MapEditorControl : GridControlBase
    {
        //The current state of the NodeGraphControl.
        private MapEditorState state = MapEditorState.Default;

        //Tracking variables for mouse drag on the graph.
        private Point lastMouseLocation;

        ///////////////////////////
        /// METHODS & OVERRIDES ///
        ///////////////////////////

        //Default constructor.
        public MapEditorControl()
        {
            //Set up events for user control.
            MouseDown += OnMouseDown;
            MouseUp += OnMouseUp;
            MouseMove += OnMouseMove;
            MouseWheel += OnMouseWheel;

            //Enable drag and drop from the node palette.
            AllowDrop = true;
        }

        ///////////////////////
        /// EVENT FUNCTIONS ///
        ///////////////////////

        /// <summary>
        /// Triggered when a key is pressed down on the control.
        /// </summary>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            //switch (e.KeyCode)
            //{
            //    //Any shortcuts here.
            //}
        }

        //Triggered when the user spins the mouse wheel.
        private void OnMouseWheel(object sender, MouseEventArgs e)
        {
            //Adjust zoom.
            Zoom += e.Delta / 120 * 0.05f;
        }

        /// <summary>
        /// Triggered when the mouse is first pressed down.
        /// </summary>
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            //Deselect any child elements.
            this.Select();

            //Start the camera drag, deselect any nodes.
            state = MapEditorState.MovingCamera;
            lastMouseLocation = e.Location;
        }

        /// <summary>
        /// Triggered when the mouse is moved on the window.
        /// </summary>
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            //Get the mouse location delta, adjust for zoom.
            Vector2f delta = new Vector2f(lastMouseLocation.X - e.Location.X, lastMouseLocation.Y - e.Location.Y);
            delta.X /= Zoom;
            delta.Y /= Zoom;

            //If we're currently moving the camera, alter camera based on the delta/zoom.
            if (state == MapEditorState.MovingCamera)
            {
                //Apply this delta to the camera.
                cameraPos.X += delta.X;
                cameraPos.Y += delta.Y;
                Invalidate();
            }

            //Update last mouse location.
            lastMouseLocation = e.Location;
        }

        /// <summary>
        /// Triggered when the mouse is released.
        /// </summary>
        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            //Return to the default state.
            state = MapEditorState.Default;
        }
    }
}
