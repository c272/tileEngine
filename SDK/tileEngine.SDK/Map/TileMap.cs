using Microsoft.Xna.Framework;
using ProtoBuf;
using System;
using System.Collections.Generic;

namespace tileEngine.SDK.Map
{
    /// <summary>
    /// Represents a single unbounded tilemap within tileEngine, used within scenes.
    /// </summary>
    [ProtoContract]
    public class TileMap
    {
        /// <summary>
        /// The size of each tile's texture within this tilemap.
        /// </summary>
        [ProtoMember(1)]
        public int TileTextureSize { get; set; } = 64;

        /// <summary>
        /// A list of tile layers that appear on this tile map.
        /// </summary>
        [ProtoMember(2)]
        public List<TileLayer> Layers = new List<TileLayer>();
    }

    /// <summary>
    /// Represents a single layer of tiles within a tilemap, containing a set of tiles, events, and a collision hull.
    /// </summary>
    [ProtoContract]
    public class TileLayer
    {
        /// <summary>
        /// Tile textures that are on this tile layer, lookup table by point.
        /// </summary>
        [ProtoMember(1)]
        public Dictionary<Point, TileData> Tiles = new Dictionary<Point,TileData>();

        /// <summary>
        /// Events that are on this tile layer, lookup table by point.
        /// </summary>
        [ProtoMember(2)]
        public Dictionary<Point, TileEvent> Events = new Dictionary<Point, TileEvent>();

        /// <summary>
        /// The collision hull for this tile layer, as a lookup table by point.
        /// </summary>
        [ProtoMember(3)]
        public Dictionary<Point, CollisionType> CollisionHull = new Dictionary<Point, CollisionType>();
    }

    /// <summary>
    /// The method of collision for a single tile.
    /// </summary>
    [Flags]
    public enum CollisionType
    {
        None = 0x0,
        Left = 0x10,
        Right = 0x100,
        Top = 0x1000,
        Bottom = 0x10000
    }
}