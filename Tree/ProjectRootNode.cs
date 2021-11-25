using DarkUI.Collections;
using DarkUI.Controls;
using tileEngine.Controls;
using tileEngine.SDK.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tileEngine
{
    /// <summary>
    /// The root node of a project.
    /// </summary>
    [SelectorIgnore]
    public class ProjectRootNode : ProjectTreeNode
    {
        //Serialization constructor.
        private ProjectRootNode() 
        {
            InitializeRoot();
        }

        public ProjectRootNode(string name)
        {
            Name = name;
            InitializeRoot();
        }

        /// <summary>
        /// Opens the project properties window from this root node.
        /// </summary>
        public void OpenProjectProperties()
        {
            //Create it if it doesn't exist already, launch the document.
            if (Document == null)
            {
                Document = new PropertiesDocument(this);
                Document.OnContentClosed += documentClosed;
            }
            Editor.Instance.OpenDocument(Document);
        }

        /// <summary>
        /// Initializes this root node to behave correctly.
        /// </summary>
        private void InitializeRoot()
        {
            Icon = Resources.Icons.ProjectIcon;
            Expanded = true;

            //Hook events.
            OnNameChanged += nameChanged;
            ProjectManager.OnProjectChanged += (Project p) => {
                p.OnNameChanged += projectNameChanged;
            };
        }

        /// <summary>
        /// No document to update from.
        /// </summary>
        public override void UpdateFromDocument() 
        {
            if (Document != null)
                ((PropertiesDocument)Document).FlushUpdates();
        }

        /// <summary>
        /// Triggered when the project name itself changes.
        /// </summary>
        /// <param name="newName"></param>
        private void projectNameChanged(string newName)
        {
            //Disconnect the rename event for us (temporarily) to set the name.
            OnNameChanged -= nameChanged;
            this.Name = newName;
            OnNameChanged += nameChanged;
        }

        /// <summary>
        /// When the name is changed on this project root node.
        /// </summary>
        private void nameChanged(object sender, string newName)
        {
            if (ProjectManager.CurrentProject != null)
                ProjectManager.CurrentProject.Name = newName;
        }

        /// <summary>
        /// Null the document. We want to create a new instance every time
        /// to avoid stale data festering in the project property document.
        /// </summary>
        private void documentClosed()
        {
            Document = null;
        }

    }
}
