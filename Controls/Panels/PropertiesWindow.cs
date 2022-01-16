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
        /// <summary>
        /// The current properties control displayed on the window.
        /// </summary>
        public PropertiesControl Current { get; private set; } = null;

        public PropertiesWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the control currently on the properties window to the provided control.
        /// Clears any existing controls on the properties window.
        /// </summary>
        public void SetPropertiesControl(PropertiesControl c, string title = null)
        {
            //If this control is already active, ignore.
            if (Current == c)
                return;

            //Clear controls, and re-add.
            Controls.Clear();
            Controls.Add(c);
            c.Location = new Point(0, 0);
            c.Dock = DockStyle.Fill;

            //Apply the title if custom one used, otherwise take from control.
            if (title != null)
            {
                DockText = title;
            }
            else
            {
                DockText = c.DisplayName;
            }

            //Focus self in dock group.
            Current = c;
            this.DockGroup.SetVisibleContent(this);
        }

        /// <summary>
        /// Removes all existing properties controls from the properties window.
        /// </summary>
        public void ClearPropertiesControl()
        {
            Controls.Clear();
            Current = null;
            DockText = "Properties";
        }
    }
}
