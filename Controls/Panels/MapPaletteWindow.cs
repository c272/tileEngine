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
        public MapPaletteWindow(ProjectTreeWindow projectTree)
        {
            InitializeComponent();
            projectTree.OnAssetImported += ReloadOptions;
            Palette.OnSizesUpdated += paletteSizesUpdated;
            spriteSelector.SelectedItemChanged += selectionChanged;

            //Set the theme from current DarkUI theme.
            Palette.SetThemeFromDarkUI();
        }

        /// <summary>
        /// Reloads the options available on the palette window.
        /// </summary>
        public void ReloadOptions()
        {
            //Temporarily de-hook selection event.
            spriteSelector.SelectedItemChanged -= selectionChanged;

            //Save the currently selected item's asset ID for re-selection later.
            int curSelectedID = -1;
            if (spriteSelector.SelectedItem != null)
            {
                curSelectedID = ((TaggedDropdownItem<ProjectSpriteNode>)spriteSelector.SelectedItem).Tag.ID;
            }

            //Reload the available options on the sprite picker.
            spriteSelector.Items.Clear();
            var sprites = ProjectManager.CurrentProject.ProjectRoot.GetNodesOfType<ProjectSpriteNode>();
            foreach (var sprite in sprites)
            {
                spriteSelector.Items.Add(new TaggedDropdownItem<ProjectSpriteNode>()
                {
                    Tag = sprite,
                    Text = sprite.Name,
                    Icon = Resources.Icons.Sprite
                });
            }

            //Attempt to re-select the previously selected item.
            var item = spriteSelector.Items.FirstOrDefault(x => ((TaggedDropdownItem<ProjectSpriteNode>)x).Tag.ID == curSelectedID);
            if (item != null && curSelectedID != -1)
            {
                spriteSelector.SelectedItem = item;
            }
            else { selectionChanged(null, null); }

            //Re-hook event.
            spriteSelector.SelectedItemChanged += selectionChanged;
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
        /// Triggered every time a new asset is imported.
        /// </summary>
        private void assetImported()
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
