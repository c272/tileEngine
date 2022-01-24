namespace tileEngine.Player
{
    partial class DebugWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DebugWindow));
            this.drawCollidersCb = new DarkUI.Controls.DarkCheckBox();
            this.debugOutput = new DarkUI.Controls.DarkTextBox();
            this.SuspendLayout();
            // 
            // drawCollidersCb
            // 
            this.drawCollidersCb.AutoSize = true;
            this.drawCollidersCb.Location = new System.Drawing.Point(10, 9);
            this.drawCollidersCb.Name = "drawCollidersCb";
            this.drawCollidersCb.Size = new System.Drawing.Size(116, 20);
            this.drawCollidersCb.TabIndex = 0;
            this.drawCollidersCb.Text = "Draw Colliders";
            this.drawCollidersCb.CheckedChanged += new System.EventHandler(this.drawCollidersChanged);
            // 
            // debugOutput
            // 
            this.debugOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.debugOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.debugOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.debugOutput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.debugOutput.Location = new System.Drawing.Point(0, 38);
            this.debugOutput.Multiline = true;
            this.debugOutput.Name = "debugOutput";
            this.debugOutput.Size = new System.Drawing.Size(366, 296);
            this.debugOutput.TabIndex = 1;
            // 
            // DebugWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 330);
            this.Controls.Add(this.debugOutput);
            this.Controls.Add(this.drawCollidersCb);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DebugWindow";
            this.Text = "tileEngine - Debug Window";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DarkUI.Controls.DarkCheckBox drawCollidersCb;
        private DarkUI.Controls.DarkTextBox debugOutput;
    }
}