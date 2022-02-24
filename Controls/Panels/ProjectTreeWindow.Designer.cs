
namespace tileEngine.Controls
{
    partial class ProjectTreeWindow
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectTreeWindow));
            this.projectTree = new tileEngine.Controls.ProjectTree();
            this.toolStrip = new DarkUI.Controls.DarkToolStrip();
            this.newProjectItemBtn = new System.Windows.Forms.ToolStripButton();
            this.importProjectItemBtn = new System.Windows.Forms.ToolStripButton();
            this.relinkAssetButton = new System.Windows.Forms.ToolStripButton();
            this.newFolderButton = new System.Windows.Forms.ToolStripButton();
            this.renameItemButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.removeItemButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // projectTree
            // 
            this.projectTree.AllowMoveNodes = true;
            this.projectTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectTree.Location = new System.Drawing.Point(0, 20);
            this.projectTree.Margin = new System.Windows.Forms.Padding(2);
            this.projectTree.MaxDragChange = 20;
            this.projectTree.Name = "projectTree";
            this.projectTree.ShowIcons = true;
            this.projectTree.Size = new System.Drawing.Size(157, 276);
            this.projectTree.TabIndex = 0;
            this.projectTree.Text = "Project Tree";
            this.projectTree.SelectedNodesChanged += new System.EventHandler(this.selectedNodesChanged);
            this.projectTree.DoubleClick += new System.EventHandler(this.treeDoubleClicked);
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectItemBtn,
            this.importProjectItemBtn,
            this.relinkAssetButton,
            this.newFolderButton,
            this.renameItemButton,
            this.toolStripSeparator1,
            this.removeItemButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 274);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(4, 0, 1, 0);
            this.toolStrip.Size = new System.Drawing.Size(157, 22);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "Project Tree Tool Strip";
            // 
            // newProjectItemBtn
            // 
            this.newProjectItemBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.newProjectItemBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newProjectItemBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.newProjectItemBtn.Image = ((System.Drawing.Image)(resources.GetObject("newProjectItemBtn.Image")));
            this.newProjectItemBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.newProjectItemBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newProjectItemBtn.Name = "newProjectItemBtn";
            this.newProjectItemBtn.Size = new System.Drawing.Size(23, 19);
            this.newProjectItemBtn.Text = "New Project Item";
            this.newProjectItemBtn.Click += new System.EventHandler(this.newProjectItemBtn_Click);
            // 
            // importProjectItemBtn
            // 
            this.importProjectItemBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.importProjectItemBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.importProjectItemBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.importProjectItemBtn.Image = ((System.Drawing.Image)(resources.GetObject("importProjectItemBtn.Image")));
            this.importProjectItemBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.importProjectItemBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.importProjectItemBtn.Name = "importProjectItemBtn";
            this.importProjectItemBtn.Size = new System.Drawing.Size(23, 19);
            this.importProjectItemBtn.Text = "Import Assets";
            this.importProjectItemBtn.Click += new System.EventHandler(this.importProjectItemBtn_Click);
            // 
            // relinkAssetButton
            // 
            this.relinkAssetButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.relinkAssetButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.relinkAssetButton.Enabled = false;
            this.relinkAssetButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.relinkAssetButton.Image = ((System.Drawing.Image)(resources.GetObject("relinkAssetButton.Image")));
            this.relinkAssetButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.relinkAssetButton.Name = "relinkAssetButton";
            this.relinkAssetButton.Size = new System.Drawing.Size(24, 19);
            this.relinkAssetButton.Text = "Relink Asset";
            this.relinkAssetButton.Click += new System.EventHandler(this.relinkAssetButton_Click);
            // 
            // newFolderButton
            // 
            this.newFolderButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.newFolderButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newFolderButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.newFolderButton.Image = ((System.Drawing.Image)(resources.GetObject("newFolderButton.Image")));
            this.newFolderButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newFolderButton.Name = "newFolderButton";
            this.newFolderButton.Size = new System.Drawing.Size(24, 19);
            this.newFolderButton.Text = "New Folder";
            this.newFolderButton.Click += new System.EventHandler(this.newFolderButton_Click);
            // 
            // renameItemButton
            // 
            this.renameItemButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.renameItemButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.renameItemButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.renameItemButton.Image = ((System.Drawing.Image)(resources.GetObject("renameItemButton.Image")));
            this.renameItemButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.renameItemButton.Name = "renameItemButton";
            this.renameItemButton.Size = new System.Drawing.Size(24, 19);
            this.renameItemButton.Text = "Rename Item";
            this.renameItemButton.Click += new System.EventHandler(this.renameItemButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 22);
            // 
            // removeItemButton
            // 
            this.removeItemButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.removeItemButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.removeItemButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.removeItemButton.Image = ((System.Drawing.Image)(resources.GetObject("removeItemButton.Image")));
            this.removeItemButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeItemButton.Name = "removeItemButton";
            this.removeItemButton.Size = new System.Drawing.Size(24, 24);
            this.removeItemButton.Text = "Delete Item";
            // 
            // ProjectTreeWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.projectTree);
            this.DefaultDockArea = DarkUI.Docking.DarkDockArea.Left;
            this.DockText = "Project Explorer";
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ProjectTreeWindow";
            this.Size = new System.Drawing.Size(157, 296);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private tileEngine.Controls.ProjectTree projectTree;
        private DarkUI.Controls.DarkToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton newFolderButton;
        private System.Windows.Forms.ToolStripButton renameItemButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton removeItemButton;
        private System.Windows.Forms.ToolStripButton newProjectItemBtn;
        private System.Windows.Forms.ToolStripButton importProjectItemBtn;
        private System.Windows.Forms.ToolStripButton relinkAssetButton;
    }
}
