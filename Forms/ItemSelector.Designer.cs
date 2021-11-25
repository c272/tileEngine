
namespace tileEngine.Forms
{
    partial class ItemSelector
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemSelector));
            this.filterTree = new DarkUI.Controls.DarkTreeView();
            this.itemList = new DarkUI.Controls.DarkListView();
            this.descriptionTitle = new DarkUI.Controls.DarkLabel();
            this.searchBar = new DarkUI.Controls.DarkTextBox();
            this.sortByLbl = new DarkUI.Controls.DarkLabel();
            this.sortBy = new DarkUI.Controls.DarkDropdownList();
            this.bottomControlBar = new System.Windows.Forms.Panel();
            this.addBtn = new DarkUI.Controls.DarkButton();
            this.cancelBtn = new DarkUI.Controls.DarkButton();
            this.nameLbl = new DarkUI.Controls.DarkLabel();
            this.nameTxt = new DarkUI.Controls.DarkTextBox();
            this.descriptionLabel = new DarkUI.Controls.DarkLabel();
            this.bottomControlBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // filterTree
            // 
            this.filterTree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.filterTree.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterTree.Location = new System.Drawing.Point(13, 12);
            this.filterTree.MaxDragChange = 20;
            this.filterTree.Name = "filterTree";
            this.filterTree.Size = new System.Drawing.Size(183, 419);
            this.filterTree.TabIndex = 0;
            this.filterTree.Text = "Filter";
            this.filterTree.SelectedNodesChanged += new System.EventHandler(this.filterSelectionChanged);
            // 
            // itemList
            // 
            this.itemList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(45)))));
            this.itemList.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemList.IconSize = 32;
            this.itemList.ItemHeight = 40;
            this.itemList.Location = new System.Drawing.Point(202, 34);
            this.itemList.Name = "itemList";
            this.itemList.ShowIcons = true;
            this.itemList.Size = new System.Drawing.Size(470, 398);
            this.itemList.TabIndex = 1;
            this.itemList.Text = "Item List";
            this.itemList.SelectedIndicesChanged += new System.EventHandler(this.selectionChanged);
            // 
            // descriptionTitle
            // 
            this.descriptionTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionTitle.AutoSize = true;
            this.descriptionTitle.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.descriptionTitle.Location = new System.Drawing.Point(678, 46);
            this.descriptionTitle.Name = "descriptionTitle";
            this.descriptionTitle.Size = new System.Drawing.Size(71, 14);
            this.descriptionTitle.TabIndex = 2;
            this.descriptionTitle.Text = "Description:";
            // 
            // searchBar
            // 
            this.searchBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.searchBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.searchBar.Location = new System.Drawing.Point(682, 8);
            this.searchBar.Name = "searchBar";
            this.searchBar.Size = new System.Drawing.Size(165, 20);
            this.searchBar.TabIndex = 3;
            // 
            // sortByLbl
            // 
            this.sortByLbl.AutoSize = true;
            this.sortByLbl.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sortByLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.sortByLbl.Location = new System.Drawing.Point(206, 11);
            this.sortByLbl.Name = "sortByLbl";
            this.sortByLbl.Size = new System.Drawing.Size(48, 14);
            this.sortByLbl.TabIndex = 4;
            this.sortByLbl.Text = "Sort by:";
            // 
            // sortBy
            // 
            this.sortBy.Location = new System.Drawing.Point(259, 8);
            this.sortBy.Name = "sortBy";
            this.sortBy.Size = new System.Drawing.Size(144, 20);
            this.sortBy.TabIndex = 5;
            this.sortBy.Text = "Sort By";
            // 
            // bottomControlBar
            // 
            this.bottomControlBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(45)))));
            this.bottomControlBar.Controls.Add(this.addBtn);
            this.bottomControlBar.Controls.Add(this.cancelBtn);
            this.bottomControlBar.Controls.Add(this.nameLbl);
            this.bottomControlBar.Controls.Add(this.nameTxt);
            this.bottomControlBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomControlBar.Location = new System.Drawing.Point(0, 439);
            this.bottomControlBar.Name = "bottomControlBar";
            this.bottomControlBar.Size = new System.Drawing.Size(854, 46);
            this.bottomControlBar.TabIndex = 6;
            // 
            // addBtn
            // 
            this.addBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addBtn.Enabled = false;
            this.addBtn.Location = new System.Drawing.Point(686, 13);
            this.addBtn.Name = "addBtn";
            this.addBtn.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.addBtn.Size = new System.Drawing.Size(78, 20);
            this.addBtn.TabIndex = 10;
            this.addBtn.Text = "Add";
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.Location = new System.Drawing.Point(770, 13);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cancelBtn.Size = new System.Drawing.Size(78, 20);
            this.cancelBtn.TabIndex = 9;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.nameLbl.Location = new System.Drawing.Point(14, 16);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(43, 14);
            this.nameLbl.TabIndex = 8;
            this.nameLbl.Text = "Name:";
            // 
            // nameTxt
            // 
            this.nameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nameTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.nameTxt.Location = new System.Drawing.Point(62, 13);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(611, 20);
            this.nameTxt.TabIndex = 7;
            this.nameTxt.TextChanged += new System.EventHandler(this.nameChanged);
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionLabel.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.descriptionLabel.Location = new System.Drawing.Point(678, 62);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(162, 370);
            this.descriptionLabel.TabIndex = 7;
            this.descriptionLabel.Text = "This is a description.";
            // 
            // ItemSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(854, 485);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.bottomControlBar);
            this.Controls.Add(this.sortBy);
            this.Controls.Add(this.sortByLbl);
            this.Controls.Add(this.searchBar);
            this.Controls.Add(this.descriptionTitle);
            this.Controls.Add(this.itemList);
            this.Controls.Add(this.filterTree);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ItemSelector";
            this.Text = "Item Selector";
            this.bottomControlBar.ResumeLayout(false);
            this.bottomControlBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DarkUI.Controls.DarkTreeView filterTree;
        private DarkUI.Controls.DarkLabel descriptionTitle;
        private DarkUI.Controls.DarkTextBox searchBar;
        private DarkUI.Controls.DarkLabel sortByLbl;
        private DarkUI.Controls.DarkDropdownList sortBy;
        private System.Windows.Forms.Panel bottomControlBar;
        private DarkUI.Controls.DarkButton addBtn;
        private DarkUI.Controls.DarkButton cancelBtn;
        private DarkUI.Controls.DarkLabel nameLbl;
        private DarkUI.Controls.DarkLabel descriptionLabel;
        protected DarkUI.Controls.DarkTextBox nameTxt;
        protected DarkUI.Controls.DarkListView itemList;
    }
}