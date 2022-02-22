
namespace tileEngine.Controls
{
    partial class GeneralProperties
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
            this.namingGb = new DarkUI.Controls.DarkGroupBox();
            this.projectTitleDesc = new DarkUI.Controls.DarkLabel();
            this.projectTitleTitle = new DarkUI.Controls.DarkLabel();
            this.projectTitleTxt = new DarkUI.Controls.DarkTextBox();
            this.projectNameDesc = new DarkUI.Controls.DarkLabel();
            this.projectNameTitle = new DarkUI.Controls.DarkLabel();
            this.projectNameTxt = new DarkUI.Controls.DarkTextBox();
            this.namingGb.SuspendLayout();
            this.SuspendLayout();
            // 
            // namingGb
            // 
            this.namingGb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.namingGb.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.namingGb.Controls.Add(this.projectTitleDesc);
            this.namingGb.Controls.Add(this.projectTitleTitle);
            this.namingGb.Controls.Add(this.projectTitleTxt);
            this.namingGb.Controls.Add(this.projectNameDesc);
            this.namingGb.Controls.Add(this.projectNameTitle);
            this.namingGb.Controls.Add(this.projectNameTxt);
            this.namingGb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.namingGb.Location = new System.Drawing.Point(13, 13);
            this.namingGb.Name = "namingGb";
            this.namingGb.Size = new System.Drawing.Size(480, 208);
            this.namingGb.TabIndex = 1;
            this.namingGb.TabStop = false;
            this.namingGb.Text = "Text & Naming";
            // 
            // projectTitleDesc
            // 
            this.projectTitleDesc.AutoSize = true;
            this.projectTitleDesc.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectTitleDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.projectTitleDesc.Location = new System.Drawing.Point(9, 122);
            this.projectTitleDesc.Name = "projectTitleDesc";
            this.projectTitleDesc.Size = new System.Drawing.Size(409, 36);
            this.projectTitleDesc.TabIndex = 9;
            this.projectTitleDesc.Text = "The name of your project as seen in-game, in places like the\r\nwindow title bar an" +
    "d process name.";
            // 
            // projectTitleTitle
            // 
            this.projectTitleTitle.AutoSize = true;
            this.projectTitleTitle.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectTitleTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.projectTitleTitle.Location = new System.Drawing.Point(9, 102);
            this.projectTitleTitle.Name = "projectTitleTitle";
            this.projectTitleTitle.Size = new System.Drawing.Size(90, 18);
            this.projectTitleTitle.TabIndex = 8;
            this.projectTitleTitle.Text = "Project Title";
            // 
            // projectTitleTxt
            // 
            this.projectTitleTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.projectTitleTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.projectTitleTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.projectTitleTxt.Location = new System.Drawing.Point(12, 161);
            this.projectTitleTxt.Name = "projectTitleTxt";
            this.projectTitleTxt.Size = new System.Drawing.Size(452, 22);
            this.projectTitleTxt.TabIndex = 7;
            // 
            // projectNameDesc
            // 
            this.projectNameDesc.AutoSize = true;
            this.projectNameDesc.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectNameDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.projectNameDesc.Location = new System.Drawing.Point(9, 45);
            this.projectNameDesc.Name = "projectNameDesc";
            this.projectNameDesc.Size = new System.Drawing.Size(319, 18);
            this.projectNameDesc.TabIndex = 6;
            this.projectNameDesc.Text = "The name of your project as seen in the editor.";
            // 
            // projectNameTitle
            // 
            this.projectNameTitle.AutoSize = true;
            this.projectNameTitle.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectNameTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.projectNameTitle.Location = new System.Drawing.Point(9, 25);
            this.projectNameTitle.Name = "projectNameTitle";
            this.projectNameTitle.Size = new System.Drawing.Size(100, 18);
            this.projectNameTitle.TabIndex = 5;
            this.projectNameTitle.Text = "Project Name";
            // 
            // projectNameTxt
            // 
            this.projectNameTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.projectNameTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.projectNameTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.projectNameTxt.Location = new System.Drawing.Point(12, 66);
            this.projectNameTxt.Name = "projectNameTxt";
            this.projectNameTxt.Size = new System.Drawing.Size(452, 22);
            this.projectNameTxt.TabIndex = 1;
            // 
            // GeneralProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Controls.Add(this.namingGb);
            this.Name = "GeneralProperties";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(506, 385);
            this.namingGb.ResumeLayout(false);
            this.namingGb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DarkUI.Controls.DarkGroupBox namingGb;
        private DarkUI.Controls.DarkTextBox projectNameTxt;
        private DarkUI.Controls.DarkLabel projectTitleDesc;
        private DarkUI.Controls.DarkLabel projectTitleTitle;
        private DarkUI.Controls.DarkTextBox projectTitleTxt;
        private DarkUI.Controls.DarkLabel projectNameDesc;
        private DarkUI.Controls.DarkLabel projectNameTitle;
    }
}
