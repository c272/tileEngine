using DarkUI.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tileEngine.SDK.Map;
using tileEngine.Utility;

namespace tileEngine.Controls
{
    /// <summary>
    /// Represents a single map editor control within tileEngine.
    /// </summary>
    public class MapEditorControl : GridControlBase
    {
        /// <summary>
        /// The palette that is being used to select tiles for this control.
        /// If null, no tile place events will register.
        /// </summary>
        public MapPaletteControl Palette { get; set; } = null;

        /// <summary>
        /// The tile layer that is currently selected on this map editor control.
        /// </summary>
        public TileLayer SelectedLayer
        {
            get { return _selectedLayer; }
            set
            {
                _selectedLayer = value;
                SelectedTile = null;
            }
        }
        private TileLayer _selectedLayer = null;

        /// <summary>
        /// The currently selected tile on the current layer, if any.
        /// </summary>
        public Point? SelectedTile { get; private set; } = null;

        /// <summary>
        /// The current edit mode of the map editor (which surface the editor is editing).
        /// </summary>
        public MapEditMode EditMode { get; set; } = MapEditMode.Tiles;

        /// <summary>
        /// The current edit tool being used to edit the map.
        /// </summary>
        public MapEditTool EditTool { get; set; } = MapEditTool.Select;

        //Event for when the selected layer is edited..
        public delegate void OnSelectedLayerEditedHandler();
        public event OnSelectedLayerEditedHandler OnSelectedLayerEdited;

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

        /// <summary>
        /// Sets the currently selected layer on this map editor control. 
        /// If the provided layer does not exist on the map currently set, the 
        /// selected layer will be set to null (no selection).
        /// </summary>
        public void SetSelectedLayer(TileLayer layer)
        {
            //Ignore if no map, or map does not contain layer.
            if (Map == null || Map.Layers.FindIndex(x => x.ID == layer.ID) == -1)
            {
                SelectedLayer = null;
                Map?.Layers.ForEach(x => x.Opacity = 1f);
                return;
            }

            //Set layer, configure opacities for below layers & hide above ones.
            SelectedLayer = layer;
            bool aboveLayer = false;
            for (int i = 0; i < Map.Layers.Count; i++)
            {
                //If we've reached the layer, then all ones after this are above the layer.
                var thisLayer = Map.Layers[i];
                if (thisLayer.ID == layer.ID)
                {
                    thisLayer.Opacity = 1f;
                    aboveLayer = true;
                    continue;
                }

                //Set opacity.
                thisLayer.Opacity = aboveLayer ? 0f : 0.5f;
            }

            //Reconfigured, invalidate.
            Invalidate();
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

        /// <summary>
        /// Triggered when the user spins the mouse wheel.
        /// </summary>
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

            //If the current tool is the grab and pan hand, all mouse actions result in pan.
            if (EditTool == MapEditTool.GrabAndPan)
            {
                state = MapEditorState.MovingCamera;
                lastMouseLocation = e.Location;
                return;
            }

            //If the user is left clicking, tool action.
            if (e.Button == MouseButtons.Left)
            {
                //If there is no layer selected, then pop up a warning.
                if (SelectedLayer == null)
                {
                    DarkMessageBox.ShowError("You must select a layer before performing edits on the map.", "tileEngine - Layer Select Error", DarkDialogButton.Ok);
                    return;
                }

                bool success;
                switch (EditTool)
                {
                    //Pencil Tool
                    case MapEditTool.Pencil:
                        success = DoPencilTool(e);
                        break;

                    //Select Tool
                    case MapEditTool.Select:
                        success = DoSelectTool(e);
                        break;

                    //Area Select
                    case MapEditTool.AreaSelect:
                        throw new NotImplementedException();

                    default:
                        success = false;
                        break;
                }

                //Done!
                return;
            }

            //Start the camera drag.
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

        ////////////////////
        /// TOOL ACTIONS ///
        ////////////////////

        /// <summary>
        /// Performs a pencil tool action on the current tile.
        /// </summary>
        private bool DoPencilTool(MouseEventArgs e)
        {
            //If no palette configured, or no selected tile, ignore.
            if (Palette == null || Palette.SelectedTile == null)
                return false;

            //Draw the tile at the current mouse position.
            Point mouseTile = ToTileLocation(e.Location);
            Microsoft.Xna.Framework.Point tileLocation = new Microsoft.Xna.Framework.Point(mouseTile.X, mouseTile.Y);
            if (SelectedLayer.Tiles.ContainsKey(tileLocation))
            {
                SelectedLayer.Tiles[tileLocation] = (TileData)Palette.SelectedTile;
            }
            else
            {
                SelectedLayer.Tiles.Add(tileLocation, (TileData)Palette.SelectedTile);
            }

            //Done!
            OnSelectedLayerEdited?.Invoke();
            Invalidate();
            return true;
        }

        /// <summary>
        /// Performs a select tool action on the current tile.
        /// </summary>
        private bool DoSelectTool(MouseEventArgs e)
        {
            SelectedTile = ToTileLocation(e.Location);
            return true;
        }
    }

    /// <summary>
    /// The edit mode of the map editor control.
    /// </summary>
    public enum MapEditMode
    {
        Tiles,
        Events,
        Collision
    }

    /// <summary>
    /// The available map edit tools for the user.
    /// </summary>
    public enum MapEditTool
    {
        Select,
        GrabAndPan,
        AreaSelect,
        Pencil
    }
}
