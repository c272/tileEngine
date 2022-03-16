using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tileEngine.SDK.Map
{
    /// <summary>
    /// Represents a single event that can occur on a single tile.
    /// </summary>
    [ProtoContract]
    public class TileEvent
    {
        /// <summary>
        /// The name of the event function that is linked to this event.
        /// </summary>
        [ProtoMember(1)]
        public string LinkedFunction { get; set; } = null;

        /// <summary>
        /// The method by which this event is triggered.
        /// </summary>
        [ProtoMember(2)]
        public EventTriggerType Trigger { get; set; } = EventTriggerType.Interaction;

        /// <summary>
        /// Some arbitrary data that can be assigned to individual tile events.
        /// </summary>
        [ProtoMember(3)]
        public string Data { get; set; } = string.Empty;

        /// <summary>
        /// Returns a clone of this tile event data.
        /// </summary>
        public TileEvent Clone()
        {
            return new TileEvent()
            {
                Data = Data,
                Trigger = Trigger,
                LinkedFunction = LinkedFunction,
            };
        }
    }

    /// <summary>
    /// Methods by which a tile map event can be triggered.
    /// </summary>
    public enum EventTriggerType
    {
        Interaction,
        GameObjectCollide,
        LevelStart
    }
}
