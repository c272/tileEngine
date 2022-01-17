namespace tileEngine.Controls.Properties
{
    partial class ScenePropertiesControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScenePropertiesControl));
            this.tileSizeLbl = new DarkUI.Controls.DarkLabel();
            this.tileSizeX = new DarkUI.Controls.DarkNumericUpDown();
            this.tileSizeY = new DarkUI.Controls.DarkNumericUpDown();
            this.timesLabel = new DarkUI.Controls.DarkLabel();
            this.showGridCb = new DarkUI.Controls.DarkCheckBox();
            this.separatorPanel = new System.Windows.Forms.Panel();
            this.darkSeparator1 = new DarkUI.Controls.DarkSeparator();
            this.layerListView = new DarkUI.Controls.DarkListView();
            this.layerToolbar = new DarkUI.Controls.DarkToolStrip();
            this.addLayerButton = new System.Windows.Forms.ToolStripButton();
            this.renameLayerButton = new System.Windows.Forms.ToolStripButton();
            this.removeLayerButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.layerMoveUpButton = new System.Windows.Forms.ToolStripButton();
            this.layerMoveDownButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.tileSizeX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileSizeY)).BeginInit();
            this.separatorPanel.SuspendLayout();
            this.layerToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tileSizeLbl
            // 
            this.tileSizeLbl.AutoSize = true;
            this.tileSizeLbl.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tileSizeLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.tileSizeLbl.Location = new System.Drawing.Point(3, 7);
            this.tileSizeLbl.Name = "tileSizeLbl";
            this.tileSizeLbl.Size = new System.Drawing.Size(69, 18);
            this.tileSizeLbl.TabIndex = 0;
            this.tileSizeLbl.Text = "Tile Size:";
            // 
            // tileSizeX
            // 
            this.tileSizeX.Location = new System.Drawing.Point(77, 4);
            this.tileSizeX.Name = "tileSizeX";
            this.tileSizeX.Size = new System.Drawing.Size(51, 22);
            this.tileSizeX.TabIndex = 1;
            // 
            // tileSizeY
            // 
            this.tileSizeY.Location = new System.Drawing.Point(151, 4);
            this.tileSizeY.Name = "tileSizeY";
            this.tileSizeY.Size = new System.Drawing.Size(50, 22);
            this.tileSizeY.TabIndex = 2;
            // 
            // timesLabel
            // 
            this.timesLabel.AutoSize = true;
            this.timesLabel.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timesLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.timesLabel.Location = new System.Drawing.Point(133, 6);
            this.timesLabel.Name = "timesLabel";
            this.timesLabel.Size = new System.Drawing.Size(15, 18);
            this.timesLabel.TabIndex = 3;
            this.timesLabel.Text = "x";
            // 
            // showGridCb
            // 
            this.showGridCb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.showGridCb.AutoSize = true;
            this.showGridCb.BackColor = System.Drawing.Color.Transparent;
            this.showGridCb.Checked = true;
            this.showGridCb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showGridCb.Location = new System.Drawing.Point(322, 3);
            this.showGridCb.Name = "showGridCb";
            this.showGridCb.Size = new System.Drawing.Size(90, 20);
            this.showGridCb.TabIndex = 4;
            this.showGridCb.Text = "Show Grid";
            // 
            // separatorPanel
            // 
            this.separatorPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.separatorPanel.BackColor = System.Drawing.Color.Transparent;
            this.separatorPanel.Controls.Add(this.darkSeparator1);
            this.separatorPanel.Location = new System.Drawing.Point(3, 30);
            this.separatorPanel.Name = "separatorPanel";
            this.separatorPanel.Size = new System.Drawing.Size(409, 10);
            this.separatorPanel.TabIndex = 5;
            // 
            // darkSeparator1
            // 
            this.darkSeparator1.Dock = System.Windows.Forms.DockStyle.Top;
            this.darkSeparator1.Location = new System.Drawing.Point(0, 0);
            this.darkSeparator1.Name = "darkSeparator1";
            this.darkSeparator1.Size = new System.Drawing.Size(409, 2);
            this.darkSeparator1.TabIndex = 0;
            this.darkSeparator1.Text = "darkSeparator1";
            // 
            // layerListView
            // 
            this.layerListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layerListView.ItemHeight = 32;
            this.layerListView.Location = new System.Drawing.Point(3, 46);
            this.layerListView.Name = "layerListView";
            this.layerListView.ShowIcons = true;
            this.layerListView.Size = new System.Drawing.Size(409, 245);
            this.layerListView.TabIndex = 6;
            this.layerListView.Text = "Layer List";
            this.layerListView.SelectedIndicesChanged += new System.EventHandler(this.selectedLayerChanged);
            // 
            // layerToolbar
            // 
            this.layerToolbar.AutoSize = false;
            this.layerToolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.layerToolbar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.layerToolbar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.layerToolbar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.layerToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addLayerButton,
            this.renameLayerButton,
            this.removeLayerButton,
            this.toolStripSeparator1,
            this.layerMoveUpButton,
            this.layerMoveDownButton});
            this.layerToolbar.Location = new System.Drawing.Point(0, 294);
            this.layerToolbar.Name = "layerToolbar";
            this.layerToolbar.Padding = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.layerToolbar.Size = new System.Drawing.Size(415, 28);
            this.layerToolbar.TabIndex = 7;
            this.layerToolbar.Text = "darkToolStrip1";
            // 
            // addLayerButton
            // 
            this.addLayerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.addLayerButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addLayerButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.addLayerButton.Image = ((System.Drawing.Image)(resources.GetObject("addLayerButton.Image")));
            this.addLayerButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addLayerButton.Name = "addLayerButton";
            this.addLayerButton.Size = new System.Drawing.Size(29, 25);
            this.addLayerButton.Text = "toolStripButton1";
            this.addLayerButton.ToolTipText = "Add Layer";
            this.addLayerButton.Click += new System.EventHandler(this.addLayerButton_Click);
            // 
            // renameLayerButton
            // 
            this.renameLayerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.renameLayerButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.renameLayerButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.renameLayerButton.Image = ((System.Drawing.Image)(resources.GetObject("renameLayerButton.Image")));
            this.renameLayerButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.renameLayerButton.Name = "renameLayerButton";
            this.renameLayerButton.Size = new System.Drawing.Size(29, 25);
            this.renameLayerButton.Text = "toolStripButton2";
            this.renameLayerButton.ToolTipText = "Rename Layer";
            this.renameLayerButton.Click += new System.EventHandler(this.renameLayerButton_Click);
            // 
            // removeLayerButton
            // 
            this.removeLayerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.removeLayerButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.removeLayerButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.removeLayerButton.Image = ((System.Drawing.Image)(resources.GetObject("removeLayerButton.Image")));
            this.removeLayerButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeLayerButton.Name = "removeLayerButton";
            this.removeLayerButton.Size = new System.Drawing.Size(29, 25);
            this.removeLayerButton.Text = "toolStripButton3";
            this.removeLayerButton.ToolTipText = "Remove Layer";
            this.removeLayerButton.Click += new System.EventHandler(this.removeLayerButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // layerMoveUpButton
            // 
            this.layerMoveUpButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.layerMoveUpButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.layerMoveUpButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.layerMoveUpButton.Image = ((System.Drawing.Image)(resources.GetObject("layerMoveUpButton.Image")));
            this.layerMoveUpButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.layerMoveUpButton.Name = "layerMoveUpButton";
            this.layerMoveUpButton.Size = new System.Drawing.Size(29, 25);
            this.layerMoveUpButton.Text = "toolStripButton4";
            this.layerMoveUpButton.ToolTipText = "Move Layer Up";
            this.layerMoveUpButton.Click += new System.EventHandler(this.layerMoveUpButton_Click);
            // 
            // layerMoveDownButton
            // 
            this.layerMoveDownButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.layerMoveDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.layerMoveDownButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.layerMoveDownButton.Image = ((System.Drawing.Image)(resources.GetObject("layerMoveDownButton.Image")));
            this.layerMoveDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.layerMoveDownButton.Name = "layerMoveDownButton";
            this.layerMoveDownButton.Size = new System.Drawing.Size(29, 25);
            this.layerMoveDownButton.Text = "toolStripButton5";
            this.layerMoveDownButton.ToolTipText = "Move Layer Down";
            this.layerMoveDownButton.Click += new System.EventHandler(this.layerMoveDownButton_Click);
            // 
            // ScenePropertiesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.layerToolbar);
            this.Controls.Add(this.layerListView);
            this.Controls.Add(this.separatorPanel);
            this.Controls.Add(this.showGridCb);
            this.Controls.Add(this.timesLabel);
            this.Controls.Add(this.tileSizeY);
            this.Controls.Add(this.tileSizeX);
            this.Controls.Add(this.tileSizeLbl);
            this.Name = "ScenePropertiesControl";
            ((System.ComponentModel.ISupportInitialize)(this.tileSizeX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileSizeY)).EndInit();
            this.separatorPanel.ResumeLayout(false);
            this.layerToolbar.ResumeLayout(false);
            this.layerToolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DarkUI.Controls.DarkLabel tileSizeLbl;
        private DarkUI.Controls.DarkNumericUpDown tileSizeX;
        private DarkUI.Controls.DarkNumericUpDown tileSizeY;
        private DarkUI.Controls.DarkLabel timesLabel;
        private DarkUI.Controls.DarkCheckBox showGridCb;
        private System.Windows.Forms.Panel separatorPanel;
        private DarkUI.Controls.DarkSeparator darkSeparator1;
        private DarkUI.Controls.DarkListView layerListView;
        private DarkUI.Controls.DarkToolStrip layerToolbar;
        private System.Windows.Forms.ToolStripButton addLayerButton;
        private System.Windows.Forms.ToolStripButton renameLayerButton;
        private System.Windows.Forms.ToolStripButton removeLayerButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton layerMoveUpButton;
        private System.Windows.Forms.ToolStripButton layerMoveDownButton;
    }
}
