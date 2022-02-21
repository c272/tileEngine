using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tileEngine.SDK.Diagnostics;

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
        public override void DrawSelf(SpriteBatch spriteBatch, Vector2 topLeft) { }

        /// <summary>
        /// Updates the size of this group based on the children within it.
        /// </summary>
        public override void ForceUpdateSize()
        {
            //Loop over children, find the maximum width & total height.
            float maxWidth = 0f;
            float totalHeight = 0f;
            foreach (var child in Children) 
            {
                if (child.SizeDirty)
                    child.ForceUpdateSize();

                //Only auto aligned elements are allowed in groups (for now).
                switch (child.Anchor)
                {
                    case UIAnchor.AutoCenter:
                    case UIAnchor.AutoInline:
                    case UIAnchor.AutoLeft:
                        break;
                    default:
                        DiagnosticsHook.LogMessage(1019, "Only auto-aligned elements are allowed to be added to UI groups.");
                        return;
                }

                if (child.Size.X > maxWidth)
                    maxWidth = child.Size.X;
                totalHeight += child.Size.Y;
            }

            //Set this as the total size of the group.
            Size = new Vector2(maxWidth, totalHeight);
        }
    }
}
