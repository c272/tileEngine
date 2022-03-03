using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tileEngine.SDK.Components
{
    /// <summary>
    /// Represents a component that draws a sprite relative to the attached GameObject.
    /// </summary>
    public class SpriteComponent : Component
    {
        /// <summary>
        /// The texture that will be drawn by this component.
        /// </summary>
        public Texture2D Texture { get; set; } = null;

        /// <summary>
        /// The relative position of this sprite to the GameObject.
        /// </summary>
        public Vector2 Position { get; set; } = new Vector2(0, 0);

        /// <summary>
        /// The rotation of the sprite, in radians.
        /// </summary>
        public float Rotation { get; set; } = 0;

        /// <summary>
        /// The scale of this sprite, relative to texture size.
        /// </summary>
        public Vector2 Scale { get; set; } = new Vector2(1, 1);

        /// <summary>
        /// The opacity of this sprite, from 0.0f (transparent) to 1.0f (opaque).
        /// </summary>
        public float Opacity { get; set; } = 1.0f;

        public SpriteComponent(Texture2D tex = null)
        {
            Texture = tex;
        }

        /// <summary>
        /// Draws the sprite to the screen at the GameObject's (relative) location.
        /// </summary>
        public override void Draw(GameObject gameObject, SpriteBatch spriteBatch)
        {
            //If no texture, ignore.
            if (Texture == null)
                return;

            Vector2 drawPosition = gameObject.Scene.ToScreenPointF(gameObject.Position + Position);
            Vector2 drawScale = new Vector2(gameObject.Scene.Zoom * Scale.X, gameObject.Scene.Zoom * Scale.Y);
            Vector2 realSize = new Vector2(Texture.Width, Texture.Height) * drawScale;
            Rectangle sourceRect = new Rectangle(0,0,Texture.Width,Texture.Height);
            spriteBatch.Draw(Texture, drawPosition + realSize / 2f, sourceRect, Color.White * Opacity, Rotation, new Vector2(Texture.Width/2f, Texture.Height/2f), drawScale, SpriteEffects.None, 0);
        }
    }
}
