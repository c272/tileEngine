
namespace tileEngine.Controls
{
    partial class GameProperties
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
            this.windowSizeTitle = new DarkUI.Controls.DarkLabel();
            this.dimensionsGb = new DarkUI.Controls.DarkGroupBox();
            this.windowSizeDesc = new DarkUI.Controls.DarkLabel();
            this.windowSizeY = new DarkUI.Controls.DarkNumericUpDown();
            this.darkLabel2 = new DarkUI.Controls.DarkLabel();
            this.windowSizeX = new DarkUI.Controls.DarkNumericUpDown();
            this.dimensionsGb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.windowSizeY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowSizeX)).BeginInit();
            this.SuspendLayout();
            // 
            // windowSizeTitle
            // 
            this.windowSizeTitle.AutoSize = true;
            this.windowSizeTitle.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowSizeTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.windowSizeTitle.Location = new System.Drawing.Point(8, 26);
            this.windowSizeTitle.Name = "windowSizeTitle";
            this.windowSizeTitle.Size = new System.Drawing.Size(93, 18);
            this.windowSizeTitle.TabIndex = 0;
            this.windowSizeTitle.Text = "Window Size";
            // 
            // dimensionsGb
            // 
            this.dimensionsGb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dimensionsGb.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.dimensionsGb.Controls.Add(this.windowSizeDesc);
            this.dimensionsGb.Controls.Add(this.windowSizeY);
            this.dimensionsGb.Controls.Add(this.darkLabel2);
            this.dimensionsGb.Controls.Add(this.windowSizeX);
            this.dimensionsGb.Controls.Add(this.windowSizeTitle);
            this.dimensionsGb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.dimensionsGb.Location = new System.Drawing.Point(13, 13);
            this.dimensionsGb.Name = "dimensionsGb";
            this.dimensionsGb.Size = new System.Drawing.Size(480, 130);
            this.dimensionsGb.TabIndex = 2;
            this.dimensionsGb.TabStop = false;
            this.dimensionsGb.Text = "Dimensions";
            // 
            // windowSizeDesc
            // 
            this.windowSizeDesc.AutoSize = true;
            this.windowSizeDesc.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowSizeDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.windowSizeDesc.Location = new System.Drawing.Point(8, 46);
            this.windowSizeDesc.Name = "windowSizeDesc";
            this.windowSizeDesc.Size = new System.Drawing.Size(428, 36);
            this.windowSizeDesc.TabIndex = 4;
            this.windowSizeDesc.Text = "Represents the default size of your game\'s window. You should\r\nfit this to work w" +
    "ith the assets you have available.";
            // 
            // windowSizeY
            // 
            this.windowSizeY.Location = new System.Drawing.Point(139, 91);
            this.windowSizeY.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.windowSizeY.Name = "windowSizeY";
            this.windowSizeY.Size = new System.Drawing.Size(102, 22);
            this.windowSizeY.TabIndex = 3;
            // 
            // darkLabel2
            // 
            this.darkLabel2.AutoSize = true;
            this.darkLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel2.Location = new System.Drawing.Point(119, 93);
            this.darkLabel2.Name = "darkLabel2";
            this.darkLabel2.Size = new System.Drawing.Size(13, 16);
            this.darkLabel2.TabIndex = 2;
            this.darkLabel2.Text = "x";
            // 
            // windowSizeX
            // 
            this.windowSizeX.Location = new System.Drawing.Point(11, 91);
            this.windowSizeX.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.windowSizeX.Name = "windowSizeX";
            this.windowSizeX.Size = new System.Drawing.Size(102, 22);
            this.windowSizeX.TabIndex = 1;
            // 
            // GameProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.dimensionsGb);
            this.Name = "GameProperties";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(508, 417);
            this.dimensionsGb.ResumeLayout(false);
            this.dimensionsGb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.windowSizeY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowSizeX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DarkUI.Controls.DarkLabel windowSizeTitle;
        private DarkUI.Controls.DarkGroupBox dimensionsGb;
        private DarkUI.Controls.DarkNumericUpDown windowSizeX;
        private DarkUI.Controls.DarkLabel windowSizeDesc;
        private DarkUI.Controls.DarkNumericUpDown windowSizeY;
        private DarkUI.Controls.DarkLabel darkLabel2;
    }
}
