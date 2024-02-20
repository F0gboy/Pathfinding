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

        private readonly Rock _rock1;
        private readonly Rock _rock2;
        private readonly Rock _rock3;
        private readonly Rock _rock4;
        private readonly Rock _rock5;
        private readonly Rock _rock6;
        private readonly Rock _rock7;
        private readonly Rock _rock8;

        public GameManager()
        {
            _map = new();
            _hero = new(Globals.Content.Load<Texture2D>("hero"), _map.Tiles[1, 7].Position);
            _statue = new(Globals.Content.Load<Texture2D>("statue"), _map.Tiles[2,2].Position + new Vector2(13, -8));
            _tree1 = new(Globals.Content.Load<Texture2D>("Bush"), _map.Tiles[3, 6].Position + new Vector2(8, 8));
            _tree2 = new(Globals.Content.Load<Texture2D>("Bush"), _map.Tiles[4, 6].Position + new Vector2(8, 8));
            _tree3 = new(Globals.Content.Load<Texture2D>("Bush"), _map.Tiles[5, 6].Position + new Vector2(8, 8));
            _tree4 = new(Globals.Content.Load<Texture2D>("Bush"), _map.Tiles[6, 6].Position + new Vector2(8, 8));
            _tree5 = new(Globals.Content.Load<Texture2D>("Bush"), _map.Tiles[3, 8].Position + new Vector2(8, 8));
            _tree6 = new(Globals.Content.Load<Texture2D>("Bush"), _map.Tiles[4, 8].Position + new Vector2(8, 8));
            _tree7 = new(Globals.Content.Load<Texture2D>("Bush"), _map.Tiles[5, 8].Position + new Vector2(8, 8));
            _tree8 = new(Globals.Content.Load<Texture2D>("Bush"), _map.Tiles[6, 8].Position + new Vector2(8, 8));

            _rock1 = new(Globals.Content.Load<Texture2D>("rock"), _map.Tiles[6, 5].Position + new Vector2(2, 6));
            _rock2 = new(Globals.Content.Load<Texture2D>("rock"), _map.Tiles[6, 4].Position + new Vector2(2, 6));
            _rock3 = new(Globals.Content.Load<Texture2D>("rock"), _map.Tiles[6, 3].Position + new Vector2(2, 6));
            _rock4 = new(Globals.Content.Load<Texture2D>("rock"), _map.Tiles[6, 2].Position + new Vector2(2, 6));
            _rock5 = new(Globals.Content.Load<Texture2D>("rock"), _map.Tiles[7, 5].Position + new Vector2(2, 6));
            _rock6 = new(Globals.Content.Load<Texture2D>("rock"), _map.Tiles[7, 4].Position + new Vector2(2, 6));
            _rock7 = new(Globals.Content.Load<Texture2D>("rock"), _map.Tiles[7, 3].Position + new Vector2(2, 6));
            _rock8 = new(Globals.Content.Load<Texture2D>("rock"), _map.Tiles[7, 2].Position + new Vector2(2, 6));

            _map.Tiles[2, 2].Blocked = true;
            _map.Tiles[4, 6].Blocked = true;
            _map.Tiles[5, 6].Blocked = true;
            _map.Tiles[6, 6].Blocked = true;
            _map.Tiles[3, 8].Blocked = true;
            _map.Tiles[4, 8].Blocked = true;
            _map.Tiles[5, 8].Blocked = true;
            _map.Tiles[6, 8].Blocked = true;
            _map.Tiles[3, 6].Blocked = true;
            _map.Tiles[6, 5].Blocked = true;
            _map.Tiles[6, 4].Blocked = true;
            _map.Tiles[6, 3].Blocked = true;
            _map.Tiles[6, 2].Blocked = true;
            _map.Tiles[7, 5].Blocked = true;
            _map.Tiles[7, 4].Blocked = true;
            _map.Tiles[7, 3].Blocked = true;
            _map.Tiles[7, 2].Blocked = true;

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
            _rock1.Draw();
            _rock2.Draw();
            _rock3.Draw();
            _rock4.Draw();
            _rock5.Draw();
            _rock6.Draw();
            _rock7.Draw();
            _rock8.Draw();
            Globals.SpriteBatch.End();
        }
    }
}
