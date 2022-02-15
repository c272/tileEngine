using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tileEngine.SDK.Audio
{
    /// <summary>
    /// Represents a generic accessible sound API within tileEngine.
    /// Should be inherited per-platform and implemented as necessary.
    /// </summary>
    public abstract class Sound
    {
        /// <summary>
        /// The current master volume of the sound API.
        /// </summary>
        public abstract float Volume { get; set; }

        /// <summary>
        /// Loads a provided sound asset into the sound cache, for use later.
        /// Can be used to prevent sounds from loading at first play, for optimisation purposes.
        /// </summary>
        public abstract SoundReference LoadSound(string assetName);

        /// <summary>
        /// Clears the current sound cache for this API.
        /// </summary>
        public abstract void ClearSoundCache();

        /// <summary>
        /// Plays a given sound asset, returning an instance of the sound for later reference.
        /// </summary>
        public abstract SoundInstance PlaySound(string assetName, bool repeating = false);

        /// <summary>
        /// Plays a given sound reference, returning an instance of the sound for later reference.
        /// </summary>
        public abstract SoundInstance PlaySound(SoundReference sound, bool repeating = false);

        /// <summary>
        /// Stops a sound playing, given a sound ID returned from PlaySound().
        /// </summary>
        public abstract void StopSound(SoundInstance toStop);
    }
}
