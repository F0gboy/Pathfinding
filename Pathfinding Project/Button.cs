using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinding_Project
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    namespace Pathfinding_Project
    {
        public class Button
        {
            private Texture2D _texture;
            private Rectangle _rectangle;
            private MouseState _previousMouseState;

            public Button(Texture2D texture, Rectangle rectangle)
            {
                _texture = texture;
                _rectangle = rectangle;
                _previousMouseState = Mouse.GetState();
            }

            public void Update(GameWorld gameWorld)
            {
                MouseState currentMouseState = Mouse.GetState();

                if (currentMouseState.LeftButton == ButtonState.Pressed && _previousMouseState.LeftButton == ButtonState.Released)
                {
                    
                    if (_rectangle.Contains(currentMouseState.Position))
                    {
                        gameWorld.ButtonClickedAsync();
                    }
                }

                _previousMouseState = currentMouseState;
            }

            public void Draw(SpriteBatch spriteBatch)
            {
                spriteBatch.Draw(_texture, _rectangle, Color.White);
            }
        }
    }
}

