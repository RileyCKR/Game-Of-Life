using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameOfLife
{
    interface IMap
    {
        int Generation { get; }

        void Tick();

        void FlipCell(int xRow, int yRow);

        ICell GetCell(int xRow, int yRow);

        void Draw(SpriteBatch spriteBatch, Camera camera);
    }
}