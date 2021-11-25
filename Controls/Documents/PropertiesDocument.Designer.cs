
namespace tileEngine.Controls
{
    partial class PropertiesDocument
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
            this.navigationPanel = new System.Windows.Forms.Panel();
            this.generalLabel = new DarkUI.Controls.DarkLabel();
            this.editPanel = new System.Windows.Forms.Panel();
            this.gameSettingsLbl = new DarkUI.Controls.DarkLabel();
            this.navigationPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // navigationPanel
            // 
            this.navigationPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(35)))));
            this.navigationPanel.Controls.Add(this.gameSettingsLbl);
            this.navigationPanel.Controls.Add(this.generalLabel);
            this.navigationPanel.Location = new System.Drawing.Point(0, 0);
            this.navigationPanel.Name = "navigationPanel";
            this.navigationPanel.Size = new System.Drawing.Size(185, 569);
            this.navigationPanel.TabIndex = 0;
            // 
            // generalLabel
            // 
            this.generalLabel.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generalLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.generalLabel.Location = new System.Drawing.Point(0, 0);
            this.generalLabel.Name = "generalLabel";
            this.generalLabel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.generalLabel.Size = new System.Drawing.Size(185, 40);
            this.generalLabel.TabIndex = 0;
            this.generalLabel.Text = "General";
            this.generalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.generalLabel.Click += new System.EventHandler(this.generalLabel_Click);
            // 
            // editPanel
            // 
            this.editPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editPanel.Location = new System.Drawing.Point(191, 3);
            this.editPanel.Name = "editPanel";
            this.editPanel.Size = new System.Drawing.Size(616, 563);
            this.editPanel.TabIndex = 1;
            // 
            // gameSettingsLbl
            // 
            this.gameSettingsLbl.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameSettingsLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.gameSettingsLbl.Location = new System.Drawing.Point(0, 40);
            this.gameSettingsLbl.Name = "gameSettingsLbl";
            this.gameSettingsLbl.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.gameSettingsLbl.Size = new System.Drawing.Size(185, 40);
            this.gameSettingsLbl.TabIndex = 1;
            this.gameSettingsLbl.Text = "Game";
            this.gameSettingsLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gameSettingsLbl.Click += new System.EventHandler(this.gameSettings_Click);
            // 
            // PropertiesDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.editPanel);
            this.Controls.Add(this.navigationPanel);
            this.Name = "PropertiesDocument";
            this.Size = new System.Drawing.Size(807, 569);
            this.navigationPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel navigationPanel;
        private DarkUI.Controls.DarkLabel generalLabel;
        private System.Windows.Forms.Panel editPanel;
        private DarkUI.Controls.DarkLabel gameSettingsLbl;
    }
}
