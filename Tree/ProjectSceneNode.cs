﻿using DarkUI.Forms;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tileEngine.Controls;
using tileEngine.SDK;
using tileEngine.SDK.Map;

namespace tileEngine
{
    /// <summary>
    /// Represents a single scene within the tileEngine project tree.
    /// </summary>
    [ProtoContract]
    public class ProjectSceneNode : ProjectTreeNode
    {
        /// <summary>
        /// The name of the type linked to this scene.
        /// </summary>
        [ProtoMember(1)]
        public string LinkedTypeName { get; private set; }

        /// <summary>
        /// The tile map that is used for this scene.
        /// </summary>
        [ProtoMember(2)]
        public TileMap TileMap { get; private set; } = new TileMap();

        /// <summary>
        /// The type linked to this scene.
        /// </summary>
        public Type LinkedType { get; private set; } = null;

        /// <summary>
        /// Whether this project scene node can currently be edited.
        /// </summary>
        public bool CanEdit { 
            get
            {
                return LinkedType != null;
            } 
        }

        /// <summary>
        /// Creates a project scene node based on an existing type from the project assembly.
        /// </summary>
        public ProjectSceneNode(Type type)
        {
            LinkedType = type;
            LinkedTypeName = type.FullName;
            Name = type.Name;
            Icon = Resources.Icons.Scene;

            //Initialize the first layer.
            TileMap.Layers.Add(new TileLayer()
            {
                Name = "Background"
            });
        }

        //Serialization constructor.
        private ProjectSceneNode() { Icon = Resources.Icons.Disconnected; }

        /// <summary>
        /// Triggered when this project scene node is double clicked.
        /// </summary>
        public override void OnDoubleClick()
        {
            if (!CanEdit)
            {
                DarkMessageBox.ShowError("Cannot edit this scene: There is currently no C# class attached to this scene, or the project has not been built." +
                    "\nYou can reassign the map by using 'Right Click -> Reassign Class', or build the project.", "tileEngine - Edit Error");
                return;
            }

            //Open the map editor.
            if (Document == null)
                Document = new MapEditorDocument(this);
            Editor.Instance.OpenDocument(Document);
        }

        public override void UpdateFromDocument()
        {
            //todo
        }

        /// <summary>
        /// Loads a type into the scene node, given that it is the same as the specified linked type name.
        /// </summary>
        public void LoadType(Type sceneType)
        {
            if (sceneType == null || sceneType.FullName != LinkedTypeName)
                throw new Exception("Failed to load type, name mismatch with linked type name.");

            //Set icon to scene to show a type has been successfully connected.
            LinkedType = sceneType;
            Icon = Resources.Icons.Scene;
        }
    }
}
