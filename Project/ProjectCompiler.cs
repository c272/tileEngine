using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.RuntimeBuilder;
using ProtoBuf.Meta;
using tileEngine.SDK;
using tileEngine.SDK.Serializer;
using tileEngine.Utility;

namespace tileEngine
{
    /// <summary>
    /// Class for compiling an tileEngine project to file.
    /// </summary>
    public static class ProjectCompiler
    {
        /// <summary>
        /// Directory containing the tileEngine player files, relative to the application directory.
        /// </summary>
        public const string PLAYER_DIRECTORY = "player";

        /// <summary>
        /// The logger to use for compiler output.
        /// </summary>
        public static ContentBuildLogger Logger = null;

        /// <summary>
        /// The current main directory that the compiler outputs to.
        /// Null when no project is loaded.
        /// </summary>
        public static string CompilePath = null;

        /// <summary>
        /// The current path that the compiler is compiling assets to.
        /// Null when no project is loaded.
        /// </summary>
        public static string AssetCompilePath = null;

        /// <summary>
        /// The runtime MonoGame asset builder used for asset compilation.
        /// </summary>
        private static RuntimeBuilder RuntimeBuilder = null;

        /// <summary>
        /// Triggered whenever a compile is completed.
        /// </summary>
        public static event OnCompileHandler OnCompile;
        public delegate void OnCompileHandler(string assetPath);

        /// <summary>
        /// Set up event handlers for project compiler.
        /// </summary>
        static ProjectCompiler()
        {
            //Compute asset compile path on project change.
            ProjectManager.OnProjectChanged += projectChanged;
            ProjectManager.OnProjectDirectoryChanged += projectDirChanged;
        }

        /// <summary>
        /// Compiles the currently active project to file at the current project location.
        /// Compiled location is "./bin".
        /// Returns null on successful compile, string compile error on failure.
        /// </summary>
        public static string Compile()
        {
            //Calculate directory paths.
            string tempDir = Path.Combine(ProjectManager.CurrentProjectDirectory, "obj", "temp");
            string workingDir = Path.Combine(ProjectManager.CurrentProjectDirectory, "obj", "assets");
            string intermediateDir = Path.Combine(ProjectManager.CurrentProjectDirectory, "obj", "intermediary");
            string assemblyCompileDir = Path.Combine(ProjectManager.CurrentProjectDirectory, "obj", "out");
            string externalDir = Path.Combine(ProjectManager.CurrentProjectDirectory, "bin", "external");

            //Compile all the assets to ./bin/compiled first.
            Logger?.LogMessage("Started compile for '" + ProjectManager.CurrentProject.Name + "' (" + DateTime.Now.ToString() + ").");
            try
            {
                CompileAssets(tempDir, workingDir, intermediateDir, AssetCompilePath);
            }
            catch (Exception e) { return e.Message; }

            //Serialize the various project properties into the game data container blob.
            Logger?.LogMessage("Packing project properties & map data into container.");
            var container = new GameDataContainer()
            {
                AssemblyName = ProjectManager.CurrentProject.AssemblyName,
                Title = ProjectManager.CurrentProject.Title,
                WindowSize = ProjectManager.CurrentProject.WindowSize
            };

            //Add all scene maps to game data container blob.
            foreach (var scene in ProjectManager.CurrentProject.ProjectRoot.GetNodesOfType<ProjectSceneNode>())
            {
                //Ignore the scene if non-editable (no linked type).
                if (!scene.CanEdit)
                    continue;
                container.Maps.Add(scene.LinkedTypeName, scene.TileMap);
            }

            //Serialize the container to file.
            Logger?.LogMessage("Serializing game data container to binary blob 'main.bin'...");
            ProtobufSerializer.PrepareSerializer();
            try
            {
                using (var file = File.Create(Path.Combine(CompilePath, "main.bin")))
                {
                    RuntimeTypeModel.Default.Serialize(file, container);
                }
            }
            catch (Exception e) { return e.Message; }
            Logger?.LogMessage("Completed container serialization.");

            //Attempt to copy the player into the output directory.
            Logger?.LogMessage("Copying tileEngine Player into the build output directory...");
            int filesCopied = 0;
            try
            {
                string playerDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, PLAYER_DIRECTORY);
                foreach (FileInfo file in new DirectoryInfo(playerDir).GetFiles())
                {
                    //If the file hasn't been copied yet, copy it.
                    string destinationFile = Path.Combine(CompilePath, file.Name);
                    if (!File.Exists(destinationFile))
                    {
                        File.Copy(file.FullName, destinationFile);
                        filesCopied++;
                    }
                }
            }
            catch (Exception e) { return e.Message; }
            Logger?.LogMessage($"Finished copying player into output directory, copied {filesCopied} files.");

            //Copy the linked assemblies for the project into the "external" subfolder.
            Logger?.LogMessage("Copying linked external game assemblies into 'external' directory...");
            filesCopied = 0;
            try
            {
                //Check that the DLL exists to be copied.
                string dllLoc = Path.Combine(assemblyCompileDir, ProjectManager.CurrentProject.AssemblyName + ".dll");
                string outputLoc = Path.Combine(externalDir, ProjectManager.CurrentProject.AssemblyName + ".dll");
                if (!File.Exists(dllLoc))
                {
                    Logger?.LogMessage("Failed to build: External game assembly has not been built. Please build it before compiling.");
                    return "External game assembly not built. Please build it before compiling.";
                }

                //Copy the DLL.
                Directory.CreateDirectory(externalDir);
                if (File.Exists(outputLoc))
                    File.Delete(outputLoc);
                File.Copy(dllLoc, outputLoc);
                filesCopied++;

                //todo: copy external DLL's dependencies
            }
            catch (Exception e) { return e.Message; }
            Logger?.LogMessage($"Finished copying external game assemblies. Copied {filesCopied} files.");

            Logger?.LogMessage("\nBuild successful.");
            OnCompile?.Invoke(AssetCompilePath);
            return null;
        }

        /// <summary>
        /// Compiles all the assets in the current project tree to file at "./bin/compiled/".
        /// </summary>
        public static async void CompileAssets(string tempDir, string workingDir, string intermediateDir, string outputDir)
        {
            Logger?.LogMessage("Beginning asset compilation step...");

            //Make all directories, if they're not already there.
            Directory.CreateDirectory(tempDir);
            Directory.CreateDirectory(workingDir);
            Directory.CreateDirectory(intermediateDir);
            Directory.CreateDirectory(outputDir);

            //If the runtime builder hasn't been created yet, make it now.
            if (RuntimeBuilder == null)
            {
                //Create the runtime builder.
                RuntimeBuilder = new RuntimeBuilder(workingDir, intermediateDir, outputDir, TargetPlatform.Windows, GraphicsProfile.HiDef, true);
                RuntimeBuilder.Logger = Logger;
            }

            //Copy all the assets into the working directory.
            var fileNames = new List<string>();
            foreach (var assetNode in ProjectManager.CurrentProject.ProjectRoot.GetNodesOfType<ProjectAssetNode>())
            {
                var fileInfo = new FileInfo(Path.Combine(ProjectManager.CurrentProjectDirectory, assetNode.RelativeLocation));

                //If the node is meant to be compiled by XNB, then set that up now.
                if (assetNode.CompileXNB)
                {
                    string outFile = Path.Combine(tempDir, assetNode.ID + fileInfo.Extension);
                    File.Copy(fileInfo.FullName, outFile, true);

                    //Add to file list.
                    fileNames.Add(outFile);
                }
                else
                {
                    //Not compiling by XNB, so just copy to output directory.
                    string outFile = Path.Combine(outputDir, assetNode.ID + fileInfo.Extension);
                    if (!File.Exists(outFile))
                        File.Copy(fileInfo.FullName, outFile);
                }
            }

            //If no assets pending a compile, we return here.
            if (fileNames.Count == 0) 
            {
                Logger?.LogMessage("Finished building assets.");
                return; 
            }

            //Compile all assets.
            await RuntimeBuilder.BuildContent(fileNames.ToArray());

            //Destroy temporary directory.
            Directory.Delete(tempDir, true);
            Logger?.LogMessage("Runtime builder has finished building assets.");
        }

        /// <summary>
        /// Invalidates the current runtime builder.
        /// Should be used if the directories to compile assets to have changed.
        /// </summary>
        public static void ResetRuntimeBuilder()
        {
            RuntimeBuilder = null;
        }

        /// <summary>
        /// Triggered when the project directory is altered.
        /// </summary>
        private static void projectDirChanged(string newDirectory)
        {
            CompilePath = Path.Combine(newDirectory, "bin");
            AssetCompilePath = Path.Combine(CompilePath, "compiled");
        }

        /// <summary>
        /// Triggered when the project is changed.
        /// </summary>
        private static void projectChanged(Project newProject)
        {
            //Reset the runtime builder.
            ResetRuntimeBuilder();
        }
    }
}
