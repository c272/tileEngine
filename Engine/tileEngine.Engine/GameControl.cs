using tileEngine.SDK;
using Microsoft.Xna.Framework;
using MonoGame.Forms.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tileEngine.Engine
{
    /// <summary>
    /// Represents a control where all MonoGame output and logic is routed.
    /// </summary>
    public class GameControl : MonoGameControl
    {
        /// <summary>
        /// Singleton instance of this control.
        /// </summary>
        public static GameControl Instance = null;

        /// <summary>
        /// The currently active scene in the game.
        /// </summary>
        public Scene Scene
        {
            get { return scene; }
            set
            {
                //If the values are the same, do not change anything.
                if (ReferenceEquals(scene, value)) { return; }

                //Dispose of old scene properly, initialize new.
                Scene oldScene = scene;
                scene = value;
                oldScene?.Dispose();
                scene.Initialize();
            }
        }
        private Scene scene = null;

        /// <summary>
        /// The content directory to load compiled .XNB files from.
        /// </summary>
        public string ContentDirectory
        {
            get { return contentDir; }
            set
            {
                //If the editor content manager has been created, set the value.
                if (Editor != null && Editor.Content != null)
                {
                    Editor.Content.RootDirectory = value;
                }

                //Otherwise, just set it pending.
                contentDir = value;
            }
        }
        private string contentDir = null;

        //Singleton constructor.
        public GameControl()
        {
            Instance = this;
        }

        /// <summary>
        /// Initializes the game control.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            //Set the global content manager.
            AssetManager.ContentManager = Editor.Content;
            if (ContentDirectory == null)
            {
                contentDir = Editor.Content.RootDirectory;
            }
            else
            {
                //Directory set before we've initialized the content manager, let's copy it in.
                Editor.Content.RootDirectory = ContentDirectory;
            }

            //Load fonts stored in the content directory into the FontManager.
            if (Directory.Exists(Editor.Content.RootDirectory))
                FontManager.LoadFromDirectory(Editor.Content.RootDirectory);

            //Set back buffer as preserving.
            Editor.graphics.PresentationParameters.RenderTargetUsage = Microsoft.Xna.Framework.Graphics.RenderTargetUsage.PreserveContents;
        }

        /// <summary>
        /// Periodic update function for this game control.
        /// Updates based on a delta from the previous update.
        /// </summary>
        protected override void Update(GameTime delta)
        {
            base.Update(delta);
            Scene?.Update(delta);
        }

        /// <summary>
        /// Draw function for this game control.
        /// </summary>
        protected override void Draw()
        {
            base.Draw();
            Scene?.Draw(Editor.spriteBatch);
        }
    }
}
