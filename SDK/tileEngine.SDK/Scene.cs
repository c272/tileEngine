using tileEngine.SDK.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tileEngine.SDK
{
    /// <summary>
    /// Represents a single scene within the tileEngine engine.
    /// </summary>
    public abstract class Scene
    {
        //The current zoom of the camera in this scene.
        public float Zoom { get; protected set; } = 1f;

        //The current location of the camera in this scene.
        public Vector2 CameraPosition { get; protected set; } = new Vector2(0, 0);

        /// <summary>
        /// Draws the scene.
        /// </summary>
        public abstract void Draw(SpriteBatch spriteBatch);

        /// <summary>
        /// Updates the scene object based on the time from the previous update.
        /// </summary>
        public abstract void Update(GameTime delta);

        /// <summary>
        /// Dispose any active assets in the current scene.
        /// </summary>
        public abstract void Dispose();

        /// <summary>
        /// Triggered when the mouse is pressed down on this scene.
        /// </summary>
        public virtual void OnMouseDown(ref bool handled, MouseButtons button, Point location) { }

        /// <summary>
        /// Triggered when the mouse is double clicked on this scene.
        /// </summary>
        public virtual void OnDoubleClick(ref bool handled, Point point) { }

        /// <summary>
        /// Triggered when the mouse moves on this scene.
        /// </summary>
        public virtual void OnMouseMove(Point location) { }

        /// <summary>
        /// Triggered when the mouse is released on this scene.
        /// </summary>
        public virtual void OnMouseUp(Point location) { }

        /// <summary>
        /// Triggered when the mouse wheel is moved either up or down.
        /// Passes "1" as the direction when the wheel moves up, and "-1" when the wheel is moved down.
        /// </summary>
        public virtual void OnMouseWheel(int direction) { }

        /////////////////////////
        /// UTILITY FUNCTIONS ///
        /////////////////////////

        /// <summary>
        /// Returns a screen rectangle (float precise) for the given grid space top left and bottom right coordinates.
        /// </summary>
        public RectF GetScreenRectangleF(Vector2 topLeft, Vector2 bottomRight)
        {
            Vector2 tlScreen = ToScreenPointF(topLeft);
            Vector2 brScreen = ToScreenPointF(bottomRight);
            return new RectF(tlScreen.X, tlScreen.Y, brScreen.X - tlScreen.X, brScreen.Y - tlScreen.Y);
        }

        /// <summary>
        /// Returns a screen rectangle (integer) for the given grid space top left and bottom right coordinates.
        /// </summary>
        public Rectangle GetScreenRectangle(Vector2 topLeft, Vector2 bottomRight)
        {
            Point tlScreen = ToScreenPoint(topLeft);
            Point brScreen = ToScreenPoint(bottomRight);
            return new Rectangle(tlScreen, new Point(brScreen.X - tlScreen.X, brScreen.Y - tlScreen.Y));
        }

        /// <summary>
        /// Returns the grid location of a given screen point "p".
        /// </summary>
        public Vector2 ToGridLocation(Point p)
        {
            return ToGridLocation(new Vector2(p.X, p.Y));
        }

        /// <summary>
        /// Returns the grid location of a given screen vector "p".
        /// </summary>
        public Vector2 ToGridLocation(Vector2 p)
        {
            return new Vector2(CameraPosition.X + (p.X / Zoom), CameraPosition.Y + (p.Y / Zoom));
        }

        /// <summary>
        /// Returns the screen point location (integer) of a given grid location "v".
        /// </summary>
        public Point ToScreenPoint(Vector2 v)
        {
            Vector2 screenPoint = ToScreenPointF(v);
            return new Point((int)screenPoint.X, (int)screenPoint.Y);
        }

        /// <summary>
        /// Returns the screen point location of a given grid location "v".
        /// </summary>
        public Vector2 ToScreenPointF(Vector2 v)
        {
            return new Vector2((v.X - CameraPosition.X) * Zoom, (v.Y - CameraPosition.Y) * Zoom);
        }
    }
}
