using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tileEngine.SDK.Attributes;

namespace tileEngine
{
    /// <summary>
    /// Represents a single font asset within a tileEngine project.
    /// </summary>
    [SelectorIgnore]
    [ProtoRecursiveIgnore]
    public class ProjectFontNode : ProjectAssetNode
    {
        public ProjectFontNode(string relativeLoc) : base(relativeLoc)
        {
            //Fonts are not compiled as XNB.
            CompileXNB = false;
            Name = "New Font";
            Icon = Resources.Icons.Font;
        }

        //Serialization constructor.
        private ProjectFontNode()
        {
            CompileXNB = false;
            Icon = Resources.Icons.Font;
        }
    }
}
