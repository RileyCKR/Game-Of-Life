using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameOfLife
{
    public class Camera
    {
        private Rectangle _Screen;
        public Rectangle Screen
        {
            get { return _Screen; }
        }

        public Camera(Point screenSize)
        {
            _Screen = new Rectangle(0, 0, screenSize.X, screenSize.Y);
        }

        public void Update(GameTime gameTime, InputState inputState)
        {
            if (inputState.KeyDown(Keys.Left))
            {
                _Screen.Offset(new Point(-16, 0));
            }
            else if (inputState.KeyDown(Keys.Right))
            {
                _Screen.Offset(new Point(16, 0));
            }

            if (inputState.KeyDown(Keys.Up))
            {
                _Screen.Offset(new Point(0, -16));
            }
            else if (inputState.KeyDown(Keys.Down))
            {
                _Screen.Offset(new Point(0, 16));
            }
        }
    }
}
