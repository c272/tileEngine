
namespace tileEngine.Controls
{
    partial class LargeImageButton
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
            this.buttonSubtitle = new DarkUI.Controls.DarkLabel();
            this.buttonTitle = new DarkUI.Controls.DarkLabel();
            this.buttonIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.buttonIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSubtitle
            // 
            this.buttonSubtitle.AutoSize = true;
            this.buttonSubtitle.Font = new System.Drawing.Font("Roboto Light", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.buttonSubtitle.Location = new System.Drawing.Point(67, 32);
            this.buttonSubtitle.Name = "buttonSubtitle";
            this.buttonSubtitle.Size = new System.Drawing.Size(101, 17);
            this.buttonSubtitle.TabIndex = 5;
            this.buttonSubtitle.Text = "Button Subtitle";
            // 
            // buttonTitle
            // 
            this.buttonTitle.AutoSize = true;
            this.buttonTitle.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.buttonTitle.Location = new System.Drawing.Point(66, 8);
            this.buttonTitle.Name = "buttonTitle";
            this.buttonTitle.Size = new System.Drawing.Size(114, 24);
            this.buttonTitle.TabIndex = 4;
            this.buttonTitle.Text = "Button Title";
            // 
            // buttonIcon
            // 
            this.buttonIcon.Location = new System.Drawing.Point(7, 8);
            this.buttonIcon.Name = "buttonIcon";
            this.buttonIcon.Size = new System.Drawing.Size(53, 54);
            this.buttonIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.buttonIcon.TabIndex = 3;
            this.buttonIcon.TabStop = false;
            // 
            // LargeImageButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Controls.Add(this.buttonSubtitle);
            this.Controls.Add(this.buttonTitle);
            this.Controls.Add(this.buttonIcon);
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Name = "LargeImageButton";
            this.Size = new System.Drawing.Size(356, 70);
            ((System.ComponentModel.ISupportInitialize)(this.buttonIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DarkUI.Controls.DarkLabel buttonSubtitle;
        private DarkUI.Controls.DarkLabel buttonTitle;
        private System.Windows.Forms.PictureBox buttonIcon;
    }
}
