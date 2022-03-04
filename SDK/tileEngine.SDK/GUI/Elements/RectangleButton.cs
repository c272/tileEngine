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
    /// Represents a single rectangular panel button with an optional border.
    /// </summary>
    public class RectangleButton : UIElement
    {
        /// <summary>
        /// Whether this button should automatically size.
        /// </summary>
        public bool AutoSize
        {
            get => _autoSize;
            set
            {
                _autoSize = value;
                SizeDirty = true;
            }
        }
        private bool _autoSize = true;

        /// <summary>
        /// The background colour of this rectangular button.
        /// </summary>
        public Color BackgroundColour { get; set; } = Color.White;

        /// <summary>
        /// The border colour of this rectangular button.
        /// </summary>
        public Color BorderColour { get; set; } = Color.Black;

        /// <summary>
        /// The thickness of the border on this button.
        /// </summary>
        public int BorderThickness { get; set; } = 0;

        /// <summary>
        /// The total size of the rectangular button, without AutoSize.
        /// </summary>
        public new Vector2 Size
        {
            get => base.Size;
            set
            {
                if (!AutoSize)
                    base.Size = value;
            }
        }

        /// <summary>
        /// The label that is used for drawing text on the button.
        /// </summary>
        public Label Label { get; set; } = new Label()
        {
            Colour = Color.Black
        };

        /// <summary>
        /// The padding between the text and the button.
        /// </summary>
        public Vector2 TextPadding { get; set; } = new Vector2(10, 5);

        /// <summary>
        /// Draws the rectangular button to the screen.
        /// </summary>
        public override void DrawSelf(SpriteBatch spriteBatch, Vector2 topLeft)
        {
            //Check if we need to resize because the text changed.
            if (Label.SizeDirty)
                ForceUpdateSize();

            //Draw background rectangle.
            spriteBatch.Draw(Scene.PointTexture, topLeft, null, BackgroundColour * Opacity, 0f, Vector2.Zero, Size, SpriteEffects.None, 0);

            //Draw border rectangles.
            if (BorderThickness > 0)
            {
                Vector2 borderVec = new Vector2(BorderThickness, BorderThickness);
                spriteBatch.Draw(Scene.PointTexture, topLeft, null, BorderColour * Opacity, 0f, Vector2.Zero, new Vector2(Size.X, BorderThickness), SpriteEffects.None, 0);
                spriteBatch.Draw(Scene.PointTexture, topLeft, null, BorderColour * Opacity, 0f, Vector2.Zero, new Vector2(BorderThickness, Size.Y), SpriteEffects.None, 0);
                spriteBatch.Draw(Scene.PointTexture, topLeft + new Vector2(Size.X - BorderThickness, 0), null, BorderColour * Opacity, 0f, Vector2.Zero, new Vector2(BorderThickness, Size.Y), SpriteEffects.None, 0);
                spriteBatch.Draw(Scene.PointTexture, topLeft + new Vector2(0, Size.Y - BorderThickness), null, BorderColour * Opacity, 0f, Vector2.Zero, new Vector2(Size.X, BorderThickness), SpriteEffects.None, 0);
            }

            //Draw the label.
            Label.Opacity = Opacity;
            Label.DrawSelf(spriteBatch, topLeft + TextPadding);
        }

        /// <summary>
        /// Updates the size of this button, if AutoSize is on.
        /// </summary>
        public override void ForceUpdateSize()
        {
            //Ignore if no autosize.
            if (!AutoSize)
                return;

            //Size based on label.
            if (Label.SizeDirty)
                Label.ForceUpdateSize();
            base.Size = Label.Size + TextPadding * 2;
        }
    }
}
