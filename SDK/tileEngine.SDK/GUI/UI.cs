using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tileEngine.SDK.GUI
{
    /// <summary>
    /// Represents the UI system for the game.
    /// </summary>
    public static class UI
    {
        /// <summary>
        /// The root elements of the UI.
        /// </summary>
        public static List<UIElement> RootElements = new List<UIElement>();

        /// <summary>
        /// Draw function for the entire UI system.
        /// </summary>
        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            for (int i = 0; i < RootElements.Count; i++)
                RootElements[i].Draw(spriteBatch);
            spriteBatch.End();
        }

        /// <summary>
        /// Updates the entire UI system on each update tick.
        /// </summary>
        public static void Update(GameTime delta)
        {
            for (int i = 0; i < RootElements.Count; i++)
                RootElements[i].Update(delta);
        }
    }
}
