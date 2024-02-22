using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pathfinding_Project
{
    public class GameManager
    {
        #region
        private readonly Map _map;
        private readonly Hero _hero;
        private readonly Statue _statue;
        private readonly Portal _portal;
        private readonly Monument _monument;
        public bool StartGame = false;

        private readonly Bricks _bricks1;
        private readonly Bricks _bricks2;

        private Texture2D TreeTexture;
        private Texture2D RockTexture;

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
        #endregion

        public GameManager()
        {
            #region
            _map = new();
            _hero = new(Globals.Content.Load<Texture2D>("hero"), _map.Tiles[1, 7].Position);

            _statue = new(Globals.Content.Load<Texture2D>("statue"), _map.Tiles[2,2].Position + new Vector2(13, -8));
            _statue.TilePos = new Vector2(2, 2);
            _portal = new(Globals.Content.Load<Texture2D>("portal"), _map.Tiles[0, 7].Position + new Vector2(-20, 0));
            _portal.TilePos = new Vector2(0, 7);
            _monument = new(Globals.Content.Load<Texture2D>("monument"), _map.Tiles[8, 7].Position + new Vector2(5, 5));
            _monument.TilePos = new Vector2(8, 7);

            _bricks1 = new(Globals.Content.Load<Texture2D>("bricks"), _map.Tiles[0, 0].Position + new Vector2(15, 20));
            _bricks1.TilePos = new Vector2(0, 0);
            _bricks2 = new(Globals.Content.Load<Texture2D>("bricks"), _map.Tiles[9, 9].Position + new Vector2(15, 20));
            _bricks2.TilePos = new Vector2(9, 9);

            TreeTexture = Globals.Content.Load<Texture2D>("Bush");
            RockTexture = Globals.Content.Load<Texture2D>("rock");

            _tree1 = new(TreeTexture, _map.Tiles[3, 6].Position + new Vector2(8, 8));
            _tree2 = new(TreeTexture, _map.Tiles[4, 6].Position + new Vector2(8, 8));
            _tree3 = new(TreeTexture, _map.Tiles[5, 6].Position + new Vector2(8, 8));
            _tree4 = new(TreeTexture, _map.Tiles[6, 6].Position + new Vector2(8, 8));
            _tree5 = new(TreeTexture, _map.Tiles[3, 8].Position + new Vector2(8, 8));
            _tree6 = new(TreeTexture, _map.Tiles[4, 8].Position + new Vector2(8, 8));
            _tree7 = new(TreeTexture, _map.Tiles[5, 8].Position + new Vector2(8, 8));
            _tree8 = new(TreeTexture, _map.Tiles[6, 8].Position + new Vector2(8, 8));

            _rock1 = new(RockTexture, _map.Tiles[6, 5].Position + new Vector2(2, 6));
            _rock2 = new(RockTexture, _map.Tiles[6, 4].Position + new Vector2(2, 6));
            _rock3 = new(RockTexture, _map.Tiles[6, 3].Position + new Vector2(2, 6));
            _rock4 = new(RockTexture, _map.Tiles[6, 2].Position + new Vector2(2, 6));
            _rock5 = new(RockTexture, _map.Tiles[7, 5].Position + new Vector2(2, 6));
            _rock6 = new(RockTexture, _map.Tiles[7, 4].Position + new Vector2(2, 6));
            _rock7 = new(RockTexture, _map.Tiles[7, 3].Position + new Vector2(2, 6));
            _rock8 = new(RockTexture, _map.Tiles[7, 2].Position + new Vector2(2, 6));

            //_map.Tiles[2, 2].Blocked = true;
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
            _map.Tiles[3, 9].Blocked = true;
            _map.Tiles[4, 9].Blocked = true;
            _map.Tiles[5, 9].Blocked = true;
            _map.Tiles[6, 9].Blocked = true;
            #endregion

            Pathfinder.Init(_map, _hero);
        }

        public void WorkerBFS()
        {
            Thread.Sleep(2000);

            GetEnergyBFS();

            DeliverEnergyBFS();

            GoToPortalBFS();

            Thread.Sleep(7000);

            _monument.Energy = false;
            _hero.Energy = false;
            _hero.bricksForStatue = false;
            _hero.bricksForMonument = false;
                
            StartGame = false;
        }

        public void WorkerAstar()
        {
            Thread.Sleep(2000);

            GetEnergyAstar();

            DeliverEnergyAstar();

            GoToPortalAstar();

            Thread.Sleep(7000);

            _monument.Energy = false;
            _hero.Energy = false;
            _hero.bricksForStatue = false;
            _hero.bricksForMonument = false;

            StartGame = false;
            
        }

        public void GetEnergyBFS()
        {
            while (_hero.Energy == false)
            {
                if (_hero.bricksForStatue == true)
                {
                    Pathfinder.BFSearch((int)_statue.TilePos.X, (int)_statue.TilePos.Y);
                    Thread.Sleep(5000);
                    _hero.Energy = true;
                }
                else
                {
                    Pathfinder.BFSearch((int)_bricks1.TilePos.X, (int)_bricks1.TilePos.Y);
                    _hero.bricksForStatue = true;
                    Thread.Sleep(5000);
                }
            }
        }

        public void GoToPortalBFS()
        {
            Pathfinder.BFSearch((int)_portal.TilePos.X, (int)_portal.TilePos.Y);
        }

        public void DeliverEnergyBFS()
        {
            while (_monument.Energy == false)
            {
                if (_hero.bricksForMonument == true)
                {
                    Pathfinder.BFSearch((int)_monument.TilePos.X, (int)_monument.TilePos.Y);
                    Thread.Sleep(5000);
                    _hero.Energy = false;
                    _monument.Energy = true;
                }
                else
                {
                    Pathfinder.BFSearch((int)_bricks2.TilePos.X, (int)_bricks2.TilePos.Y);
                    Thread.Sleep(1600);
                    _map.Tiles[5, 7].Blocked = true;
                    _hero.bricksForMonument = true;
                    Thread.Sleep(5000);
                }
            }
        }

        public void GetEnergyAstar()
        {
            while (_hero.Energy == false)
            {
                if (_hero.bricksForStatue == true)
                {
                    Pathfinder.AStarPathfinding((int)_statue.TilePos.X, (int)_statue.TilePos.Y);
                    Thread.Sleep(5000);
                    _hero.Energy = true;
                }
                else
                {
                    Pathfinder.AStarPathfinding((int)_bricks1.TilePos.X, (int)_bricks1.TilePos.Y);
                    _hero.bricksForStatue = true;
                    Thread.Sleep(5000);
                }
            }
        }

        public void GoToPortalAstar()
        {
            Pathfinder.AStarPathfinding((int)_portal.TilePos.X, (int)_portal.TilePos.Y);
        }

        public void DeliverEnergyAstar()
        {
            while (_monument.Energy == false)
            {
                if (_hero.bricksForMonument == true)
                {
                    Pathfinder.AStarPathfinding((int)_monument.TilePos.X, (int)_monument.TilePos.Y);
                    Thread.Sleep(5000);
                    _hero.Energy = false;
                    _monument.Energy = true;
                }
                else
                {
                    Pathfinder.AStarPathfinding((int)_bricks2.TilePos.X, (int)_bricks2.TilePos.Y);
                    Thread.Sleep(1600);
                    _map.Tiles[5, 7].Blocked = true;
                    _hero.bricksForMonument = true;
                    Thread.Sleep(5000);
                }
            }
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

            #region
            _map.Draw();
            _portal.Draw();
            _statue.Draw();
            _monument.Draw();

            _bricks1.Draw();
            _bricks2.Draw();

            _hero.Draw();

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
            #endregion

            Globals.SpriteBatch.End();
        }
    }
}
