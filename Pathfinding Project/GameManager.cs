using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinding_Project
{
    public class GameManager
    {
        private readonly Map _map;
        private readonly Hero _hero;
        private readonly Statue _statue;
        private readonly Tree _tree1;
        private readonly Tree _tree2;
        private readonly Tree _tree3;
        private readonly Tree _tree4;
        private readonly Tree _tree5;
        private readonly Tree _tree6;
        private readonly Tree _tree7;
        private readonly Tree _tree8;

        public GameManager()
        {
            _map = new();
            _hero = new(Globals.Content.Load<Texture2D>("hero"), Vector2.Zero);
            _statue = new(Globals.Content.Load<Texture2D>("statue"), _map.Tiles[2,2].Position + new Vector2(13, -8));
            _tree1 = new(Globals.Content.Load<Texture2D>("Bush"), _map.Tiles[3, 6].Position + new Vector2(8, 8));
            _tree2 = new(Globals.Content.Load<Texture2D>("Bush"), _map.Tiles[4, 6].Position + new Vector2(8, 8));
            _tree3 = new(Globals.Content.Load<Texture2D>("Bush"), _map.Tiles[5, 6].Position + new Vector2(8, 8));
            _tree4 = new(Globals.Content.Load<Texture2D>("Bush"), _map.Tiles[6, 6].Position + new Vector2(8, 8));
            _tree5 = new(Globals.Content.Load<Texture2D>("Bush"), _map.Tiles[3, 8].Position + new Vector2(8, 8));
            _tree6 = new(Globals.Content.Load<Texture2D>("Bush"), _map.Tiles[4, 8].Position + new Vector2(8, 8));
            _tree7 = new(Globals.Content.Load<Texture2D>("Bush"), _map.Tiles[5, 8].Position + new Vector2(8, 8));
            _tree8 = new(Globals.Content.Load<Texture2D>("Bush"), _map.Tiles[6, 8].Position + new Vector2(8, 8));
            _map.Tiles[2, 2].Blocked = true;
            _map.Tiles[4, 6].Blocked = true;
            _map.Tiles[5, 6].Blocked = true;
            _map.Tiles[6, 6].Blocked = true;
            _map.Tiles[3, 8].Blocked = true;
            _map.Tiles[4, 8].Blocked = true;
            _map.Tiles[5, 8].Blocked = true;
            _map.Tiles[6, 8].Blocked = true;
            _map.Tiles[3, 6].Blocked = true;
            Pathfinder.Init(_map, _hero);
        }

        public void Update()
        {
            InputManager.Update();
            _map.Update();
            _hero.Update();
        }

        public void Draw()
        {
            Globals.SpriteBatch.Begin();
            _map.Draw();
            _hero.Draw();
            _statue.Draw();
            _tree1.Draw();
            _tree2.Draw();
            _tree3.Draw();
            _tree4.Draw();
            _tree5.Draw();
            _tree6.Draw();
            _tree7.Draw();
            _tree8.Draw();
            Globals.SpriteBatch.End();
        }
    }
}
