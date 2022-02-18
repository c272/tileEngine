using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tileEngine.Utility;

namespace tileEngine.SDK.GUI
{
    /// <summary>
    /// Represents a single UI element within the tileEngine UI system.
    /// </summary>
    public abstract class UIElement : Snowflake
    {
        /// <summary>
        /// The parent of this UI element, if it has one.
        /// </summary>
        public UIElement Parent { get; private set; } = null;

        /// <summary>
        /// The children under this UI element.
        /// </summary>
        public IEnumerable<UIElement> Children => children;
        private List<UIElement> children = new List<UIElement>();

        /// <summary>
        /// Represents the sides to which this UI element is anchored.
        /// </summary>
        public UIAnchor Anchor { get; set; } = UIAnchor.Top | UIAnchor.Left;

        /// <summary>
        /// The offset from the anchor position this UI element is at.
        /// </summary>
        public Point Offset { get; set; } = Point.Zero;

        /// <summary>
        /// The current size of this UI element.
        /// </summary>
        public Point Size { get; private set; }

        /// <summary>
        /// Adds a child UI element to this element.
        /// </summary>
        public void AddChild(UIElement child)
        {
            //Ignore duplicate additions.
            if (children.Any(x => x.ID == child.ID))
                return;

            //Set parent/child.
            child.Parent = this;
            children.Add(child);
        }

        /// <summary>
        /// Removes a child UI element from this element.
        /// </summary>
        public void RemoveChild(UIElement child)
        {
            if (children.RemoveAll(x => x.ID == child.ID) > 0)
                child.Parent = null;
        }

        /// <summary>
        /// Forces this UI element (and it's children) to update their sizes.
        /// </summary>
        public abstract void ForceUpdateSize();

        /// <summary>
        /// Draws this UI element to the screen.
        /// </summary>
        public abstract void Draw(SpriteBatch spriteBatch);

        /// <summary>
        /// Updates this UI element each tick.
        /// </summary>
        public abstract void Update(GameTime delta);
    }
}
