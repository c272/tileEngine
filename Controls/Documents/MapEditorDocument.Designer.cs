namespace tileEngine.Controls
{
    partial class MapEditorDocument
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
            this.mapEditor = new tileEngine.Controls.MapEditorControl();
            this.SuspendLayout();
            // 
            // mapEditor
            // 
            this.mapEditor.BackgroundColour = System.Drawing.Color.White;
            this.mapEditor.BackgroundLineColour = System.Drawing.Color.LightGray;
            this.mapEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapEditor.GridLineWidth = 2;
            this.mapEditor.GridStep = 30F;
            this.mapEditor.Location = new System.Drawing.Point(0, 0);
            this.mapEditor.Name = "mapEditor";
            this.mapEditor.Size = new System.Drawing.Size(150, 150);
            this.mapEditor.TabIndex = 0;
            this.mapEditor.Text = "mapEditorControl1";
            this.mapEditor.Zoom = 1F;
            // 
            // MapEditorDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mapEditor);
            this.Name = "MapEditorDocument";
            this.ResumeLayout(false);

        }

        #endregion

        private MapEditorControl mapEditor;
    }
}
