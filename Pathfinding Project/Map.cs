using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinding_Project
{
    public class Map
    {
        public readonly Point Size = new(10, 10);
        public Tile[,] Tiles { get; }
        public Point TileSize { get; }

        public Vector2 MapToScreen(int x, int y) => new(x * TileSize.X, y * TileSize.Y);
        public (int x, int y) ScreenToMap(int x, int y) => (x / TileSize.X, y / TileSize.Y);

        public Map()
        {
            Tiles = new Tile[Size.X, Size.Y];
            var texture = Globals.Content.Load<Texture2D>("tile");
            TileSize = new(texture.Width, texture.Height);

            for (int y = 0; y < Size.Y; y++)
            {
                for (int x = 0; x < Size.X; x++)
                {
                    Tiles[x, y] = new(texture, MapToScreen(x, y), x, y);
                }
            }
        }

        public void Update()
        {
            for (int y = 0; y < Size.Y; y++)
            {

                for (int x = 0; x < Size.X; x++)
                {
                    Tiles[x, y].Update();
                }
            }
        }

        public void Draw()
        {
            for (int y = 0; y < Size.Y; y++)
            {

                for(int x = 0;x < Size.X; x++)
                {
                    Tiles[x, y].Draw();
                }
            }
        }
    }
}
