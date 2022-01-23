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
using tileEngine.SDK.Diagnostics;
using Microsoft.Xna.Framework.Input;
using tileEngine.SDK.Input;

namespace tileEngine.Engine
{
    /// <summary>
    /// Represents a control where all MonoGame output and logic is routed.
    /// </summary>
    public class GameControl : MonoGameControl, ITileEngine
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

                //Fire event for new scene.
                OnSceneChanged?.Invoke(scene);
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

        /// <summary>
        /// The game data container loaded for this control.
        /// Contains map information, and other non-XNB and non-C# assembly data.
        /// </summary>
        public GameDataContainer GameData { get; private set; } = null;
        
        /// <summary>
        /// The keyboard input handler for this game control.
        /// </summary>
        public KeyboardInputHandler KeyboardInput { get; set; } = new KeyboardInputHandler();

        /// <summary>
        /// Whether this game control is fully initialized yet.
        /// </summary>
        public bool Initialized { get; private set; } = false;

        /// <summary>
        /// Event triggered when this game control has initialized fully.
        /// </summary>
        public event OnInitializedHandler OnInitialized;
        public delegate void OnInitializedHandler();

        /// <summary>
        /// Event triggered when this game control has initialized fully.
        /// </summary>
        public event OnSceneChangedHandler OnSceneChanged;
        public delegate void OnSceneChangedHandler(Scene newScene);

        //Singleton constructor.
        public GameControl()
        {
            Instance = this;
            TileEngine.SetInstance(this);
        }

        /// <summary>
        /// Returns the currently active scene of the game.
        /// </summary>
        public Scene GetScene()
        {
            return Scene;
        }

        /// <summary>
        /// Sets the current scene of the game to a new instance of the given scene type.
        /// </summary>
        public void SetScene(Type sceneType)
        {
            //Does the type inherit from Scene, and is it non-abstract?
            if (!sceneType.IsSubclassOf(typeof(Scene)) || sceneType.IsAbstract)
            {
                DiagnosticsHook.LogMessage(21004, $"Cannot switch to scene '{sceneType.Name}', type does not inherit from scene/is abstract.");
                return;
            }

            //Yes, attempt to create an instance.
            Scene sceneInstance = null;
            try
            {
                sceneInstance = (Scene)Activator.CreateInstance(sceneType);
            }
            catch (Exception ex)
            {
                DiagnosticsHook.LogMessage(21005, $"Failed to create scene instance for '{sceneType.Name}':\n{ex.Message}");
                return;
            }

            //If there is a map registered for this scene in the game data, load it.
            if (GameData != null && GameData.Maps.ContainsKey(sceneType.FullName))
                sceneInstance.SetTileMap(GameData.Maps[sceneType.FullName]);

            //Load the scene.
            Scene = sceneInstance;
        }

        /// <summary>
        /// Sets the game data container for this game control instance.
        /// Once the container has been loaded, no other containers can then be loaded.
        /// </summary>
        public void SetGameData(GameDataContainer container)
        {
            if (GameData != null)
            {
                DiagnosticsHook.LogMessage(21003, "Failed to load game data container - there was already a game data container loaded.");
                return;
            }
            GameData = container;
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
            Initialized = true;
            OnInitialized?.Invoke();
        }

        /// <summary>
        /// Periodic update function for this game control.
        /// Updates based on a delta from the previous update.
        /// </summary>
        protected override void Update(GameTime delta)
        {
            //Update input handlers.
            KeyboardInput?.Update(Keyboard.GetState());

            //Inputs are updated, now do scenes.
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
