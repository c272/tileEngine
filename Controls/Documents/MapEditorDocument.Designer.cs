namespace tileEngine.Controls
{
    partial class MapEditorDocument
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapEditorDocument));
            this.MapEditor = new tileEngine.Controls.MapEditorControl();
            this.darkToolStrip1 = new DarkUI.Controls.DarkToolStrip();
            this.selectToolButton = new System.Windows.Forms.ToolStripButton();
            this.panToolButton = new System.Windows.Forms.ToolStripButton();
            this.areaSelectToolButton = new System.Windows.Forms.ToolStripButton();
            this.pencilToolButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.eventEditModeBtn = new System.Windows.Forms.ToolStripButton();
            this.collisionEditModeBtn = new System.Windows.Forms.ToolStripButton();
            this.tileEditModeBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.darkToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MapEditor
            // 
            this.MapEditor.AllowDrop = true;
            this.MapEditor.BackgroundColour = System.Drawing.Color.White;
            this.MapEditor.BackgroundLineColour = System.Drawing.Color.LightGray;
            this.MapEditor.CollisionBackgroundColour = System.Drawing.Color.Red;
            this.MapEditor.CollisionForegroundColour = System.Drawing.Color.White;
            this.MapEditor.CollisionOpacity = 0.75F;
            this.MapEditor.CollisionPipSize = 2;
            this.MapEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapEditor.DoGridDraw = true;
            this.MapEditor.EditMode = tileEngine.Controls.MapEditMode.Tiles;
            this.MapEditor.EditTool = tileEngine.Controls.MapEditTool.Select;
            this.MapEditor.EventColour = System.Drawing.Color.Orange;
            this.MapEditor.EventOpacity = 0.75F;
            this.MapEditor.GridLineWidth = 2;
            this.MapEditor.GridStep = 30F;
            this.MapEditor.Location = new System.Drawing.Point(0, 0);
            this.MapEditor.Map = null;
            this.MapEditor.Margin = new System.Windows.Forms.Padding(2);
            this.MapEditor.Name = "MapEditor";
            this.MapEditor.Palette = null;
            this.MapEditor.SelectedLayer = null;
            this.MapEditor.SelectionColour = System.Drawing.Color.White;
            this.MapEditor.SelectionWidth = 2;
            this.MapEditor.Size = new System.Drawing.Size(423, 312);
            this.MapEditor.TabIndex = 0;
            this.MapEditor.Text = "mapEditorControl1";
            this.MapEditor.Zoom = 1F;
            // 
            // darkToolStrip1
            // 
            this.darkToolStrip1.AutoSize = false;
            this.darkToolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.darkToolStrip1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectToolButton,
            this.panToolButton,
            this.areaSelectToolButton,
            this.pencilToolButton,
            this.toolStripSeparator1,
            this.eventEditModeBtn,
            this.collisionEditModeBtn,
            this.tileEditModeBtn,
            this.toolStripLabel1});
            this.darkToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.darkToolStrip1.Name = "darkToolStrip1";
            this.darkToolStrip1.Padding = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.darkToolStrip1.Size = new System.Drawing.Size(423, 28);
            this.darkToolStrip1.TabIndex = 1;
            this.darkToolStrip1.Text = "darkToolStrip1";
            // 
            // selectToolButton
            // 
            this.selectToolButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.selectToolButton.Checked = true;
            this.selectToolButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.selectToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.selectToolButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.selectToolButton.Image = ((System.Drawing.Image)(resources.GetObject("selectToolButton.Image")));
            this.selectToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectToolButton.Name = "selectToolButton";
            this.selectToolButton.Size = new System.Drawing.Size(23, 25);
            this.selectToolButton.Text = "Select";
            this.selectToolButton.ToolTipText = "Select";
            this.selectToolButton.Click += new System.EventHandler(this.selectToolButton_Click);
            // 
            // panToolButton
            // 
            this.panToolButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.panToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.panToolButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.panToolButton.Image = ((System.Drawing.Image)(resources.GetObject("panToolButton.Image")));
            this.panToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.panToolButton.Name = "panToolButton";
            this.panToolButton.Size = new System.Drawing.Size(23, 25);
            this.panToolButton.Text = "Grab & Pan";
            this.panToolButton.ToolTipText = "Grab/Pan";
            this.panToolButton.Click += new System.EventHandler(this.panToolButton_Click);
            // 
            // areaSelectToolButton
            // 
            this.areaSelectToolButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.areaSelectToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.areaSelectToolButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.areaSelectToolButton.Image = ((System.Drawing.Image)(resources.GetObject("areaSelectToolButton.Image")));
            this.areaSelectToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.areaSelectToolButton.Name = "areaSelectToolButton";
            this.areaSelectToolButton.Size = new System.Drawing.Size(23, 25);
            this.areaSelectToolButton.Text = "Area Select";
            this.areaSelectToolButton.Click += new System.EventHandler(this.areaSelectToolButton_Click);
            // 
            // pencilToolButton
            // 
            this.pencilToolButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.pencilToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pencilToolButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.pencilToolButton.Image = ((System.Drawing.Image)(resources.GetObject("pencilToolButton.Image")));
            this.pencilToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pencilToolButton.Name = "pencilToolButton";
            this.pencilToolButton.Size = new System.Drawing.Size(23, 25);
            this.pencilToolButton.Text = "Pencil";
            this.pencilToolButton.Click += new System.EventHandler(this.pencilToolButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // eventEditModeBtn
            // 
            this.eventEditModeBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.eventEditModeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.eventEditModeBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.eventEditModeBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.eventEditModeBtn.Image = ((System.Drawing.Image)(resources.GetObject("eventEditModeBtn.Image")));
            this.eventEditModeBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.eventEditModeBtn.Name = "eventEditModeBtn";
            this.eventEditModeBtn.Size = new System.Drawing.Size(23, 25);
            this.eventEditModeBtn.Text = "Event Edit Mode";
            this.eventEditModeBtn.Click += new System.EventHandler(this.eventEditModeBtn_Click);
            // 
            // collisionEditModeBtn
            // 
            this.collisionEditModeBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.collisionEditModeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.collisionEditModeBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.collisionEditModeBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.collisionEditModeBtn.Image = ((System.Drawing.Image)(resources.GetObject("collisionEditModeBtn.Image")));
            this.collisionEditModeBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.collisionEditModeBtn.Name = "collisionEditModeBtn";
            this.collisionEditModeBtn.Size = new System.Drawing.Size(23, 25);
            this.collisionEditModeBtn.Text = "Collision Edit Mode";
            this.collisionEditModeBtn.Click += new System.EventHandler(this.collisionEditModeBtn_Click);
            // 
            // tileEditModeBtn
            // 
            this.tileEditModeBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tileEditModeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.tileEditModeBtn.Checked = true;
            this.tileEditModeBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tileEditModeBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tileEditModeBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.tileEditModeBtn.Image = ((System.Drawing.Image)(resources.GetObject("tileEditModeBtn.Image")));
            this.tileEditModeBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tileEditModeBtn.Name = "tileEditModeBtn";
            this.tileEditModeBtn.Size = new System.Drawing.Size(23, 25);
            this.tileEditModeBtn.Text = "Tile Edit Mode";
            this.tileEditModeBtn.Click += new System.EventHandler(this.tileEditModeBtn_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(61, 25);
            this.toolStripLabel1.Text = "Edit Mode";
            this.toolStripLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MapEditorDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.darkToolStrip1);
            this.Controls.Add(this.MapEditor);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MapEditorDocument";
            this.Size = new System.Drawing.Size(423, 312);
            this.darkToolStrip1.ResumeLayout(false);
            this.darkToolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public MapEditorControl MapEditor;
        private DarkUI.Controls.DarkToolStrip darkToolStrip1;
        private System.Windows.Forms.ToolStripButton selectToolButton;
        private System.Windows.Forms.ToolStripButton areaSelectToolButton;
        private System.Windows.Forms.ToolStripButton pencilToolButton;
        private System.Windows.Forms.ToolStripButton panToolButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton tileEditModeBtn;
        private System.Windows.Forms.ToolStripButton collisionEditModeBtn;
        private System.Windows.Forms.ToolStripButton eventEditModeBtn;
    }
}
