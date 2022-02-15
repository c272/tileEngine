using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tileEngine.Utility;

namespace tileEngine.SDK.Audio
{
    /// <summary>
    /// Represents a single currently active instance of a sound.
    /// </summary>
    public abstract class SoundInstance : Snowflake
    {
        /// <summary>
        /// The volume of this sound. Ranges from 0.0f (silent) to 1.0f (full volume).
        /// </summary>
        public abstract float Volume { get; set; }

        /// <summary>
        /// Whether this sound loops or not.
        /// </summary>
        public abstract bool Looping { get; set; }
    }
}
