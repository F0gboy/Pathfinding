using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Pathfinding_Project
{
    public class GameWorld : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GameManager _gameManager;

        public GameWorld()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            Globals.WindowSize = new(640, 640);
            _graphics.PreferredBackBufferWidth = Globals.WindowSize.X;
            _graphics.PreferredBackBufferHeight = Globals.WindowSize.Y;
            _graphics.ApplyChanges();

            Globals.Content = Content;
            _gameManager = new();

            /*/
            //Graph<string> graph = new Graph<string>();

            //graph.AddNode("Entrance");
            //graph.AddNode("Ice Blaster");
            //graph.AddNode("Slot Machines");
            //graph.AddNode("Funhouse");
            //graph.AddNode("Rocket Ships");
            //graph.AddNode("Hotdogs");
            //graph.AddNode("Log Flume");
            //graph.AddNode("Big Dipper");
            //graph.AddNode("Rollercoaster");
            //graph.AddNode("Ghost Train");
            //graph.AddNode("Carousel");
            //graph.AddNode("Flying Chairs");
            //graph.AddNode("3D Cinema");
            //graph.AddNode("Pirate Ship");

            //graph.AddEdge("Entrance", "Ice Blaster");
            //graph.AddEdge("Entrance", "Funhouse");
            //graph.AddEdge("Entrance", "Slot Machines");

            //graph.AddEdge("Ice Blaster", "Funhouse");
            //graph.AddEdge("Ice Blaster", "Slot Machines");
            //graph.AddEdge("Ice Blaster", "Rocket Ships");
            //graph.AddEdge("Ice Blaster", "3D Cinema");

            //graph.AddEdge("Slot Machines", "Rocket Ships");
            //graph.AddEdge("Slot Machines", "Hotdogs");

            //graph.AddEdge("Hotdogs", "Log Flume");

            //graph.AddEdge("Log Flume", "Big Dipper");

            //graph.AddEdge("Big Dipper", "Ghost Train");
            //graph.AddEdge("Big Dipper", "Rollercoaster");

            //graph.AddEdge("Ghost Train", "Carousel");
            //graph.AddEdge("Ghost Train", "Flying Chairs");

            //graph.AddEdge("Rocket Ships", "3D Cinema");
            //graph.AddEdge("Rocket Ships", "Ghost Train");

            //graph.AddEdge("Funhouse", "3D Cinema");

            //graph.AddEdge("3D Cinema", "Pirate Ship");

            //Node<string> n = DFS<string>(graph.Nodes.Find(x => x.Data == "Entrance"), graph.Nodes.Find(x => x.Data == "Ghost Train"));

            //List<Node<string>> path = TrackPath<string>(n, graph.Nodes.Find(x => x.Data == "Entrance"));

            //foreach (Node<string> pathNode in path)
            //{
            //    Debug.WriteLine(pathNode.Data);
            //}
            /*/

            base.Initialize();
        }

        //private static Pathfinder<T> DFS<T>(Pathfinder<T> start, Pathfinder<T> goal)
        //{
        //    Stack<Edge<T>> edges = new Stack<Edge<T>>();
        //    edges.Push(new Edge<T>(start, start));

        //    while (edges.Count > 0)
        //    {
        //        Edge<T> edge = edges.Pop();

        //        if (!edge.To.Visited)
        //        {
        //            edge.To.Visited = true;
        //            edge.To.Parent = edge.From;
        //        }
        //        if (edge.To == goal)
        //        {
        //            return edge.To;
        //        }

        //        foreach (Edge<T> e in edge.To.Edges)
        //        {
        //            if (!e.To.Visited)
        //            {
        //                edges.Push(e);
        //            }
        //        }
        //    }

        //    return null;
        //}

        //private static List<Pathfinder<T>> TrackPath<T>(Pathfinder<T> node, Pathfinder<T> start)
        //{
        //    List<Pathfinder<T>> path = new List<Pathfinder<T>>();

        //    while (!node.Equals(start))
        //    {
        //        path.Add(node);
        //        node = node.Parent;
        //    }

        //    path.Add(start);

        //    path.Reverse();

        //    return path;
        //}

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.SpriteBatch = _spriteBatch;

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Globals.Update(gameTime);
            _gameManager.Update();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _gameManager.Draw();

            base.Draw(gameTime);
        }
    }
}