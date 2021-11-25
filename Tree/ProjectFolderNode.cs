using DarkUI.Controls;
using tileEngine.SDK.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tileEngine
{
    /// <summary>
    /// Represents a single folder node within the tree.
    /// </summary>
    [SelectorIgnore]
    public class ProjectFolderNode : ProjectTreeNode
    {
        public ProjectFolderNode()
        {
            Name = "New Folder";
            Icon = Resources.Icons.FolderClosed;
            ExpandedIcon = Resources.Icons.FolderOpened;
        }

        /// <summary>
        /// No requirement to update from document, we are a folder.
        /// </summary>
        public override void UpdateFromDocument() { }
    }
}
