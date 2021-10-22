
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
            this.nodeGraphControl1.FieldPadding = 5F;
            this.nodeGraphControl1.GridStep = 10F;
            this.nodeGraphControl1.Location = new System.Drawing.Point(12, 33);
            this.nodeGraphControl1.Name = "nodeGraphControl1";
            this.nodeGraphControl1.NodeBackgroundColour = System.Drawing.Color.Black;
            this.nodeGraphControl1.NodeTextFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nodeGraphControl1.NodeTitleFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nodeGraphControl1.Size = new System.Drawing.Size(425, 276);
            this.nodeGraphControl1.TabIndex = 0;
            this.nodeGraphControl1.Text = "nodeGraphControl1";
            this.nodeGraphControl1.TitlePadding = 5F;
            this.nodeGraphControl1.Zoom = 1F;
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.nodeGraphControl1);
            this.Name = "Editor";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.NodeGraphControl nodeGraphControl1;
    }
}

