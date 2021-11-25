using DarkUI.Config;
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

namespace tileEngine.Controls
{
    /// <summary>
    /// Represents a single properties tab that is editable in the "properties" document.
    /// </summary>
    public partial class PropertiesTab : UserControl
    {
        /// <summary>
        /// The document we're placed on.
        /// </summary>
        protected PropertiesDocument Document;

        public PropertiesTab(PropertiesDocument document)
        {
            InitializePropertiesTab(document);
        }

        //Private constructor for design-time.
        private PropertiesTab() { InitializePropertiesTab(Document); }

        /// <summary>
        /// Called when the properties tab should flush its updates to the main project.
        /// </summary>
        public virtual void FlushUpdates() { }

        /// <summary>
        /// Initializes this properties tab with the given document.
        /// </summary>
        private void InitializePropertiesTab(PropertiesDocument doc = null)
        {
            InitializeComponent();
            BackColor = ThemeProvider.Theme.Colors.GreyBackground;
            Document = doc;

            //Set self to fix group boxes on load.
            this.Load += styleGroupBoxes;
        }

        /// <summary>
        /// Styles group boxes to not be the ugly default colour, and instead match the theme.
        /// </summary>
        private void styleGroupBoxes(object sender, EventArgs e)
        {
            foreach (var control in ((Control)sender).Controls)
            {
                //Set the colour if this is a group box.
                if (control is DarkGroupBox)
                {
                    ((DarkGroupBox)control).BorderColor = ThemeProvider.Theme.Colors.LightBorder;
                }

                //Recursively style child controls.
                styleGroupBoxes(control, e);
            }
        }
    }
}
