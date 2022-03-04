using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tileEngine.SDK.GUI.Elements
{
    /// <summary>
    /// Represents a solid coloured panel.
    /// </summary>
    public class Panel : UIElement
    {
        /// <summary>
        /// Whether the panel should auto-size to fill the parent container.
        /// </summary>
        public bool FillParent
        {
            get => _fillParent;
            set
            {
                _fillParent = value;
                SizesFromParent = value;
                SizeDirty = true;
            }
        }
        private bool _fillParent = false;

        /// <summary>
        /// The total size of the panel.
        /// </summary>
        public new Vector2 Size
        {
            get => base.Size;
            set
            {
                base.Size = value;
            }
        }
        
        /// <summary>
        /// The colour of the panel.
        /// </summary>
        public Color Colour { get; set; } = Color.Black;

        /// <summary>
        /// Draws the solid colour panel to screen.
        /// </summary>
        public override void DrawSelf(SpriteBatch spriteBatch, Vector2 topLeft)
        {
            spriteBatch.Draw(Scene.PointTexture, topLeft, null, Colour, 0f, Vector2.Zero, Size, SpriteEffects.None, 0);
            if (FillParent)
                SizeDirty = true;
        }

        /// <summary>
        /// Updates the size of the panel based on parent if necessary.
        /// </summary>
        public override void ForceUpdateSize()
        {
            //If not auto sizing, ignore.
            if (!FillParent)
                return;

            //Set position & size from parent.
            Position = Parent == null ? Vector2.Zero : Parent.Position;
            Size = Parent == null ? TileEngine.Instance.GraphicsDevice.Viewport.Bounds.Size.ToVector2() : Parent.Size;
        }
    }
}
