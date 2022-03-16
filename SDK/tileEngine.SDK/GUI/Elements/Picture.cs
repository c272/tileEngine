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
    /// Represents a single image element within the GUI system.
    /// </summary>
    public class Picture : UIElement
    {
        /// <summary>
        /// The texture used for drawing the picture element.
        /// </summary>
        public Texture2D Texture
        {
            get => _texture;
            set
            {
                _texture = value;
                SizeDirty = true;
            }
        }
        private Texture2D _texture = null;

        /// <summary>
        /// The scale of the picture (this is irrelevant to UIElement-level scaling).
        /// </summary>
        public new float Scale { get; set; } = 1f;

        /// <summary>
        /// The colour modifier for this picture.
        /// </summary>
        public Color Colour { get; set; } = Color.White;

        /// <summary>
        /// Draws the picture to the screen.
        /// </summary>
        public override void DrawSelf(SpriteBatch spriteBatch, Vector2 topLeft)
        {
            spriteBatch.Draw(Texture, topLeft, null, Colour * Opacity, 0f, Vector2.Zero, Scale, SpriteEffects.None, 0);
        }

        /// <summary>
        /// Updates the size of this picture.
        /// </summary>
        public override void ForceUpdateSize()
        {
            Size = new Vector2(Texture.Width, Texture.Height) * Scale;
        }
    }
}
