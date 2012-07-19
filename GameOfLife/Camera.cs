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

            if(inputState.KeyDown(Keys.PageUp))
            {
                ZoomIn();
            }
            else if (inputState.KeyDown(Keys.PageDown))
            {
                ZoomOut();
            }
        }

        public Point GetCellPointOfClick(Point mouseClick)
        {
            int cellSize = 16;
            if (Zoom > 0)
            {
                cellSize = 8;
            }
            int xRow = mouseClick.X / cellSize;
            int yRow = mouseClick.Y / cellSize;
            Point cellPoint = new Point(Screen.X / cellSize, Screen.Y / cellSize);
            cellPoint.X = cellPoint.X + xRow;
            cellPoint.Y = cellPoint.Y + yRow;
            return cellPoint;
        }

        private void ZoomIn()
        {
            if (Zoom > 0)
            {
                Zoom--;
            }
        }

        private void ZoomOut()
        {
            if (Zoom < 4)
            {
                Zoom++;
            }
        }
    }
}
