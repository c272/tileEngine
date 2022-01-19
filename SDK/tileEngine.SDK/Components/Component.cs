using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tileEngine.SDK.Components
{
    /// <summary>
    /// Represents a single component that can be attached to a GameObject.
    /// Components are addons to a GameObject that can perform their own independent Draw, Update
    /// and other code dependent on engine support.
    /// </summary>
    public abstract class Component
    {
        /// <summary>
        /// Called when this component should be drawn to the screen.
        /// Allows the component to draw its own information at runtime on the linked GameObject.
        /// </summary>
        public virtual void Draw(GameObject gameObject, SpriteBatch spriteBatch) { }

        /// <summary>
        /// Called when the component should be updated.
        /// </summary>
        public virtual void Update(GameObject gameObject, GameTime delta) { }
    }
}
