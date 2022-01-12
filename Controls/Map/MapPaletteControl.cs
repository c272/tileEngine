using DarkUI.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                RefreshTiles();
            }
        }

        //The tilemap used for displaying the palette.
        private TileMap map = new TileMap();

        //The texture currently being used for the palette.
        private Image texture = null;

        //The ID of the texture currently being used.
        private int textureID = -1;

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

            RefreshTiles();
        }

        /// <summary>
        /// Refreshes the tiles on the tilemap based on the current texture and
        /// tile map texture size.
        /// </summary>
        private void RefreshTiles()
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
    }
}
