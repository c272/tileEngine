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
        /// <summary>
        /// The name of this properties control as it appears in the properties window bar.
        /// </summary>
        public string DisplayName { get; private set; }

        public PropertiesControl(string name)
        {
            InitializeComponent();
            DisplayName = name;

            //Style in accordance with editor theme.
            this.BackColor = ThemeProvider.Theme.Colors.GreyBackground;
        }

        //Designer constructor.
        private PropertiesControl() { InitializeComponent(); }
    }
}
