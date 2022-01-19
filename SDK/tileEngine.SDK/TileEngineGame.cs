using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tileEngine.SDK
{
    /// <summary>
    /// Represents a "main" class for a given external C# tileEngine game assembly.
    /// Allows external code to perform setup before a game starts, and other non-scene related actions.
    /// </summary>
    public abstract class TileEngineGame
    {
        /// <summary>
        /// Called when the game is first started, before any scenes are active
        /// Should be used to run any necessary setup code, then start the first scene.
        /// </summary>
        public abstract void Initialize();

        /// <summary>
        /// Called when the game is closing for any reason.
        /// Should be used to run any disposal or cleanup code, and save state.
        /// </summary>
        public abstract void Shutdown();
    }
}
