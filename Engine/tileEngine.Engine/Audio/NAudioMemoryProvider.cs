using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tileEngine.SDK.Audio;

namespace tileEngine.Engine.Audio
{
    /// <summary>
    /// Represents a single NAudio sample provider to play cached in-memory sounds.
    /// </summary>
    public class NAudioMemoryProvider : SoundInstance, ISampleProvider
    {
        /// <summary>
        /// The wave format that this provider uses.
        /// </summary>
        public WaveFormat WaveFormat => Sound.Format;

        /// <summary>
        /// The sound that this provider is providing samples for from memory.
        /// </summary>
        public LoadedNAudioSound Sound { get; private set; }

        /// <summary>
        /// The volume of this sample provider.
        /// </summary>
        public override float Volume { get; set; } = 1.0f;

        /// <summary>
        /// Whether this sample provider loops or not.
        /// </summary>
        public override bool Looping { get; set; } = false;

        //The current position of the head in the sample.
        private long position = 0;

        public NAudioMemoryProvider(LoadedNAudioSound sound)
        {
            Sound = sound;
        }

        /// <summary>
        /// Reads the given amount of data from the sample in memory.
        /// </summary>
        public int Read(float[] buffer, int offset, int count)
        {
            //If we're not looping or not on the end, do it the normal way.
            if (!Looping || count < Sound.Data.Length - position)
            {
                //Don't try and read more samples than we have left.
                long samplesToCopy = Math.Min(count, Sound.Data.Length - position);

                //Copy into buffer, bump position.
                Array.Copy(Sound.Data, position, buffer, offset, samplesToCopy);
                position += samplesToCopy;
                return (int)samplesToCopy;
            }

            //We're looping back to the start, copy samples up till end.
            long amtTillEnd = Sound.Data.Length - position;
            Array.Copy(Sound.Data, position, buffer, offset, amtTillEnd);
            position = 0;
            Array.Copy(Sound.Data, position, buffer, offset + amtTillEnd, count - amtTillEnd);
            return count;
        }
    }
}
