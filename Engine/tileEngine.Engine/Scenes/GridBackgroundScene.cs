using tileEngine.SDK;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tileEngine.Engine.Scenes
{
    /// <summary>
    /// Represents a scene within the engine that has a grid-based background.
    /// </summary>
    public abstract class GridBackgroundScene : Scene
    {
        /// <summary>
        /// The internal size of each grid square.
        /// </summary>
        public int GridSquareSize { get; set; } = 32;

        /// <summary>
        /// The thickness of the lines for each grid square.
        /// </summary>
        public int LineThickness { get; set; }= 3;

        /// <summary>
        /// The origin of the grid.
        /// </summary>
        public Vector2 GridOrigin { get; set; } = new Vector2(0, 0);

        /// <summary>
        /// The colour of the lines on the grid.
        /// </summary>
        public Color LineColour { get; set; } = Color.DarkGray;

        /// <summary>
        /// The colour of the grid background.
        /// </summary>
        public Color BackgroundColour { get; set; } = Color.Black;

        //Static pixel texture for drawing the line.
        protected static Texture2D pointTex;
        
        public override void Draw(SpriteBatch spriteBatch)
        {
            //Initialize the point texture if we don't already have it.
            if (pointTex == null)
            {
                pointTex = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
                pointTex.SetData(new Color[] { Color.White });
            }

            //Draw the background.
            spriteBatch.GraphicsDevice.Clear(BackgroundColour);

            //If zoom is below .05, we're not drawing anything.
            if (Zoom < 0.05f) { return; }
            spriteBatch.Begin();

            //Loop for the size of the render buffer.
            Vector2 topLeft = ToGridLocation(new Point(0, 0));
            Vector2 bottomRight = ToGridLocation(new Point(spriteBatch.GraphicsDevice.PresentationParameters.BackBufferWidth, spriteBatch.GraphicsDevice.PresentationParameters.BackBufferHeight));

            //Vertical lines.
            Vector2 curPos = new Vector2(topLeft.X - (topLeft.X % GridSquareSize), topLeft.Y);
            while (curPos.X <= bottomRight.X)
            {
                Vector2 lineTop = ToScreenPointF(curPos);
                Vector2 lineBottom = ToScreenPointF(new Vector2(curPos.X + LineThickness, bottomRight.Y));
                spriteBatch.Draw(pointTex, lineTop, null, LineColour, 0, Vector2.Zero, lineBottom - lineTop, SpriteEffects.None, 0);
                curPos.X += GridSquareSize;
            }

            //Horizontal lines.
            curPos = new Vector2(topLeft.X, topLeft.Y - (topLeft.Y % GridSquareSize));
            while (curPos.Y <= bottomRight.Y)
            {
                Vector2 lineLeft = ToScreenPointF(curPos);
                Vector2 lineRight = ToScreenPointF(new Vector2(bottomRight.X, curPos.Y + LineThickness));
                spriteBatch.Draw(pointTex, lineLeft, null, LineColour, 0, Vector2.Zero, lineRight - lineLeft, SpriteEffects.None, 0);
                curPos.Y += GridSquareSize;
            }

            spriteBatch.End();
        }

        /// <summary>
        /// Dispose of the single pixel texture.
        /// </summary>
        public override void Dispose()
        {
            pointTex?.Dispose();
        }
    }
}
