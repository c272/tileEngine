using tileEngine.Controls;
using Microsoft.Xna.Framework;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tileEngine.Utility;

namespace tileEngine
{
    /// <summary>
    /// Represents a single project that can be saved and loaded from disk in tileEngine.
    /// </summary>
    [ProtoContract]
    public class Project
    {
        /// <summary>
        /// Regex representing a valid project name.
        /// This should be a valid C# namespace identifier. 
        /// </summary>
        public const string VALID_NAME_REGEX = "^([a-z_A-Z]\\w+(?:\\.[a-z_A-Z]\\w+)*)$";

        /// <summary>
        /// The name of this project.
        /// </summary>
        [ProtoMember(2)]
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnNameChanged?.Invoke(value);
            }
        }
        private string name;

        //Event for when the name of the project is changed.
        public delegate void OnNameChangedHandler(string newName);
        public event OnNameChangedHandler OnNameChanged;

        /// <summary>
        /// The name of the C# assembly that this project is tied to.
        /// This is immutable.
        /// </summary>
        [ProtoMember(5)]
        public string AssemblyName { get; private set; }

        /// <summary>
        /// The title of the project (as seen in-game).
        /// </summary>
        [ProtoMember(3)]
        public string Title { get; set; }

        /// <summary>
        /// The desired window size of the game at runtime.
        /// </summary>
        [ProtoMember(4)]
        public Point WindowSize
        {
            get { return windowSize; }
            set
            {
                windowSize = value;
                OnWindowSizeChanged?.Invoke(value);
            }
        }
        private Point windowSize = new Point(800, 600);

        //Event for when the window size of the project is changed.
        public delegate void OnWindowSizeChangedHandler(Point size);
        public event OnWindowSizeChangedHandler OnWindowSizeChanged;

        /// <summary>
        /// The project items contained within the project.
        /// </summary>
        [ProtoMember(1)]
        public ProjectRootNode ProjectRoot { get; set; }

        public Project(string name)
        {
            Name = name;
            AssemblyName = name;
            Title = name;
            ProjectRoot = new ProjectRootNode(Name);
        }

        //Blank constructor for deserialization.
        private Project() { }
    }
}
