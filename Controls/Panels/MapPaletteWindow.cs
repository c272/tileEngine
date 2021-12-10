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

            //Set the theme from current DarkUI theme.
            palette.SetThemeFromDarkUI();
        }
    }
}
