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

        public int Zoom { get; private set; }

        public Camera(Point screenSize)
        {
            _Screen = new Rectangle(0, 0, screenSize.X, screenSize.Y);
            Zoom = 0;
        }

        public void Update(GameTime gameTime, InputState inputState)
        {
            if (inputState.RightMousePressed())
            {
                Point offset = new Point(inputState.LastMousePosition.X - inputState.MousePosition.X, inputState.LastMousePosition.Y - inputState.MousePosition.Y);

                _Screen.Offset(offset);
            }

            if(inputState.MouseScrolledUp() || inputState.KeyDown(Keys.PageUp))
            {
                ZoomIn(inputState.MousePosition);
            }
            else if (inputState.MouseScrolledDown() || inputState.KeyDown(Keys.PageDown))
            {
                ZoomOut();
            }
        }

        public Point GetCellCoordinatesOfClick(Point mouseClick)
        {
            int cellSize;
            if (Zoom == 0)
            {
                cellSize = 16;
            }
            else if (Zoom == 1)
            {
                cellSize = 8;
            }
            else if (Zoom == 2)
            {
                cellSize = 4;
            }
            else if (Zoom == 3)
            {
                cellSize = 2;
            }
            else
            {
                cellSize = 1;
            }

            int xRow = (mouseClick.X + _Screen.X) / cellSize;
            int yRow = (mouseClick.Y + _Screen.Y) / cellSize;
            return new Point(xRow, yRow);
        }

        private void ZoomIn(Point mouseLocation)
        {
            if (Zoom > 0)
            {
                Zoom--;
                CenterCamera(mouseLocation);
            }
        }

        private void ZoomOut()
        {
            if (Zoom < 4)
            {
                Zoom++;
            }
        }

        private void CenterCamera(Point location)
        {
            int width = _Screen.Width;
            int height = _Screen.Height;

        }
    }
}
