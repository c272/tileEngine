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
    /// Represents a simple, solid coloured progress bar as a UI element within tileEngine.
    /// </summary>
    public class ProgressBar : UIElement
    {
        /// <summary>
        /// The total size of the progress bar.
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
        /// The background colour of the progress bar.
        /// </summary>
        public Color BackgroundColour { get; set; } = Color.Black * 0.6f;

        /// <summary>
        /// The foreground colour of the progress bar.
        /// </summary>
        public Color ForegroundColour { get; set; } = Color.Green;

        /// <summary>
        /// The current value of the progress bar.
        /// Ranges from 0f (no progress) to 1f (full).
        /// </summary>
        public float Value
        {
            get => _value;
            set
            {
                _value = Math.Min(Math.Max(0f, value), 1f);
            }
        }
        private float _value = 0f;

        /// <summary>
        /// Creates a progress bar of the given unit size.
        /// </summary>
        public ProgressBar(Vector2 size)
        {
            Size = size;
        }

        /// <summary>
        /// Draws the progress bar to the screen on UI draw.
        /// </summary>
        public override void DrawSelf(SpriteBatch spriteBatch, Vector2 topLeft)
        {
            spriteBatch.Draw(Scene.PointTexture, topLeft, null, BackgroundColour, 0f, Vector2.Zero, Size, SpriteEffects.None, 0);
            spriteBatch.Draw(Scene.PointTexture, topLeft, null, ForegroundColour, 0f, Vector2.Zero, new Vector2(Size.X * Value, Size.Y), SpriteEffects.None, 0);
        }

        /// <summary>
        /// The size is always user defined, and starts at a default value.
        /// </summary>
        public override void ForceUpdateSize() { }
    }
}
