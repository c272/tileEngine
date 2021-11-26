﻿using DarkUI.Controls;
using DarkUI.Docking;
using DarkUI.Forms;
using tileEngine.Forms;
using tileEngine.SDK.Diagnostics;
using tileEngine.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tileEngine.Controls
{
    /// <summary>
    /// Represents a dockable project tree inspector within tileEngine, containing a (virtual) tree of files.
    /// </summary>
    public partial class ProjectTreeWindow : DarkToolWindow
    {
        /// <summary>
        /// The currently selected parent for new nodes to be created under.
        /// </summary>
        public DarkTreeNode CurrentSelectedParent;

        /// <summary>
        /// The root node of the currently loaded project.
        /// </summary>
        public ProjectRootNode RootNode { get; private set; }

        public ProjectTreeWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the nodes on this tree from an external list of items.
        /// </summary>
        public void SetNodes(ProjectRootNode projectRoot)
        {
            projectTree.Nodes.Clear();
            projectTree.Nodes.Add(projectRoot);
            RootNode = projectRoot;
            CurrentSelectedParent = RootNode;
        }

        /// <summary>
        /// Returns whether this project tree currently contains any documents with unsaved changes.
        /// </summary>
        public bool HasUnsavedChanges()
        {
            //Iterate over every node and check for changes. If none, return false.
            var toSearch = new List<ProjectTreeNode>();
            toSearch.AddRange(projectTree.Nodes.Select(x => (ProjectTreeNode)x));
            for (int i = 0; i < toSearch.Count; i++)
            {
                if (toSearch[i].UnsavedChanges)
                    return true;
                toSearch.AddRange(toSearch[i].Nodes.Select(x => (ProjectTreeNode)x));
            }

            return false;
        }

        /// <summary>
        /// Registers all sub-documents as having their changes saved.
        /// </summary>
        public void AllChangesSaved()
        {
            //Iterate over every node and set to false.
            var toSet = new List<ProjectTreeNode>();
            toSet.AddRange(projectTree.Nodes.Select(x => (ProjectTreeNode)x));
            for (int i = 0; i < toSet.Count; i++)
            {
                toSet[i].UnsavedChanges = false;
                toSet.AddRange(toSet[i].Nodes.Select(x => (ProjectTreeNode)x));
            }
        }

        /// <summary>
        /// Triggered when the selected nodes on the graph have changed.
        /// </summary>
        private void selectedNodesChanged(object sender, EventArgs e)
        {
            //If we're not selecting a single folder, just set the global parent as the current parent.
            if (projectTree.SelectedNodes.Count != 1 || !(projectTree.SelectedNodes[0] is ProjectFolderNode))
            {
                CurrentSelectedParent = RootNode;
            }
            else
            {
                //Otherwise, set folder.
                CurrentSelectedParent = projectTree.SelectedNodes[0];
            }
        }

        /// <summary>
        /// Triggered when the user wants to add a new project item.
        /// </summary>
        private void newProjectItemBtn_Click(object sender, EventArgs e)
        {
            //Let the user select what they want to add.
            var selector = new ProjectItemSelector(this, "Add New Project Item");
            if (selector.ShowDialog(this) != DialogResult.OK)
                return;

            //Add to the currently selected parent.
            CurrentSelectedParent.Nodes.Add(selector.SelectedItem);
        }

        /// <summary>
        /// Triggered when the "New Folder" button is clicked on the project viewer.
        /// </summary>
        private void newFolderButton_Click(object sender, EventArgs e)
        {
            //Create a new folder node to add.
            var folder = new ProjectFolderNode();
            CurrentSelectedParent.Nodes.Add(folder);

            //Trigger a rename on the new element.
            this.Focus();
            folder.Rename();
        }

        /// <summary>
        /// Triggered when a user clicks the "Rename Item" button.
        /// </summary>
        private void renameItemButton_Click(object sender, EventArgs e)
        {
            //Is there a node currently selected (singular)?
            if (projectTree.SelectedNodes.Count != 1 || !(projectTree.SelectedNodes[0] is ProjectTreeNode))
            {
                return;
            }

            //Yes, rename it.
            ((ProjectTreeNode)projectTree.SelectedNodes[0]).Rename();
        }

        /// <summary>
        /// Triggered when the project tree is double clicked.
        /// </summary>
        private void treeDoubleClicked(object sender, EventArgs e)
        {
            foreach (var node in projectTree.SelectedNodes)
            {
                if (!(node is ProjectTreeNode))
                    return;
                ((ProjectTreeNode)node).OnDoubleClick();
            }
        }

        /// <summary>
        /// Triggered when the user clicks the "import asset" button on the project tree.
        /// </summary>
        private void importProjectItemBtn_Click(object sender, EventArgs e)
        {
            //Show the dialog.
            var dialog = new OpenFileDialog()
            {
                Title = "Select an asset to import from file.",
                Filter = ".PNG Files|*.png|.JPG Files|*.jpg|.JPEG Files|*.jpeg|.TTF Files|*.ttf",
                Multiselect = false
            };
            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            //Get the relative path and file info to determine asset type.
            string relPath = PathHelpers.GetRelativePath(ProjectManager.CurrentProjectDirectory, dialog.FileName);
            var fileInfo = new FileInfo(dialog.FileName);

            //Check that this file hasn't been imported before.
            var assetList = ProjectManager.CurrentProject.ProjectRoot.GetNodesOfType<ProjectAssetNode>();
            if (assetList.FindIndex(x => x.RelativeLocation == relPath) != -1)
            {
                //Already imported this asset, and it's in the tree.
                DarkMessageBox.ShowError("Cannot import this asset; the asset has already been imported and is in the project tree.", "tileEngine - Asset Already Imported", DarkDialogButton.Ok);
                return;
            }

            //Determine the asset type to make.
            ProjectTreeNode newNode = null;
            switch (fileInfo.Extension.ToLower())
            {
                case ".png":
                case ".jpg":
                case ".jpeg":
                    newNode = new ProjectSpriteNode(relPath);
                    break;
                default:
                    DiagnosticsHook.LogMessage(21002, "Failed to parse asset type from file extension '" + fileInfo.Extension + "'.");
                    return;
            }

            //Check the name isn't a duplicate, then add.
            int suffix = 1;
            string newName = fileInfo.Name;
            while (CurrentSelectedParent.Nodes.FindIndex(x => ((ProjectTreeNode)x).Name == newName) != -1)
            {
                newName = fileInfo.Name + " (" + suffix + ")";
            }
            newNode.Name = newName;
            CurrentSelectedParent.Nodes.Add(newNode);

            //Rename the element.
            this.Focus();
            newNode.Rename();
        }
    }
}