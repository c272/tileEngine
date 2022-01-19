namespace tileEngine.Controls.Properties
{
    partial class EventPropertiesControl
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
            this.darkLabel2 = new DarkUI.Controls.DarkLabel();
            this.functionDropdown = new DarkUI.Controls.DarkDropdownList();
            this.triggerDropdown = new DarkUI.Controls.DarkDropdownList();
            this.SuspendLayout();
            // 
            // darkLabel1
            // 
            this.darkLabel1.AutoSize = true;
            this.darkLabel1.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel1.Location = new System.Drawing.Point(6, 10);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(76, 18);
            this.darkLabel1.TabIndex = 0;
            this.darkLabel1.Text = "Trigger On";
            // 
            // darkLabel2
            // 
            this.darkLabel2.AutoSize = true;
            this.darkLabel2.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel2.Location = new System.Drawing.Point(6, 63);
            this.darkLabel2.Name = "darkLabel2";
            this.darkLabel2.Size = new System.Drawing.Size(104, 18);
            this.darkLabel2.TabIndex = 2;
            this.darkLabel2.Text = "Calls Function";
            // 
            // functionDropdown
            // 
            this.functionDropdown.Location = new System.Drawing.Point(9, 80);
            this.functionDropdown.Name = "functionDropdown";
            this.functionDropdown.Size = new System.Drawing.Size(171, 26);
            this.functionDropdown.TabIndex = 4;
            this.functionDropdown.Text = "darkDropdownList1";
            // 
            // triggerDropdown
            // 
            this.triggerDropdown.Location = new System.Drawing.Point(9, 27);
            this.triggerDropdown.Name = "triggerDropdown";
            this.triggerDropdown.Size = new System.Drawing.Size(171, 26);
            this.triggerDropdown.TabIndex = 5;
            this.triggerDropdown.Text = "darkDropdownList1";
            // 
            // EventPropertiesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.triggerDropdown);
            this.Controls.Add(this.functionDropdown);
            this.Controls.Add(this.darkLabel2);
            this.Controls.Add(this.darkLabel1);
            this.Name = "EventPropertiesControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DarkUI.Controls.DarkLabel darkLabel1;
        private DarkUI.Controls.DarkLabel darkLabel2;
        private DarkUI.Controls.DarkDropdownList functionDropdown;
        private DarkUI.Controls.DarkDropdownList triggerDropdown;
    }
}
