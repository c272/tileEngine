using Microsoft.Xna.Framework;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tileEngine.SDK.Map;

namespace tileEngine.SDK
{
    /// <summary>
    /// Represents non-C# project data required to run a game from file, encapsulated within a single class.
    /// Used by tileEngine.Player to run compiled games from file.
    /// </summary>
    [ProtoContract]
    public class GameDataContainer
    {
        /// <summary>
        /// The title of the game (as seen in the title bar & within the player).
        /// </summary>
        [ProtoMember(2)]
        public string Title { get; set; }

        /// <summary>
        /// The name of the C# assembly that this project is tied to.
        /// This will be loaded from file at the configured player directory.
        /// </summary>
        [ProtoMember(5)]
        public string AssemblyName { get; set; }

        /// <summary>
        /// The desired window size of the game at runtime.
        /// </summary>
        [ProtoMember(3)]
        public Point WindowSize { get; set; }

        /// <summary>
        /// The scenes contained within the game, and their linked class name.
        /// </summary>
        [ProtoMember(1)]
        public Dictionary<string, TileMap> Maps { get; set; } = new Dictionary<string, TileMap>();

        /// <summary>
        /// Mappings of asset tree string paths into asset ID values.
        /// Necessary for the asset manager to translate project tree paths into asset IDs.
        /// </summary>
        [ProtoMember(6)]
        public Dictionary<string, int> AssetMapping { get; set; } = new Dictionary<string, int>();
    }
}
