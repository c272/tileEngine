
namespace tileEngine.Controls
{
    partial class CreateProjectControl
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
            this.titleLabel = new DarkUI.Controls.DarkLabel();
            this.darkLabel1 = new DarkUI.Controls.DarkLabel();
            this.darkLabel2 = new DarkUI.Controls.DarkLabel();
            this.chooseFileLocationBtn = new DarkUI.Controls.DarkButton();
            this.createBtn = new DarkUI.Controls.DarkButton();
            this.createRepoCheck = new DarkUI.Controls.DarkCheckBox();
            this.backBtn = new DarkUI.Controls.DarkButton();
            this.subtitleLabel = new DarkUI.Controls.DarkLabel();
            this.fileLocationText = new tileEngine.Controls.ValidationTextBox();
            this.projectNameText = new tileEngine.Controls.ValidationTextBox();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Roboto", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.titleLabel.Location = new System.Drawing.Point(3, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(259, 44);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Create Project";
            // 
            // darkLabel1
            // 
            this.darkLabel1.AutoSize = true;
            this.darkLabel1.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel1.Location = new System.Drawing.Point(8, 94);
            this.darkLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(100, 18);
            this.darkLabel1.TabIndex = 2;
            this.darkLabel1.Text = "Project Name";
            // 
            // darkLabel2
            // 
            this.darkLabel2.AutoSize = true;
            this.darkLabel2.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel2.Location = new System.Drawing.Point(8, 158);
            this.darkLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.darkLabel2.Name = "darkLabel2";
            this.darkLabel2.Size = new System.Drawing.Size(95, 18);
            this.darkLabel2.TabIndex = 4;
            this.darkLabel2.Text = "File Location";
            // 
            // chooseFileLocationBtn
            // 
            this.chooseFileLocationBtn.Location = new System.Drawing.Point(513, 178);
            this.chooseFileLocationBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chooseFileLocationBtn.Name = "chooseFileLocationBtn";
            this.chooseFileLocationBtn.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.chooseFileLocationBtn.Size = new System.Drawing.Size(39, 25);
            this.chooseFileLocationBtn.TabIndex = 6;
            this.chooseFileLocationBtn.Text = "...";
            this.chooseFileLocationBtn.Click += new System.EventHandler(this.chooseFileLocationBtn_Click);
            // 
            // createBtn
            // 
            this.createBtn.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createBtn.Location = new System.Drawing.Point(672, 418);
            this.createBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.createBtn.Name = "createBtn";
            this.createBtn.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.createBtn.Size = new System.Drawing.Size(129, 41);
            this.createBtn.TabIndex = 7;
            this.createBtn.Text = "Create";
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // createRepoCheck
            // 
            this.createRepoCheck.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createRepoCheck.Location = new System.Drawing.Point(12, 210);
            this.createRepoCheck.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.createRepoCheck.Name = "createRepoCheck";
            this.createRepoCheck.Size = new System.Drawing.Size(339, 30);
            this.createRepoCheck.TabIndex = 8;
            this.createRepoCheck.Text = "Create new repository for project (Git)";
            // 
            // backBtn
            // 
            this.backBtn.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backBtn.Location = new System.Drawing.Point(535, 418);
            this.backBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.backBtn.Name = "backBtn";
            this.backBtn.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.backBtn.Size = new System.Drawing.Size(129, 41);
            this.backBtn.TabIndex = 9;
            this.backBtn.Text = "Back";
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // subtitleLabel
            // 
            this.subtitleLabel.AutoSize = true;
            this.subtitleLabel.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.subtitleLabel.Location = new System.Drawing.Point(8, 46);
            this.subtitleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new System.Drawing.Size(513, 18);
            this.subtitleLabel.TabIndex = 10;
            this.subtitleLabel.Text = "Give your project a name and a file location to save to, and we\'ll do the rest.";
            // 
            // fileLocationText
            // 
            this.fileLocationText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.fileLocationText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fileLocationText.Enabled = false;
            this.fileLocationText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.fileLocationText.Location = new System.Drawing.Point(12, 178);
            this.fileLocationText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.fileLocationText.Name = "fileLocationText";
            this.fileLocationText.Size = new System.Drawing.Size(493, 22);
            this.fileLocationText.TabIndex = 12;
            this.fileLocationText.Valid = true;
            // 
            // projectNameText
            // 
            this.projectNameText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.projectNameText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.projectNameText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.projectNameText.Location = new System.Drawing.Point(12, 114);
            this.projectNameText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.projectNameText.Name = "projectNameText";
            this.projectNameText.Size = new System.Drawing.Size(539, 22);
            this.projectNameText.TabIndex = 11;
            this.projectNameText.Valid = true;
            // 
            // CreateProjectControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Controls.Add(this.fileLocationText);
            this.Controls.Add(this.projectNameText);
            this.Controls.Add(this.subtitleLabel);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.createRepoCheck);
            this.Controls.Add(this.createBtn);
            this.Controls.Add(this.chooseFileLocationBtn);
            this.Controls.Add(this.darkLabel2);
            this.Controls.Add(this.darkLabel1);
            this.Controls.Add(this.titleLabel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CreateProjectControl";
            this.Size = new System.Drawing.Size(812, 463);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DarkUI.Controls.DarkLabel titleLabel;
        private DarkUI.Controls.DarkLabel darkLabel1;
        private DarkUI.Controls.DarkLabel darkLabel2;
        private DarkUI.Controls.DarkButton chooseFileLocationBtn;
        private DarkUI.Controls.DarkButton createBtn;
        private DarkUI.Controls.DarkCheckBox createRepoCheck;
        private DarkUI.Controls.DarkButton backBtn;
        private DarkUI.Controls.DarkLabel subtitleLabel;
        private ValidationTextBox projectNameText;
        private ValidationTextBox fileLocationText;
    }
}
