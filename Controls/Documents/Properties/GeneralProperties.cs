using DarkUI.Config;
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

namespace tileEngine.Controls
{
    /// <summary>
    /// Represents the editable general properties for the current project.
    /// </summary>
    public partial class GeneralProperties : PropertiesTab
    {
        public GeneralProperties(PropertiesDocument document) : base(document)
        {
            InitializeComponent();

            //Set name and title from project.
            projectNameTxt.Text = ProjectManager.CurrentProject.Name;
            projectTitleTxt.Text = ProjectManager.CurrentProject.Title;

            //Hook events.
            projectNameTxt.TextChanged += projectNameChanged;
            projectTitleTxt.TextChanged += projectTitleChanged;
        }

        /// <summary>
        /// Flushes the updates to this window to the project.
        /// </summary>
        public override void FlushUpdates()
        {
            //Name
            if (Regex.IsMatch(projectNameTxt.Text, Project.VALID_NAME_REGEX))
                ProjectManager.CurrentProject.Name = projectNameTxt.Text;

            //Title
            if (projectTitleTxt.Text != "" && projectTitleTxt.Text != null)
                ProjectManager.CurrentProject.Title = projectTitleTxt.Text;
        }

        /// <summary>
        /// Triggered when the project name is changed in the text field.
        /// </summary>
        private void projectNameChanged(object sender, EventArgs e)
        {
            //Is it a valid name?
            if (!Regex.IsMatch(projectNameTxt.Text, Project.VALID_NAME_REGEX))
            {
                //Highlight red, exit.
                projectNameTxt.ForeColor = Color.Red;
                return;
            }

            //Valid name, set unsaved changes.
            projectNameTxt.ForeColor = ThemeProvider.Theme.Colors.LightText;
            Document.Node.UnsavedChanges = true;
        }

        /// <summary>
        /// Triggered when the project title is changed in the text field.
        /// </summary>
        private void projectTitleChanged(object sender, EventArgs e)
        {
            if (projectTitleTxt.Text == "" && projectTitleTxt.Text == null)
            {
                //Invalid name.
                projectTitleTxt.ForeColor = Color.Red;
                return;
            }

            //Valid name, set unsaved.
            projectTitleTxt.ForeColor = ThemeProvider.Theme.Colors.LightText;
            Document.Node.UnsavedChanges = true;
        }
    }
}
