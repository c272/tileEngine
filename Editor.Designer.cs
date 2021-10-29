
namespace easyCase
{
    partial class Editor
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
            this.nodeGraphControl1 = new easyCase.Controls.NodeGraphControl();
            this.executeBtn = new System.Windows.Forms.Button();
            this.nodeGraphControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nodeGraphControl1
            // 
            this.nodeGraphControl1.BackgroundColour = System.Drawing.Color.White;
            this.nodeGraphControl1.BackgroundLineColour = System.Drawing.Color.WhiteSmoke;
            this.nodeGraphControl1.Controls.Add(this.executeBtn);
            this.nodeGraphControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nodeGraphControl1.FieldPadding = 10F;
            this.nodeGraphControl1.GlobalPadding = 10F;
            this.nodeGraphControl1.GridStep = 30F;
            this.nodeGraphControl1.Location = new System.Drawing.Point(0, 0);
            this.nodeGraphControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nodeGraphControl1.Name = "nodeGraphControl1";
            this.nodeGraphControl1.NodeBackgroundColour = System.Drawing.SystemColors.Control;
            this.nodeGraphControl1.NodeBackgroundOpacity = 200;
            this.nodeGraphControl1.NodeConnectionGap = 80;
            this.nodeGraphControl1.NodeConnectorPadding = 5F;
            this.nodeGraphControl1.NodeErrorColour = System.Drawing.Color.Red;
            this.nodeGraphControl1.NodeRoundingRadius = 10;
            this.nodeGraphControl1.NodeTextColour = System.Drawing.Color.Black;
            this.nodeGraphControl1.NodeTextFont = new System.Drawing.Font("Montserrat", 10.8F);
            this.nodeGraphControl1.NodeTitleFont = new System.Drawing.Font("Montserrat SemiBold", 10.8F);
            this.nodeGraphControl1.Size = new System.Drawing.Size(800, 450);
            this.nodeGraphControl1.TabIndex = 0;
            this.nodeGraphControl1.Text = "nodeGraphControl1";
            this.nodeGraphControl1.TitlePadding = 10F;
            this.nodeGraphControl1.Zoom = 1F;
            // 
            // executeBtn
            // 
            this.executeBtn.Location = new System.Drawing.Point(0, 0);
            this.executeBtn.Name = "executeBtn";
            this.executeBtn.Size = new System.Drawing.Size(100, 29);
            this.executeBtn.TabIndex = 0;
            this.executeBtn.Text = "Execute";
            this.executeBtn.UseVisualStyleBackColor = true;
            this.executeBtn.Click += new System.EventHandler(this.executeBtn_Click);
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.nodeGraphControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Editor";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Editor_Load);
            this.nodeGraphControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.NodeGraphControl nodeGraphControl1;
        private System.Windows.Forms.Button executeBtn;
    }
}

