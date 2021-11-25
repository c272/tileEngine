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

        //Event triggered when the currently open project changes.
        public delegate void ProjectChangedHandler(Project newProject);
        public static event ProjectChangedHandler OnProjectChanged;

        //Event triggered when the current project directory changes.
        public delegate void ProjectDirectoryChangedHandler(string newDirectory);
        public static event ProjectDirectoryChangedHandler OnProjectDirectoryChanged;

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

            return null;
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

            //Set current project.
            CurrentProject = project;
            CurrentProjectLocation = fileLoc;
            CurrentProjectDirectory = new FileInfo(fileLoc).DirectoryName;
            return true;
        }
    }
}
