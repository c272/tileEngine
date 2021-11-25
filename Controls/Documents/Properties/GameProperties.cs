using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tileEngine.Controls
{
    /// <summary>
    /// Represents an editor for the properties of the game in tileEngine.
    /// </summary>
    public partial class GameProperties : PropertiesTab
    {
        public GameProperties(PropertiesDocument document) : base(document)
        {
            InitializeComponent();

            //Set the window size based on existing values.
            windowSizeX.Value = (decimal)ProjectManager.CurrentProject.WindowSize.X;
            windowSizeY.Value = (decimal)ProjectManager.CurrentProject.WindowSize.Y;

            //Hook events.
            windowSizeX.ValueChanged += windowSizeChanged;
            windowSizeY.ValueChanged += windowSizeChanged;
        }

        //Set unsaved changes when things are altered.
        private void windowSizeChanged(object sender, EventArgs e) { Document.Node.UnsavedChanges = true; }
    }
}
