using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using tileEngine.SDK.Components;
using tileEngine.SDK.Diagnostics;
using tileEngine.Utility;

namespace tileEngine.SDK
{
    /// <summary>
    /// Represents a single active game object within the scene.
    /// Intended as a programmable in-game entity.
    /// </summary>
    public class GameObject : Snowflake
    {
        /// <summary>
        /// The position of this game object within grid space.
        /// </summary>
        public Vector2 Position { get; set; } = new Vector2();

        /// <summary>
        /// The ID of the layer that this game object is on.
        /// This corresponds to what layer on the map events/collisions will occur on.
        /// </summary>
        public int Layer { get; private set; } = 0;

        /// <summary>
        /// Whether this game object is allowed to trigger events.
        /// </summary>
        public bool TriggersEvents { get; set; } = false;

        /// <summary>
        /// The scene this GameObject is currently in.
        /// </summary>
        public Scene Scene
        {
            get { return _scene; }
            set
            {
                _scene?.RemoveObject(this);
                _scene = value;
                _scene.AddObject(this);
            }
        }
        internal Scene _scene = null;

        //The components currently attached to this GameObject.
        private List<Component> components = new List<Component>();

        //Whether this object has been initialized.
        internal bool _initialized = false;

        /// <summary>
        /// Returns a list of components currently on this GameObject.
        /// </summary>
        public List<Component> GetComponents() => components;

        /// <summary>
        /// Adds the given component to this game object, if it is not already added.
        /// </summary>
        public void AddComponent(Component component)
        {
            if (components.Any(x => x.ID == component.ID))
                return;
            component.GameObject = this;
            components.Add(component);
        }

        /// <summary>
        /// Removes the given component from this game object, if it is present.
        /// </summary>
        public void RemoveComponent(Component component)
        {
            if (components.RemoveAll(x => x.ID == component.ID) > 0)
                component.GameObject = null;
        }

        /// <summary>
        /// Sets the layer based on a search for the given layer name.
        /// Not guaranteed to find a single layer, as layers are not bound to have unique names.
        /// If no layer is found, the layer is not changed.
        /// </summary>
        public void SetLayer(string name)
        {
            //Throw if no scene.
            if (Scene == null)
            {
                DiagnosticsHook.LogMessage(21012, "Attempted to switch layer by name, but the GameObject was not in a scene.", DiagnosticsSeverity.Warning);
                return;
            }

            //Get the layer out, set ID.
            var layer = Scene.Map.Layers.FirstOrDefault(x => x.Name == name);
            if (layer == null)
                return;

            Layer = layer.ID;
        }

        /// <summary>
        /// Sets the current layer to the given layer ID.
        /// </summary>
        public void SetLayer(int layerID) => Layer = layerID;

        /// <summary>
        /// Initializes this game object.
        /// </summary>
        public virtual void Initialize() { }

        /// <summary>
        /// Called every update tick.
        /// Allows for dynamic updating of game objects.
        /// </summary>
        public virtual void Update(GameTime delta) { }

        /// <summary>
        /// Called when this game object must be drawn.
        /// </summary>
        public virtual void Draw(SpriteBatch spriteBatch) { }
    }
}