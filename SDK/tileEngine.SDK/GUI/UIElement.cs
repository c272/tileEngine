﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tileEngine.SDK.Utility;
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
        public Vector2 Offset { get; set; } = Vector2.Zero;

        /// <summary>
        /// The offset of this element, adjusted for the current scale.
        /// </summary>
        public Vector2 ScaledOffset => Offset * Scale;

        /// <summary>
        /// The current calculated top left position of this UI element.
        /// </summary>
        public Vector2 Position { get; protected set; }

        /// <summary>
        /// The current size of this UI element.
        /// </summary>
        public Vector2 Size { get; protected set; } = Vector2.Zero;

        /// <summary>
        /// Whether this UI element sizes based on it's parent.
        /// </summary>
        internal bool SizesFromParent { get; set; } = false;

        /// <summary>
        /// The size of the parent of this UI element.
        /// If there is no parent, then the parent container is just the viewport of the game.
        /// </summary>
        public Vector2 ParentSize
        {
            get { return Parent == null ? TileEngine.Instance.GraphicsDevice.Viewport.Bounds.Size.ToVector2() : Parent.Size; }
        }

        /// <summary>
        /// The current bounds of this UI element.
        /// </summary>
        public RectF Bounds => new RectF(Position, Size);

        /// <summary>
        /// The scale of this UI element.
        /// </summary>
        public float Scale
        {
            get => _scale;
            set
            {
                _scale = value;

                //Propagate down.
                foreach (var child in Children)
                    child.Scale = value;

                SizeDirty = true;
            }
        }
        private float _scale = 1f;

        /// <summary>
        /// Whether the size of this UI element is stale, and should be updated next draw.
        /// </summary>
        public bool SizeDirty
        {
            get => _sizeDirty;
            set
            {
                _sizeDirty = value;
                if (value)
                {
                    //Propagate up tree of parents.
                    var curParent = Parent;
                    while (curParent != null)
                    {
                        curParent._sizeDirty = true;
                        curParent = curParent.Parent;
                    }
                }
            }
        }
        private bool _sizeDirty = true;

        /// <summary>
        /// The opacity of the UI element. Ranges from 0.0f (transparent) to 1.0f (opaque).
        /// </summary>
        public float Opacity
        {
            get => _opacity;
            set
            {
                //Bound between 0 and 1.
                _opacity = Math.Max(0f, Math.Min(value, 1f));

                //Propagate down.
                foreach (var child in Children)
                    child.Opacity = _opacity;
            }
        }
        private float _opacity = 1f;

        /// <summary>
        /// Event triggered when this UI element is clicked.
        /// </summary>
        public event OnClickedHandler OnClick;
        public delegate void OnClickedHandler(UIElement element, Point location);

        /// <summary>
        /// Event triggered when the mouse first enters this UI element.
        /// </summary>
        public event OnEnteredHandler OnEnter;
        public delegate void OnEnteredHandler(UIElement element);

        /// <summary>
        /// Event triggered when the mouse first enters this UI element.
        /// </summary>
        public event OnExitedHandler OnExit;
        public delegate void OnExitedHandler(UIElement element);

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
            ForceUpdateSize();
        }

        /// <summary>
        /// Removes a child UI element from this element.
        /// </summary>
        public void RemoveChild(UIElement child)
        {
            if (children.RemoveAll(x => x.ID == child.ID) > 0)
            {
                child.Parent = null;
                return;
            }
        }

        /// <summary>
        /// Unparents this element from it's existing parent.
        /// </summary>
        public void Unparent()
        {
            if (Parent == null)
                return;
            Parent.RemoveChild(this);
        }

        /// <summary>
        /// Returns the closest previous element to this that matches one of the given anchors.
        /// </summary>
        public UIElement GetPreviousElement(Func<UIAnchor, bool> selector)
        {
            //If no parent, we use UI element root list.
            List<UIElement> siblings = Parent == null ? UI.RootElements.ToList() : Parent.Children.ToList();

            int ourIndex = siblings.FindIndex(x => x.ID == this.ID);
            for (int i = ourIndex - 1; i >= 0; i--)
            {
                //Is this a valid anchor? If so, return.
                if (selector(siblings[i].Anchor))
                    return siblings[i];
            }

            //There wasn't a valid prior sibling, return null.
            return null;
        }

        /// <summary>
        /// Forces this UI element (and it's children) to update their sizes.
        /// </summary>
        public abstract void ForceUpdateSize();

        /// <summary>
        /// Forces this UI element to update it's position.
        /// </summary>
        private void ForceUpdatePosition()
        {
            //Calculate the starting position based on anchor.
            Vector2 startPos = (Parent?.Position + Parent?.Offset ?? Vector2.Zero) + ParentSize / 2f;
            if (Anchor.HasFlag(UIAnchor.Right))
                startPos.X += ParentSize.X / 2f;
            if (Anchor.HasFlag(UIAnchor.Left))
                startPos.X -= ParentSize.X / 2f;
            if (Anchor.HasFlag(UIAnchor.Top))
                startPos.Y -= ParentSize.Y / 2f;
            if (Anchor.HasFlag(UIAnchor.Bottom))
                startPos.Y += ParentSize.Y / 2f;

            //Account for own size (non-center).
            if (Anchor.HasFlag(UIAnchor.Bottom) && !Anchor.HasFlag(UIAnchor.Top))
                startPos.Y -= Size.Y;
            if (Anchor.HasFlag(UIAnchor.Right) && !Anchor.HasFlag(UIAnchor.Left))
                startPos.X -= Size.X;

            //Account for own size (centered).
            var leftAndRight = (Anchor & (UIAnchor.Left | UIAnchor.Right));
            var topAndBottom = (Anchor & (UIAnchor.Top | UIAnchor.Bottom));
            if (topAndBottom == 0 || topAndBottom == (UIAnchor.Top | UIAnchor.Bottom))
                startPos.Y -= Size.Y / 2f;
            if (leftAndRight == 0 || leftAndRight == (UIAnchor.Left | UIAnchor.Right))
                startPos.X -= Size.X / 2f;

            //If this is an auto anchoring element, get the sibling to anchor from.
            var anchorSibling = GetPreviousElement(x => x >= UIAnchor.AutoLeft || x == UIAnchor.Left || x == (UIAnchor.Top | UIAnchor.Left));
            if (anchorSibling != null)
            {
                switch (Anchor) 
                {
                    //Place directly under other element.
                    case UIAnchor.AutoLeft:
                    case UIAnchor.AutoCenter:
                    case UIAnchor.AutoRight:
                        startPos.Y = anchorSibling.Position.Y + anchorSibling.Size.Y;
                        break;

                    //Place directly to the right of other element.
                    case UIAnchor.AutoInline:
                        startPos.Y = anchorSibling.Position.Y;
                        startPos.X = anchorSibling.Position.X + anchorSibling.Size.X;
                        break;
                }
            }

            //Set calculated position.
            Position = startPos;
        }

        /// <summary>
        /// Draws this UI element to the screen.
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            //If we have a stale size, recalculate.
            if (SizeDirty)
                ForceUpdateSize();

            //Update position and draw self.
            ForceUpdatePosition();
            DrawSelf(spriteBatch, Position + ScaledOffset);

            //Draw all children.
            foreach (var child in Children)
                child.Draw(spriteBatch);
        }

        /// <summary>
        /// Draw the UI element with the given top left point position.
        /// </summary>
        public abstract void DrawSelf(SpriteBatch spriteBatch, Vector2 topLeft);

        /// <summary>
        /// Updates this UI element each tick.
        /// </summary>
        public virtual void Update(GameTime delta) 
        {
            //Update children.
            foreach (var child in Children)
                child.Update(delta);
        }

        /// <summary>
        /// Checks whether this element (or it's children) are clicked.
        /// </summary>
        internal bool CheckClicked(MouseState state)
        {
            //Check children first.
            foreach (var child in Children)
            {
                if (child.CheckClicked(state))
                {
                    //If our child has been clicked, then we've been clicked too.
                    OnClick?.Invoke(this, state.Position);
                    return true;
                }
            }

            //Check self, is the mouse within the bounds?
            if (Bounds.Contains(state.Position))
            {
                OnClick?.Invoke(this, state.Position);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks whether this element (or it's children) have just been entered.
        /// </summary>
        internal void CheckEnteredExited(MouseState prevState, MouseState state)
        {
            //Check children.
            foreach (var child in Children)
                child.CheckEnteredExited(prevState, state);

            //Check entered for self.
            if (Bounds.Contains(state.Position) &&
                !Bounds.Contains(prevState.Position))
            {
                OnEnter?.Invoke(this);
            }

            //Check left for self.
            if (!Bounds.Contains(state.Position) &&
                Bounds.Contains(prevState.Position))
            {
                OnExit?.Invoke(this);
            }
        }
    }
}
