using tileEngine.SDK.Diagnostics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tileEngine.SDK
{
    /// <summary>
    /// Manages the loading and disposing of assets within the engine in a safe and exception-free manner.
    /// </summary>
    public static class AssetManager
    {
        /// <summary>
        /// The content manager used for loading assets.
        /// </summary>
        public static ContentManager ContentManager { get; set; }

        /// <summary>
        /// Mappings for this asset manager from a given set of string keys into asset IDs.
        /// Used for readable programming mappings for ID values.
        /// </summary>
        public static Dictionary<string, int> Mappings { get; set; } = new Dictionary<string, int>();

        /// <summary>
        /// Attempts to load the provided asset, given an asset binding, from asset storage.
        /// On failure, returns null.
        /// </summary>
        public static T AttemptLoad<T>(string mapping) where T : class
        {
            if (!Mappings.ContainsKey(mapping))
            {
                DiagnosticsHook.LogMessage(1007, $"Could not find asset mapping for asset '{mapping}' to attempt load.");
                return null;
            }

            return AttemptLoad<T>(Mappings[mapping]);
        }

        /// <summary>
        /// Attempts to load the provided asset ID from asset storage.
        /// On failure, returns null.
        /// </summary>
        public static T AttemptLoad<T>(int? assetID) where T : class
        {
            //If ID is null, return null.
            if (assetID == null)
                return null;

            //Attempt to grab asset.
            T toReturn;
            try
            {
                toReturn = ContentManager.Load<T>(assetID.ToString());
            }
            catch 
            {
                //Failed to load an asset.
                if (DiagnosticsHook.Mode == DiagnosticsMode.Editor)
                {
                    DiagnosticsHook.LogMessage(1001, "An asset tried to load that has not yet been compiled. Build your project for it to appear.", DiagnosticsSeverity.Notice);
                }
                else { DiagnosticsHook.LogMessage(1002, "Could not find asset of ID '" + assetID + "' to load."); }
                return null; 
            }
            return toReturn;
        }
    }
}
