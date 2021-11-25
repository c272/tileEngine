using DarkUI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tileEngine.Controls
{
    /// <summary>
    /// Represents the "Create Project" portion of the landing page.
    /// </summary>
    public partial class CreateProjectControl : UserControl
    {
        public CreateProjectControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Triggered when the "Create" button is clicked on the create project window.
        /// </summary>
        private void createBtn_Click(object sender, EventArgs e)
        {
            //todo: error popover control
            //for error messages on failing validation

            //Is the project name valid? (A-Za-z0-9-_ with spaces).
            if (!Regex.IsMatch(projectNameText.Text, Project.VALID_NAME_REGEX))
            {
                //Highlight the text box red and give an error popup.
                projectNameText.Valid = false;
                return;
            }

            //Check the directory exists.
            var dirInfo = new DirectoryInfo(Path.GetDirectoryName(fileLocationText.Text));
            if (!dirInfo.Exists)
            {
                fileLocationText.Valid = false;
                return;
            }

            //Check the directory is empty.
            if (dirInfo.EnumerateFiles().Count() > 0)
            {
                fileLocationText.Valid = false;
                return;
            }

            //Check the file ending is correct.
            if (!fileLocationText.Text.EndsWith(".teproj"))
            {
                fileLocationText.Valid = false;
                return;
            }

            //Check a file with that name doesn't already exist.
            if (File.Exists(fileLocationText.Text))
            {
                fileLocationText.Valid = false;
                return;
            }

            //Create the new project file, load editor.
            var editor = new Editor();
            if (!ProjectManager.CreateNew(projectNameText.Text, fileLocationText.Text))
            {
                //Error of some kind.
                DarkMessageBox.ShowError("Failed to save new project to file. Check you have adequate permissions to save in that location.", "tileEngine - Project Save Error");
                return;
            }

            //Open the editor, close this window.
            editor.Show();
            ParentForm.Close();
        }

        /// <summary>
        /// Opens the choose file dialog on clicking the "...".
        /// </summary>
        private void chooseFileLocationBtn_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog()
            {
                AddExtension = true,
                DefaultExt = ".teproj",
                Title = "Create a new tileEngine project (*.teproj).",
                Filter = "tileEngine Project (.teproj)|*.teproj"
            };

            //Show the dialog.
            if (dialog.ShowDialog() != DialogResult.OK)
                return;
            fileLocationText.Text = dialog.FileName;
        }

        /// <summary>
        /// Triggered when the "back" button is clicked.
        /// </summary>
        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Parent = null;
            this.Dispose();
        }
    }
}
