using tileEngine.SDK.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProtoBuf;

namespace tileEngine.SDK
{
    /// <summary>
    /// Represents a single scene within the tileEngine engine.
    /// </summary>
    [ProtoContract]
    public abstract class Scene
    {
        /// <summary>
        /// The game objects that are currently a part of this scene.
        /// </summary>
        public List<GameObject> GameObjects { get; private set; } = new List<GameObject>();

        /// <summary>
        /// The tilemap for this scene.
        /// </summary>
        [ProtoMember(1)]
        public TileMap Map { get; private set; } = new TileMap();

        /// <summary>
        /// The current location of the camera in this scene.
        /// Represents the top left of the current view.
        /// </summary>
        public Vector2 CameraPosition { get; protected set; } = new Vector2(0, 0);

        /// <summary>
        /// The current zoom of the camera in this scene.
        /// </summary>
        public float Zoom { get; protected set; } = 1f;

        /// <summary>
        /// Draws the scene.
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called when the scene is first entered.
        /// </summary>
        public virtual void Initialize() { }

        /// <summary>
        /// Updates the scene object based on the time from the previous update.
        /// </summary>
        public virtual void Update(GameTime delta) { }

        /// <summary>
        /// Dispose any active assets in the current scene.
        /// </summary>
        public abstract void Dispose();

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
