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
using tileEngine.SDK.Map;

namespace tileEngine.Controls
{
    /// <summary>
    /// Represents the map editor document for a single scene in tileEngine.
    /// </summary>
    public partial class MapEditorDocument : ProjectDocument
    {
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
            MapEditor.OnSelectedLayerEdited += mapLayerEdited;
        }

        /// <summary>
        /// Triggered when this document is focused for any reason.
        /// </summary>
        public override void OnDocumentFocused()
        {
            //Open the properties window, set palette size & reload options..
            Editor.Instance.PropertiesWindow.SetPropertiesControl(propsControl, Node.Name + " Properties");
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
    }
}
