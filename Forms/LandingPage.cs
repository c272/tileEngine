using DarkUI.Config;
using DarkUI.Forms;
using tileEngine.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tileEngine
{
    /// <summary>
    /// Represents a landing page from which the user can launch or create a project.
    /// </summary>
    public partial class LandingPage : DarkForm
    {
        public LandingPage()
        {
            InitializeComponent();

            //Remove titlebar.
            this.ControlBox = false;
            this.Text = String.Empty;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //Hook up button click events.
            openProjectBtn.OnButtonClicked += openProject;
            createProjectBtn.OnButtonClicked += createProject;
            cloneRepoBtn.OnButtonClicked += cloneRepo;
        }

        /// <summary>
        /// Triggered when the user wants to create a new project.
        /// </summary>
        private void createProject()
        {
            //Open the "create project" window.
            var createWindow = new CreateProjectControl();
            createWindow.Parent = this;
            createWindow.Visible = true;
            createWindow.Location = welcomeLabel.Location;
            createWindow.BringToFront();
        }
            
        /// <summary>
        /// Created when the user wants to clone a repo for a project.
        /// </summary>
        private void cloneRepo()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Triggered when the user wants to open an existing project.
        /// </summary>
        private void openProject()
        {
            //Get the dialog result.
            string fileName = ProjectManager.ShowOpenProjectDialog();
            if (fileName == null)
                return;

            //Attempt a load.
            var editor = new Editor();
            Exception error = ProjectManager.LoadProject(fileName);
            if (error != null)
            {
                DarkMessageBox.ShowError("Failed to load project from file: " + error.Message, "tileEngine - Project Load Error");
                return;
            }

            //Load the editor.
            editor.Show();
            this.Close();
        }

        /// <summary>
        /// Handle moving the form around by the top bar.
        /// </summary>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            //Start a drag if we're clicking w/ left mouse.
            if (e.Button == MouseButtons.Left)
            {
                this.Capture = false;
                Message msg = Message.Create(this.Handle, 0XA1, new IntPtr(2), IntPtr.Zero);
                this.WndProc(ref msg);
            }
        }

        /// <summary>
        /// Triggered when the minimize button is clicked.
        /// </summary>
        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Triggered when the close window button is clicked.
        /// </summary>
        private void closeWindowBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Triggered when the mouse enters a top bar button.
        /// </summary>
        private void mouseEnterTopButton(object sender, EventArgs e)
        {
            ((PictureBox)sender).BackColor = ThemeProvider.Theme.Colors.LightBackground;
        }

        /// <summary>
        /// Triggered when the mouse leaves the top bar button.
        /// </summary>
        private void mouseLeaveTopButton(object sender, EventArgs e)
        {
            ((PictureBox)sender).BackColor = ThemeProvider.Theme.Colors.GreyBackground;
        }
    }
}
