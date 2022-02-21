using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tileEngine.SDK.GUI.Elements
{
    public class Spacer : UIElement
    {
        /// <summary>
        /// The width that this spacer occupies.
        /// </summary>
        public float Width
        {
            get => _width;
            set
            {
                _width = value;
                SizeDirty = true;
            }
        }
        private float _width;

        /// <summary>
        /// The height that this spacer occupies.
        /// </summary>
        public float Height
        {
            get => _height;
            set
            {
                _height = value;
                SizeDirty = true;
            }
        }
        private float _height;

        /// <summary>
        /// Creates a spacing element with the given width and height.
        /// </summary>
        public Spacer(float width, float height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Spacers are blank, so they don't draw anything.
        /// </summary>
        public override void DrawSelf(SpriteBatch spriteBatch, Vector2 topLeft) { }

        /// <summary>
        /// Updates the size of this spacer.
        /// </summary>
        public override void ForceUpdateSize()
        {
            Size = new Vector2(Width, Height);
        }
    }
}
