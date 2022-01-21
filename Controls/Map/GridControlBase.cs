using DarkUI.Config;
using DarkUI.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tileEngine.SDK.Diagnostics;
using tileEngine.SDK.Map;
using tileEngine.Utility;

namespace tileEngine.Controls
{
    /// <summary>
    /// Base control for drawing tile maps with a guide grid.
    /// Contains no user-interaction functionality.
    /// </summary>
    public abstract class GridControlBase : Control
    {
        /////////////////////////
        /// PUBLIC PROPERTIES ///
        /////////////////////////

        #region Configuration

        /// <summary>
        /// Property to alter the zoom of the node graph editor.
        /// </summary>
        public float Zoom
        {
            get { return zoom; }
            set
            {
                //Bound zoom to 0.01 or above.
                if (value < 0.01)
                    value = 0.01f;

                //Update font size values.
                //...

                //Update zoom value.
                zoom = value;
                Invalidate();
            }
        }

        private float zoom = 1f;

        /// <summary>
        /// The size of the grid step (in pixels) when at default zoom.
        /// </summary>
        public float GridStep
        {
            get { return gridStep; }
            set
            {
                gridStep = value;
                Invalidate();
            }
        }
        private float gridStep = 30f;

        /// <summary>
        /// Whether to draw the grid lines over the tiles.
        /// </summary>
        public bool DoGridDraw
        {
            get { return doGridDraw; }
            set
            {
                doGridDraw = value;
                Invalidate();
            }
        }
        private bool doGridDraw = true;

        /// <summary>
        /// The width of the lines making up the grid.
        /// </summary>
        public int GridLineWidth
        {
            get { return gridLineWidth; }
            set
            {
                gridLineWidth = value;
                Invalidate();
            }
        }
        private int gridLineWidth = 2;

        /// <summary>
        /// Property to set the background colour of the editor.
        /// </summary>
        public Color BackgroundColour
        {
            get { return bgColour; }
            set
            {
                bgColour = value;
                Invalidate();
            }
        }
        private Color bgColour = Color.White;

        /// <summary>
        /// Property to set the background line colour of the editor.
        /// </summary>
        public Color BackgroundLineColour
        {
            get { return bgLineColour; }
            set
            {
                bgLineColour = value;
                Invalidate();
            }
        }
        private Color bgLineColour = Color.LightGray;

        /// <summary>
        /// Whether to draw event squares over the tiles.
        /// Depends on EventDrawLayer being set to non-null.
        /// </summary>
        public bool DoEventDraw
        {
            get { return doEventDraw; }
            set
            {
                doEventDraw = value;
                Invalidate();
            }
        }
        private bool doEventDraw = true;

        /// <summary>
        /// The layer at which to draw events as semi-transparent squares over tiles.
        /// </summary>
        public TileLayer EventDrawLayer
        {
            get { return eventDrawLayer; }
            set
            {
                eventDrawLayer = value;
                Invalidate();
            }
        }
        private TileLayer eventDrawLayer = null;

        /// <summary>
        /// Property to set the colour of events drawn over tiles (if enabled).
        /// </summary>
        public Color EventColour
        {
            get { return eventColour; }
            set
            {
                eventColour = value;
                Invalidate();
            }
        }
        private Color eventColour = Color.Orange;

        /// <summary>
        /// The opacity of events drawn over tiles (if enabled).
        /// Ranges from 0.0f to 1.0f.
        /// </summary>
        public float EventOpacity
        {
            get { return eventOpacity; }
            set
            {
                eventOpacity = value;
                Invalidate();
            }
        }
        private float eventOpacity = 0.75f;

        /// <summary>
        /// Whether to draw collision squares over the tiles.
        /// Depends on CollisionDrawLayer being set to non-null.
        /// </summary>
        public bool DoCollisionDraw
        {
            get { return doCollisionDraw; }
            set
            {
                doCollisionDraw = value;
                Invalidate();
            }
        }
        private bool doCollisionDraw = true;

        /// <summary>
        /// The layer at which to draw events as semi-transparent squares over tiles.
        /// </summary>
        public TileLayer CollisionDrawLayer
        {
            get { return collisionDrawLayer; }
            set
            {
                collisionDrawLayer = value;
                Invalidate();
            }
        }
        private TileLayer collisionDrawLayer = null;

        /// <summary>
        /// Property to set the colour of the background of collision squares drawn over tiles (if enabled).
        /// </summary>
        public Color CollisionBackgroundColour
        {
            get { return collisionBgColour; }
            set
            {
                collisionBgColour = value;
                Invalidate();
            }
        }
        private Color collisionBgColour = Color.Red;

        /// <summary>
        /// Property to set the colour of the foreground of collision squares drawn over tiles (if enabled).
        /// </summary>
        public Color CollisionForegroundColour
        {
            get { return collisionFgColour; }
            set
            {
                collisionFgColour = value;
                Invalidate();
            }
        }
        private Color collisionFgColour = Color.White;

        /// <summary>
        /// The opacity of collision squares backgrounds drawn over tiles (if enabled).
        /// Ranges from 0.0f to 1.0f.
        /// </summary>
        public float CollisionOpacity
        {
            get { return collisionOpacity; }
            set
            {
                collisionOpacity = value;
                Invalidate();
            }
        }
        private float collisionOpacity = 0.75f;

        /// <summary>
        /// The size of the pips indicating which direction entities can enter the collision square.
        /// </summary>
        public int CollisionPipSize
        {
            get { return collisionPipSize; }
            set
            {
                collisionPipSize = value;
                Invalidate();
            }
        }
        private int collisionPipSize = 2;

        /// <summary>
        /// The colour of the selection box that is used for selected tiles.
        /// </summary>
        public Color SelectionColour
        {
            get { return _selectionColour; }
            set
            {
                _selectionColour = value;
                Invalidate();
            }
        }
        private Color _selectionColour = Color.White;

        /// <summary>
        /// The colour of the selection box that is used when a user selects tiles.
        /// </summary>
        public int SelectionWidth
        {
            get { return _selectionWidth; }
            set
            {
                _selectionWidth = value;
                Invalidate();
            }
        }
        private int _selectionWidth = 2;

        /// <summary>
        /// The tile map to be drawn.
        /// </summary>
        public TileMap Map { get; set; } = null;

        #endregion

        ////////////////////////////
        /// PROTECTED PROPERTIES ///
        ////////////////////////////

        //The cache of assets that are used to draw the tiles on screen.
        protected Dictionary<int, Image> assetCache = new Dictionary<int, Image>();

        //The current location of the camera (X and Y).
        protected Vector2f cameraPos = new Vector2f(0, 0);

        public GridControlBase()
        {
            //Set redraw on, double buffer self.
            SetStyle(ControlStyles.ResizeRedraw, true);
            DoubleBuffered = true;
        }

        /// <summary>
        /// Sets the theme of the provided node graph based on the current theme of DarkUI,
        /// found at DarkUI.Config.ThemeProvider.Theme.
        /// </summary>
        public virtual void SetThemeFromDarkUI()
        {
            BackgroundColour = ThemeProvider.Theme.Colors.DarkBackground;
            BackgroundLineColour = ThemeProvider.Theme.Colors.DarkBorder;
        }

        /// <summary>
        /// Copies all the settings on the given node graph base to the current one.
        /// </summary>
        public void CopySettings(GridControlBase other)
        {
            PropertyInfo[] infos = typeof(GridControlBase).GetProperties();
            foreach (PropertyInfo info in infos)
            {
                if (!info.CanRead || !info.CanWrite) { continue; }
                info.SetValue(this, info.GetValue(other, null), null);
            }
        }

        /// <summary>
        /// Paints the node graph to the screen.
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.Clear(BackgroundColour);

            //Set up graphical options.
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            //Draw the tiles currently on the grid.
            if (Map != null)
                DrawMap(e);

            //Draw the grid.
            if (DoGridDraw)
                DrawGrid(e);
        }

        /// <summary>
        /// Draws all the map layer portions currently on the screen.
        /// </summary>
        private void DrawMap(PaintEventArgs e)
        {
            //Get the top left and bottom right of the grid.
            Vector2f screenTL = ToGridCoordinate(ClientRectangle.X, ClientRectangle.Y);
            Vector2f screenBR = ToGridCoordinate(ClientRectangle.X + ClientRectangle.Width, ClientRectangle.Y + ClientRectangle.Height);
            Vector2f topLeft = new Vector2f(screenTL.X - (screenTL.X % GridStep), screenTL.Y - (screenTL.Y % GridStep));
            Vector2f bottomRight = new Vector2f(screenBR.X + (GridStep - (screenBR.X % GridStep)), screenBR.Y + (GridStep - (screenBR.Y % GridStep)));

            //Enable nearest neighbour draw.
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

            //Draw all layers.
            for (int i = 0; i < Map.Layers.Count; i++)
            {
                var layer = Map.Layers[i];
                Vector2f curPos = new Vector2f(topLeft);

                //Set up opacity ImageAttributes for this layer's tile draws.
                ColorMatrix matrix = new ColorMatrix();
                matrix.Matrix33 = layer.Opacity;
                ImageAttributes tileImageAttribs = new ImageAttributes();
                tileImageAttribs.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                //Create the brush for drawing events.
                SolidBrush eventBrush = new SolidBrush(Color.FromArgb((int)(EventOpacity * 255), EventColour));

                //Create the brushes for drawing collisions.
                SolidBrush collisionBgBrush = new SolidBrush(Color.FromArgb((int)(EventOpacity * 255), CollisionBackgroundColour));
                SolidBrush collisionFgBrush = new SolidBrush(CollisionForegroundColour);

                //Loop over all visible tiles.
                while (curPos.Y < bottomRight.Y)
                {
                    while (curPos.X < bottomRight.X)
                    {
                        //Calculate the tile point for this location.
                        Microsoft.Xna.Framework.Point tilePoint = new Microsoft.Xna.Framework.Point((int)(curPos.X / GridStep), (int)(curPos.Y / GridStep));

                        //Get the current tile, draw it (if it exists).
                        DrawTile(layer, curPos, tilePoint, tileImageAttribs, e);

                        //Draw events if enabled.
                        if (DoEventDraw && EventDrawLayer?.ID == layer.ID)
                            DrawEvent(layer, curPos, tilePoint, eventBrush, e);

                        //Draw collisions if enabled.
                        if (DoCollisionDraw && CollisionDrawLayer?.ID == layer.ID)
                            DrawCollisionBox(layer, curPos, tilePoint, collisionBgBrush, collisionFgBrush, e);

                        curPos.X += GridStep;
                    }

                    //Go to the next line.
                    curPos.X = topLeft.X;
                    curPos.Y += GridStep;
                }

            }
        }

        /// <summary>
        /// Draws a selection box at the given tile locations.
        /// </summary>
        protected void DrawSelectionBox(PaintEventArgs e, Rectangle selectedTiles)
        {
            Vector2f selectTopLeft = TileToGridCoordinate(selectedTiles.Location);
            Vector2f selectBottomRight = TileToGridCoordinate(new Point(selectedTiles.Right, selectedTiles.Bottom));

            //Draw in pixel space.
            PointF topLeft = ToPixelPointF(selectTopLeft);
            PointF bottomRight = ToPixelPointF(selectBottomRight);
            Pen selectionPen = new Pen(new SolidBrush(SelectionColour), SelectionWidth);
            selectionPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            e.Graphics.DrawRectangles(selectionPen, new RectangleF[] { new RectangleF(topLeft, new SizeF(bottomRight.X - topLeft.X, bottomRight.Y - topLeft.Y)) });
        }

        /// <summary>
        /// Draws a single collision box at a provided tile location on a given layer.
        /// Utilises the provided brushes for drawing the collision box.
        /// If there is no valid collision box at the specified location, the call is ignored.
        /// </summary>
        private void DrawCollisionBox(TileLayer layer, Vector2f curPos, Microsoft.Xna.Framework.Point tilePoint, SolidBrush collisionBgBrush, SolidBrush collisionFgBrush, PaintEventArgs e)
        {
            //Ignore if no collision here.
            if (!layer.CollisionHull.ContainsKey(tilePoint))
                return;

            //Draw the collision background rectangle.
            PointF topLeft = ToPixelPointF(curPos);
            PointF bottomRight = ToPixelPointF(curPos + new Vector2f(GridStep, GridStep));
            e.Graphics.FillRectangle(collisionBgBrush, new RectangleF(topLeft, new SizeF(bottomRight.X - topLeft.X, bottomRight.Y - topLeft.Y)));

            //Draw the four pips indicating the direction in which entities are allowed to enter the collision box.
            //...
        }

        /// <summary>
        /// Draws a single event at a provided tile location on a given layer.
        /// Utilises the provided brush for drawing the event.
        /// If there is no valid event at the specified location, the call is ignored.
        /// </summary>
        private void DrawEvent(TileLayer layer, Vector2f curPos, Microsoft.Xna.Framework.Point tilePoint, Brush brush, PaintEventArgs e)
        {
            //Ignore if no event here.
            if (!layer.Events.ContainsKey(tilePoint))
                return;

            //Draw the event rectangle.
            PointF topLeft = ToPixelPointF(curPos);
            PointF bottomRight = ToPixelPointF(curPos + new Vector2f(GridStep, GridStep));
            e.Graphics.FillRectangle(brush, new RectangleF(topLeft, new SizeF(bottomRight.X - topLeft.X, bottomRight.Y - topLeft.Y)));
        }

        /// <summary>
        /// Draws a single tile at a provided tile location on a given layer.
        /// Applies image attributes specified by a System.Drawing.ImageAttributes class.
        /// If there is no valid tile at the specified location, the call is ignored.
        /// </summary>
        private void DrawTile(TileLayer layer, Vector2f curPos, Microsoft.Xna.Framework.Point tilePoint, ImageAttributes imageAttribs, PaintEventArgs e)
        {
            if (!layer.Tiles.ContainsKey(tilePoint))
            {
                //No tile here.
                return;
            }

            //Get the texture for the tile, if it hasn't been loaded into cache already.
            TileData tile = layer.Tiles[tilePoint];
            Image tex = null;
            if (assetCache.ContainsKey(tile.TextureID))
            {
                //Cache hit.
                tex = assetCache[tile.TextureID];
            }
            else
            {
                //Cache miss, attempt to load from file.
                var assetNode = ProjectManager.CurrentProject.ProjectRoot.FindChild<ProjectSpriteNode>(tile.TextureID);
                string assetPath = Path.Combine(ProjectManager.CurrentProjectDirectory, assetNode.RelativeLocation);

                //On failure, just load the "invalid" texture.
                try
                {
                    tex = Image.FromFile(assetPath);
                }
                catch (Exception ex)
                {
                    tex = new Bitmap(Map.TileTextureSize, Map.TileTextureSize);
                    DarkMessageBox.ShowError($"Failed to load texture '{assetNode.Name}' for draw, it may have been moved or deleted.\n{ex.Message}", "tileEngine - Texture Failed Load", DarkDialogButton.Ok);
                }

                //Add the texture to cache.
                assetCache.Add(tile.TextureID, tex);
            }

            //Calculate the source and destination rectangles on textures.
            PointF screenPoint = ToPixelPointF(curPos);
            RectangleF screenRect = new RectangleF(screenPoint, new SizeF(GridStep * Zoom, GridStep * Zoom));
            PointF sourcePoint = new PointF(tile.Position.X * Map.TileTextureSize, tile.Position.Y * Map.TileTextureSize);
            RectangleF sourceRect = new RectangleF(sourcePoint, new SizeF(Map.TileTextureSize, Map.TileTextureSize));

            //Check that the source rectangle is within bounds.
            if (sourceRect.Right > tex.Width || sourceRect.Bottom > tex.Height)
            {
                DiagnosticsHook.LogMessage(21005, $"Source rectangle draw for map tile ({tilePoint.X}, {tilePoint.Y}) outside of bounds. Tile removed.");
                layer.Tiles.Remove(tilePoint);
                return;
            }

            //Draw the tile.
            e.Graphics.DrawImage(tex, screenRect.ToPoints(), sourceRect, GraphicsUnit.Pixel, imageAttribs);
        }

        /// <summary>
        /// Draws the background of the node graph editor using a PaintEventArgs.
        /// </summary>
        protected void DrawGrid(PaintEventArgs e)
        {
            //Draw the grid (at the correct zoom level).
            var brush = new SolidBrush(BackgroundLineColour);
            Pen pen = new Pen(brush);
            pen.Width = GridLineWidth;
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

            //Round up to the nearest grid step.
            Vector2f topLeft = ToGridCoordinate(ClientRectangle.X, ClientRectangle.Y);
            Vector2f bottomRight = ToGridCoordinate(ClientRectangle.X + ClientRectangle.Width, ClientRectangle.Y + ClientRectangle.Height);

            //Vertical lines.
            Vector2f curPos = new Vector2f(topLeft.X - (topLeft.X % GridStep), topLeft.Y);
            while (curPos.X <= bottomRight.X)
            {
                e.Graphics.DrawLine(pen, ToPixelPointF(curPos), ToPixelPointF(curPos.X, bottomRight.Y));
                curPos.X += GridStep;
            }

            //Horizontal lines.
            curPos = new Vector2f(topLeft.X, topLeft.Y - (topLeft.Y % GridStep));
            while (curPos.Y <= bottomRight.Y)
            {
                e.Graphics.DrawLine(pen, ToPixelPointF(curPos), ToPixelPointF(bottomRight.X, curPos.Y));
                curPos.Y += GridStep;
            }
        }

        //////////////////////////////////////
        /// UTILITY FUNCTIONS (CONVERSION) ///
        //////////////////////////////////////

        /// <summary>
        /// Returns a given string's measurements in grid units based on the current zoom.
        /// </summary>
        public Vector2f GetStringAsUnits(Graphics graphics, string text, Font font)
        {
            SizeF size = graphics.MeasureString(text, font);
            return new Vector2f(size.Width / zoom, size.Height / zoom);
        }

        /// <summary>
        /// Gets a pixel space rectangle based on the top left and bottom right of a rectangle in grid space.
        /// Returns a floating point rectangle.
        /// </summary>
        public RectangleF GetPixelRectangleF(Vector2f topLeft, Vector2f bottomRight)
        {
            PointF pixelTopLeft = ToPixelPointF(topLeft);
            PointF pixelBottomRight = ToPixelPointF(bottomRight);
            return new RectangleF(pixelTopLeft, new SizeF(pixelBottomRight.X - pixelTopLeft.X, pixelBottomRight.Y - pixelTopLeft.Y));
        }

        /// <summary>
        /// Gets a pixel space rectangle based on an existing grid space RectangleF.
        /// Returns a floating point rectangle.
        /// </summary>
        public RectangleF GetPixelRectangleF(RectangleF gridRect)
        {
            return GetPixelRectangleF(new Vector2f(gridRect.X, gridRect.Y), new Vector2f(gridRect.X + gridRect.Width, gridRect.Y + gridRect.Height));
        }

        /// <summary>
        /// Gets a pixel-space rectangle based on the top left and bottom right of a rectangle in grid space.
        /// </summary>
        public Rectangle GetPixelRectangle(Vector2f topLeft, Vector2f bottomRight)
        {
            RectangleF floatVer = GetPixelRectangleF(topLeft, bottomRight);
            return new Rectangle((int)floatVer.X, (int)floatVer.Y, (int)floatVer.Width, (int)floatVer.Height);
        }

        /// <summary>
        /// Gets a pixel-space rectangle based on the top left and bottom right of a rectangle in grid space.
        /// </summary>
        public RectangleF GetGridRectangle(Point topLeft, Point bottomRight)
        {
            Vector2f gridTopLeft = ToGridCoordinate(topLeft.X, topLeft.Y);
            Vector2f gridBottomRight = ToGridCoordinate(bottomRight.X, bottomRight.Y);
            return new RectangleF(gridTopLeft.X, gridTopLeft.Y, gridBottomRight.X - gridTopLeft.X, gridBottomRight.Y - gridTopLeft.Y);
        }

        /// <summary>
        /// Converts an existing pixel-space coordinate into a grid space coordinate.
        /// </summary>
        public Vector2f ToGridCoordinate(float x, float y)
        {
            //The amount of grid coordinates traversed per pixel.
            float pixelValue = 1 / zoom;

            //Calculate how far away we are (in pixels) from the center, as a vector.
            Vector2f center = new Vector2f(ClientRectangle.X + ClientRectangle.Width / 2f, ClientRectangle.Y + ClientRectangle.Height / 2f);
            Vector2f relativeToCenter = new Vector2f(x - center.X, y - center.Y);

            //Convert this vector into grid space coordinates, then apply the vector to the camera position.
            return new Vector2f(cameraPos.X + relativeToCenter.X * pixelValue, cameraPos.Y + relativeToCenter.Y * pixelValue);
        }

        /// <summary>
        /// Converts a given tile coordinate into a grid coordinate representing the top left of the tile.
        /// </summary>
        public Vector2f TileToGridCoordinate(Point tilePoint)
        {
            return new Vector2f(tilePoint.X * GridStep, tilePoint.Y * GridStep);
        }

        /// <summary>
        /// Converts an existing grid-space coordinate into a client rectangle pixel coordinate.
        /// </summary>
        public Point ToPixelPoint(Vector2f point) { return ToPixelPoint(point.X, point.Y); }

        /// <summary>
        /// Converts an existing grid-space coordinate into a single client rectangle pixel point.
        /// </summary>
        public Point ToPixelPoint(float x, float y)
        {
            PointF floatVer = ToPixelPointF(x, y);
            return new Point((int)floatVer.X, (int)floatVer.Y);
        }

        /// <summary>
        /// Converts an existing grid-space coordinate into a client rectangle pixel coordinate.
        /// </summary>
        public PointF ToPixelPointF(Vector2f point) { return ToPixelPointF(point.X, point.Y); }

        /// <summary>
        /// Converts an existing grid-space coordinate into a client rectangle pixel coordinate.
        /// </summary>
        public PointF ToPixelPointF(float x, float y)
        {
            //Get the vector from the camera to this point.
            Vector2f relativeToCamera = new Vector2f(x - cameraPos.X, y - cameraPos.Y);

            //Convert this vector into pixel space coordinates, correct for the center of the control.
            Vector2f center = new Vector2f(ClientRectangle.X + ClientRectangle.Width / 2f, ClientRectangle.Y + ClientRectangle.Height / 2f);
            Vector2f relativePixels = new Vector2f(relativeToCamera.X * zoom, relativeToCamera.Y * zoom);
            return new PointF(center.X + relativePixels.X, center.Y + relativePixels.Y);
        }

        /// <summary>
        /// Converts the given mouse point location into the equivalent tile location on the map.
        /// </summary>
        public Point ToTileLocation(Point mousePoint)
        {
            Vector2f clickPosition = ToGridCoordinate(mousePoint.X, mousePoint.Y);
            int tileX = (int)Math.Floor(clickPosition.X / GridStep);
            int tileY = (int)Math.Floor(clickPosition.Y / GridStep);
            return new Point(tileX, tileY);
        }

        /////////////////////////////////
        /// PRIVATE UTILITY FUNCTIONS ///
        /////////////////////////////////

        //Updates the size of all fonts when "zoom" is changed.
        private Font UpdateFontSize(Font font, float newZoom, float zoom)
        {
            return new Font(font.FontFamily, font.SizeInPoints * (newZoom / zoom));
        }
    }
}
