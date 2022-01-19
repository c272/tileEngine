using Microsoft.Xna.Framework;
using System.Collections.Generic;
using tileEngine.SDK.Components;
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
        /// The layer that this game object is on.
        /// This corresponds to what layer on the map events/collisions will occur on.
        /// </summary>
        public int Layer { get; set; } = 0;

        /// <summary>
        /// The components currently attached to this GameObject.
        /// </summary>
        public List<Component> Components = new List<Component>();

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

        /// <summary>
        /// Called every update tick.
        /// Allows for dynamic updating of game objects.
        /// </summary>
        public virtual void Update(GameTime delta) { }

        /// <summary>
        /// Called when this game object must be drawn.
        /// </summary>
        public virtual void Draw() { }
    }
}