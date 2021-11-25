﻿using DarkUI.Config;
using DarkUI.Docking;
using DarkUI.Forms;
using tileEngine.Controls;
using tileEngine.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tileEngine
{
    public partial class Editor : DarkForm
    {
        /// <summary>
        /// Incredibly nasty hack to solve a fundamental problem with WinForms drawing.
        /// Without WS_EX_COMPOSITED, WinForms will leave a giant gaping black hole in place while the
        /// child control is drawing over the invalidated part of the form, making it look really ugly.
        /// WS_EX_COMPOSITED solves this by not drawing until all child controls have been written.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                //Turn on WS_EX_COMPOSITED to stop child control flickering.
                CreateParams cp = base.CreateParams;
                cp.Style &= ~0x00C00000; // remove WS_CAPTION
                //cp.Style &= ~0x00040000;  // remove WS_SIZEBOX
                cp.ExStyle |= 0x02000000; //For WS_EX_COMPOSITED.
                cp.Style |= 0x20000; //For border resizing.
                return cp;
            }
        }

        //The currently active instance of the editor.
        public static Editor Instance = null;

        //The project tree window.
        ProjectTreeWindow projectWindow = new ProjectTreeWindow();

        //The error list window.
        ErrorWindow errorWindow = new ErrorWindow();

        //The compile output window.
        OutputWindow outputWindow = new OutputWindow();

        //The last time this editor was clicked (for double click tracking, in-built event does not register).
        DateTime lastClickTime = DateTime.MinValue;

        //Whether the editor is currently saving to file.
        bool currentlySaving = false;

        public Editor()
        {
            //Set instance, game control.
            Instance = this;

            //Make the font ignore DPI scaling.
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);

            //Scale with DPI for nice font drawing.
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;
            KeyPreview = true;

            //Remove titlebar, make draggable.
            this.ControlBox = false;
            this.Text = String.Empty;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //Add message filters for the dark dock panel.
            Application.AddMessageFilter(dockPanel.DockContentDragFilter);
            Application.AddMessageFilter(dockPanel.DockResizeFilter);

            //Hook into project manager to detect project changes.
            ProjectManager.OnProjectChanged += projectChanged;

            //Add dock panel content.
            dockPanel.AddContent(projectWindow);
            dockPanel.AddContent(errorWindow);
            dockPanel.AddContent(outputWindow, errorWindow.DockGroup);

            //Set the size of the right, bottom region to be a normal size.
            var right = dockPanel.Regions[DarkDockArea.Right];
            right.Size = new Size((int)(right.Size.Width * 2f), right.Size.Height);
            var bottom = dockPanel.Regions[DarkDockArea.Bottom];
            bottom.Size = new Size(bottom.Size.Width, (int)(bottom.Size.Height * 1.7f));
        }

        /// <summary>
        /// Opens the provided project document in the editor window.
        /// If the document is already open, focuses it.
        /// </summary>
        public void OpenDocument(ProjectDocument document)
        {
            //If the panel has the content already, just focus.
            if (dockPanel.ContainsContent(document))
            {
                dockPanel.ActiveContent = document;
                return;
            }

            //Add the document.
            dockPanel.AddContent(document);
        }

        private void Editor_Load(object sender, EventArgs e)
        {

        }

        //////////////////////////////
        /// GENERAL EVENT HANDLERS ///
        //////////////////////////////

        /// <summary>
        /// Triggered when the active project is changed.
        /// </summary>
        private void projectChanged(Project newProject)
        {
            //Update the window title, project name label (& position).
            Text = (newProject.Name.Length <= 30 ? newProject.Name : newProject.Name.Substring(0, 30) + "...") + " - tileEngine";
            updateProjectNameLabel(newProject.Name);

            //Copy in the project items from the project to the node tree.
            projectWindow.SetNodes(newProject.ProjectRoot);

            //Set labels that are dependent on project name.
            newProject.OnNameChanged += projectNameChanged;
            projectNameChanged(newProject.Name);
        }

        /// <summary>
        /// Updates the project name label from the given name.
        /// </summary>
        private void updateProjectNameLabel(string name)
        {
            projectNameLabel.Text = name;
            Size nameSize = TextRenderer.MeasureText(name, projectNameLabel.Font);

            //Bound the width of the name size to be non-ridiculous.
            if (nameSize.Width > 200)
                nameSize.Width = 200;
            projectNameLabel.Location = new Point(minimizeBtn.Left - 5 - nameSize.Width - 6, minimizeBtn.Top + 5);
            projectNameLabel.Size = new Size(nameSize.Width + 8, nameSize.Height + 8);
        }

        /// <summary>
        /// Triggered when the name of the current project changes.
        /// </summary>
        private void projectNameChanged(string name)
        {
            //Set labels that are dependent on project name.
            startProjectBtn.Text = "Start " + name;
            projectPropertiesBtn.Text = name + " Properties";
            projectPropertiesMenuBtn.Text = name + " Properties";
            updateProjectNameLabel(name);
        }

        /// <summary>
        /// Requests the user to open a new project.
        /// </summary>
        private void openProject(object sender, EventArgs e)
        {
            //Get the dialog result.
            string fileName = ProjectManager.ShowOpenProjectDialog();
            if (fileName == null)
                return;

            //Attempt to open.
            Exception error = ProjectManager.LoadProject(fileName);
            if (error != null)
            {
                DarkMessageBox.ShowError("Failed to load project from file: " + error.Message, "tileEngine - Project Load Error");
                return;
            }
        }

        private void saveAll(object sender, EventArgs e) 
        {
            //Update all nodes from document.
            foreach (var node in projectWindow.RootNode.Nodes.Select(x => (ProjectTreeNode)x))
            {
                node.UpdateFromDocument();
            }

            //Save the project.
            ProjectManager.CurrentProject.ProjectRoot = projectWindow.RootNode;
            currentlySaving = true;
            Task.Run(() =>
            {
                var error = ProjectManager.SaveProject();
                if (error != null)
                    DarkMessageBox.ShowError("Failed to save project: " + error.Message, "tileEngine - Save Project Error");
            });

            //Register the changes as saved.
            currentlySaving = false;
            projectWindow.RootNode.UnsavedChanges = false;
            foreach (var node in projectWindow.RootNode.Nodes.Select(x => (ProjectTreeNode)x))
                node.UnsavedChanges = false;
        }

        /// <summary>
        /// Saves the currently open document, and then the project.
        /// </summary>
        private void saveDocument(object sender, EventArgs e)
        {
            //Copy the currently open document (if any) into its project node.
            if (dockPanel.ActiveDocument == null) { return; }
            var curDoc = ((ProjectDocument)dockPanel.ActiveDocument);
            curDoc.Node.UpdateFromDocument();

            //Save the project to file.
            ProjectManager.CurrentProject.ProjectRoot = projectWindow.RootNode;
            currentlySaving = true;
            Task.Run(() =>
            {
                var error = ProjectManager.SaveProject();
                if (error != null)
                    DarkMessageBox.ShowError("Failed to save project: " + error.Message, "tileEngine - Save Project Error");
            });

            //Register the changes as saved.
            currentlySaving = false;
            curDoc.Node.UnsavedChanges = false;
        }

        /// <summary>
        /// Triggered when the build button is clicked.
        /// </summary>
        private void buildBtn_Click(object sender, EventArgs e)
        {
            //Always save all before a compile.
            saveAll(null, null);

            //Reset output window, launch a compile.
            outputWindow.Reset();
            outputWindow.DockGroup.SetVisibleContent(outputWindow);
            outputWindow.Focus();
            string error = ProjectCompiler.Compile();
            if (error != null)
                DarkMessageBox.ShowError("Compile Error: " + error, "tileEngine - Placeholder Compile Error");
        }

        /// <summary>
        /// Triggered when the user wants to view the project properties.
        /// </summary>
        private void openProjectProperties(object sender, EventArgs e)
        {
            ProjectManager.CurrentProject?.ProjectRoot.OpenProjectProperties();
        }

        ////////////////////////////
        /// HOTKEY FUNCTIONALITY ///
        ////////////////////////////

        /// <summary>
        /// Triggered when a key is pressed while the form is open.
        /// </summary>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            //If control isn't pressed, we don't care.
            if (!e.Control)
            {
                e.Handled = false;
                return;
            }

            //What hotkey are they hitting?
            switch (e.KeyCode)
            {
                //(S)ave Document
                case Keys.S:
                    if (projectWindow.ContainsFocus)
                    {
                        saveAll(null, null);
                        break;
                    }
                    saveDocument(null, null);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    break;
            }
        }

        /////////////////////////////
        /// TOP BAR FUNCTIONALITY ///
        /////////////////////////////

        /// <summary>
        /// Handle moving the form around by the top bar.
        /// </summary>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            //Check for double click.
            if ((DateTime.Now - lastClickTime).TotalSeconds < 0.5)
            {
                //Maximize/normalize window.
                maximizeBtn_Click(null, null);
            }
            lastClickTime = DateTime.Now;

            //Start a drag if we're clicking w/ left mouse.
            if (e.Button == MouseButtons.Left)
            {
                this.Capture = false;
                Message msg = Message.Create(this.Handle, 0XA1, new IntPtr(2), IntPtr.Zero);
                this.WndProc(ref msg);
                changeWindowState(WindowState);
            }
        }

        /// <summary>
        /// Overriding WndProc messages to make the form resizeable without a border.
        /// </summary>
        protected override void WndProc(ref Message m)
        {
            const int RESIZE_HANDLE_SIZE = 10;

            switch (m.Msg)
            {
                case 0x0084/*NCHITTEST*/ :
                    base.WndProc(ref m);

                    if ((int)m.Result == 0x01/*HTCLIENT*/)
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32());
                        Point clientPoint = this.PointToClient(screenPoint);
                        if (clientPoint.Y <= RESIZE_HANDLE_SIZE)
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)13/*HTTOPLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)12/*HTTOP*/ ;
                            else
                                m.Result = (IntPtr)14/*HTTOPRIGHT*/ ;
                        }
                        else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE))
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)10/*HTLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)2/*HTCAPTION*/ ;
                            else
                                m.Result = (IntPtr)11/*HTRIGHT*/ ;
                        }
                        else
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)16/*HTBOTTOMLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)15/*HTBOTTOM*/ ;
                            else
                                m.Result = (IntPtr)17/*HTBOTTOMRIGHT*/ ;
                        }
                    }
                    return;
            }

            FormWindowState originalState = this.WindowState;
            base.WndProc(ref m);
            if (this.WindowState != originalState)
                windowStateChanged();
        }

        /// <summary>
        /// Prevent form from closing from Alt+F4s, go through the checks instead.
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.UserClosing:
                    e.Cancel = true;
                    closeWindowBtn_Click(null, null);
                    break;
            }

            base.OnFormClosing(e);
        }

        /// <summary>
        /// Triggered when the user clicks the minimize button on the form.
        /// </summary>
        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            changeWindowState(FormWindowState.Minimized);
        }

        /// <summary>
        /// Triggered when the maximize/restore down button is clicked.
        /// </summary>
        private void maximizeBtn_Click(object sender, EventArgs e)
        {
            //Depending on the state we're in, change to the other.
            if (WindowState == FormWindowState.Maximized)
            {
                changeWindowState(FormWindowState.Normal);
            }
            else
            {
                changeWindowState(FormWindowState.Maximized);
            }
        }

        /// <summary>
        /// Change the window state to the new given state.
        /// </summary>
        private void changeWindowState(FormWindowState newState)
        {
            maximizeBtn.Image = newState == FormWindowState.Maximized ? Resources.Icons.RestoreDown : Resources.Icons.Maximize;
            WindowState = newState;
            windowStateChanged();
        }

        /// <summary>
        /// Triggered when the window state changes.
        /// </summary>
        private void windowStateChanged()
        {
            Invalidate();
            Update();
        }

        /// <summary>
        /// Triggered when the close window button is clicked.
        /// </summary>
        private void closeWindowBtn_Click(object sender, EventArgs e)
        {
            //If there are unsaved changes, make sure the user wants to leave.
            if (projectWindow.HasUnsavedChanges() && DarkMessageBox.ShowWarning("There are unsaved changes. Are you sure you want to close?", "tileEngine - Unsaved Changes", DarkDialogButton.YesNo) != DialogResult.Yes)
                return;

            //Cancel if we're currently saving.
            if (currentlySaving)
            {
                DialogResult result = DarkMessageBox.ShowWarning("tileEngine is currently saving to disk. Are you sure you want to exit?", "tileEngine - Operation Incomplete", DarkDialogButton.YesNo);
                if (result != DialogResult.Yes)
                    return;
            }
            Application.Exit();
        }

        /// <summary>
        /// Triggered when the mouse enters one of the control buttons.
        /// </summary>
        private void mouseEnterControlButton(object sender, EventArgs e)
        {
            ((PictureBox)sender).BackColor = ThemeProvider.Theme.Colors.LightBackground;
        }

        /// <summary>
        /// Triggered when the mouse leaves one of the control buttons.
        /// </summary>
        private void mouseLeaveControlButton(object sender, EventArgs e)
        {
            ((PictureBox)sender).BackColor = Color.Transparent;
        }
    }
}
