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
            this.palette = new tileEngine.Controls.MapPaletteControl();
            this.SuspendLayout();
            // 
            // palette
            // 
            this.palette.BackgroundColour = System.Drawing.Color.White;
            this.palette.BackgroundLineColour = System.Drawing.Color.LightGray;
            this.palette.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palette.GridLineWidth = 2;
            this.palette.GridStep = 30F;
            this.palette.Location = new System.Drawing.Point(0, 25);
            this.palette.Name = "palette";
            this.palette.Size = new System.Drawing.Size(150, 144);
            this.palette.TabIndex = 0;
            this.palette.Text = "mapPaletteControl1";
            this.palette.Zoom = 1F;
            // 
            // MapPaletteWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.palette);
            this.DefaultDockArea = DarkUI.Docking.DarkDockArea.Right;
            this.DockText = "Tile Palette";
            this.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MapPaletteWindow";
            this.Size = new System.Drawing.Size(150, 169);
            this.ResumeLayout(false);

        }

        #endregion

        private MapPaletteControl palette;
    }
}
