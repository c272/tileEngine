using DarkUI.Forms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tileEngine.Configuration
{
    /// <summary>
    /// Represents a class to configure global settings for tileEngine.
    /// </summary>
    public class TileEngineConfig
    {
        /// <summary>
        /// The currently loaded instance of the configuration.
        /// </summary>
        public static TileEngineConfig Config { get; private set; }

        /// <summary>
        /// The font size of the editor, for scaling purposes.
        /// </summary>
        [JsonProperty("scale")]
        public float Scale { get; private set; } = 1f;

        /// <summary>
        /// Loads the editor config from the given file.
        /// </summary>
        public static void LoadFromFile(string fileName)
        {
            //If file does not exist, create it.
            if (!File.Exists(fileName))
            {
                Config = new TileEngineConfig();
                File.WriteAllText(fileName, JsonConvert.SerializeObject(Config));
                return;
            }

            //File exists, attempt to load config.
            try
            {
                Config = JsonConvert.DeserializeObject<TileEngineConfig>(File.ReadAllText(fileName));
            }
            catch (Exception e)
            {
                DarkMessageBox.ShowError("Failed to load configuration from file: " + e.Message + "\nFalling back to default config.", "tileEngine - Config Load Failed");
                Config = new TileEngineConfig();
            }
        }
    }
}
