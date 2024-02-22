using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pathfinding_Project.Pathfinding_Project;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Pathfinding_Project
{
    public class GameWorld : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GameManager _gameManager;
        public bool startGame = false;

        private Button button1;
        private Button button2;

        private GameWorld _gameWorld;

        SpriteFont font;


        public GameWorld()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _gameWorld = this;
        }


        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            Globals.WindowSize = new(640, 640);
            _graphics.PreferredBackBufferWidth = Globals.WindowSize.X;
            _graphics.PreferredBackBufferHeight = Globals.WindowSize.Y;
            _graphics.ApplyChanges();

            Texture2D buttonTexture = Content.Load<Texture2D>("StoneGround");
            Rectangle buttonRectangle = new Rectangle(100, 100, buttonTexture.Width, buttonTexture.Height);
            button1 = new Button(buttonTexture, buttonRectangle);

            Rectangle buttonRectangle2 = new Rectangle(400, 100, buttonTexture.Width, buttonTexture.Height);
            button2 = new Button(buttonTexture, buttonRectangle2);

            Globals.Content = Content;
            _gameManager = new();

            base.Initialize();
        }

        public async Task ButtonClickedAsync()
        {
            _gameManager.StartGame = true;
            startGame = true;

            await Task.Run(() => _gameManager.WorkerBFS());
        }

        public async Task ButtonClickedAsync2()
        {
            _gameManager.StartGame = true;
            startGame = true;

            await Task.Run(() => _gameManager.WorkerAstar());
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.SpriteBatch = _spriteBatch;
            font = Content.Load<SpriteFont>("font");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Globals.Update(gameTime);

            startGame = _gameManager.StartGame;

            if (startGame == true)
            {
                _gameManager.Update();
            }
            else
            {
                button1.Update(this);
                button2.Update(this);
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            if (startGame == true)
            {
                _gameManager.Draw();
            }
            else
            {
                _spriteBatch.Begin();

                button1.Draw(_spriteBatch);
                _spriteBatch.DrawString(font, "DFS", new Vector2(130, 130), Color.White);

                button2.Draw(_spriteBatch);
                _spriteBatch.DrawString(font, "a*", new Vector2(430, 130), Color.White);

                _spriteBatch.End();
            }

            base.Draw(gameTime);
        }
    }
}