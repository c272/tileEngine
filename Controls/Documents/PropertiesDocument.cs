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
    /// Represents the project properties editor document.
    /// </summary>
    public partial class PropertiesDocument : ProjectDocument
    {
        //The currently open properties tab.
        private List<PropertiesTab> tabs = new List<PropertiesTab>();
        private PropertiesTab curOpenTab = null;

        public PropertiesDocument(ProjectRootNode node) : base(node)
        {
            InitializeComponent();

            //Set background colours.
            navigationPanel.BackColor = ThemeProvider.Theme.Colors.DarkBackground;

            //Open default tab.
            generalLabel_Click(generalLabel, null);
        }

        /// <summary>
        /// Flushes the updates currently present on the properties document to the project.
        /// </summary>
        public void FlushUpdates()
        {
            //Flush all tab updates.
            foreach (var tab in tabs)
            {
                tab.FlushUpdates();
            }
        }

        /// <summary>
        /// Triggered when the "general" label is clicked.
        /// </summary>
        private void generalLabel_Click(object sender, EventArgs e)
        {
            //Deselect all other labels, highlight this one.
            highlightLabel((DarkLabel)sender);

            //Open the general tab.
            var tabToOpen = tabs.FirstOrDefault(x => x is GeneralProperties);
            openTab(tabToOpen == null ? new GeneralProperties(this) : tabToOpen);
        }

        /// <summary>
        /// Triggered when the user clicks on the "Game" settings label.
        /// </summary>
        private void gameSettings_Click(object sender, EventArgs e)
        {
            //Deselect all other labels, highlight this one.
            highlightLabel((DarkLabel)sender);

            //Open the game tab.
            var tabToOpen = tabs.FirstOrDefault(x => x is GameProperties);
            openTab(tabToOpen == null ? new GameProperties(this) : tabToOpen);
        }

        /// <summary>
        /// Opens the provided properties tab on the properties editor window.
        /// </summary>
        private void openTab(PropertiesTab tab)
        {
            //Get rid of the currently open tab, if there is one.
            if (curOpenTab != null)
                editPanel.Controls.Remove(curOpenTab);

            //Add to the tabs list if there isn't a tab of the same type there already.
            if (tabs.FirstOrDefault(x => x.GetType().Equals(tab.GetType())) == null)
                tabs.Add(tab);

            //Open the new tab.
            curOpenTab = tab;
            editPanel.Controls.Add(tab);
            tab.Dock = DockStyle.Fill;
            tab.Visible = true;
        }

        /// <summary>
        /// Highlights the given label, and turns all other labels to have a transparent background.
        /// </summary>
        private void highlightLabel(DarkLabel sender)
        {
            sender.BackColor = ThemeProvider.Theme.Colors.BlueBackground;
            foreach (Control control in navigationPanel.Controls)
            {
                //Ignore the sender, we've already highlighted that.
                if (control.Equals(sender)) { continue; }
                control.BackColor = Color.Transparent;
            }
        }
    }
}
