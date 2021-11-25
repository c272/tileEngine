
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
            this.titleLabel.Location = new System.Drawing.Point(2, 0);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(209, 37);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Create Project";
            // 
            // darkLabel1
            // 
            this.darkLabel1.AutoSize = true;
            this.darkLabel1.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel1.Location = new System.Drawing.Point(6, 76);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(81, 14);
            this.darkLabel1.TabIndex = 2;
            this.darkLabel1.Text = "Project Name";
            // 
            // darkLabel2
            // 
            this.darkLabel2.AutoSize = true;
            this.darkLabel2.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel2.Location = new System.Drawing.Point(6, 128);
            this.darkLabel2.Name = "darkLabel2";
            this.darkLabel2.Size = new System.Drawing.Size(76, 14);
            this.darkLabel2.TabIndex = 4;
            this.darkLabel2.Text = "File Location";
            // 
            // chooseFileLocationBtn
            // 
            this.chooseFileLocationBtn.Location = new System.Drawing.Point(385, 145);
            this.chooseFileLocationBtn.Name = "chooseFileLocationBtn";
            this.chooseFileLocationBtn.Padding = new System.Windows.Forms.Padding(5);
            this.chooseFileLocationBtn.Size = new System.Drawing.Size(29, 20);
            this.chooseFileLocationBtn.TabIndex = 6;
            this.chooseFileLocationBtn.Text = "...";
            this.chooseFileLocationBtn.Click += new System.EventHandler(this.chooseFileLocationBtn_Click);
            // 
            // createBtn
            // 
            this.createBtn.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createBtn.Location = new System.Drawing.Point(504, 340);
            this.createBtn.Name = "createBtn";
            this.createBtn.Padding = new System.Windows.Forms.Padding(5);
            this.createBtn.Size = new System.Drawing.Size(97, 33);
            this.createBtn.TabIndex = 7;
            this.createBtn.Text = "Create";
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // createRepoCheck
            // 
            this.createRepoCheck.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createRepoCheck.Location = new System.Drawing.Point(9, 171);
            this.createRepoCheck.Name = "createRepoCheck";
            this.createRepoCheck.Size = new System.Drawing.Size(254, 24);
            this.createRepoCheck.TabIndex = 8;
            this.createRepoCheck.Text = "Create new repository for project (Git)";
            // 
            // backBtn
            // 
            this.backBtn.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backBtn.Location = new System.Drawing.Point(401, 340);
            this.backBtn.Name = "backBtn";
            this.backBtn.Padding = new System.Windows.Forms.Padding(5);
            this.backBtn.Size = new System.Drawing.Size(97, 33);
            this.backBtn.TabIndex = 9;
            this.backBtn.Text = "Back";
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // subtitleLabel
            // 
            this.subtitleLabel.AutoSize = true;
            this.subtitleLabel.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.subtitleLabel.Location = new System.Drawing.Point(6, 37);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new System.Drawing.Size(412, 14);
            this.subtitleLabel.TabIndex = 10;
            this.subtitleLabel.Text = "Give your project a name and a file location to save to, and we\'ll do the rest.";
            // 
            // fileLocationText
            // 
            this.fileLocationText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.fileLocationText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fileLocationText.Enabled = false;
            this.fileLocationText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.fileLocationText.Location = new System.Drawing.Point(9, 145);
            this.fileLocationText.Name = "fileLocationText";
            this.fileLocationText.Size = new System.Drawing.Size(370, 20);
            this.fileLocationText.TabIndex = 12;
            this.fileLocationText.Valid = true;
            // 
            // projectNameText
            // 
            this.projectNameText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.projectNameText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.projectNameText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.projectNameText.Location = new System.Drawing.Point(9, 93);
            this.projectNameText.Name = "projectNameText";
            this.projectNameText.Size = new System.Drawing.Size(405, 20);
            this.projectNameText.TabIndex = 11;
            this.projectNameText.Valid = true;
            // 
            // CreateProjectControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.Name = "CreateProjectControl";
            this.Size = new System.Drawing.Size(609, 376);
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
