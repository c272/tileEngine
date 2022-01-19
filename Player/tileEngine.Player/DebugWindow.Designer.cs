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
            this.debugOutput = new System.Windows.Forms.TextBox();
            this.drawCollidersCb = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // debugOutput
            // 
            this.debugOutput.Location = new System.Drawing.Point(-1, 30);
            this.debugOutput.Multiline = true;
            this.debugOutput.Name = "debugOutput";
            this.debugOutput.Size = new System.Drawing.Size(346, 279);
            this.debugOutput.TabIndex = 0;
            // 
            // drawCollidersCb
            // 
            this.drawCollidersCb.AutoSize = true;
            this.drawCollidersCb.Location = new System.Drawing.Point(6, 6);
            this.drawCollidersCb.Name = "drawCollidersCb";
            this.drawCollidersCb.Size = new System.Drawing.Size(93, 17);
            this.drawCollidersCb.TabIndex = 1;
            this.drawCollidersCb.Text = "Draw Colliders";
            this.drawCollidersCb.UseVisualStyleBackColor = true;
            this.drawCollidersCb.CheckedChanged += new System.EventHandler(this.drawCollidersChanged);
            // 
            // DebugWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 305);
            this.Controls.Add(this.drawCollidersCb);
            this.Controls.Add(this.debugOutput);
            this.Name = "DebugWindow";
            this.Text = "tileEngine Player - Debug Window";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox debugOutput;
        private System.Windows.Forms.CheckBox drawCollidersCb;
    }
}