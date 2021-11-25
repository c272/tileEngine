using tileEngine.SDK.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tileEngine
{
    /// <summary>
    /// Represents a single sprite in the project asset tree.
    /// </summary>
    [SelectorIgnore]
    public class ProjectSpriteNode : ProjectAssetNode
    {
        //Serializer constructor.
        private ProjectSpriteNode() 
        {
            Icon = Resources.Icons.Sprite;
        }

        public ProjectSpriteNode(string relativeLoc) : base(relativeLoc)
        {
            Icon = Resources.Icons.Sprite;
            Name = "New Sprite";
        }
    }
}
