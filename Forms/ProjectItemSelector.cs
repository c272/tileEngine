using DarkUI.Config;
using tileEngine.Controls;
using tileEngine.SDK.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tileEngine.Forms
{
    /// <summary>
    /// Opens a selector which allows the user to select a new project item.
    /// </summary>
    public partial class ProjectItemSelector : ItemSelector
    {
        /// <summary>
        /// The item that has been selected by the user to add.
        /// </summary>
        public ProjectTreeNode SelectedItem = null;

        /// <summary>
        /// The list of types available to pick from.
        /// </summary>
        private static List<Type> types = null;

        /// <summary>
        /// The project window that is used for node name dupe checks.
        /// </summary>
        private ProjectTreeWindow projectWindow;

        public ProjectItemSelector(ProjectTreeWindow projWin, string title)
        {
            InitializeComponent();
            projectWindow = projWin;
            this.Text = title;

            //Append the name of the project to the title, if one's loaded.
            if (ProjectManager.CurrentProject != null)
                this.Text += " - " + ProjectManager.CurrentProject.Name;

            //By reflection, receive all types to pick from (if there are any).
            if (types == null)
                types = GetValidInheritingTypes(typeof(ProjectTreeNode));

            //Add all the types to the selector.
            foreach (var type in types)
                AddItem(type);
        }

        /// <summary>
        /// Creates the item from the currently selected item.
        /// </summary>
        public override void CreateItem()
        {
            //Get the type out.
            var type = GetSelectedType();
            SelectedItem = (ProjectTreeNode)Activator.CreateInstance(type);
            SelectedItem.Name = nameTxt.Text;
        }

        /// <summary>
        /// Whether the current state of the selector is a valid selection to create an item.
        /// </summary>
        public override bool IsValidSelection()
        {
            //Assume the name is invalid for now.
            nameTxt.ForeColor = Color.Red;

            //Check if the name is empty, or formatted stupidly.
            if (string.IsNullOrWhiteSpace(nameTxt.Text))
                return false;
            if (!Regex.IsMatch(nameTxt.Text, ProjectTreeNode.VALID_NAME_REGEX))
                return false;

            //Check if there is not already a project item with this name.
            if (projectWindow.CurrentSelectedParent.Nodes.FindIndex(x => ((ProjectTreeNode)x).Name == nameTxt.Text) != -1)
                return false;

            //We're fine! Name is valid.
            nameTxt.ForeColor = ThemeProvider.Theme.Colors.LightText;
            return true;
        }
    }
}
