using DarkUI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tileEngine.Controls
{
    /// <summary>
    /// Represents the project tree view control within the tileEngine editor.
    /// </summary>
    public class ProjectTree : DarkTreeView
    {
        public ProjectTree()
        {
            AllowMoveNodes = true;
        }

        /// <summary>
        /// Returns whether the given collection of nodes can be dropped onto the given target node.
        /// </summary>
        protected override bool CanMoveNodes(List<DarkTreeNode> dragNodes, DarkTreeNode dropNode, bool isMoving = false)
        {
            //Check base stuff.
            if (!base.CanMoveNodes(dragNodes, dropNode, isMoving))
                return false;

            //Is the node a ProjectFolderNode or the ProjectRootNode?
            //If not, we can't move stuff under it.
            if (!(dropNode is ProjectFolderNode) && !(dropNode is ProjectRootNode))
                return false;

            //Set destination node as unsaved changes.
            ((ProjectTreeNode)dropNode).UnsavedChanges = true;
            return true;
        }
    }
}
