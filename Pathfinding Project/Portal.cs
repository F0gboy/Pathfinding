using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinding_Project
{
    internal class Portal : Sprite
    {
        public Portal(Texture2D texture, Vector2 pos) : base(texture, pos)
        {
            this.Position = pos;
        }
    }
}
