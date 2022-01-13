using DarkUI.Docking;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tileEngine.Utility;

namespace tileEngine.Controls
{
    /// <summary>
    /// Represents the palette selector window in the main editor for tileEngine.
    /// </summary>
    public partial class MapPaletteWindow : DarkToolWindow
    {
        public MapPaletteWindow()
        {
            InitializeComponent();
            ProjectCompiler.OnCompile += projectCompiled;
            Palette.OnSizesUpdated += paletteSizesUpdated;

            //Set the theme from current DarkUI theme.
            Palette.SetThemeFromDarkUI();
        }

        /// <summary>
        /// Reloads the options available on the palette window.
        /// </summary>
        public void ReloadOptions()
        {
            //Reload the available options on the sprite picker.
            spriteSelector.Items.Clear();
            var sprites = ProjectManager.CurrentProject.ProjectRoot.GetNodesOfType<ProjectSpriteNode>();
            foreach (var sprite in sprites)
            {
                spriteSelector.Items.Add(new TaggedDropdownItem<ProjectSpriteNode>()
                {
                    Tag = sprite,
                    Text = sprite.Name
                });
            }
        }

        /// <summary>
        /// Triggered when either of the scroll bars have their scroll values changed.
        /// </summary>
        private void scrollValueChanged(object sender, DarkUI.Controls.ScrollValueEventArgs e)
        {
            Palette.ViewScroll = new Vector2f(horizontalScroll.Value, verticalScroll.Value);
        }

        /// <summary>
        /// Triggered when the palette control updates sizes for view/total area.
        /// </summary>
        private void paletteSizesUpdated()
        {
            //Update scroll bar maximums & view sizes.
            verticalScroll.Maximum = (int)Palette.TotalSize.Y;
            horizontalScroll.Maximum = (int)Palette.TotalSize.X;

            //Make sure view size isn't larger than the maximum, otherwise the control breaks.
            verticalScroll.ViewSize = verticalScroll.Maximum < Palette.ViewSize.Y ? verticalScroll.Maximum : (int)Palette.ViewSize.Y;
            horizontalScroll.ViewSize = horizontalScroll.Maximum < Palette.ViewSize.X ? horizontalScroll.Maximum : (int)Palette.ViewSize.X;
        }

        /// <summary>
        /// Triggered every time the project is compiled.
        /// </summary>
        private void projectCompiled(string assetPath)
        {
            ReloadOptions();
        }

        /// <summary>
        /// Triggered when the selected sprite is changed.
        /// </summary>
        private void selectionChanged(object sender, EventArgs e)
        {
            //Ignore if selection is none.
            if (spriteSelector.SelectedItem == null)
                return;

            //Alter the palette.
            Palette.SetTilesheet(((TaggedDropdownItem<ProjectSpriteNode>)spriteSelector.SelectedItem).Tag);
        }
    }
}
