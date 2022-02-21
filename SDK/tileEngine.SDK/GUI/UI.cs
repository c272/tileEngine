using FontStashSharp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tileEngine.SDK.Diagnostics;

namespace tileEngine.SDK.GUI
{
    /// <summary>
    /// Represents the UI system for the game.
    /// </summary>
    public static class UI
    {
        /// <summary>
        /// The canonical name of the font used within this UI system.
        /// </summary>
        public static string Font { get; set; }

        /// <summary>
        /// The root elements of the UI.
        /// </summary>
        public static List<UIElement> RootElements = new List<UIElement>();

        /// <summary>
        /// Initializes the UI with the given required assets.
        /// </summary>
        /// <param name="fontAsset">The font asset to use for drawing text.</param>
        public static void Initialize(string fontAsset)
        {
            //Make sure game data & asset manager are initialized before starting UI.
            if (TileEngine.Instance?.GameData?.AssetMapping == null || AssetManager.ContentManager == null)
            {
                DiagnosticsHook.LogMessage(1016, "Cannot initialize UI system before game data mappings/asset manager are initialized.");
                return;
            }

            //Load all fonts from content directory into font system.
            FontManager.LoadFromDirectory(AssetManager.ContentManager.RootDirectory);

            //Attempt to grab the font for this UI system.
            if (!TileEngine.Instance.GameData.AssetMapping.ContainsKey(fontAsset))
            {
                DiagnosticsHook.LogMessage(1017, "Invalid asset name for UI font: Asset not found in mappings.");
                return;
            }
            Font = TileEngine.Instance.GameData.AssetMapping[fontAsset].ToString();
            if (!FontManager.IsFontLoaded(Font))
            {
                DiagnosticsHook.LogMessage(1018, "Invalid asset name for UI font: Asset was not a font.");
                return;
            }
        }

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
