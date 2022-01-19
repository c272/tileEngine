using Config.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tileEngine.Player
{
    /// <summary>
    /// Represents the configuration of the tileEngine player.
    /// Can be configured by the user by including a "config.ini" file in the base directory with the player.
    /// </summary>
    public interface IPlayerConfiguration
    {
        /// <summary>
        /// The location of the game container binary blob.
        /// Contains maps and other non-C# project scene data.
        /// </summary>
        [Option(DefaultValue = "main.bin")]
        string GameContainerLocation { get; }

        /// <summary>
        /// The directory in which .XNB compiled assets are held for the content manager.
        /// Relative to the runtime working directory of the player.
        /// </summary>
        [Option(DefaultValue = "compiled")]
        string CompiledAssetDirectory { get; }

        /// <summary>
        /// The directory from which developed game assemblies should be loaded.
        /// Relative to the runtime working directory of the player.
        /// </summary>
        [Option(DefaultValue = "external")]
        string AssemblyLoadDirectory { get; }
    }
}
