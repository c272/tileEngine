
namespace tileEngine
{
    partial class Editor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
            this.dockPanel = new DarkUI.Docking.DarkDockPanel();
            this.statusStrip = new DarkUI.Controls.DarkStatusStrip();
            this.statusIndicator = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ramUsageLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip = new DarkUI.Controls.DarkToolStrip();
            this.navigateBackBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.navigateForwardsBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.newProjectBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.openProjectBtn = new System.Windows.Forms.ToolStripButton();
            this.saveDocumentBtn = new System.Windows.Forms.ToolStripButton();
            this.saveAllBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.undoBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.redoBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.startBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.startProjectBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.projectPropertiesBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new DarkUI.Controls.DarkMenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cloneRepositoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.saveDocumentFileStripBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllFileStripBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.recentProjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recentProjectsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectPropertiesMenuBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.buildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.rebuildProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectNameLabel = new DarkUI.Controls.DarkLabel();
            this.minimizeBtn = new System.Windows.Forms.PictureBox();
            this.maximizeBtn = new System.Windows.Forms.PictureBox();
            this.closeWindowBtn = new System.Windows.Forms.PictureBox();
            this.logoPicture = new System.Windows.Forms.PictureBox();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.reloadAssemblyBtn = new System.Windows.Forms.ToolStripButton();
            this.statusStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimizeBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximizeBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeWindowBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // dockPanel
            // 
            this.dockPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dockPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.dockPanel.Location = new System.Drawing.Point(5, 79);
            this.dockPanel.Margin = new System.Windows.Forms.Padding(4);
            this.dockPanel.Name = "dockPanel";
            this.dockPanel.Size = new System.Drawing.Size(1562, 706);
            this.dockPanel.TabIndex = 0;
            // 
            // statusStrip
            // 
            this.statusStrip.AutoSize = false;
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.statusStrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusIndicator,
            this.statusLabel,
            this.ramUsageLabel});
            this.statusStrip.Location = new System.Drawing.Point(8, 789);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(0, 6, 0, 4);
            this.statusStrip.Size = new System.Drawing.Size(1559, 36);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "darkStatusStrip1";
            // 
            // statusIndicator
            // 
            this.statusIndicator.Image = ((System.Drawing.Image)(resources.GetObject("statusIndicator.Image")));
            this.statusIndicator.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.statusIndicator.Margin = new System.Windows.Forms.Padding(8, 3, 0, 2);
            this.statusIndicator.Name = "statusIndicator";
            this.statusIndicator.Size = new System.Drawing.Size(20, 21);
            // 
            // statusLabel
            // 
            this.statusLabel.Margin = new System.Windows.Forms.Padding(5, 3, 0, 2);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(50, 21);
            this.statusLabel.Text = "Ready";
            // 
            // ramUsageLabel
            // 
            this.ramUsageLabel.Name = "ramUsageLabel";
            this.ramUsageLabel.Size = new System.Drawing.Size(1476, 20);
            this.ramUsageLabel.Spring = true;
            this.ramUsageLabel.Text = "0MB";
            this.ramUsageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.navigateBackBtn,
            this.navigateForwardsBtn,
            this.toolStripSeparator1,
            this.newProjectBtn,
            this.openProjectBtn,
            this.saveDocumentBtn,
            this.saveAllBtn,
            this.toolStripSeparator2,
            this.undoBtn,
            this.redoBtn,
            this.toolStripSeparator3,
            this.startBtn,
            this.toolStripSeparator8,
            this.reloadAssemblyBtn});
            this.toolStrip.Location = new System.Drawing.Point(5, 41);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(8, 0, 1, 0);
            this.toolStrip.Size = new System.Drawing.Size(1575, 34);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "darkToolStrip1";
            // 
            // navigateBackBtn
            // 
            this.navigateBackBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.navigateBackBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.navigateBackBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.navigateBackBtn.Image = ((System.Drawing.Image)(resources.GetObject("navigateBackBtn.Image")));
            this.navigateBackBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.navigateBackBtn.Name = "navigateBackBtn";
            this.navigateBackBtn.Size = new System.Drawing.Size(34, 31);
            this.navigateBackBtn.Text = "Navigate Backwards";
            this.navigateBackBtn.ToolTipText = "Navigate Backwards";
            // 
            // navigateForwardsBtn
            // 
            this.navigateForwardsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.navigateForwardsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.navigateForwardsBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.navigateForwardsBtn.Image = ((System.Drawing.Image)(resources.GetObject("navigateForwardsBtn.Image")));
            this.navigateForwardsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.navigateForwardsBtn.Name = "navigateForwardsBtn";
            this.navigateForwardsBtn.Size = new System.Drawing.Size(29, 31);
            this.navigateForwardsBtn.Text = "Navigate Forwards";
            this.navigateForwardsBtn.ToolTipText = "Navigate Forwards";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 34);
            // 
            // newProjectBtn
            // 
            this.newProjectBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.newProjectBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newProjectBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.newProjectBtn.Image = ((System.Drawing.Image)(resources.GetObject("newProjectBtn.Image")));
            this.newProjectBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newProjectBtn.Name = "newProjectBtn";
            this.newProjectBtn.Size = new System.Drawing.Size(34, 31);
            this.newProjectBtn.Text = "New Project";
            // 
            // openProjectBtn
            // 
            this.openProjectBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.openProjectBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openProjectBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.openProjectBtn.Image = ((System.Drawing.Image)(resources.GetObject("openProjectBtn.Image")));
            this.openProjectBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openProjectBtn.Name = "openProjectBtn";
            this.openProjectBtn.Size = new System.Drawing.Size(29, 31);
            this.openProjectBtn.Text = "Open Project";
            this.openProjectBtn.Click += new System.EventHandler(this.openProject);
            // 
            // saveDocumentBtn
            // 
            this.saveDocumentBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.saveDocumentBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveDocumentBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.saveDocumentBtn.Image = ((System.Drawing.Image)(resources.GetObject("saveDocumentBtn.Image")));
            this.saveDocumentBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveDocumentBtn.Name = "saveDocumentBtn";
            this.saveDocumentBtn.Size = new System.Drawing.Size(29, 31);
            this.saveDocumentBtn.Text = "Save Document";
            this.saveDocumentBtn.Click += new System.EventHandler(this.saveDocument);
            // 
            // saveAllBtn
            // 
            this.saveAllBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.saveAllBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveAllBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.saveAllBtn.Image = ((System.Drawing.Image)(resources.GetObject("saveAllBtn.Image")));
            this.saveAllBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveAllBtn.Name = "saveAllBtn";
            this.saveAllBtn.Size = new System.Drawing.Size(29, 31);
            this.saveAllBtn.Text = "Save All";
            this.saveAllBtn.Click += new System.EventHandler(this.saveAll);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 34);
            // 
            // undoBtn
            // 
            this.undoBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.undoBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undoBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.undoBtn.Image = ((System.Drawing.Image)(resources.GetObject("undoBtn.Image")));
            this.undoBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoBtn.Name = "undoBtn";
            this.undoBtn.Size = new System.Drawing.Size(34, 31);
            this.undoBtn.Text = "Undo";
            // 
            // redoBtn
            // 
            this.redoBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.redoBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.redoBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.redoBtn.Image = ((System.Drawing.Image)(resources.GetObject("redoBtn.Image")));
            this.redoBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redoBtn.Name = "redoBtn";
            this.redoBtn.Size = new System.Drawing.Size(34, 31);
            this.redoBtn.Text = "Redo";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator3.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 34);
            // 
            // startBtn
            // 
            this.startBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.startBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startProjectBtn,
            this.toolStripSeparator7,
            this.projectPropertiesBtn});
            this.startBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.startBtn.Image = ((System.Drawing.Image)(resources.GetObject("startBtn.Image")));
            this.startBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(74, 31);
            this.startBtn.Text = "Start";
            // 
            // startProjectBtn
            // 
            this.startProjectBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.startProjectBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.startProjectBtn.Image = ((System.Drawing.Image)(resources.GetObject("startProjectBtn.Image")));
            this.startProjectBtn.Name = "startProjectBtn";
            this.startProjectBtn.Size = new System.Drawing.Size(209, 26);
            this.startProjectBtn.Text = "Start Project";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator7.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(206, 6);
            // 
            // projectPropertiesBtn
            // 
            this.projectPropertiesBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.projectPropertiesBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.projectPropertiesBtn.Image = ((System.Drawing.Image)(resources.GetObject("projectPropertiesBtn.Image")));
            this.projectPropertiesBtn.Name = "projectPropertiesBtn";
            this.projectPropertiesBtn.Size = new System.Drawing.Size(209, 26);
            this.projectPropertiesBtn.Text = "Project Properties";
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.projectToolStripMenuItem,
            this.buildToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(42, 9);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(227, 28);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "darkMenuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.cloneRepositoryToolStripMenuItem,
            this.toolStripSeparator4,
            this.saveDocumentFileStripBtn,
            this.saveAllFileStripBtn,
            this.toolStripSeparator5,
            this.recentProjectsToolStripMenuItem,
            this.recentProjectsToolStripMenuItem1,
            this.toolStripSeparator6,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.newToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.newToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.openToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // cloneRepositoryToolStripMenuItem
            // 
            this.cloneRepositoryToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.cloneRepositoryToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.cloneRepositoryToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cloneRepositoryToolStripMenuItem.Image")));
            this.cloneRepositoryToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cloneRepositoryToolStripMenuItem.Name = "cloneRepositoryToolStripMenuItem";
            this.cloneRepositoryToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.cloneRepositoryToolStripMenuItem.Text = "Clone Repository";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator4.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(213, 6);
            // 
            // saveDocumentFileStripBtn
            // 
            this.saveDocumentFileStripBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.saveDocumentFileStripBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.saveDocumentFileStripBtn.Image = ((System.Drawing.Image)(resources.GetObject("saveDocumentFileStripBtn.Image")));
            this.saveDocumentFileStripBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.saveDocumentFileStripBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.saveDocumentFileStripBtn.Name = "saveDocumentFileStripBtn";
            this.saveDocumentFileStripBtn.Size = new System.Drawing.Size(216, 26);
            this.saveDocumentFileStripBtn.Text = "Save Document";
            this.saveDocumentFileStripBtn.Click += new System.EventHandler(this.saveDocument);
            // 
            // saveAllFileStripBtn
            // 
            this.saveAllFileStripBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.saveAllFileStripBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.saveAllFileStripBtn.Image = ((System.Drawing.Image)(resources.GetObject("saveAllFileStripBtn.Image")));
            this.saveAllFileStripBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.saveAllFileStripBtn.Name = "saveAllFileStripBtn";
            this.saveAllFileStripBtn.Size = new System.Drawing.Size(216, 26);
            this.saveAllFileStripBtn.Text = "Save All";
            this.saveAllFileStripBtn.Click += new System.EventHandler(this.saveAll);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator5.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(213, 6);
            // 
            // recentProjectsToolStripMenuItem
            // 
            this.recentProjectsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.recentProjectsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.recentProjectsToolStripMenuItem.Name = "recentProjectsToolStripMenuItem";
            this.recentProjectsToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.recentProjectsToolStripMenuItem.Text = "Recent Documents";
            // 
            // recentProjectsToolStripMenuItem1
            // 
            this.recentProjectsToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.recentProjectsToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.recentProjectsToolStripMenuItem1.Name = "recentProjectsToolStripMenuItem1";
            this.recentProjectsToolStripMenuItem1.Size = new System.Drawing.Size(216, 26);
            this.recentProjectsToolStripMenuItem1.Text = "Recent Projects";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator6.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(213, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.exitToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.editToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectPropertiesMenuBtn});
            this.projectToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
            this.projectToolStripMenuItem.Text = "Project";
            // 
            // projectPropertiesMenuBtn
            // 
            this.projectPropertiesMenuBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.projectPropertiesMenuBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.projectPropertiesMenuBtn.Image = ((System.Drawing.Image)(resources.GetObject("projectPropertiesMenuBtn.Image")));
            this.projectPropertiesMenuBtn.Name = "projectPropertiesMenuBtn";
            this.projectPropertiesMenuBtn.Size = new System.Drawing.Size(209, 26);
            this.projectPropertiesMenuBtn.Text = "Project Properties";
            this.projectPropertiesMenuBtn.Click += new System.EventHandler(this.openProjectProperties);
            // 
            // buildToolStripMenuItem
            // 
            this.buildToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.buildToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buildBtn,
            this.rebuildProjectToolStripMenuItem});
            this.buildToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.buildToolStripMenuItem.Name = "buildToolStripMenuItem";
            this.buildToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.buildToolStripMenuItem.Text = "Build";
            // 
            // buildBtn
            // 
            this.buildBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.buildBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.buildBtn.Image = ((System.Drawing.Image)(resources.GetObject("buildBtn.Image")));
            this.buildBtn.Name = "buildBtn";
            this.buildBtn.Size = new System.Drawing.Size(193, 26);
            this.buildBtn.Text = "Build Project";
            this.buildBtn.Click += new System.EventHandler(this.buildBtn_Click);
            // 
            // rebuildProjectToolStripMenuItem
            // 
            this.rebuildProjectToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.rebuildProjectToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.rebuildProjectToolStripMenuItem.Name = "rebuildProjectToolStripMenuItem";
            this.rebuildProjectToolStripMenuItem.Size = new System.Drawing.Size(193, 26);
            this.rebuildProjectToolStripMenuItem.Text = "Rebuild Project";
            // 
            // projectNameLabel
            // 
            this.projectNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.projectNameLabel.AutoEllipsis = true;
            this.projectNameLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.projectNameLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.projectNameLabel.Location = new System.Drawing.Point(1299, 5);
            this.projectNameLabel.Margin = new System.Windows.Forms.Padding(4);
            this.projectNameLabel.Name = "projectNameLabel";
            this.projectNameLabel.Padding = new System.Windows.Forms.Padding(4);
            this.projectNameLabel.Size = new System.Drawing.Size(99, 29);
            this.projectNameLabel.TabIndex = 8;
            this.projectNameLabel.Text = " projectName";
            this.projectNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizeBtn.Image = ((System.Drawing.Image)(resources.GetObject("minimizeBtn.Image")));
            this.minimizeBtn.Location = new System.Drawing.Point(1405, 0);
            this.minimizeBtn.Margin = new System.Windows.Forms.Padding(4);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.Size = new System.Drawing.Size(58, 32);
            this.minimizeBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.minimizeBtn.TabIndex = 7;
            this.minimizeBtn.TabStop = false;
            this.minimizeBtn.Click += new System.EventHandler(this.minimizeBtn_Click);
            this.minimizeBtn.MouseEnter += new System.EventHandler(this.mouseEnterControlButton);
            this.minimizeBtn.MouseLeave += new System.EventHandler(this.mouseLeaveControlButton);
            // 
            // maximizeBtn
            // 
            this.maximizeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maximizeBtn.Image = ((System.Drawing.Image)(resources.GetObject("maximizeBtn.Image")));
            this.maximizeBtn.Location = new System.Drawing.Point(1462, 0);
            this.maximizeBtn.Margin = new System.Windows.Forms.Padding(4);
            this.maximizeBtn.Name = "maximizeBtn";
            this.maximizeBtn.Size = new System.Drawing.Size(58, 32);
            this.maximizeBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.maximizeBtn.TabIndex = 6;
            this.maximizeBtn.TabStop = false;
            this.maximizeBtn.Click += new System.EventHandler(this.maximizeBtn_Click);
            this.maximizeBtn.MouseEnter += new System.EventHandler(this.mouseEnterControlButton);
            this.maximizeBtn.MouseLeave += new System.EventHandler(this.mouseLeaveControlButton);
            // 
            // closeWindowBtn
            // 
            this.closeWindowBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeWindowBtn.Image = ((System.Drawing.Image)(resources.GetObject("closeWindowBtn.Image")));
            this.closeWindowBtn.Location = new System.Drawing.Point(1519, 0);
            this.closeWindowBtn.Margin = new System.Windows.Forms.Padding(4);
            this.closeWindowBtn.Name = "closeWindowBtn";
            this.closeWindowBtn.Size = new System.Drawing.Size(58, 32);
            this.closeWindowBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.closeWindowBtn.TabIndex = 5;
            this.closeWindowBtn.TabStop = false;
            this.closeWindowBtn.Click += new System.EventHandler(this.closeWindowBtn_Click);
            this.closeWindowBtn.MouseEnter += new System.EventHandler(this.mouseEnterControlButton);
            this.closeWindowBtn.MouseLeave += new System.EventHandler(this.mouseLeaveControlButton);
            // 
            // logoPicture
            // 
            this.logoPicture.Image = ((System.Drawing.Image)(resources.GetObject("logoPicture.Image")));
            this.logoPicture.Location = new System.Drawing.Point(15, 10);
            this.logoPicture.Margin = new System.Windows.Forms.Padding(4);
            this.logoPicture.Name = "logoPicture";
            this.logoPicture.Size = new System.Drawing.Size(24, 24);
            this.logoPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPicture.TabIndex = 4;
            this.logoPicture.TabStop = false;
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator8.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 34);
            // 
            // reloadAssemblyBtn
            // 
            this.reloadAssemblyBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.reloadAssemblyBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.reloadAssemblyBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.reloadAssemblyBtn.Image = ((System.Drawing.Image)(resources.GetObject("reloadAssemblyBtn.Image")));
            this.reloadAssemblyBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.reloadAssemblyBtn.Name = "reloadAssemblyBtn";
            this.reloadAssemblyBtn.Size = new System.Drawing.Size(29, 31);
            this.reloadAssemblyBtn.Text = "Reload Assembly";
            this.reloadAssemblyBtn.Click += new System.EventHandler(this.reloadAssemblyBtn_Click);
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1575, 831);
            this.Controls.Add(this.projectNameLabel);
            this.Controls.Add(this.minimizeBtn);
            this.Controls.Add(this.maximizeBtn);
            this.Controls.Add(this.closeWindowBtn);
            this.Controls.Add(this.logoPicture);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.dockPanel);
            this.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Editor";
            this.Padding = new System.Windows.Forms.Padding(8, 0, 8, 6);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "tileEngine - Internal Use Beta";
            this.Load += new System.EventHandler(this.Editor_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimizeBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximizeBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeWindowBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DarkUI.Docking.DarkDockPanel dockPanel;
        private DarkUI.Controls.DarkStatusStrip statusStrip;
        private DarkUI.Controls.DarkToolStrip toolStrip;
        private System.Windows.Forms.ToolStripDropDownButton navigateBackBtn;
        private System.Windows.Forms.ToolStripButton navigateForwardsBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton newProjectBtn;
        private System.Windows.Forms.ToolStripButton openProjectBtn;
        private System.Windows.Forms.ToolStripButton saveDocumentBtn;
        private System.Windows.Forms.ToolStripButton saveAllBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton undoBtn;
        private System.Windows.Forms.ToolStripDropDownButton redoBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripStatusLabel statusIndicator;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripStatusLabel ramUsageLabel;
        private DarkUI.Controls.DarkMenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.PictureBox logoPicture;
        private System.Windows.Forms.PictureBox closeWindowBtn;
        private System.Windows.Forms.PictureBox maximizeBtn;
        private System.Windows.Forms.PictureBox minimizeBtn;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cloneRepositoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem saveDocumentFileStripBtn;
        private System.Windows.Forms.ToolStripMenuItem saveAllFileStripBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem recentProjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recentProjectsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private DarkUI.Controls.DarkLabel projectNameLabel;
        private System.Windows.Forms.ToolStripDropDownButton startBtn;
        private System.Windows.Forms.ToolStripMenuItem startProjectBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem projectPropertiesBtn;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectPropertiesMenuBtn;
        private System.Windows.Forms.ToolStripMenuItem buildToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildBtn;
        private System.Windows.Forms.ToolStripMenuItem rebuildProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton reloadAssemblyBtn;
    }
}

