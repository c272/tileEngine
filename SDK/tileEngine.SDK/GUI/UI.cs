using FontStashSharp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        /// The current root elements of this UI.
        /// </summary>
        public static IEnumerable<UIElement> RootElements => rootElements;

        /// <summary>
        /// The root elements of the UI.
        /// </summary>
        private static List<UIElement> rootElements = new List<UIElement>();

        //The state of the mouse from the previous update cycle.
        static MouseState previousMouseState = default;

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
        /// Adds a single root element to the UI.
        /// </summary>
        public static void AddElement(UIElement element)
        {
            if (rootElements.Any(x => x.ID == element.ID))
                return;
            element.Unparent();
            rootElements.Add(element);
        }

        /// <summary>
        /// Removes a single root element from the UI.
        /// </summary>
        public static void RemoveElement(UIElement element)
        {
            rootElements.RemoveAll(x => x.ID == element.ID);
        }

        /// <summary>
        /// Clears the UI system of all elements.
        /// </summary>
        public static void Clear()
        {
            rootElements.Clear();
        }

        /// <summary>
        /// Draw function for the entire UI system.
        /// </summary>
        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            for (int i = 0; i < rootElements.Count; i++)
                rootElements[i].Draw(spriteBatch);
            spriteBatch.End();
        }

        /// <summary>
        /// Updates the entire UI system on each update tick.
        /// </summary>
        public static void Update(GameTime delta)
        {
            //Update all root elements.
            for (int i = 0; i < rootElements.Count; i++)
                rootElements[i].Update(delta);

            //If the user is clicking, check if they're in bounds of any UI elements.
            var mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton != ButtonState.Pressed)
            {
                foreach (var element in rootElements) 
                {
                    if (element.CheckClicked(element, mouseState))
                        break;
                }
            }

            //Check if the mouse has freshly entered/left any UI elements.
            foreach (var element in rootElements)
                element.CheckEnteredExited(element, previousMouseState, mouseState);

            //Update previous mouse state.
            previousMouseState = mouseState;
        }

        

        
    }
}
