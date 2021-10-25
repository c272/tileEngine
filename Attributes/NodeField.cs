using easyCase.Controls;
using easyCase.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyCase.Attributes
{
    /// <summary>
    /// Represents a single field on a node, either an input or an output.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]

    public abstract class NodeField : Attribute
    {
        //The name of this field.
        public string Name;

        //The type of node field this is (input, output, etc.)
        public FieldType Type;

        //The field this node is currently connected to.
        public NodeField ConnectedTo = null;

        //The colour of the attach node for this field.
        public Color NodeColour { get; private set; }

        public NodeField(string name, FieldType type, Color nodeColour)
        {
            Name = name;
            Type = type;
            NodeColour = nodeColour;
        }

        /// <summary>
        /// Gets the dimensions of this node field based on the settings of the node graph.
        /// </summary>
        public abstract Vector2 GetDimensions(NodeGraphControl control, Graphics graphics);
        
        /// <summary>
        /// Draws this field to the node graph at the provided position.
        /// </summary>
        public abstract void Draw(NodeGraphControl control, Graphics graphics, Vector2 position);
    }

    /// <summary>
    /// Represents the type of node field that is being created.
    /// </summary>
    public enum FieldType
    {
        Input,
        Output
    }
}
