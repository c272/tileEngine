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
        /// The background colour of this group.
        /// By default, no background is drawn (transparent).
        /// </summary>
        public Color BackgroundColour { get; set; } = Color.Transparent;

        /// <summary>
        /// Draws the background of the group (if non-transparent).
        /// </summary>
        public override void DrawSelf(SpriteBatch spriteBatch, Vector2 topLeft) 
        {
            //Just draw the background.
            spriteBatch.Draw(Scene.PointTexture, topLeft, null, BackgroundColour, 0, Vector2.Zero, Size, SpriteEffects.None, 0);
        }

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
                if (child.Anchor < UIAnchor.AutoLeft) 
                {
                    DiagnosticsHook.LogMessage(1019, "Only auto-aligned elements are allowed to be added to UI groups.");
                    return;
                }

                //Ignore element if sizes from parent.
                if (child.SizesFromParent)
                    continue;

                if (child.Size.X > maxWidth)
                    maxWidth = child.Size.X;
                totalHeight += child.Size.Y;
            }

            //Set this as the total size of the group.
            SizeDirty = false;
            Size = new Vector2(maxWidth, totalHeight);
        }
    }
}
