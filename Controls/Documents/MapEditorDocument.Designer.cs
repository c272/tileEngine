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
            this.MapEditor = new tileEngine.Controls.MapEditorControl();
            this.SuspendLayout();
            // 
            // MapEditor
            // 
            this.MapEditor.AllowDrop = true;
            this.MapEditor.BackgroundColour = System.Drawing.Color.White;
            this.MapEditor.BackgroundLineColour = System.Drawing.Color.LightGray;
            this.MapEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapEditor.GridLineWidth = 2;
            this.MapEditor.GridStep = 30F;
            this.MapEditor.Location = new System.Drawing.Point(0, 0);
            this.MapEditor.Map = null;
            this.MapEditor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MapEditor.Name = "MapEditor";
            this.MapEditor.Size = new System.Drawing.Size(112, 122);
            this.MapEditor.TabIndex = 0;
            this.MapEditor.Text = "mapEditorControl1";
            this.MapEditor.Zoom = 1F;
            // 
            // MapEditorDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MapEditor);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MapEditorDocument";
            this.Size = new System.Drawing.Size(112, 122);
            this.ResumeLayout(false);

        }

        #endregion

        public MapEditorControl MapEditor;
    }
}
