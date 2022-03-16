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
            this.darkLabel3 = new DarkUI.Controls.DarkLabel();
            this.dataText = new DarkUI.Controls.DarkTextBox();
            this.SuspendLayout();
            // 
            // darkLabel1
            // 
            this.darkLabel1.AutoSize = true;
            this.darkLabel1.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel1.Location = new System.Drawing.Point(5, 8);
            this.darkLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(63, 14);
            this.darkLabel1.TabIndex = 0;
            this.darkLabel1.Text = "Trigger On";
            // 
            // darkLabel2
            // 
            this.darkLabel2.AutoSize = true;
            this.darkLabel2.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel2.Location = new System.Drawing.Point(5, 50);
            this.darkLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.darkLabel2.Name = "darkLabel2";
            this.darkLabel2.Size = new System.Drawing.Size(48, 14);
            this.darkLabel2.TabIndex = 2;
            this.darkLabel2.Text = "Invokes";
            // 
            // functionDropdown
            // 
            this.functionDropdown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.functionDropdown.Location = new System.Drawing.Point(7, 64);
            this.functionDropdown.Margin = new System.Windows.Forms.Padding(2);
            this.functionDropdown.Name = "functionDropdown";
            this.functionDropdown.Size = new System.Drawing.Size(311, 21);
            this.functionDropdown.TabIndex = 4;
            this.functionDropdown.Text = "darkDropdownList1";
            // 
            // triggerDropdown
            // 
            this.triggerDropdown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.triggerDropdown.Location = new System.Drawing.Point(7, 22);
            this.triggerDropdown.Margin = new System.Windows.Forms.Padding(2);
            this.triggerDropdown.Name = "triggerDropdown";
            this.triggerDropdown.Size = new System.Drawing.Size(311, 21);
            this.triggerDropdown.TabIndex = 5;
            this.triggerDropdown.Text = "darkDropdownList1";
            // 
            // darkLabel3
            // 
            this.darkLabel3.AutoSize = true;
            this.darkLabel3.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel3.Location = new System.Drawing.Point(5, 96);
            this.darkLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.darkLabel3.Name = "darkLabel3";
            this.darkLabel3.Size = new System.Drawing.Size(85, 14);
            this.darkLabel3.TabIndex = 6;
            this.darkLabel3.Text = "Attached Data";
            // 
            // dataText
            // 
            this.dataText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.dataText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.dataText.Location = new System.Drawing.Point(8, 113);
            this.dataText.Multiline = true;
            this.dataText.Name = "dataText";
            this.dataText.Size = new System.Drawing.Size(310, 125);
            this.dataText.TabIndex = 7;
            this.dataText.TextChanged += new System.EventHandler(this.dataTextChanged);
            // 
            // EventPropertiesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.dataText);
            this.Controls.Add(this.darkLabel3);
            this.Controls.Add(this.triggerDropdown);
            this.Controls.Add(this.functionDropdown);
            this.Controls.Add(this.darkLabel2);
            this.Controls.Add(this.darkLabel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EventPropertiesControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DarkUI.Controls.DarkLabel darkLabel1;
        private DarkUI.Controls.DarkLabel darkLabel2;
        private DarkUI.Controls.DarkDropdownList functionDropdown;
        private DarkUI.Controls.DarkDropdownList triggerDropdown;
        private DarkUI.Controls.DarkLabel darkLabel3;
        private DarkUI.Controls.DarkTextBox dataText;
    }
}
