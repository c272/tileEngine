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
    /// Represents the map editor document for a single scene in tileEngine.
    /// </summary>
    public partial class MapEditorDocument : ProjectDocument
    {
        public MapEditorDocument(ProjectSceneNode scene) : base(scene)
        {
            InitializeComponent();

            //Style document from DarkUI.
            mapEditor.SetThemeFromDarkUI();
        }
    }
}
