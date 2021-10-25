
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
            this.SuspendLayout();
            // 
            // nodeGraphControl1
            // 
            this.nodeGraphControl1.BackgroundColour = System.Drawing.Color.White;
            this.nodeGraphControl1.BackgroundLineColour = System.Drawing.Color.WhiteSmoke;
            this.nodeGraphControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nodeGraphControl1.FieldPadding = 5F;
            this.nodeGraphControl1.GlobalPadding = 10F;
            this.nodeGraphControl1.GridStep = 30F;
            this.nodeGraphControl1.Location = new System.Drawing.Point(0, 0);
            this.nodeGraphControl1.Margin = new System.Windows.Forms.Padding(2);
            this.nodeGraphControl1.Name = "nodeGraphControl1";
            this.nodeGraphControl1.NodeBackgroundColour = System.Drawing.Color.Black;
            this.nodeGraphControl1.NodeRoundingRadius = 10;
            this.nodeGraphControl1.NodeTextColour = System.Drawing.Color.White;
            this.nodeGraphControl1.NodeTextFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nodeGraphControl1.NodeTitleFont = new System.Drawing.Font("Fjalla One", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nodeGraphControl1.Size = new System.Drawing.Size(600, 366);
            this.nodeGraphControl1.TabIndex = 0;
            this.nodeGraphControl1.Text = "nodeGraphControl1";
            this.nodeGraphControl1.TitlePadding = 10F;
            this.nodeGraphControl1.Zoom = 1.4F;
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.nodeGraphControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Editor";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Editor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.NodeGraphControl nodeGraphControl1;
    }
}

