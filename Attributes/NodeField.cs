﻿using nodeGame.Controls;
using nodeGame.Nodes;
using nodeGame.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace nodeGame.Attributes
{
    /// <summary>
    /// Represents a single field on a node, either an input or an output.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]

    public abstract class NodeField : SnowflakeAttribute
    {
        /// <summary>
        /// The name of this field.
        /// </summary>
        public string Name;

        /// <summary>
        /// The type of node field this is (input, output, etc.)
        /// </summary>
        public FieldType Type;

        /// <summary>
        /// The underlying value type this field is expecting.
        /// </summary>
        public Type ValueType { get; protected set; }

        /// <summary>
        /// The field this node is currently connected to.
        /// </summary>
        public NodeField ConnectedTo 
        { 
            get { return connectedTo; }
            set 
            {
                connectedTo = value;
                OnConnectedFieldChanged?.Invoke(this);
            } 
        }
        private NodeField connectedTo = null;

        /// <summary>
        /// The colour of the attach node for this field.
        /// </summary>
        public Color NodeColour { get; protected set; }

        /// <summary>
        /// The current location of this field's connector.
        /// </summary>
        public Vector2 ConnectorLocation { get; set; }

        /// <summary>
        /// The node that owns this field.
        /// </summary>
        public Node Node { get; private set; }

        /// <summary>
        /// The underlying property for this field (if valid).
        /// Not guaranteed to have a non-null value.
        /// </summary>
        public PropertyInfo Property { get; private set; } = null;

        /// <summary>
        /// Whether this is an automatic field or not.
        /// If a field is automatic, output fields of this type will automatically set their
        /// value onto the input fields of other nodes when the node is executed.
        /// </summary>
        public bool IsAutoField { get; protected set; } = true;

        /// <summary>
        /// Event that is fired every time the property on this object is altered.
        /// </summary>
        public event PropertyUpdatedHandler OnPropertyChanged;
        public delegate void PropertyUpdatedHandler(NodeField sender);

        /// <summary>
        /// Event that is fired every time the field we are connected to is altered.
        /// </summary>
        public event ConnectedFieldChangedHandler OnConnectedFieldChanged;
        public delegate void ConnectedFieldChangedHandler(NodeField sender);

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
        /// Sets the underlying property of this node to the given property.
        /// </summary>
        public void SetProperty(PropertyInfo prop)
        {
            //Check if the property has a correct type for the fields' value type.
            if (!prop.PropertyType.IsAssignableFrom(ValueType))
                throw new Exception("Invalid property type decorated by field, got " + prop.PropertyType.Name + " but was expecting " + ValueType.Name + ".");

            Property = prop;
            OnPropertyChanged?.Invoke(this);
        }

        /// <summary>
        /// Returns the underlying property's value with the provided type.
        /// This is a hard cast, so make sure of the type before calling.
        /// </summary>
        public T GetPropertyValue<T>()
        {
            if (Property == null)
                throw new Exception("Attempted to get property value with no property set.");
            return (T)Property.GetValue(Node);
        }

        /// <summary>
        /// Sets the underlying property's value on this node to the given object.
        /// </summary>
        public void SetPropertyValue(object value)
        {
            if (Property == null)
                throw new Exception("Attempted to set property value with no property set.");
            Property.SetValue(Node, value);
        }

        /// <summary>
        /// Returns whether the field currently has a valid value entered in it.
        /// </summary>
        public abstract bool ValueIsValid();

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
