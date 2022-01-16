using DarkUI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tileEngine.Controls.Properties;
using tileEngine.SDK.Attributes;
using tileEngine.SDK.Map;
using tileEngine.Utility;

namespace tileEngine.Controls
{
    /// <summary>
    /// Represents the map editor document for a single scene in tileEngine.
    /// </summary>
    public partial class MapEditorDocument : ProjectDocument
    {
        /// <summary>
        /// A list of event function names that are available for this scene.
        /// </summary>
        public List<string> EventFunctions { get; private set; } = new List<string>();

        //The properties control for this map editor.
        ScenePropertiesControl propsControl = null;

        public MapEditorDocument(ProjectSceneNode scene) : base(scene)
        {
            InitializeComponent();
            propsControl = new ScenePropertiesControl(this, scene);

            //Hook events from properties control.
            propsControl.OnSelectedLayerChanged += selectedLayerChanged;

            //Configure map editor.
            MapEditor.Map = scene.TileMap;
            MapEditor.Palette = Editor.Instance.PaletteWindow.Palette;
            MapEditor.SetThemeFromDarkUI();

            //Hook editor events.
            MapEditor.OnSelectedLayerEdited += mapLayerEdited;
            MapEditor.OnEditModeChanged += mapEditModeChanged;
            MapEditor.OnEditToolChanged += mapEditToolChanged;
            MapEditor.OnSelectedTilesChanged += mapSelectedTilesChanged;

            //Grab current event functions associated with this map, set up reloads.
            reloadEventFunctions();
            ProjectManager.OnProjectAssemblyReload += reloadEventFunctions;
        }

        /// <summary>
        /// Reloads all event functions that are used for this map from the current project assembly.
        /// </summary>
        private void reloadEventFunctions()
        {
            //Get the class associated with the current map.
            string sceneTypeName = ((ProjectSceneNode)Node).LinkedTypeName;
            var sceneClass = ProjectManager.CurrentProjectAssembly.GetTypes().Where(t => t.FullName == sceneTypeName).FirstOrDefault();
            if (sceneClass == null)
            {
                DarkMessageBox.ShowError($"Failed to load event methods for scene '{sceneTypeName}', no class found.", "tileEngine - Event Load Failure");
                return;
            }

            //Grab all functions that have the "EventFunction" attribute, add their names to a list.
            var eventMethods = sceneClass.GetMethods()
                                         .SelectMany(m => m.GetCustomAttributes(typeof(EventFunctionAttribute), false))
                                         .Select(x => (EventFunctionAttribute)x).ToList();
            EventFunctions.Clear();
            foreach (var eventFuncAttrib in eventMethods)
            {
                EventFunctions.Add(eventFuncAttrib.Name);
            }
        }

        /// <summary>
        /// Triggered when this document is focused for any reason.
        /// </summary>
        public override void OnDocumentFocused()
        {
            //Open the properties window, set palette size & reload options..
            Editor.Instance.PropertiesWindow.SetPropertiesControl(propsControl);
            Editor.Instance.PaletteWindow.ReloadOptions();
            Editor.Instance.PaletteWindow.Palette.TileTextureSize = ((ProjectSceneNode)Node).TileMap.TileTextureSize;
        }

        /// <summary>
        /// Triggered when this document is unfocused.
        /// </summary>
        public override void OnDocumentUnfocused()
        {
            //Close the properties tab for this document.
            Editor.Instance.PropertiesWindow.ClearPropertiesControl();
        }

        /// <summary>
        /// Triggered when the user changes selected tiles on the map editor.
        /// </summary>
        private void mapSelectedTilesChanged(Rectangle? newTiles)
        {
            //Ignore if edit mode is not event mode.
            var propsWindow = Editor.Instance.PropertiesWindow;
            if (MapEditor.EditMode != MapEditMode.Events)
            {
                propsWindow.SetPropertiesControl(propsControl);
                return;
            }

            //Ignore if null tiles or more than one tile.
            if (newTiles == null || ((Rectangle)newTiles).Width > 1 || ((Rectangle)newTiles).Height > 1)
            {
                propsWindow.SetPropertiesControl(propsControl);
                return;
            }

            //Get the selected tile out, see if there's a valid event there.
            Point tilePoint = ((Rectangle)newTiles).Location;
            if (!MapEditor.SelectedLayer.Events.ContainsKey(tilePoint.ToXnaPoint()))
            {
                propsWindow.SetPropertiesControl(propsControl);
                return;
            }

            //There is! Create the events property window.
            var eventProps = new EventPropertiesControl(this, tilePoint, MapEditor.SelectedLayer.Events[tilePoint.ToXnaPoint()]);
            Editor.Instance.PropertiesWindow.SetPropertiesControl(eventProps);
        }

        /// <summary>
        /// Triggered when the user changes the selected layer in the properties window.
        /// </summary>
        private void selectedLayerChanged(TileLayer newLayer)
        {
            //Pass down to the tile map.
            MapEditor.SetSelectedLayer(newLayer);
        }

        /// <summary>
        /// Triggered when the user edits the selected layer on the map.
        /// </summary>
        private void mapLayerEdited()
        {
            Node.UnsavedChanges = true;
        }

        /// <summary>
        /// Triggered when the map's edit mode is altered.
        /// </summary>
        private void mapEditModeChanged(MapEditMode newMode)
        {
            //Check the correct button on the GUI.
            tileEditModeBtn.Checked = newMode == MapEditMode.Tiles;
            collisionEditModeBtn.Checked = newMode == MapEditMode.Collision;
            eventEditModeBtn.Checked = newMode == MapEditMode.Events;
        }

        /// <summary>
        /// Triggered when the map's edit tool is changed.
        /// </summary>
        private void mapEditToolChanged(MapEditTool newTool)
        {
            //Check the correct button on the GUI.
            selectToolButton.Checked = newTool == MapEditTool.Select;
            panToolButton.Checked = newTool == MapEditTool.GrabAndPan;
            areaSelectToolButton.Checked = newTool == MapEditTool.AreaSelect;
            pencilToolButton.Checked = newTool == MapEditTool.Pencil;
        }

        //Edit tool buttons, configures the edit tool on the map editor.
        private void selectToolButton_Click(object sender, EventArgs e) { MapEditor.EditTool = MapEditTool.Select; }
        private void panToolButton_Click(object sender, EventArgs e) { MapEditor.EditTool = MapEditTool.GrabAndPan; }
        private void areaSelectToolButton_Click(object sender, EventArgs e) { MapEditor.EditTool = MapEditTool.AreaSelect; }
        private void pencilToolButton_Click(object sender, EventArgs e) { MapEditor.EditTool = MapEditTool.Pencil; }

        //Edit mode buttons, configures which edit mode the editor is placed in.
        private void tileEditModeBtn_Click(object sender, EventArgs e) { MapEditor.EditMode = MapEditMode.Tiles; }
        private void collisionEditModeBtn_Click(object sender, EventArgs e) { MapEditor.EditMode = MapEditMode.Collision; }
        private void eventEditModeBtn_Click(object sender, EventArgs e) { MapEditor.EditMode = MapEditMode.Events; }
    }
}
