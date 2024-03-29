﻿using DarkUI.Config;
using DarkUI.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tileEngine.SDK.Map;
using tileEngine.SDK.Utility;
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
                //Configure selected layer, and also event/collide draw layers.
                _selectedLayer = value;
                EventDrawLayer = value;
                CollisionDrawLayer = value;

                //Deselect all tiles.
                SelectedTiles = null;
            }
        }
        private TileLayer _selectedLayer = null;

        /// <summary>
        /// The currently selected tiles on the current layer, if any.
        /// </summary>
        public Rectangle? SelectedTiles
        {
            get { return _selectedTiles; }
            set
            {
                _selectedTiles = value;
                OnSelectedTilesChanged?.Invoke(value);
            }
        }
        private Rectangle? _selectedTiles = null;

        /// <summary>
        /// The current edit mode of the map editor (which surface the editor is editing).
        /// </summary>
        public MapEditMode EditMode
        {
            get { return _editMode; }
            set
            {
                _editMode = value;
                OnEditModeChanged?.Invoke(value);
            }
        }
        private MapEditMode _editMode = MapEditMode.Tiles;

        /// <summary>
        /// The current edit tool being used to edit the map.
        /// </summary>
        public MapEditTool EditTool
        {
            get { return _editTool; }
            set
            {
                _editTool = value;
                OnEditToolChanged?.Invoke(value);
            }
        }
        private MapEditTool _editTool = MapEditTool.Select;

        //Event for when the selected tiles are changed.
        public delegate void OnSelectedTilesChangedHandler(Rectangle? newTiles);
        public event OnSelectedTilesChangedHandler OnSelectedTilesChanged;

        //Event for when the selected layer is edited..
        public delegate void OnSelectedLayerEditedHandler();
        public event OnSelectedLayerEditedHandler OnSelectedLayerEdited;

        //Event for when the edit mode is changed.
        public delegate void OnEditModeChangedHandler(MapEditMode newMode);
        public event OnEditModeChangedHandler OnEditModeChanged;

        //Event for when the edit tool is changed.
        public delegate void OnEditToolChangedHandler(MapEditTool newTool);
        public event OnEditToolChangedHandler OnEditToolChanged;

        //The current state of the NodeGraphControl.
        private MapEditorState state = MapEditorState.Default;

        //Tracking variables for mouse drag on the graph.
        private Point lastMouseLocation;

        //Tiles that have been copied from the map, and their originating mode.
        private List<List<object>> copiedTiles = null;
        private MapEditMode copiedTilesMode = MapEditMode.Tiles;

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
            OnEditModeChanged += editModeChanged;
            OnEditToolChanged += editToolChanged;

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
            if (layer == null || Map == null || Map.Layers.FindIndex(x => x.ID == layer.ID) == -1)
            {
                SelectedLayer = null;
                Map?.Layers.ForEach(x => x.Opacity = 1f);
                Invalidate();
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

        /// <summary>
        /// Sets the theme of this control from the current theme settings within DarkUI configuration.
        /// </summary>
        public override void SetThemeFromDarkUI()
        {
            base.SetThemeFromDarkUI();
            SelectionColour = ThemeProvider.Theme.Colors.LightText;
        }

        ///////////////////////
        /// PAINT OVERRIDES ///
        ///////////////////////

        /// <summary>
        /// Triggered when the control must be repainted.
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            //Paint base.
            base.OnPaint(e);

            //Draw point displaying the origin.
            PointF originPoint = ToPixelPointF(new Vector2f(0, 0));
            drawCross(e.Graphics, SelectionColour, originPoint, 1 * Zoom, 10 * Zoom);

            //Draw selection rectangle on selected square(s).
            if (SelectedTiles != null) 
            {
                //Calculate selection in grid space.
                Rectangle selected = (Rectangle)SelectedTiles;
                DrawSelectionBox(e, selected);
            }
        }

        /// <summary>
        /// Draws a cross centered at the given location, with a provided colour, length & width.
        /// </summary>
        private void drawCross(Graphics graphics, Color colour, PointF origin, float lineWidth, float lineLength)
        {
            Brush crossBrush = new SolidBrush(colour);
            graphics.FillRectangle(crossBrush, new RectangleF()
            {
                Location = new PointF(origin.X - lineWidth / 2f, origin.Y - lineLength / 2f),
                Size = new SizeF(lineWidth, lineLength)
            });
            graphics.FillRectangle(crossBrush, new RectangleF()
            {
                Location = new PointF(origin.X - lineLength / 2f, origin.Y - lineWidth / 2f),
                Size = new SizeF(lineLength, lineWidth)
            });
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

            //Single-key shortcuts (eg. no CTRL/SHIFT).
            if (e.Modifiers == Keys.None)
            {
                switch (e.KeyCode)
                {
                    //Tile Layer (1)
                    case Keys.D1:
                        EditMode = MapEditMode.Tiles;
                        break;

                    //Collision Layer (2)
                    case Keys.D2:
                        EditMode = MapEditMode.Collision;
                        break;

                    //Event Layer (3)
                    case Keys.D3:
                        EditMode = MapEditMode.Events;
                        break;

                    //Select Tool (V)
                    case Keys.V:
                        EditTool = MapEditTool.Select;
                        break;

                    //Area Select Tool (A)
                    case Keys.A:
                        EditTool = MapEditTool.AreaSelect;
                        break;

                    //Pencil Tool (P)
                    case Keys.P:
                        EditTool = MapEditTool.Pencil;
                        break;

                    //Grab and Pan (G)
                    case Keys.G:
                        EditTool = MapEditTool.GrabAndPan;
                        break;

                    //Delete selected tiles.
                    case Keys.Back:
                    case Keys.Delete:
                        DeleteSelectedTiles();
                        break;
                }
            }

            //CTRL+(key) shortcuts.
            else if (e.Modifiers.HasFlag(Keys.Control))
            {
                switch (e.KeyCode)
                {
                    //CTRL+(C)opy.
                    case Keys.C:
                        CopySelectedTiles();
                        break;

                    //CTRL+V (Paste)
                    case Keys.V:
                        PasteTiles();
                        break;
                }
            }
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
            Select();

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

                //Invoke the appropriate tool.
                switch (EditTool)
                {
                    case MapEditTool.Pencil:
                        DoPencilTool(e);
                        break;

                    case MapEditTool.Select:
                        DoSelectTool(e);
                        break;

                    case MapEditTool.AreaSelect:
                        DoAreaSelect(e);
                        break;
                }

                //Done!
                return;
            }

            //Not a left click, start the camera drag and clear selection.
            SelectedTiles = null;
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

            //Are we doing an area drag?
            if (state == MapEditorState.SelectingArea && SelectedTiles != null)
            {
                //Yes, determine the current selection rectangle.
                Rectangle curSelected = (Rectangle)SelectedTiles;
                Point curTile = ToTileLocation(e.Location);
                int rectWidth = curTile.X - curSelected.Location.X;
                int rectHeight = curTile.Y - curSelected.Location.Y;

                //Correct for under-1 values.
                rectWidth = Math.Max(rectWidth, 1);
                rectHeight = Math.Max(rectHeight, 1);

                //If the width/height are any different, set and invalidate.
                if (curSelected.Width != rectWidth || curSelected.Height != rectHeight)
                {
                    SelectedTiles = new Rectangle(curSelected.Location, new Size(rectWidth, rectHeight));
                    Invalidate();
                }
            }

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

        /// <summary>
        /// Triggered when the event mode for this map editor control changes.
        /// </summary>
        private void editModeChanged(MapEditMode newMode)
        {
            //Disable/enable drawing for each layer.
            switch (newMode)
            {
                case MapEditMode.Collision:
                    DoEventDraw = false;
                    DoCollisionDraw = true;
                    break;

                case MapEditMode.Events:
                    DoCollisionDraw = false;
                    DoEventDraw = true;
                    break;

                case MapEditMode.Tiles:
                    DoEventDraw = false;
                    DoCollisionDraw = false;
                    break;

                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Triggered when the edit tool is changed.
        /// </summary>
        private void editToolChanged(MapEditTool newTool)
        {
            switch (newTool)
            {
                case MapEditTool.GrabAndPan:
                    SelectedTiles = null;
                    Invalidate();
                    break;
            }
        }

        ////////////////////////////
        /// SHORTCUT KEY ACTIONS ///
        ////////////////////////////

        /// <summary>
        /// Deletes the currently selected tiles.
        /// </summary>
        private void DeleteSelectedTiles()
        {
            //Ignore if no selection.
            if (SelectedTiles == null)
                return;

            //Remove the selected tiles based on mode.
            var selected = (Rectangle)SelectedTiles;
            for (int y = selected.Y; y < selected.Y + selected.Height; y++)
            {
                for (int x = selected.X; x < selected.X + selected.Width; x++)
                {
                    var tile = new Microsoft.Xna.Framework.Point(x, y);
                    switch (EditMode)
                    {
                        case MapEditMode.Tiles:
                            if (SelectedLayer.Tiles.ContainsKey(tile))
                                SelectedLayer.Tiles.Remove(tile);
                            break;

                        case MapEditMode.Collision:
                            if (SelectedLayer.CollisionHull.ContainsKey(tile))
                                SelectedLayer.CollisionHull.Remove(tile);
                            break;

                        case MapEditMode.Events:
                            if (SelectedLayer.Events.ContainsKey(tile))
                                SelectedLayer.Events.Remove(tile);
                            break;

                        default:
                            throw new NotImplementedException();
                    }
                }
            }

            //Invalidate, we're done.
            Invalidate();
        }

        /// <summary>
        /// Pastes previously copied tiles at the selected location.
        /// </summary>
        private void PasteTiles()
        {
            //If there is no selection, ignore.
            if (SelectedTiles == null || copiedTiles == null || copiedTiles.Count == 0)
                return;

            //If the current mode differs from the originating mode, ignore.
            if (EditMode != copiedTilesMode)
            {
                DarkMessageBox.ShowError($"Cannot copy tiles from {Enum.GetName(typeof(MapEditMode), copiedTilesMode)} mode into {Enum.GetName(typeof(MapEditMode), EditMode)} mode.", "tileEngine - Paste Error");
                return;
            }

            //Paste in the data from the top left selected tile, continue repeating until done.
            var selected = (Rectangle)SelectedTiles;
            Point curPos = new Point(0, 0);
            for (int y = selected.Y; y < selected.Y + selected.Height; y++)
            {
                for (int x = selected.X; x < selected.X + selected.Width; x++)
                {
                    Microsoft.Xna.Framework.Point curTile = new Microsoft.Xna.Framework.Point(x, y);
                    var data = copiedTiles[curPos.Y][curPos.X];

                    //Remove the data at this tile.
                    switch (EditMode)
                    {
                        case MapEditMode.Events:
                            if (SelectedLayer.Events.ContainsKey(curTile))
                                SelectedLayer.Events.Remove(curTile);
                            break;
                        case MapEditMode.Tiles:
                            if (SelectedLayer.Tiles.ContainsKey(curTile))
                                SelectedLayer.Tiles.Remove(curTile);
                            break;
                        case MapEditMode.Collision:
                            if (SelectedLayer.CollisionHull.ContainsKey(curTile))
                                SelectedLayer.CollisionHull.Remove(curTile);
                            break;
                    }

                    //If data is non-null, copy new data into this tile.
                    if (data != null)
                    {
                        switch (EditMode)
                        {
                            case MapEditMode.Events:
                                SelectedLayer.Events.Add(curTile, ((TileEvent)data).Clone());
                                break;
                            case MapEditMode.Tiles:
                                SelectedLayer.Tiles.Add(curTile, (TileData)data);
                                break;
                            case MapEditMode.Collision:
                                SelectedLayer.CollisionHull.Add(curTile, (EntryDirection)data);
                                break;
                        }
                    }

                    //Increase current position, bound to valid copy region.
                    curPos.X++;
                    if (curPos.X >= copiedTiles[curPos.Y].Count)
                        curPos.X = 0;
                }

                //Step to next row, if over the limit loop back round.
                curPos.X = 0;
                curPos.Y++;
                if (curPos.Y >= copiedTiles.Count)
                    curPos.Y = 0;
            }

            OnSelectedLayerEdited?.Invoke();
            Invalidate();
        }

        /// <summary>
        /// Copies the currently selected tiles to clipboard.
        /// </summary>
        private void CopySelectedTiles()
        {
            //If there is no selection, ignore.
            if (SelectedTiles == null)
                return;

            //Set the copy source.
            copiedTilesMode = EditMode;

            //Create an array of tiles to copy from the rectangle.
            var selected = (Rectangle)SelectedTiles;
            copiedTiles = new List<List<object>>();
            for (int y=selected.Top; y<selected.Bottom; y++)
            {
                copiedTiles.Add(new List<object>());
                for (int x=selected.Left; x<selected.Right; x++)
                {
                    Point tile = new Point(x, y);

                    //Get the tile to add here. If no tile, make a null entry.
                    object toAdd = null;
                    if (EditMode == MapEditMode.Tiles && SelectedLayer.Tiles.ContainsKey(tile.ToXnaPoint()))
                    {
                        toAdd = SelectedLayer.Tiles[tile.ToXnaPoint()];
                    }
                    else if (EditMode == MapEditMode.Events && SelectedLayer.Events.ContainsKey(tile.ToXnaPoint()))
                    {
                        toAdd = SelectedLayer.Events[tile.ToXnaPoint()];
                    }
                    else if (EditMode == MapEditMode.Collision && SelectedLayer.CollisionHull.ContainsKey(tile.ToXnaPoint()))
                    {
                        toAdd = SelectedLayer.CollisionHull[tile.ToXnaPoint()];
                    }

                    copiedTiles.Last().Add(toAdd);
                }
            }
        }

        ////////////////////
        /// TOOL ACTIONS ///
        ////////////////////

        /// <summary>
        /// Performs a pencil tool action on the current tile.
        /// </summary>
        private bool DoPencilTool(MouseEventArgs e)
        {
            //Calculate basic stuff like tile location.
            Point mouseTile = ToTileLocation(e.Location);
            Microsoft.Xna.Framework.Point tileLocation = mouseTile.ToXnaPoint();

            //If there is currently an area selected, and the tile isn't within it, ignore.
            if (SelectedTiles != null)
            {
                if (!((Rectangle)SelectedTiles).Contains(new Point(tileLocation.X, tileLocation.Y)))
                    return false;
            }

            //Switch on the current edit mode, call the appropriate function.
            switch (EditMode)
            {
                case MapEditMode.Tiles:
                    return DoPencilTile(tileLocation);
                case MapEditMode.Events:
                    return DoPencilEvent(tileLocation);
                case MapEditMode.Collision:
                    return DoPencilCollision(tileLocation);
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Performs a pencil edit tool action in collision edit mode.
        /// </summary>
        private bool DoPencilCollision(Microsoft.Xna.Framework.Point tileLocation)
        {
            //Is there already a collision box at this location? If so, ignore.
            if (SelectedLayer.CollisionHull.ContainsKey(tileLocation))
                return false;

            //Add the collision to the layer (default to colliding on all sides).
            SelectedLayer.CollisionHull.Add(tileLocation, EntryDirection.None);
            OnSelectedLayerEdited?.Invoke();
            Invalidate();
            return true;
        }

        /// <summary>
        /// Performs a pencil edit tool action in event edit mode.
        /// </summary>
        private bool DoPencilEvent(Microsoft.Xna.Framework.Point tileLocation)
        {
            //Is there already an event at this location?
            if (SelectedLayer.Events.ContainsKey(tileLocation))
            {
                DarkMessageBox.ShowError("There is already an event at this location. Use the select tool to edit it, or delete it first.", "tileEngine - Event Already Placed");
                return false;
            }

            //Add an event to the given location.
            SelectedLayer.Events.Add(tileLocation, new TileEvent());

            //Done!
            OnSelectedLayerEdited?.Invoke();
            Invalidate();
            return true;
        }

        /// <summary>
        /// Performs a pencil edit tool action in tile edit mode.
        /// </summary>
        private bool DoPencilTile(Microsoft.Xna.Framework.Point tileLocation)
        {
            //If no palette configured, or no selected tile, ignore.
            if (Palette == null || Palette.SelectedTiles == null)
                return false;

            //Draw the tiles selected at the currently selected location.
            int rowIndex = 0;
            for (int y = tileLocation.Y; y < tileLocation.Y + Palette.SelectedTiles.Count; y++)
            {
                List<TileData> thisRow = Palette.SelectedTiles[rowIndex];
                int colIndex = 0;
                for (int x = tileLocation.X; x < tileLocation.X + thisRow.Count; x++)
                {
                    //Replace if key already there, otherwise add.
                    Microsoft.Xna.Framework.Point curPoint = new Microsoft.Xna.Framework.Point(x, y);
                    if (SelectedLayer.Tiles.ContainsKey(curPoint))
                        SelectedLayer.Tiles.Remove(curPoint);

                    SelectedLayer.Tiles.Add(curPoint, thisRow[colIndex]);
                    colIndex++;
                }

                //Bump to next selected tile row.
                rowIndex++;
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
            SelectedTiles = new Rectangle(ToTileLocation(e.Location), new Size(1, 1));
            Invalidate();
            return true;
        }

        /// <summary>
        /// Performs the start of an area select tool action on the current tile.
        /// </summary>
        private bool DoAreaSelect(MouseEventArgs e)
        {
            //Set the initial selection to just where the user's clicked.
            Point selectionTopLeft = ToTileLocation(e.Location);
            SelectedTiles = new Rectangle(selectionTopLeft, new Size(1, 1));

            //Start the area selection state.
            state = MapEditorState.SelectingArea;
            lastMouseLocation = e.Location;
            Invalidate();
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
