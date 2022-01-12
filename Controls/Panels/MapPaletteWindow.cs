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

            //Set the theme from current DarkUI theme.
            Palette.SetThemeFromDarkUI();
        }

        /// <summary>
        /// Triggered every time the project is compiled.
        /// </summary>
        private void projectCompiled(string assetPath)
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
