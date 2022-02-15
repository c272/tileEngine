using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tileEngine.Engine.Audio;
using tileEngine.SDK;
using tileEngine.SDK.Audio;
using tileEngine.SDK.Diagnostics;

namespace tileEngine.Engine
{
    /// <summary>
    /// Represents the Windows NAudio platform-specific implementation of the tileEngine Sound API.
    /// </summary>
    public class NAudioSound : Sound
    {
        /// <summary>
        /// The current overall volume of the sound API.
        /// </summary>
        public override float Volume { get => outputDevice.Volume; set => outputDevice.Volume = value; }

        /// <summary>
        /// The sample rate that this sound API is targeting.
        /// </summary>
        public int SampleRate { get; private set; }

        /// <summary>
        /// The number of channels this sound API is targeting.
        /// </summary>
        public int Channels { get; private set; }

        //The sound cache for loaded sound assets.
        Dictionary<string, LoadedNAudioSound> soundCache = new Dictionary<string, LoadedNAudioSound>();

        //The output device & mixing sampler for NAudio implementation.
        private IWavePlayer outputDevice;
        private MixingSampleProvider mixer;

        /// <summary>
        /// Constructs an instance of this NAudio sound API.
        /// </summary>
        /// <param name="sampleRate">The target sample rate of the API.</param>
        /// <param name="channels">The number of channels the API targets.</param>
        public NAudioSound(int sampleRate, int channels)
        {
            //Set properties.
            SampleRate = sampleRate;

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

        /// <summary>
        /// Loads the given sound into memory, returning a reference.
        /// This can be done to pre-load sounds, thus improving runtime latency/performance when playing sounds.
        /// </summary>
        public override SoundReference LoadSound(string assetName)
        {
            //If sound already in cache, return it.
            if (soundCache.ContainsKey(assetName))
                return new SoundReference(soundCache[assetName].ID, assetName);

            //If asset content path not available, throw.
            if (AssetManager.ContentManager == null)
            {
                DiagnosticsHook.LogMessage(21013, "Failed to load sound, asset manager was not yet initialized.");
                return default;
            }

            //If asset path mappings not available, throw.
            if (TileEngine.Instance?.GameData?.AssetMapping == null)
            {
                DiagnosticsHook.LogMessage(21014, "Failed to load sound, no game data asset mappings were loaded.");
                return default;
            }

            //Mapping exists?
            if (!TileEngine.Instance.GameData.AssetMapping.ContainsKey(assetName))
            {
                DiagnosticsHook.LogMessage(1011, $"Could not find asset mapping for asset '{assetName}' to attempt sound load.");
                return default;
            }

            //Attempt to get the file name.
            string fileName = null;
            try
            {
                FileInfo[] assetFiles = new DirectoryInfo(AssetManager.ContentManager.RootDirectory).GetFiles();
                fileName = assetFiles.Where(x => x.Name.Contains(TileEngine.Instance.GameData.AssetMapping[assetName].ToString()))
                                            .Select(x => x.FullName)
                                            .FirstOrDefault();
            }
            catch (Exception ex)
            {
                DiagnosticsHook.LogMessage(21015, $"Failed to find file path for sound '{assetName}': {ex.Message}");
                return default;
            }

            //Was a file found?
            if (fileName == null)
            {
                DiagnosticsHook.LogMessage(21016, $"Failed to find file path for '{assetName}', it did not exist in compiled directory.");
                return default;
            }

            //Try loading the file as a LoadedNAudioSound.
            LoadedNAudioSound loadedSound;
            try
            {
                loadedSound = new LoadedNAudioSound(fileName, SampleRate);
            }
            catch (Exception ex)
            {
                DiagnosticsHook.LogMessage(21017, $"Failed to load sound '{assetName}': {ex.Message}");
                return default;
            }

            //Add the sound to cache, return a reference.
            soundCache.Add(assetName, loadedSound);
            return new SoundReference(loadedSound.ID, assetName);
        }

        /// <summary>
        /// Plays the given sound, returning a reference to the playing instance of that sound.
        /// This instance can then be used to cancel/adjust the sound.
        /// </summary>
        public override SoundInstance PlaySound(string assetName, bool repeating = false)
        {
            //Load sound, pass to overload.
            var sound = LoadSound(assetName);
            return PlaySound(sound, repeating);
        }

        /// <summary>
        /// Plays the given sound reference, returning a reference to the instance of the playing sound.
        /// This instance can then be used to cancel/adjust the sound.
        /// </summary>
        public override SoundInstance PlaySound(SoundReference sound, bool repeating = false)
        {
            //Is the sound in cache, or is this a stale cache reference?
            var loadedSound = soundCache.Values.Where(x => x.ID == sound.ID).FirstOrDefault();
            if (loadedSound == null)
            {
                DiagnosticsHook.LogMessage(1012, $"Failed to play loaded sound from reference (ID {sound.ID}), this likely means you " +
                    $"have cleared sound cache, but have attempted to use a stale sound reference.");
                return null;
            }

            //Create a memory sample provider for sound instance, add to mixer.
            var memorySampler = new NAudioMemoryProvider(loadedSound);
            mixer.AddMixerInput(memorySampler);
            return memorySampler;
        }

        /// <summary>
        /// Stops the given currently playing sound instance.
        /// </summary>
        public override void StopSound(SoundInstance toStop)
        {
            var inputToStop = mixer.MixerInputs.Where(x => x is NAudioMemoryProvider)
                                               .Cast<NAudioMemoryProvider>()
                                               .Where(x => x.ID == toStop.ID)
                                               .FirstOrDefault();
            if (inputToStop != null)
                mixer.RemoveMixerInput(inputToStop);
        }
    }
}
