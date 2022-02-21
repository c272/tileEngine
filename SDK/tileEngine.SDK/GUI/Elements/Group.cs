using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tileEngine.SDK.GUI.Elements
{
    /// <summary>
    /// Represents a parent for a group of UI elements, used as an "empty" parent.
    /// Does not draw anything itself.
    /// </summary>
    public class Group : UIElement
    {
        /// <summary>
        /// Group does not draw anything but its children.
        /// </summary>
        public override void DrawSelf(SpriteBatch spriteBatch) { }

        /// <summary>
        /// Updates the size of this group based on the children within it.
        /// </summary>
        public override void ForceUpdateSize()
        {
            //First, force update the size of all children.
            foreach (var child in Children)
                child.ForceUpdateSize();

            //...
        }
    }
}
