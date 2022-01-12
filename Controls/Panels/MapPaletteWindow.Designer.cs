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
            this.SuspendLayout();
            // 
            // spriteSelector
            // 
            this.spriteSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spriteSelector.Location = new System.Drawing.Point(0, 26);
            this.spriteSelector.Name = "spriteSelector";
            this.spriteSelector.Size = new System.Drawing.Size(150, 23);
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
            this.Palette.Size = new System.Drawing.Size(150, 120);
            this.Palette.TabIndex = 0;
            this.Palette.Text = "mapPaletteControl1";
            this.Palette.TileTextureSize = 64;
            this.Palette.Zoom = 1F;
            // 
            // MapPaletteWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spriteSelector);
            this.Controls.Add(this.Palette);
            this.DefaultDockArea = DarkUI.Docking.DarkDockArea.Right;
            this.DockText = "Tile Palette";
            this.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MapPaletteWindow";
            this.Size = new System.Drawing.Size(150, 169);
            this.ResumeLayout(false);

        }

        #endregion
        private DarkUI.Controls.DarkDropdownList spriteSelector;
        public MapPaletteControl Palette;
    }
}
