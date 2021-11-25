using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.RuntimeBuilder;

namespace tileEngine
{
    /// <summary>
    /// Class for compiling an tileEngine project to file.
    /// </summary>
    public static class ProjectCompiler
    {
        /// <summary>
        /// The logger to use for compiler output.
        /// </summary>
        public static ContentBuildLogger Logger = null;

        /// <summary>
        /// The current path that the compiler is compiling assets to.
        /// Null if no project is loaded.
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
        /// Compiled location is "./bin/output/".
        /// Returns null on successful compile, string compile error on failure.
        /// </summary>
        public static string Compile()
        {
            //Calculate directory paths.
            string tempDir = Path.Combine(ProjectManager.CurrentProjectDirectory, "obj", "temp");
            string workingDir = Path.Combine(ProjectManager.CurrentProjectDirectory, "obj", "assets");
            string intermediateDir = Path.Combine(ProjectManager.CurrentProjectDirectory, "obj", "intermediary");
            string outputDir = AssetCompilePath;

            //Compile all the assets to ./bin/compiled first.
            Logger?.LogMessage("Started compile for '" + ProjectManager.CurrentProject.Name + "' (" + DateTime.Now.ToString() + ").");
            try
            {
                CompileAssets(tempDir, workingDir, intermediateDir, outputDir);
            }
            catch (Exception e) { return e.Message; }

            //todo
            OnCompile?.Invoke(outputDir);
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
            foreach (var node in ProjectManager.CurrentProject.ProjectRoot.Nodes.Select(x => (ProjectTreeNode)x))
            {
                //Ignore non-asset nodes.
                if (!(node is ProjectAssetNode))
                    continue;

                //Get the asset node out.
                var assetNode = (ProjectAssetNode)node;
                var fileInfo = new FileInfo(Path.Combine(ProjectManager.CurrentProjectDirectory, assetNode.RelativeLocation));

                //If the node is meant to be compiled by XNB, then set that up now.
                if (assetNode.CompileXNB)
                {
                    string outFile = Path.Combine(tempDir, node.ID + fileInfo.Extension);
                    File.Copy(fileInfo.FullName, outFile, true);

                    //Add to file list.
                    fileNames.Add(outFile);
                }
                else
                {
                    //Not compiling by XNB, so just copy to output directory.
                    string outFile = Path.Combine(outputDir, node.ID + fileInfo.Extension);
                    if (!File.Exists(outFile))
                        File.Copy(fileInfo.FullName, outFile);
                }
            }

            //If no assets pending a compile, we return here.
            if (fileNames.Count == 0) { return; }

            //Compile all assets.
            await RuntimeBuilder.BuildContent(fileNames.ToArray());

            //Destroy temporary directory.
            Directory.Delete(tempDir, true);
            Logger?.LogMessage("Finished building assets.");
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
            AssetCompilePath = Path.Combine(newDirectory, "bin", "compiled");
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
