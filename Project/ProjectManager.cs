using DarkUI.Forms;
using tileEngine.Utility;
using Microsoft.Xna.Framework;
using ProtoBuf;
using ProtoBuf.Meta;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using tileEngine.SDK;

namespace tileEngine
{
    /// <summary>
    /// The project manager for the editor.
    /// Handles the saving, loading and modification of projects on disk.
    /// </summary>
    public static class ProjectManager
    {
        /// <summary>
        /// The currently loaded project.
        /// </summary>
        public static Project CurrentProject
        {
            get { return curProj; }
            set
            {
                curProj = value;
                OnProjectChanged?.Invoke(curProj);
            }
        }
        private static Project curProj = null;

        /// <summary>
        /// The currently loaded project's location.
        /// </summary>
        public static string CurrentProjectLocation = null;

        /// <summary>
        /// The currently loaded project's root directory.
        /// </summary>
        public static string CurrentProjectDirectory
        {
            get { return curProjDir; }
            set
            {
                curProjDir = value;
                OnProjectDirectoryChanged?.Invoke(value);
            }
        }
        private static string curProjDir = null;

        /// <summary>
        /// The current assembly loaded for the project.
        /// </summary>
        public static Assembly CurrentProjectAssembly { get; private set; }

        //Event triggered when the currently open project changes.
        public delegate void ProjectChangedHandler(Project newProject);
        public static event ProjectChangedHandler OnProjectChanged;

        //Event triggered when the current project directory changes.
        public delegate void ProjectDirectoryChangedHandler(string newDirectory);
        public static event ProjectDirectoryChangedHandler OnProjectDirectoryChanged;

        //Event triggered when the project assembly is reloaded.
        public delegate void ProjectAssemblyReloadedHandler();
        public static event ProjectAssemblyReloadedHandler OnProjectAssemblyReload;

        /// <summary>
        /// A private app domain for dynamically loading and unloading assemblies.
        /// </summary>
        private static AppDomain dynamicLoaderDomain = null;

        //Whether the serializer has already been prepared or not.
        private static bool serializerPrepared = false;

        /// <summary>
        /// Prepares the serializer to save nodes to file by registering them as sub-types at runtime.
        /// </summary>
        private static void PrepareSerializer()
        {
            //If the serializer has already been prepared, ignore this call.
            if (serializerPrepared)
                return;

            //Register all subtypes of necessary types for serialization.
            RegisterSubTypes(typeof(Snowflake), 500);
            RegisterSubTypes(typeof(ProjectTreeNode), 500);

            //Force protobuf to compile MonoGame's Vector2.
            var vec2 = RuntimeTypeModel.Default.Add(typeof(Vector2));
            vec2.AddField(1, "X");
            vec2.AddField(2, "Y");

            //Force protobuf to serialize MonoGame's Point.
            var point = RuntimeTypeModel.Default.Add(typeof(Point));
            point.AddField(1, "X");
            point.AddField(2, "Y");
            serializerPrepared = true;
        }

        /// <summary>
        /// Registers all subtypes of the given type into Protobuf-net, with the given starting ID.
        /// </summary>
        private static void RegisterSubTypes(Type baseType, int startID)
        {
            //Get all sub-types of the given type.
            var assembly = baseType.Assembly;
            var subTypes = assembly.GetTypes().Where(t => t.IsSubclassOf(baseType) && t.BaseType == baseType);

            //Register them with the runtime model, starting at ID "startID".
            for (int i = 0; i < subTypes.Count(); i++)
            {
                Type subType = subTypes.ElementAt(i);
                RuntimeTypeModel.Default[baseType].AddSubType(startID + i, subType);
                RegisterSubTypes(subType, startID);
            }
        }

        /// <summary>
        /// Attempts to load a project from the given path.
        /// </summary>
        public static Exception LoadProject(string filePath)
        {
            //Prepare the serializer for deserialization.
            PrepareSerializer();

            //Attempt to deserialize from the path.
            try
            {
                using (var file = File.OpenRead(filePath))
                {
                    CurrentProject = RuntimeTypeModel.Default.Deserialize<Project>(file);
                }
                CurrentProjectLocation = filePath;
                CurrentProjectDirectory = new FileInfo(filePath).DirectoryName;
            }
            catch (Exception e) { return e; }

            //Complete deserialization on the project items.
            CurrentProject.ProjectRoot.CompleteDeserialize();
            foreach (var item in CurrentProject.ProjectRoot.Nodes.Select(x => (ProjectTreeNode)x))
            {
                item.CompleteDeserialize();
            }

            //Start a scan for classes in the built project ".dll" (if we can find it).
            ReloadProjectClasses();
            return null;
        }

        /// <summary>
        /// Searches for classes within the built project CLR ".dll" file to display in the editor.
        /// </summary>
        public static bool ReloadProjectClasses()
        {
            //Does the DLL exist?
            string dllLoc = Path.Combine(CurrentProjectDirectory, "obj", "out", CurrentProject.AssemblyName + ".dll");
            if (!File.Exists(dllLoc))
                return false;

            //If we've not cycled the dynamic loading AppDomain yet, do it.
            if (dynamicLoaderDomain != null)
                AppDomain.Unload(dynamicLoaderDomain);

            //Create the new domain.
            dynamicLoaderDomain = AppDomain.CreateDomain("tileEngine.DynamicLoader", null, new AppDomainSetup
            {
                ApplicationName = "tileEngine.DynamicLoader",
                ShadowCopyFiles = "true",
                PrivateBinPath = Path.Combine(CurrentProjectDirectory, "bin", "dynamic")
            });

            //Attempt to load the new assembly into the system.
            var loader = new AppDomainLoader(dllLoc);
            dynamicLoaderDomain.DoCallBack(loader.Run);
            CurrentProjectAssembly = loader.Result;

            //Finished!
            OnProjectAssemblyReload?.Invoke();
            return true;
        }

        /// <summary>
        /// Shows an open project dialog to the user.
        /// Returns null on fail, file path on selection.
        /// </summary>
        public static string ShowOpenProjectDialog()
        {
            //Show the user the dialog.
            var dialog = new OpenFileDialog()
            {
                DefaultExt = ".teproj",
                Filter = "tileEngine Project (.teproj)|*.teproj",
                Title = "Open an existing tileEngine project (*.teproj).",
                Multiselect = false
            };
            if (dialog.ShowDialog() != DialogResult.OK)
                return null;
            return dialog.FileName;
        }

        /// <summary>
        /// Saves the project currently open to file.
        /// Returns null on success, exception on fail.
        /// </summary>
        public static Exception SaveProject()
        {
            if (CurrentProject == null || CurrentProjectLocation == null)
                return new Exception("No project currently loaded, cannot save.");
            return SaveProject(CurrentProject, CurrentProjectLocation);
        }

        /// <summary>
        /// Attempts to save the project to the given file path.
        /// Returns null on success, exception on fail.
        /// </summary>
        public static Exception SaveProject(Project project, string filePath)
        {
            //Prepare the serializer for deserialization.
            PrepareSerializer();

            //Prepare the project items for serialization.
            project.ProjectRoot.PrepareSerialize();
            foreach (var item in project.ProjectRoot.Nodes.Select(x => (ProjectTreeNode)x))
            {
                item.PrepareSerialize();
            }

            //Serialize!
            try
            {
                using (var file = File.Create(filePath))
                {
                    RuntimeTypeModel.Default.Serialize(file, project);
                }
            }
            catch (Exception e) { return e; }
            return null;
        }

        /// <summary>
        /// Attempts to create a new project at the given location, returning a success or not.
        /// Also sets the new project as the current project.
        /// </summary>
        public static bool CreateNew(string name, string fileLoc)
        {
            //Create a new project with the given name.
            Project project = new Project(name);

            //Attempt to serialize to file.
            var err = SaveProject(project, fileLoc);
            if (err != null)
                return false;

            //Try and create the C# solution for this project w/ default config.
            var csRoot = Microsoft.Build.Construction.ProjectRootElement.Create();
            csRoot.AddImport("$(MSBuildExtensionsPath)\\$(MSBuildToolsVersion)\\Microsoft.Common.props");
            csRoot.AddImport("$(MSBuildToolsPath)\\Microsoft.CSharp.targets");
                
            //Build configuration.
            var defaultGroup = csRoot.AddPropertyGroup();
            defaultGroup.AddProperty("Configuration", "Debug");
            defaultGroup.AddProperty("DebugSymbols", "false");
            defaultGroup.AddProperty("Platform", "x64");
            defaultGroup.AddProperty("ProjectGuid", "{" + Guid.NewGuid().ToString().ToUpper() + "}");
            defaultGroup.AddProperty("OutputType", "Library");
            defaultGroup.AddProperty("OutputPath", "obj/out");
            defaultGroup.AddProperty("RootNamespace", project.Name);
            defaultGroup.AddProperty("AssemblyName", project.Name);
            defaultGroup.AddProperty("TargetFrameworkVersion", "v4.7.2");
            defaultGroup.AddProperty("FileAlignment", "512");
            defaultGroup.AddProperty("AutoGenerateBindingRedirects", "true");
            defaultGroup.AddProperty("Deterministic", "true");

            //Compile properties.
            defaultGroup.AddProperty("PlatformTarget", "x64");
            defaultGroup.AddProperty("ErrorReport", "prompt");
            defaultGroup.AddProperty("WarningLevel", "4");
             
            //Add references to basic stuff (System, etc.).
            var refGroup = csRoot.AddItemGroup();
            refGroup.AddItem("Reference", "System, Version=4.0.0.0");
            refGroup.AddItem("Reference", "System.Core, Version=4.0.0.0");
            refGroup.AddItem("Reference", "Microsoft.CSharp");

            //Add an empty compile group.
            var compile = csRoot.AddItemGroup();

            //Save the project to file.
            try
            {
                csRoot.Save(Path.Combine(new FileInfo(fileLoc).DirectoryName, project.Name + ".csproj"));
            }
            catch { return false; }

            //Set current project.
            CurrentProject = project;
            CurrentProjectLocation = fileLoc;
            CurrentProjectDirectory = new FileInfo(fileLoc).DirectoryName;
            return true;
        }
    }
}
