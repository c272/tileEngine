using DarkUI.Config;
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
    /// Represents the base properties control that all other properties controls inherit from.
    /// </summary>
    public partial class PropertiesControl : UserControl
    {
        public PropertiesControl()
        {
            InitializeComponent();

            //Style in accordance with editor theme.
            this.BackColor = ThemeProvider.Theme.Colors.DarkBackground;
        }
    }
}
