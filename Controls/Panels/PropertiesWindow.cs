using DarkUI.Config;
using DarkUI.Docking;
using tileEngine.SDK.Diagnostics;
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

namespace tileEngine.Controls
{
    /// <summary>
    /// Represents a window where properties for selected elements can be edited.
    /// </summary>
    public partial class PropertiesWindow : DarkToolWindow
    {
        public PropertiesWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the control currently on the properties window to the provided control.
        /// Clears any existing controls on the properties window.
        /// </summary>
        public void SetPropertiesControl(PropertiesControl c, string title)
        {
            Controls.Clear();
            Controls.Add(c);
            c.Location = new Point(0, 0);
            c.Dock = DockStyle.Fill;
            DockText = title;
        }

        /// <summary>
        /// Removes all existing properties controls from the properties window.
        /// </summary>
        public void ClearPropertiesControl()
        {
            Controls.Clear();
            DockText = "Properties";
        }
    }
}
