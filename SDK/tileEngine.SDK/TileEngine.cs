using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tileEngine.SDK.Input;

namespace tileEngine.SDK
{
    /// <summary>
    /// Represents a currently (if any) running instance of a tileEngine API, for interfacing
    /// with external assemblies such as game code.
    /// </summary>
    public static class TileEngine
    {
        /// <summary>
        /// The current tileEngine API instance. By default, null.
        /// </summary>
        public static ITileEngine Instance { get; private set; } = null;

        /// <summary>
        /// Configures the current tileEngine API instance.
        /// </summary>
        public static void SetInstance(ITileEngine engine)
        {
            Instance = engine;
        }
    }

    /// <summary>
    /// Represents the interface with which external assemblies such as game code can
    /// interact with a tileEngine instance.
    /// </summary>
    public interface ITileEngine
    {
        /// <summary>
        /// The keyboard input handler for this tileEngine instance.
        /// </summary>
        KeyboardInputHandler KeyboardInput { get; set; }

        /// <summary>
        /// Returns the scene that is currently active.
        /// Null if no scene is active.
        /// </summary>
        Scene GetScene();

        /// <summary>
        /// Changes the scene to the given scene type.
        /// </summary>
        void SetScene(Type scene);
    }
}
