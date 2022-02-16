using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using tileEngine.SDK.Diagnostics;
using tileEngine.Utility;

namespace tileEngine.Engine
{
    /// <summary>
    /// Represents a single NAudio-based sound loaded at runtime.
    /// </summary>
    public class LoadedNAudioSound : Snowflake
    {
        /// <summary>
        /// The raw audio data for this sound.
        /// </summary>
        public float[] Data { get; private set; }

        /// <summary>
        /// The format of the audio that has been loaded.
        /// </summary>
        public WaveFormat Format { get; private set; }

        public LoadedNAudioSound(string fileLocation, int sampleRate)
        {
            //Create a reader, resample audio to target if required.
            var reader = new AudioFileReader(fileLocation);
            ISampleProvider provider = reader;
            if (reader.WaveFormat.SampleRate != sampleRate)
            {
                //Resample required.
                provider = new WdlResamplingSampleProvider(reader, sampleRate);
            }
            Format = provider.WaveFormat;

            //Ignore all formats but dual channel at the moment.
            if (Format.Channels != 2)
            {
                throw new Exception("Audio processing is currently limited to dual-channel audio only.");
            }

            //Read file into data.
            //TODO: This could probably be made more efficient (remove LINQ conversions).
            var fileData = new List<float>();
            float[] buf = new float[provider.WaveFormat.Channels * provider.WaveFormat.SampleRate];
            int numSamples = 0;
            do
            {
                numSamples = provider.Read(buf, 0, buf.Length);
                fileData.AddRange(buf.Take(numSamples));
            }
            while (numSamples > 0);

            //Copy final data.
            Data = fileData.ToArray();
            if (Data.Length == 0)
            {
                DiagnosticsHook.LogMessage(1013, $"The sound at '{fileLocation}' could not be read into a properly formatted byte stream." +
                    $"\nThis is usually because of a formatting issue, try this sound in a different file format.");
                return;
            }
        }
    }
}