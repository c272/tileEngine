using DarkUI.Collections;
using DarkUI.Controls;
using tileEngine.Controls;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tileEngine
{
    /// <summary>
    /// Represents an arbitrary node in the project tree, with added capability
    /// on top of the base DarkTreeNode from DarkUI.
    /// </summary>
    [ProtoContract]
    public abstract class ProjectTreeNode : DarkTreeNode
    {
        /// <summary>
        /// Regex describing a valid name for project tree nodes.
        /// </summary>
        public const string VALID_NAME_REGEX = "^[A-Za-z0-9_ -]+$";

        /// <summary>
        /// A unique ID for this project tree node, generated on creation.
        /// </summary>
        [ProtoMember(1)]
        public int ID { get; private set; } = Guid.NewGuid().GetHashCode();

        /// <summary>
        /// The name of this node.
        /// </summary>
        [ProtoMember(2)]
        public string Name { 
            get { return name; }
            set
            {
                name = value;

                //Check if we're a duplicate from parent.
                if (this.ParentNode != null)
                    CheckNameDuplicates(this.ParentNode.Nodes);
                OnNameChanged?.Invoke(this, name);
                OnDisplayTextChanged?.Invoke(this, DisplayText);
            }
        }
        private string name = "New Node";

        /// <summary>
        /// The display text to put on the project viewer and any documents.
        /// </summary>
        public string DisplayText
        {
            get
            {
                return Name + (UnsavedChanges ? "*" : "");
            }
        }

        /// <summary>
        /// Whether this node has unsaved changes.
        /// </summary>
        public bool UnsavedChanges
        {
            get { return unsavedChanges; }
            set
            {
                //Update value, call change to display text if necessary.
                bool prevValue = unsavedChanges;
                unsavedChanges = value;
                if (value != prevValue)
                {
                    OnDisplayTextChanged?.Invoke(this, DisplayText);
                }
                
            }
        }
        bool unsavedChanges = false;

        /// <summary>
        /// List of children for this tree node, as a serialization workaround (cannot serialize "Nodes").
        /// </summary>
        [ProtoMember(3)]
        private List<ProjectTreeNode> children = new List<ProjectTreeNode>();

        /// <summary>
        /// The document for this tree node (if there is one).
        /// Not guaranteed to be non-null.
        /// </summary>
        public ProjectDocument Document { get; protected set; } = null;

        //Event for when the name of this node is changed.
        public delegate void NameChangedHandler(object sender, string newName);
        public event NameChangedHandler OnNameChanged;

        //Event for when the display text of this node is changed.
        public delegate void DisplayTextChangedHandler(object sender, string newName);
        public event DisplayTextChangedHandler OnDisplayTextChanged;

        public ProjectTreeNode()
        {
            ItemsAdded += nodesAltered;
            ItemsRemoved += nodesAltered;
            OnDisplayTextChanged += displayTextChanged;
        }

        /// <summary>
        /// Updates this project tree node from the source document.
        /// </summary>
        public abstract void UpdateFromDocument();

        /// <summary>
        /// Triggers a user-entered rename of this node.
        /// </summary>
        public void Rename()
        {
            //Create a new (dark) text box at the text area.
            DarkTextBox textBox = new DarkTextBox()
            {
                Location = TextArea.Location,
                Size = TextArea.Size,
                Visible = true,
                Text = this.Name,
                SelectionLength = this.Text.Length,
                SelectionStart = 0
            };

            //Temporarily hide text.
            Text = "";

            //Hook to necessary events on the text box.
            textBox.LostFocus += endRename;
            textBox.KeyDown += renameKeyDown;
            textBox.TextChanged += renameTextChanged;

            //Add control, focus for rename.
            ParentTree.Controls.Add(textBox);
            textBox.Focus();
        }

        /// <summary>
        /// Returns a list of all nodes of the given type that exist in the current tree.
        /// </summary>
        public List<T> GetNodesOfType<T>() where T : ProjectTreeNode
        {
            List<T> output = new List<T>();
            foreach (var node in Nodes)
            {
                if (node is T)
                {
                    output.Add(node as T);
                }
                output.AddRange(((ProjectTreeNode)node).GetNodesOfType<T>());
            }

            return output;
        }

        /// <summary>
        /// Returns a child of this object with the given ID and type, if that child exists.
        /// Mismatching type but equal ID will not return.
        /// </summary>
        public T FindChild<T>(int id) where T : class
        {
            foreach (var node in children)
            {
                //Is it this child?
                if (node is T && node.ID == id)
                    return node as T;

                //See if it's a child of a child.
                var childResult = node.FindChild<T>(id);
                if (childResult != null)
                    return childResult;
            }

            //Not found.
            return null;
        }

        /// <summary>
        /// Triggered when the rename text box's text is changed.
        /// </summary>
        private void renameTextChanged(object sender, EventArgs e)
        {
            DarkTextBox textBox = (DarkTextBox)sender;

            //Alter the size/location of the text box.
            textBox.Location = TextArea.Location;
            var textSize = TextRenderer.MeasureText(textBox.Text, textBox.Font);
            textBox.Size = new Size(Math.Max(textSize.Width + 5, 10), textSize.Height);
        }

        //Triggered when a user presses a key down while renaming an item.
        private void renameKeyDown(object sender, KeyEventArgs e)
        {
            //If the key is enter, we're done.
            if (e != null && e.KeyCode == Keys.Enter)
                endRename(sender, null);

            //If the key is escape, invalidate our input, then finish.
            if (e != null && e.KeyCode == Keys.Escape)
            {
                ((DarkTextBox)sender).Text = null;
                endRename(sender, null);
                UnsavedChanges = false;
            }
        }

        //Triggered when a rename event is ended because the user clicked away from the text box.
        private void endRename(object sender, EventArgs e)
        {
            DarkTextBox textBox = (DarkTextBox)sender;

            //Update node text if value is valid.
            if (textBox.Text != null && textBox.Text != "")
                this.Name = textBox.Text;

            //Un-hide text.
            Text = DisplayText;

            //Dispose of the text box.
            textBox.Parent = null;
            textBox.Dispose();

            //Register unsaved changes.
            UnsavedChanges = true;
        }

        /// <summary>
        /// Triggered when the nodes on this node are altered.
        /// </summary>
        private void nodesAltered(object sender, ObservableListModified<DarkTreeNode> e)
        {
            Expanded = true;
            CheckNameDuplicates(Nodes);
        }

        /// <summary>
        /// Checks for name duplicates in a given parent, and then renames the children as necessary.
        /// </summary>
        protected void CheckNameDuplicates(ObservableList<DarkTreeNode> toCheck)
        {
            //Do any of the child nodes have identical names?
            var childrenByName = toCheck.GroupBy(x => ((ProjectTreeNode)x).Name).ToList();
            foreach (var items in childrenByName)
            {
                //Ignore distinct items.
                if (items.Count() == 1) { continue; }

                //Loop over all items (starting from second), modify name.
                for (int i = 1; i < items.Count(); i++)
                {
                    ((ProjectTreeNode)items.ElementAt(i)).Name += " (" + i + ")";
                }
            }
        }

        /// <summary>
        /// Triggered when the display text on this node is changed.
        /// </summary>
        private void displayTextChanged(object sender, string newName)
        {
            Text = DisplayText;
            if (Document != null)
                Document.DockText = DisplayText;
        }

        /// <summary>
        /// Triggered when the user double clicks this element.
        /// </summary>
        public virtual void OnDoubleClick() { }

        /// <summary>
        /// Should be called before any serialization with Protobuf, to prepare
        /// the class for serialization.
        /// </summary>
        public virtual void PrepareSerialize()
        {
            children.Clear();
            foreach (var node in Nodes)
            {
                var ptNode = (ProjectTreeNode)node;
                children.Add(ptNode);
                ptNode.PrepareSerialize();
            }
        }

        /// <summary>
        /// Completes deserialization from file from the dummy "children" property into the actual
        /// list of nodes for the tree itself.
        /// </summary>
        public virtual void CompleteDeserialize()
        {
            //Add child nodes.
            Nodes.Clear();
            foreach (var item in children)
            {
                Nodes.Add(item);
            }
        }
    }
}
