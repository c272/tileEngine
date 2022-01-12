using DarkUI.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public ScenePropertiesControl(ProjectSceneNode scene)
        {
            InitializeComponent();
            Scene = scene;

            //Set initial values from scene.
            tileSizeX.Value = scene.TileMap.TileTextureSize;
            tileSizeY.Value = scene.TileMap.TileTextureSize;

            //Hook event handlers.
            tileSizeX.ValueChanged += tileSizeValueChanged;
            tileSizeY.ValueChanged += tileSizeValueChanged;
        }

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
    }
}
