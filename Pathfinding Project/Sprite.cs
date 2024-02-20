using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinding_Project
{
    public class Sprite
    {
        protected Texture2D texture;
        public Vector2 Position { get; set; }
        public Vector2 Origin { get; protected set; }
        public Color Color { get; set; }
        public Rectangle Rectangle => new((int)Position.X, (int)Position.Y, texture.Width, texture.Height);
        public Sprite(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            Position = position;
            Origin = Vector2.Zero;
            Color = Color.White;
        }

        public virtual void Draw()
        {
            Globals.SpriteBatch.Draw(texture, Position, null, Color, 0f, Origin, 1f, SpriteEffects.None, 0f);
        }
    }
}
