using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tileEngine.SDK.Audio;

namespace tileEngine.Engine
{
    /// <summary>
    /// Represents the Windows platform-specific implementation of the tileEngine Sound API.
    /// </summary>
    public class GameSound : Sound
    {
        public override int Volume { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        //The sound cache for loaded sound assets.
        Dictionary<string, RuntimeSound> soundCache = new Dictionary<string, RuntimeSound>();

        //The output device & mixing sampler for NAudio implementation.
        private IWavePlayer outputDevice;
        private MixingSampleProvider mixer;

        public GameSound(int sampleRate, int channels)
        {
            //Initialize the output device with a blank mixer, and start playing.
            outputDevice = new WaveOutEvent();
            mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, channels))
            {
                ReadFully = true
            };
            outputDevice.Init(mixer);
            outputDevice.Play();
        }

        /// <summary>
        /// Clears the sound API's cache of all loaded sounds.
        /// </summary>
        public override void ClearSoundCache()
        {
            soundCache.Clear();
        }

        public override void LoadSound(string assetName)
        {
            throw new NotImplementedException();
        }

        public override int PlaySound(string assetName, bool repeating = false)
        {
            throw new NotImplementedException();
        }

        public override void StopSound(int soundID)
        {
            throw new NotImplementedException();
        }
    }
}
