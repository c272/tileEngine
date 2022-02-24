using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tileEngine
{
    /// <summary>
    /// Represents a single asset within the project tree (of any type).
    /// </summary>
    [ProtoContract]
    public abstract class ProjectAssetNode : ProjectTreeNode
    {
        /// <summary>
        /// The relative location of the asset from the project file.
        /// </summary>
        [ProtoMember(1)]
        public string RelativeLocation { get; private set; }

        /// <summary>
        /// Whether to compile this asset as XNB, or to simply copy the file.
        /// </summary>
        public bool CompileXNB { get; protected set; } = true;

        //Serialization constructor.
        protected ProjectAssetNode() { }

        public ProjectAssetNode(string relativeLoc)
        {
            RelativeLocation = relativeLoc;
        }

        /// <summary>
        /// No requirement to update from document.
        /// </summary>
        public override void UpdateFromDocument() { }

        /// <summary>
        /// Updates the relative location of this asset node.
        /// </summary>
        public void UpdateRelativeLocation(string newLocation)
        {
            RelativeLocation = newLocation;
        }
    }
}
