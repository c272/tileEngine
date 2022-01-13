namespace tileEngine.Controls
{
    partial class MapPaletteWindow
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
            this.spriteSelector = new DarkUI.Controls.DarkDropdownList();
            this.Palette = new tileEngine.Controls.MapPaletteControl();
            this.horizontalScroll = new DarkUI.Controls.DarkScrollBar();
            this.verticalScroll = new DarkUI.Controls.DarkScrollBar();
            this.SuspendLayout();
            // 
            // spriteSelector
            // 
            this.spriteSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spriteSelector.Location = new System.Drawing.Point(0, 26);
            this.spriteSelector.Name = "spriteSelector";
            this.spriteSelector.Size = new System.Drawing.Size(273, 23);
            this.spriteSelector.TabIndex = 2;
            this.spriteSelector.Text = "darkDropdownList1";
            this.spriteSelector.SelectedItemChanged += new System.EventHandler(this.selectionChanged);
            // 
            // Palette
            // 
            this.Palette.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Palette.BackgroundColour = System.Drawing.Color.White;
            this.Palette.BackgroundLineColour = System.Drawing.Color.LightGray;
            this.Palette.GridLineWidth = 2;
            this.Palette.GridStep = 30F;
            this.Palette.Location = new System.Drawing.Point(0, 49);
            this.Palette.Map = null;
            this.Palette.Name = "Palette";
            this.Palette.Size = new System.Drawing.Size(256, 187);
            this.Palette.TabIndex = 0;
            this.Palette.Text = "mapPaletteControl1";
            this.Palette.TileTextureSize = 64;
            this.Palette.ViewScroll = new Utility.Vector2f();
            this.Palette.Zoom = 1F;
            // 
            // horizontalScroll
            // 
            this.horizontalScroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.horizontalScroll.Location = new System.Drawing.Point(0, 238);
            this.horizontalScroll.Name = "horizontalScroll";
            this.horizontalScroll.ScrollOrientation = DarkUI.Controls.DarkScrollOrientation.Horizontal;
            this.horizontalScroll.Size = new System.Drawing.Size(253, 18);
            this.horizontalScroll.TabIndex = 3;
            this.horizontalScroll.Text = "darkScrollBar1";
            this.horizontalScroll.ValueChanged += new System.EventHandler<DarkUI.Controls.ScrollValueEventArgs>(this.scrollValueChanged);
            // 
            // verticalScroll
            // 
            this.verticalScroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.verticalScroll.Location = new System.Drawing.Point(257, 49);
            this.verticalScroll.Name = "verticalScroll";
            this.verticalScroll.Size = new System.Drawing.Size(16, 206);
            this.verticalScroll.TabIndex = 4;
            this.verticalScroll.Text = "darkScrollBar2";
            this.verticalScroll.ValueChanged += new System.EventHandler<DarkUI.Controls.ScrollValueEventArgs>(this.scrollValueChanged);
            // 
            // MapPaletteWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.verticalScroll);
            this.Controls.Add(this.horizontalScroll);
            this.Controls.Add(this.spriteSelector);
            this.Controls.Add(this.Palette);
            this.DefaultDockArea = DarkUI.Docking.DarkDockArea.Right;
            this.DockText = "Tile Palette";
            this.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MapPaletteWindow";
            this.Size = new System.Drawing.Size(273, 256);
            this.ResumeLayout(false);

        }

        #endregion
        private DarkUI.Controls.DarkDropdownList spriteSelector;
        public MapPaletteControl Palette;
        private DarkUI.Controls.DarkScrollBar horizontalScroll;
        private DarkUI.Controls.DarkScrollBar verticalScroll;
    }
}
