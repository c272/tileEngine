using FontStashSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tileEngine.SDK.Diagnostics;

namespace tileEngine.SDK.GUI
{
    /// <summary>
    /// Font manager for the GUI system within tileEngine.
    /// Can be interacted with directly, however is also managed automatically by the UI system.
    /// </summary>
    public static class FontManager
    {
        /// <summary>
        /// The font system for loading and managing fonts.
        /// </summary>
        private static Dictionary<string, FontSystem> fontSystems = new Dictionary<string, FontSystem>();

        /// <summary>
        /// Fonts that have already had errors logged, and don't need pushing again.
        /// </summary>
        private static List<string> errorLogged = new List<string>();

        /// <summary>
        /// Returns whether the given font is currently loaded in the font manager.
        /// </summary>
        public static bool IsFontLoaded(string name) { return fontSystems.ContainsKey(name); }

        /// <summary>
        /// Loads the given absolute path font into the font manager for later use.
        /// </summary>
        public static bool LoadFont(string fontName, string path)
        {
            //If the font is already loaded, we'll ignore this call.
            if (fontSystems.ContainsKey(fontName))
            {
                return false;
            }

            //Attempt to load font file.
            try
            {
                byte[] font = File.ReadAllBytes(path);
                var fontSystem = new FontSystem();
                fontSystem.AddFont(font);
                fontSystems.Add(fontName, fontSystem);
            }
            catch (Exception e)
            {
                DiagnosticsHook.LogMessage(1013, $"Failed to load provided font file '{path}': {e.Message}");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Attempts to load all font files from the given root directory.
        /// Supports the ".otf" and ".ttf" file extensions.
        /// </summary>
        public static void LoadFromDirectory(string rootDirectory)
        {
            //Attempt to iterate over all files in the directory.
            var fontsToLoad = new List<FileInfo>();
            try
            {
                var dirInfo = new DirectoryInfo(rootDirectory);
                foreach (FileInfo file in dirInfo.GetFiles())
                {
                    if (file.Extension == ".ttf" || file.Extension == ".otf")
                    {
                        fontsToLoad.Add(file);
                    }
                }
            }
            catch (Exception e)
            {
                DiagnosticsHook.LogMessage(1014, $"Failed to get font list from directory '{rootDirectory}': {e.Message}");
                return;
            }

            //Load all the fonts.
            foreach (var font in fontsToLoad)
            {
                LoadFont(Path.GetFileNameWithoutExtension(font.FullName), font.FullName);
            }

            //Clear error logs.
            errorLogged.Clear();
        }

        /// <summary>
        /// Gets the font of the given name, at the provided point size.
        /// </summary>
        public static SpriteFontBase GetFont(string name, int size)
        {
            if (!fontSystems.ContainsKey(name))
            {
                if (!errorLogged.Contains(name))
                {
                    DiagnosticsHook.LogMessage(1015, $"Font '{name}' called for use, but has not been loaded.");
                    errorLogged.Add(name);
                }
                return null;
            }

            //Return the font.
            return fontSystems[name].GetFont(size);
        }

        /// <summary>
        /// Attempts to get the font specified at the given size for use.
        /// If this attempt fails, then returns false. Returns true on success.
        /// </summary>
        public static bool TryGetFont(string name, int size, out SpriteFontBase font)
        {
            font = GetFont(name, size);
            if (font == null)
                return false;
            return true;
        }
    }
}
