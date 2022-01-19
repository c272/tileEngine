using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tileEngine.SDK.Map
{
    /// <summary>
    /// Represents data passed to the event handler upon an event firing.
    /// </summary>
    public class TileEventData
    {
        /// <summary>
        /// The game object that triggered the event.
        /// </summary>
        public GameObject TriggeringObject { get; set; }

        /// <summary>
        /// The type of interaction that triggered this event.
        /// </summary>
        public EventTriggerType TriggerType { get; set; }

        /// <summary>
        /// The in-game location at which this event was triggered.
        /// </summary>
        public Vector2 Location { get; set; }
    }
}
