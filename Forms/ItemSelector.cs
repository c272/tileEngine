using DarkUI.Config;
using DarkUI.Controls;
using DarkUI.Forms;
using tileEngine.Controls;
using tileEngine.SDK.Attributes;
using tileEngine.SDK.Diagnostics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tileEngine.Forms
{
    /// <summary>
    /// Form for adding a new layout item to a layout. 
    /// </summary>
    public abstract partial class ItemSelector : DarkForm
    {
        //The root node of the filter tree.
        public DarkTreeNode FilterRoot = null;

        //The items available in the selector.
        private List<SelectorItem> items = new List<SelectorItem>(); 

        public ItemSelector()
        {
            InitializeComponent();
            this.AcceptButton = addBtn;
            this.CancelButton = cancelBtn;

            //Set ourselves to be centered in the parent.
            if (Editor.Instance != null)
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = new Point(Editor.Instance.Location.X + ((Editor.Instance.Size.Width - this.Size.Width) / 2),
                                          Editor.Instance.Location.Y + ((Editor.Instance.Size.Height - this.Size.Height) / 2));
            }

            //Set our colours correctly.
            this.BackColor = ThemeProvider.Theme.Colors.GreyBackground;
            bottomControlBar.BackColor = ThemeProvider.Theme.Colors.DarkBackground;

            //Add the root node for the filter tree.
            FilterRoot = new DarkTreeNode()
            {
                Text = "All Categories"
            };
            filterTree.Nodes.Add(FilterRoot);

            //Reset description text.
            descriptionLabel.Text = "";
        }

        /// <summary>
        /// Called when the user changes either the selected item or the name.
        /// Returns whether the user can currently add the given item.
        /// </summary>
        public abstract bool IsValidSelection();

        /// <summary>
        /// Creates the item on the "Add" button being pressed from a valid selection.
        /// </summary>
        public abstract void CreateItem();

        /// <summary>
        /// Get the currently selected type. If none selected, returns null.
        /// </summary>
        protected Type GetSelectedType()
        {
            if (itemList.SelectedIndices.Count == 0)
                return null;
            return ((SelectorItem)itemList.Items[itemList.SelectedIndices[0]]).Type;
        }

        /// <summary>
        /// Adds all types that inherit from the given type.
        /// Ignores types that have the attribute "SelectorIgnore" attached.
        /// </summary>
        protected List<Type> GetValidInheritingTypes(Type baseType)
        {
            //Find all inheriting subtypes that don't have "SelectorIgnore".
            var types = new List<Type>();
            foreach (var domainAssembly in AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName.Contains("tileEngine")))
            {
                var matchingTypes = domainAssembly.GetTypes()
                  .Where(type => type.IsSubclassOf(baseType) && !type.IsAbstract && type.GetCustomAttributes(typeof(SelectorIgnore), false).Length == 0);
                types.AddRange(matchingTypes);
            }

            return types;
        }

        /// <summary>
        /// Adds an item to the selection of available items, given the type.
        /// </summary>
        protected void AddItem(Type toAdd)
        {
            //Prepare default values.
            string name = toAdd.Name;
            string description = "No description provided.";
            string[] categories = new string[0];
            Bitmap icon = null;

            //Get the attributes on this type. Is there a "SelectorMetadata" attribute?
            var attribs = toAdd.GetCustomAttributes(typeof(SelectorMetadata), false);
            if (attribs.Length > 0)
            {
                SelectorMetadata attrib = (SelectorMetadata)attribs[0];
                name = attrib.Name;
                description = attrib.Description;
                categories = attrib.Categories;

                //Attempt to load the icon from resources. On fail, notify via. editor.
                try
                {
                    if (attrib.IconName != null)
                        icon = (Bitmap)Resources.Icons.ResourceManager.GetObject(attrib.IconName);
                }
                catch (Exception e)
                {
                    DiagnosticsHook.LogMessage(21000, "Failed to load icon for selector '" + attrib.IconName + "': " + e.Message);
                }
            }

            //Add the item to the list of options.
            var item = new SelectorItem()
            {
                Icon = icon,
                Text = name,
                Categories = categories,
                Description = description,
                Type = toAdd
            };
            items.Add(item);
            itemList.Items.Add(item);

            //Add any new categories to the tree.
            foreach (var category in categories)
            {
                //Already exists.
                if (FilterRoot.Nodes.FindIndex(x => x.Text == category) != -1)
                    continue;

                //Add the new category!
                FilterRoot.Nodes.Add(new DarkTreeNode()
                {
                    Text = category
                });
                FilterRoot.Expanded = true;
            }

            //Sort category nodes by alphabetical order.
            var ordered = FilterRoot.Nodes.OrderBy(x => x.Text).ToList();
            FilterRoot.Nodes.Clear();
            FilterRoot.Nodes.AddRange(ordered);
            FilterRoot.Expanded = true;
        }

        /// <summary>
        /// Closes the form when "cancel" is clicked.
        /// </summary>
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Attempts to add the item when "Add" is clicked.
        /// </summary>
        private void addBtn_Click(object sender, EventArgs e)
        {
            CreateItem();
            DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Triggered when the selected items on the item selector are altered.
        /// </summary>
        private void selectionChanged(object sender, EventArgs e)
        {
            //If there's anything selected, set the description field.
            if (itemList.SelectedIndices.Count == 0)
            {
                descriptionLabel.Text = "";
                addBtn.Enabled = false;
                return;
            }
            descriptionLabel.Text = ((SelectorItem)itemList.Items[itemList.SelectedIndices[0]]).Description;

            //Verify selection.
            addBtn.Enabled = IsValidSelection();
        }

        /// <summary>
        /// Triggered when the user clicks a node on the filter list.
        /// </summary>
        private void filterSelectionChanged(object sender, EventArgs e)
        {
            //Clear the current list view.
            itemList.Items.Clear();

            //If the selected filter is nothing or the root node, we show everything.
            if (filterTree.SelectedNodes.Count == 0 || filterTree.SelectedNodes[0].Text == FilterRoot.Text)
            {
                foreach (var item in items)
                    itemList.Items.Add(item);
                return;
            }

            //Only add those with a category matching the filter category.
            string filter = filterTree.SelectedNodes[0].Text;
            foreach (var item in items)
            {
                if (item.Categories.Contains(filter))
                    itemList.Items.Add(item);
            }
        }

        /// <summary>
        /// Triggered when the user changes the name of the new item.
        /// </summary>
        private void nameChanged(object sender, EventArgs e)
        {
            //Only bother updating enabled if there's a valid item selected too.
            if (itemList.SelectedIndices.Count > 0)
                addBtn.Enabled = IsValidSelection();
        }
    }
}
