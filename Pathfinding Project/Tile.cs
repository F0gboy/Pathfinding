using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinding_Project
{
    public class Tile : Sprite
    {
        public bool Blocked { get; set; }
        public bool Path { get; set; }

        private readonly int _mapX;
        private readonly int _mapY;

        public Tile(Texture2D texture, Vector2 position, int mapX, int mapY) : base(texture, position)
        {
            _mapX = mapX;
            _mapY = mapY;
        }

        public void Update()
        {
            if (Pathfinder.Ready() && Rectangle.Contains(InputManager.MouseRectangle))
            {
                if (InputManager.MouseClicked)
                {
                    Blocked = !Blocked;
                }

                if (InputManager.MouseRightClicked)
                {
                    Pathfinder.BFSearch(_mapX, _mapY);
                }
            }

            Color = Path ? Microsoft.Xna.Framework.Color.Green : Microsoft.Xna.Framework.Color.White;
            Color = Blocked ? Microsoft.Xna.Framework.Color.Red : Color;
        }

        //public override void Draw()
        //{
        //    Globals.SpriteBatch.Draw(texture, position, null, Color, 0f, Origin, 1f, SpriteEffects.None, 0f);
        //}
    }
}


