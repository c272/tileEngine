using easyCase.Controls;
using easyCase.Nodes;
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

    public abstract class NodeField : SnowflakeAttribute
    {
        //The name of this field.
        public string Name;

        //The type of node field this is (input, output, etc.)
        public FieldType Type;

        //The underlying value type this field is expecting.
        public Type ValueType { get; protected set; }

        //The field this node is currently connected to.
        public NodeField ConnectedTo = null;

        //The colour of the attach node for this field.
        public Color NodeColour { get; protected set; }

        //The current location of this field's connector.
        public Vector2 ConnectorLocation { get; set; }

        //The node that owns this field.
        public Node Node { get; private set; }

        public NodeField(string name, FieldType type, Type valueType, Color nodeColour)
        {
            Name = name;
            Type = type;
            ValueType = valueType;
            NodeColour = nodeColour;
        }

        /// <summary>
        /// Sets the owner of this field to the provided node.
        /// </summary>
        public void SetOwner(Node node)
        {
            Node = node;
        }

        /// <summary>
        /// Gets the dimensions of this node field based on the settings of the node graph.
        /// </summary>
        public abstract Vector2 GetDimensions(NodeGraphControl control, Graphics graphics);

        /// <summary>
        /// Returns a Vector2 representing the dimensions of the connector in grid units.
        /// </summary>
        /// <returns></returns>
        public abstract Vector2 GetConnectorDimensions();

        /// <summary>
        /// Draws the connector at the provided point, on the given control.
        /// </summary>
        public abstract void DrawConnector(NodeGraphControl control, Graphics graphics, Vector2 topLeft, Vector2 bottomRight);

        /// <summary>
        /// Returns whether a given point is within the bounds of the connector for this field.
        /// </summary>
        public abstract bool PointWithinConnector(NodeGraphControl control, Point point);
        
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
