using Microsoft.Xna.Framework;
using ProtoBuf;
using System;

namespace tileEngine.SDK.Map
{
    /// <summary>
    /// Represents a single tile reference within tileEngine.
    /// </summary>
    [ProtoContract]
    public struct TileData
    {
        /// <summary>
        /// The ID of the texture that contains this tile.
        /// </summary>
        [ProtoMember(1)]
        public int TextureID;

        /// <summary>
        /// The position of the tile on that texture.
        /// </summary>
        [ProtoMember(2)]
        public Point Position;
    }
}