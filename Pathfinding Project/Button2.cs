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

    namespace YourNamespace
    {
        public class Button2
        {
            private Texture2D _texture;
            private Rectangle _rectangle;
            private MouseState _previousMouseState;

            public Button2(Texture2D texture, Rectangle rectangle)
            {
                _texture = texture;
                _rectangle = rectangle;
                _previousMouseState = Mouse.GetState();
            }

            public void Update(GameWorld gameWorld)
            {
                MouseState currentMouseState = Mouse.GetState();

                // Check if the left mouse button was pressed
                if (currentMouseState.LeftButton == ButtonState.Pressed && _previousMouseState.LeftButton == ButtonState.Released)
                {
                    // Check if the mouse cursor is within the button bounds
                    if (_rectangle.Contains(currentMouseState.Position))
                    {
                        // Call the click method in the GameWorld
                        gameWorld.ButtonClickedAsync2();
                    }
                }

                // Update previous mouse state
                _previousMouseState = currentMouseState;
            }

            public void Draw(SpriteBatch spriteBatch)
            {
                spriteBatch.Draw(_texture, _rectangle, Color.White);
            }
        }
    }
}

