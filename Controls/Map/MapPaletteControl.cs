using DarkUI.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tileEngine.SDK.Map;
using tileEngine.Utility;

namespace tileEngine.Controls
{
    /// <summary>
    /// Palette of selectable tiles that can be drawn onto a connected tile map.
    /// </summary>
    public class MapPaletteControl : GridControlBase
    {
        /// <summary>
        /// The tilesheet that is currently loaded on this palette control.
        /// </summary>
        public ProjectSpriteNode Tilesheet { get; private set; }

        /// <summary>
        /// The tile texture size used by the tile palette.
        /// </summary>
        public int TileTextureSize
        {
            get { return map.TileTextureSize; }
            set
            {
                map.TileTextureSize = value;
                refreshTiles();
            }
        }

        /// <summary>
        /// The currently selected tile on the palette.
        /// </summary>
        public TileData? SelectedTile { get; private set; } = null;

        /// <summary>
        /// The size of the view (control) of the palette, in grid units.
        /// </summary>
        public Vector2f ViewSize { get; private set; } = new Vector2f();

        /// <summary>
        /// The total size of the available palette area, in grid units.
        /// </summary>
        public Vector2f TotalSize { get; private set; } = new Vector2f();

        /// <summary>
        /// Represents the amount that the view is currently scrolled (X, Y).
        /// </summary>
        public Vector2f ViewScroll
        {
            get { return _viewScroll; }
            set
            {
                _viewScroll = value;
                adjustCameraPosition();
            }
        }
        private Vector2f _viewScroll = new Vector2f();

        //Event for when the view/total sizes are updated.
        public delegate void SizesUpdatedHandler();
        public event SizesUpdatedHandler OnSizesUpdated;

        //The tilemap used for displaying the palette.
        private TileMap map = new TileMap();

        //The texture currently being used for the palette.
        private Image texture = null;

        //The ID of the texture currently being used.
        private int textureID = -1;

        //////////////////////////
        /// PUBLIC API METHODS ///
        //////////////////////////

        /// <summary>
        /// Switches the currently displayed tilesheet to the one provided.
        /// </summary>
        public void SetTilesheet(ProjectSpriteNode newSheet)
        {
            //Attempt to load the asset for tile creation.
            string assetPath = Path.Combine(ProjectManager.CurrentProjectDirectory, newSheet.RelativeLocation);

            //On failure, just load the "invalid" texture.
            texture = null;
            try
            {
                texture = Image.FromFile(assetPath);
                textureID = newSheet.ID;
            }
            catch (Exception ex)
            {
                DarkMessageBox.ShowError($"Failed to load texture '{newSheet.Name}' for the tile palette, it may have been moved or deleted.\n{ex.Message}", "tileEngine - Texture Failed Load", DarkDialogButton.Ok);
                return;
            }

            //Add the new tiles and adjust camera.
            refreshTiles();
            adjustCameraPosition();
        }

        //////////////////////
        /// EVENT HANDLERS ///
        //////////////////////

        /// <summary>
        /// Triggered when the user clicks the mouse on the palette.
        /// </summary>
        protected override void OnMouseClick(MouseEventArgs e)
        {
            //Convert the click position to a grid location.
            Vector2f clickPosition = ToGridCoordinate(e.X, e.Y);
            int tileX = (int)((clickPosition.X - (clickPosition.X % GridStep)) / GridStep);
            int tileY = (int)((clickPosition.Y - (clickPosition.Y % GridStep)) / GridStep);
            Microsoft.Xna.Framework.Point tilePosition = new Microsoft.Xna.Framework.Point(tileX, tileY);

            //Is there a valid tile to select at that location?
            if (map.Layers.Count == 0 || !map.Layers[0].Tiles.ContainsKey(tilePosition))
                return;

            //Set this tile as selected data.
            SelectedTile = map.Layers[0].Tiles[tilePosition];
        }

        /// <summary>
        /// Triggered when the user spins the mouse wheel.
        /// </summary>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            //Adjust zoom.
            Zoom += e.Delta / 120 * 0.05f;
            adjustCameraPosition();
        }

        ////////////////////////
        /// HELPER FUNCTIONS ///
        ////////////////////////

        /// <summary>
        /// Refreshes the tiles on the tilemap based on the current texture and
        /// tile map texture size.
        /// </summary>
        private void refreshTiles()
        {
            //Can't refresh if no texture.
            if (texture == null)
                return;

            map.Layers = new List<TileLayer>();
            TileLayer layer = new TileLayer();

            //Set up the tiles on the tilemap.
            Point curPos = new Point(0, 0);
            Microsoft.Xna.Framework.Point tilePos = new Microsoft.Xna.Framework.Point(0, 0);
            while (curPos.Y < texture.Height - TileTextureSize)
            {
                while (curPos.X < texture.Width - TileTextureSize)
                {
                    //Add the tile.
                    layer.Tiles.Add(tilePos, new TileData()
                    {
                        Position = tilePos,
                        TextureID = textureID
                    });

                    //Increment to next horizontal tile.
                    curPos.X += TileTextureSize;
                    tilePos.X++;
                }

                //Reset for next line.
                tilePos.Y++;
                tilePos.X = 0;
                curPos.X = 0;
                curPos.Y += TileTextureSize;
            }

            //Add layer to map, invalidate.
            map.Layers.Add(layer);
            Map = map;
            Invalidate();
        }

        /// <summary>
        /// Adjusts the camera position to the correct location on a change to the palette.
        /// </summary>
        private void adjustCameraPosition()
        {
            //Calculate the top left of the palette with tile (0,0).
            Vector2f initialTopLeft = new Vector2f((Size.Width / 2f / Zoom) , (Size.Height / 2f / Zoom));
            int tileWidth = (int)(Size.Width / Zoom / GridStep);
            int tileHeight = (int)(Size.Height / Zoom / GridStep);

            //If no texture, set the position here.
            if (texture == null)
            {
                ViewSize = new Vector2f();
                TotalSize = new Vector2f();
                OnSizesUpdated?.Invoke();

                cameraPos = initialTopLeft;
                return;
            }

            //Calculate surplus area in width/height from texture size.
            ViewSize = new Vector2f(Size.Width / Zoom, Size.Height / Zoom);
            TotalSize = new Vector2f(texture.Width / TileTextureSize * GridStep, texture.Height / TileTextureSize * GridStep);
            OnSizesUpdated?.Invoke();

            //Adjust the current camera position, set.
            initialTopLeft += ViewScroll;
            cameraPos = initialTopLeft;
            Invalidate();
        }
    }
}
