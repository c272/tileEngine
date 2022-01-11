﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tileEngine.Controls.Properties;

namespace tileEngine.Controls
{
    /// <summary>
    /// Represents the map editor document for a single scene in tileEngine.
    /// </summary>
    public partial class MapEditorDocument : ProjectDocument
    {
        //The properties control for this map editor.
        PropertiesControl propsControl = null;

        public MapEditorDocument(ProjectSceneNode scene) : base(scene)
        {
            InitializeComponent();
            propsControl = new ScenePropertiesControl(scene);

            //Style document from DarkUI.
            mapEditor.SetThemeFromDarkUI();
        }

        /// <summary>
        /// Triggered when this document is focused for any reason.
        /// </summary>
        public override void OnDocumentFocused()
        {
            //Open the properties window.
            Editor.Instance.PropertiesWindow.SetPropertiesControl(propsControl, Node.Name + " Properties");
        }

        /// <summary>
        /// Triggered when this document is unfocused.
        /// </summary>
        public override void OnDocumentUnfocused()
        {
            //Close the properties tab for this document.
            Editor.Instance.PropertiesWindow.ClearPropertiesControl();
        }
    }
}
