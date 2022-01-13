using DarkUI.Config;
using DarkUI.Controls;
using DarkUI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using tileEngine.SDK.Map;

namespace tileEngine.Controls.Properties
{
    /// <summary>
    /// Properties control to edit the properties of a given scene node.
    /// </summary>
    public partial class ScenePropertiesControl : PropertiesControl
    {
        /// <summary>
        /// The scene this properties control is modifying.
        /// </summary>
        public ProjectSceneNode Scene { get; private set; }

        /// <summary>
        /// The map editor control this properties control is modifying.
        /// </summary>
        public MapEditorControl MapEditor { get; private set; }

        /// <summary>
        /// The currently selected layer in the properties control menu, if any.
        /// Null when none selected.
        /// </summary>
        public TileLayer SelectedLayer
        {
            get { return _selectedLayer; }
            set
            {
                _selectedLayer = value;
                OnSelectedLayerChanged?.Invoke(_selectedLayer);
            }
        }
        private TileLayer _selectedLayer = null;

        //Event for when the selected layer is changed.
        public delegate void OnSelectedLayerChangedHandler(TileLayer newLayer);
        public event OnSelectedLayerChangedHandler OnSelectedLayerChanged;

        //The item currently being renamed, if any.
        private DarkListItem renameItem = null;

        public ScenePropertiesControl(MapEditorDocument doc, ProjectSceneNode scene)
        {
            InitializeComponent();
            Scene = scene;
            MapEditor = doc.MapEditor;

            //Set initial values from scene.
            tileSizeX.Value = scene.TileMap.TileTextureSize;
            tileSizeY.Value = scene.TileMap.TileTextureSize;
            showGridCb.Checked = MapEditor.DoGridDraw;

            //Hook event handlers.
            showGridCb.CheckedChanged += showGridChanged;
            tileSizeX.ValueChanged += tileSizeValueChanged;
            tileSizeY.ValueChanged += tileSizeValueChanged;

            //Set up the layers from the current map.
            refreshLayers();
        }

        /// <summary>
        /// Refreshes the layers from the backend representation.
        /// </summary>
        private void refreshLayers()
        {
            layerListView.Items.Clear();
            foreach (var layer in Scene.TileMap.Layers)
            {
                layerListView.Items.Insert(0, new DarkListItem()
                {
                    Icon = Resources.Icons.Layer,
                    Text = layer.Name,
                    Tag = layer
                });
            }
        }

        //////////////////////
        /// EVENT HANDLERS ///
        //////////////////////

        /// <summary>
        /// Triggered when either of the tile size values are changed.
        /// </summary>
        private void tileSizeValueChanged(object sender, EventArgs e)
        {
            //Update the other one if necessary.
            int value = (int)((DarkNumericUpDown)sender).Value;
            if (tileSizeX.Value != value)
                tileSizeX.Value = value;
            if (tileSizeY.Value != value)
                tileSizeY.Value = value;

            //Push to tile map, alter palette.
            Scene.TileMap.TileTextureSize = value;
            Editor.Instance.PaletteWindow.Palette.TileTextureSize = value;
        }

        /// <summary>
        /// Triggered when the user clicks "add layer".
        /// </summary>
        private void addLayerButton_Click(object sender, EventArgs e)
        {
            //Insert a new layer in the map, refresh.
            var layer = new TileLayer();
            Scene.TileMap.Layers.Add(layer);
            layerListView.Items.Insert(0, new DarkListItem()
            {
                Icon = Resources.Icons.Layer,
                Text = layer.Name,
                Tag = layer
            });
        }

        /// <summary>
        /// Triggered when the user clicks the "rename layer" button.
        /// </summary>
        private void renameLayerButton_Click(object sender, EventArgs e)
        {
            //If there are no layers selected, ignore.
            if (layerListView.SelectedIndices.Count == 0)
                return;

            //Get the selected layer item location, and spawn a text box there, hook up events.
            renameItem = layerListView.Items[layerListView.SelectedIndices[0]];
            renameItem.Text = "";
            DarkTextBox renameBox = new DarkTextBox()
            {
                Location = new Point(layerListView.Location.X + renameItem.TextArea.Location.X,
                                     layerListView.Location.Y + renameItem.TextArea.Location.Y - layerListView.Viewport.Top),
                Visible = true
            };
            renameBox.TextChanged += renameTextChanged;
            renameBox.KeyDown += renameKeyDown;
            renameBox.LostFocus += endRename;

            //Set up text, select everything and add the control.
            renameBox.Text = ((TileLayer)renameItem.Tag).Name;
            renameBox.SelectionStart = 0;
            renameBox.SelectionLength = ((TileLayer)renameItem.Tag).Name.Length;
            Controls.Add(renameBox);

            //Focus the text box.
            renameBox.BringToFront();
            renameBox.Focus();
        }

        /// <summary>
        /// Triggered when a key is pushed while a rename is occuring.
        /// </summary>
        private void renameKeyDown(object sender, KeyEventArgs e)
        {
            //If enter was pressed, finish the rename & handle.
            if (e.KeyCode == Keys.Enter)
            {
                endRename(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        /// <summary>
        /// Triggered when the text is changed during a rename.
        /// </summary>
        private void renameTextChanged(object sender, EventArgs e)
        {
            //Expand/contract the textbox to fit the text.
            DarkTextBox renameBox = (DarkTextBox)sender;
            Size textSize = TextRenderer.MeasureText(renameBox.Text, renameBox.Font);
            renameBox.Size = new Size(textSize.Width + 5, textSize.Height);
        }

        /// <summary>
        /// Ends an ongoing rename of the current layer.
        /// </summary>
        private void endRename(object sender, EventArgs e)
        {
            //Verify the name is valid.
            var textBox = (DarkTextBox)sender;
            if (Regex.IsMatch(textBox.Text, "^[A-Za-z0-9\\(\\) _-]+$"))
            {
                //Get the text, set new layer name & display on list.
                ((TileLayer)renameItem.Tag).Name = textBox.Text;
            }
            renameItem.Text = ((TileLayer)renameItem.Tag).Name;

            //Remove control.
            textBox.LostFocus -= endRename;
            Controls.Remove(textBox);
            textBox.Dispose();
        }

        /// <summary>
        /// Triggered when the user wants to remove an existing layer.
        /// </summary>
        private void removeLayerButton_Click(object sender, EventArgs e)
        {
            //No selected layer? Ignore.
            if (layerListView.SelectedIndices.Count == 0)
                return;
            var layer = (TileLayer)(layerListView.Items[layerListView.SelectedIndices[0]].Tag);

            //Ensure the user *really* wants to delete a layer.
            if (DarkMessageBox.ShowWarning("Are you sure you want to delete this layer?", "tileEngine - Map Layer Delete", DarkDialogButton.YesNo) != DialogResult.Yes)
                return;

            //Delete the item at that index in the underlying map.
            Scene.TileMap.Layers.RemoveAll(x => x.ID == layer.ID);

            //Remove from the list view.
            layerListView.Items.RemoveAt(layerListView.SelectedIndices[0]);
        }

        /// <summary>
        /// Triggered when the user selects a new layer on the properties window.
        /// </summary>
        private void selectedLayerChanged(object sender, EventArgs e)
        {
            //Update the selected layer.
            if (layerListView.SelectedIndices.Count == 0)
            {
                SelectedLayer = null;
                return;
            }
            SelectedLayer = (TileLayer)layerListView.Items[layerListView.SelectedIndices[0]].Tag;
        }

        /// <summary>
        /// Triggered when the "Show Grid" checkbox is altered.
        /// </summary>
        private void showGridChanged(object sender, EventArgs e)
        {
            MapEditor.DoGridDraw = showGridCb.Checked;
        }
    }
}
