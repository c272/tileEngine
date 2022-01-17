using tileEngine.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Config.Net;
using tileEngine.SDK;
using tileEngine.SDK.Serializer;
using ProtoBuf.Meta;
using System.IO;
using tileEngine.SDK.Diagnostics;
using System.Reflection;

namespace tileEngine.Player
{
    public partial class Main : Form
    {
        /// <summary>
        /// The game that is running in this player.
        /// </summary>
        GameControl game;

        /// <summary>
        /// The configuration for the currently running player.
        /// </summary>
        IPlayerConfiguration config;

        /// <summary>
        /// The game data container for the game currently running in the player.
        /// </summary>
        GameDataContainer gameData = null;

        /// <summary>
        /// The C# assembly for the game currently running in the player.
        /// </summary>
        Assembly gameAssembly = null;

        /// <summary>
        /// The main game class from the C# assembly.
        /// Used by 3rd parties for running scene independent actions such as initialization and shutdown/disposal.
        /// </summary>
        TileEngineGame gameMain = null;

        public Main()
        {
            InitializeComponent();

            //Load settings from configuration sources.
            config = new ConfigurationBuilder<IPlayerConfiguration>()
                .UseCommandLineArgs()
                .UseIniFile("config.ini")
                .Build();

            //Add game control to the form, dock.
            game = new GameControl();
            Controls.Add(game);
            game.Dock = DockStyle.Fill;

            //Configure diagnostics to display errors.
            DiagnosticsHook.Mode = DiagnosticsMode.Standalone;
            DiagnosticsHook.OnDiagnosticsMessage += diagnosticsMessageReceived;

            //Load all prerequisite on-file data.
            if (!loadPrerequisites())
                return;

            //Set game window title, size.
            this.Text = gameData.Title;
            this.ClientSize = new Size(gameData.WindowSize.X, gameData.WindowSize.Y);

            //Load the game data container into the engine.
            game.SetGameData(gameData);

            //Run main class' initialization method to start the game.
            gameMain.Initialize();
            this.Visible = true;
        }

        /// <summary>
        /// Triggered when the form is closing for any reason.
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            gameMain?.Shutdown();
            base.OnFormClosing(e);
        }

        /// <summary>
        /// Loads all the prerequisite on-file data required for setting up and running a game
        /// within the player.
        /// </summary>
        private bool loadPrerequisites()
        {
            //Attempt to load main game container binary blob.
            ProtobufSerializer.PrepareSerializer();
            try
            {
                using (var file = File.OpenRead(config.GameContainerLocation))
                {
                    gameData = RuntimeTypeModel.Default.Deserialize<GameDataContainer>(file);
                }
            }
            catch (Exception ex)
            {
                DiagnosticsHook.LogMessage(21007, $"Failed to load game data container ({config.GameContainerLocation}):\n" + ex.Message);
                return false;
            }

            //Successfully read the game data container, set up the content directory.
            if (!Directory.Exists(config.CompiledAssetDirectory))
            {
                DiagnosticsHook.LogMessage(21008, $"Failed to find game asset directory (./{config.CompiledAssetDirectory}), did not exist.");
                return false;
            }
            game.ContentDirectory = Path.GetFullPath(config.CompiledAssetDirectory);

            //Attempt to load the configured linked assembly.
            string asmDir = config.AssemblyLoadDirectory == null ? AppDomain.CurrentDomain.BaseDirectory : config.AssemblyLoadDirectory;
            try
            {
                gameAssembly = Assembly.LoadFrom(Path.Combine(asmDir, gameData.AssemblyName + ".dll"));
            }
            catch (Exception ex)
            {
                DiagnosticsHook.LogMessage(21009, $"Failed to load game assembly ({gameData.AssemblyName}.dll):\n{ex.Message}");
                return false;
            }

            //Is there a TileEngineGame class? If not, we need an error.
            var gameMainType = gameAssembly.GetTypes().Where(x => x.IsSubclassOf(typeof(TileEngineGame)) && !x.IsAbstract).FirstOrDefault();
            if (gameMainType == null)
            {
                DiagnosticsHook.LogMessage(21010, "No main TileEngineGame class found within game assembly. Please create a class inheriting from" +
                    " TileEngineGame, and use this to initialize and start the first scene.");
                return false;
            }
            
            //Attempt to load the game main class.
            try
            {
                gameMain = (TileEngineGame)Activator.CreateInstance(gameMainType);
            }
            catch (Exception ex)
            {
                DiagnosticsHook.LogMessage(21006, $"Failed to load game main class '{gameMainType.Name}':\n{ex.Message}");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Triggered whenever a new diagnostics message is sent from the game.
        /// </summary>
        private void diagnosticsMessageReceived(DiagnosticsMessage msg)
        {
            //Get correct icon for severity.
            MessageBoxIcon icon;
            switch (msg.Severity)
            {
                case DiagnosticsSeverity.Error:
                    icon = MessageBoxIcon.Error;
                    break;
                case DiagnosticsSeverity.Warning:
                    icon = MessageBoxIcon.Warning;
                    break;
                case DiagnosticsSeverity.Notice:
                    icon = MessageBoxIcon.Information;
                    break;
                default:
                    icon = MessageBoxIcon.None;
                    break;
            }

            //Show the message.
            string title = gameData == null ? "tileEngine Player" : gameData.Title;
            MessageBox.Show($"[{msg.Code}] - {msg.Message}", $"{title} - Diagnostics Message", MessageBoxButtons.OK, icon);
            if (msg.Severity == DiagnosticsSeverity.Error)
            {
                //Close, we hit an error.
                Environment.Exit(-1);
            }
        }
    }
}
