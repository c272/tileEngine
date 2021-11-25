
namespace tileEngine
{
    partial class LandingPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LandingPage));
            this.welcomeLabel = new DarkUI.Controls.DarkLabel();
            this.openRecentLabel = new DarkUI.Controls.DarkLabel();
            this.projectListView = new DarkUI.Controls.DarkListView();
            this.recentSearchBar = new DarkUI.Controls.DarkComboBox();
            this.getStartedLabel = new DarkUI.Controls.DarkLabel();
            this.closeWindowBtn = new System.Windows.Forms.PictureBox();
            this.cloneRepoBtn = new tileEngine.Controls.LargeImageButton();
            this.createProjectBtn = new tileEngine.Controls.LargeImageButton();
            this.openProjectBtn = new tileEngine.Controls.LargeImageButton();
            this.minimizeBtn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.closeWindowBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimizeBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Font = new System.Drawing.Font("Roboto", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.welcomeLabel.Location = new System.Drawing.Point(21, 37);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(410, 46);
            this.welcomeLabel.TabIndex = 0;
            this.welcomeLabel.Text = "Welcome to tileEngine.";
            // 
            // openRecentLabel
            // 
            this.openRecentLabel.AutoSize = true;
            this.openRecentLabel.Font = new System.Drawing.Font("Roboto Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openRecentLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.openRecentLabel.Location = new System.Drawing.Point(27, 102);
            this.openRecentLabel.Name = "openRecentLabel";
            this.openRecentLabel.Size = new System.Drawing.Size(121, 24);
            this.openRecentLabel.TabIndex = 1;
            this.openRecentLabel.Text = "Open Recent";
            // 
            // projectListView
            // 
            this.projectListView.Location = new System.Drawing.Point(29, 165);
            this.projectListView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.projectListView.Name = "projectListView";
            this.projectListView.Size = new System.Drawing.Size(397, 338);
            this.projectListView.TabIndex = 2;
            this.projectListView.Text = "darkListView1";
            // 
            // recentSearchBar
            // 
            this.recentSearchBar.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.recentSearchBar.FormattingEnabled = true;
            this.recentSearchBar.Location = new System.Drawing.Point(29, 129);
            this.recentSearchBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.recentSearchBar.Name = "recentSearchBar";
            this.recentSearchBar.Size = new System.Drawing.Size(399, 23);
            this.recentSearchBar.TabIndex = 4;
            // 
            // getStartedLabel
            // 
            this.getStartedLabel.AutoSize = true;
            this.getStartedLabel.Font = new System.Drawing.Font("Roboto Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getStartedLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.getStartedLabel.Location = new System.Drawing.Point(467, 102);
            this.getStartedLabel.Name = "getStartedLabel";
            this.getStartedLabel.Size = new System.Drawing.Size(108, 24);
            this.getStartedLabel.TabIndex = 5;
            this.getStartedLabel.Text = "Get Started";
            // 
            // closeWindowBtn
            // 
            this.closeWindowBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeWindowBtn.Image = ((System.Drawing.Image)(resources.GetObject("closeWindowBtn.Image")));
            this.closeWindowBtn.Location = new System.Drawing.Point(793, 0);
            this.closeWindowBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.closeWindowBtn.Name = "closeWindowBtn";
            this.closeWindowBtn.Size = new System.Drawing.Size(61, 37);
            this.closeWindowBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.closeWindowBtn.TabIndex = 12;
            this.closeWindowBtn.TabStop = false;
            this.closeWindowBtn.Click += new System.EventHandler(this.closeWindowBtn_Click);
            this.closeWindowBtn.MouseEnter += new System.EventHandler(this.mouseEnterTopButton);
            this.closeWindowBtn.MouseLeave += new System.EventHandler(this.mouseLeaveTopButton);
            // 
            // cloneRepoBtn
            // 
            this.cloneRepoBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cloneRepoBtn.Icon = ((System.Drawing.Image)(resources.GetObject("cloneRepoBtn.Icon")));
            this.cloneRepoBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cloneRepoBtn.Location = new System.Drawing.Point(469, 282);
            this.cloneRepoBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cloneRepoBtn.Name = "cloneRepoBtn";
            this.cloneRepoBtn.Size = new System.Drawing.Size(356, 70);
            this.cloneRepoBtn.Subtitle = "Clone an existing repository for a project.";
            this.cloneRepoBtn.TabIndex = 11;
            this.cloneRepoBtn.Title = "Clone Repository";
            // 
            // createProjectBtn
            // 
            this.createProjectBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.createProjectBtn.Icon = ((System.Drawing.Image)(resources.GetObject("createProjectBtn.Icon")));
            this.createProjectBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.createProjectBtn.Location = new System.Drawing.Point(469, 206);
            this.createProjectBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.createProjectBtn.Name = "createProjectBtn";
            this.createProjectBtn.Size = new System.Drawing.Size(356, 70);
            this.createProjectBtn.Subtitle = "Make a new tileEngine project.";
            this.createProjectBtn.TabIndex = 10;
            this.createProjectBtn.Title = "Create a New Project";
            // 
            // openProjectBtn
            // 
            this.openProjectBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.openProjectBtn.Icon = ((System.Drawing.Image)(resources.GetObject("openProjectBtn.Icon")));
            this.openProjectBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.openProjectBtn.Location = new System.Drawing.Point(469, 129);
            this.openProjectBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.openProjectBtn.Name = "openProjectBtn";
            this.openProjectBtn.Size = new System.Drawing.Size(356, 70);
            this.openProjectBtn.Subtitle = "Open an tileEngine project from local disk.";
            this.openProjectBtn.TabIndex = 9;
            this.openProjectBtn.Title = "Open a Project";
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizeBtn.Image = ((System.Drawing.Image)(resources.GetObject("minimizeBtn.Image")));
            this.minimizeBtn.Location = new System.Drawing.Point(733, 0);
            this.minimizeBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.Size = new System.Drawing.Size(61, 37);
            this.minimizeBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.minimizeBtn.TabIndex = 13;
            this.minimizeBtn.TabStop = false;
            this.minimizeBtn.Click += new System.EventHandler(this.minimizeBtn_Click);
            this.minimizeBtn.MouseEnter += new System.EventHandler(this.mouseEnterTopButton);
            this.minimizeBtn.MouseLeave += new System.EventHandler(this.mouseLeaveTopButton);
            // 
            // LandingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 528);
            this.Controls.Add(this.minimizeBtn);
            this.Controls.Add(this.closeWindowBtn);
            this.Controls.Add(this.cloneRepoBtn);
            this.Controls.Add(this.createProjectBtn);
            this.Controls.Add(this.openProjectBtn);
            this.Controls.Add(this.getStartedLabel);
            this.Controls.Add(this.recentSearchBar);
            this.Controls.Add(this.projectListView);
            this.Controls.Add(this.openRecentLabel);
            this.Controls.Add(this.welcomeLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "LandingPage";
            this.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.Text = "Welcome - tileEngine";
            ((System.ComponentModel.ISupportInitialize)(this.closeWindowBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimizeBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DarkUI.Controls.DarkLabel openRecentLabel;
        private DarkUI.Controls.DarkListView projectListView;
        private DarkUI.Controls.DarkComboBox recentSearchBar;
        private DarkUI.Controls.DarkLabel getStartedLabel;
        private Controls.LargeImageButton openProjectBtn;
        private Controls.LargeImageButton createProjectBtn;
        private Controls.LargeImageButton cloneRepoBtn;
        private System.Windows.Forms.PictureBox closeWindowBtn;
        private DarkUI.Controls.DarkLabel welcomeLabel;
        private System.Windows.Forms.PictureBox minimizeBtn;
    }
}