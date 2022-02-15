using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tileEngine.Utility;

namespace tileEngine.SDK.Audio
{
    /// <summary>
    /// Represents a single reference to a sound loaded by the audio engine.s
    /// </summary>
    public struct SoundReference
    {
        /// <summary>
        /// The ID of this sound reference.
        /// </summary>
        public int ID { get; private set; }

        /// <summary>
        /// The name of the loaded sound that this reference points to.
        /// </summary>
        public string Name { get; private set; }


        /// <summary>
        /// Constructs this sound reference with the given ID and name.
        /// </summary>
        public SoundReference(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
