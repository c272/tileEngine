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
            this.darkLabel1 = new DarkUI.Controls.DarkLabel();
            this.tileSizeX = new DarkUI.Controls.DarkNumericUpDown();
            this.tileSizeY = new DarkUI.Controls.DarkNumericUpDown();
            this.darkLabel2 = new DarkUI.Controls.DarkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.tileSizeX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileSizeY)).BeginInit();
            this.SuspendLayout();
            // 
            // darkLabel1
            // 
            this.darkLabel1.AutoSize = true;
            this.darkLabel1.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel1.Location = new System.Drawing.Point(3, 9);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(51, 14);
            this.darkLabel1.TabIndex = 0;
            this.darkLabel1.Text = "Tile Size";
            // 
            // tileSizeX
            // 
            this.tileSizeX.Location = new System.Drawing.Point(6, 26);
            this.tileSizeX.Name = "tileSizeX";
            this.tileSizeX.Size = new System.Drawing.Size(73, 20);
            this.tileSizeX.TabIndex = 1;
            // 
            // tileSizeY
            // 
            this.tileSizeY.Location = new System.Drawing.Point(96, 26);
            this.tileSizeY.Name = "tileSizeY";
            this.tileSizeY.Size = new System.Drawing.Size(73, 20);
            this.tileSizeY.TabIndex = 2;
            // 
            // darkLabel2
            // 
            this.darkLabel2.AutoSize = true;
            this.darkLabel2.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel2.Location = new System.Drawing.Point(81, 28);
            this.darkLabel2.Name = "darkLabel2";
            this.darkLabel2.Size = new System.Drawing.Size(13, 14);
            this.darkLabel2.TabIndex = 3;
            this.darkLabel2.Text = "x";
            // 
            // ScenePropertiesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.darkLabel2);
            this.Controls.Add(this.tileSizeY);
            this.Controls.Add(this.tileSizeX);
            this.Controls.Add(this.darkLabel1);
            this.Name = "ScenePropertiesControl";
            ((System.ComponentModel.ISupportInitialize)(this.tileSizeX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileSizeY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DarkUI.Controls.DarkLabel darkLabel1;
        private DarkUI.Controls.DarkNumericUpDown tileSizeX;
        private DarkUI.Controls.DarkNumericUpDown tileSizeY;
        private DarkUI.Controls.DarkLabel darkLabel2;
    }
}
