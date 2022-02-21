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
    /// Represents a simple text label within the tileEngine UI.
    /// </summary>
    public class Label : UIElement
    {
        /// <summary>
        /// The text currently displayed on this label.
        /// </summary>
        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                SizeDirty = true;
            }
        }
        private string _text = string.Empty;

        /// <summary>
        /// The font size of this label (in points).
        /// </summary>
        public int FontSize
        {
            get => _fontSize;
            set
            {
                _fontSize = value;
                SizeDirty = true;
            }
        }
        private int _fontSize = 16;

        /// <summary>
        /// The colour of this text.
        /// </summary>
        public Color Colour { get; set; } = Color.White;

        /// <summary>
        /// Draws this font to the screen.
        /// </summary>
        public override void DrawSelf(SpriteBatch spriteBatch)
        {
            var font = FontManager.GetFont(UI.Font, FontSize);
            font.DrawText(spriteBatch, Text, Position, Colour);
        }

        /// <summary>
        /// Updates the calculated size of this UI element.
        /// </summary>
        public override void ForceUpdateSize()
        {
            var font = FontManager.GetFont(UI.Font, FontSize);
            Size = font.MeasureString(Text);
        }
    }
}
