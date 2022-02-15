using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tileEngine.SDK.Attributes;

namespace tileEngine
{
    /// <summary>
    /// Represents a single audio asset within a tileEngine project.
    /// </summary>
    [SelectorIgnore]
    [ProtoRecursiveIgnore]
    public class ProjectAudioNode : ProjectAssetNode
    {
        public ProjectAudioNode(string relativeLoc) : base(relativeLoc)
        {
            //Audio is not compiled as XNB.
            CompileXNB = false;
            Name = "New Sound";
            Icon = Resources.Icons.Sound;
        }

        //Serialization constructor.
        private ProjectAudioNode()
        {
            CompileXNB = false;
            Icon = Resources.Icons.Sound;
        }
    }
}
