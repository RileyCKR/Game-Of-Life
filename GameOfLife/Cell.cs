using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GameOfLife
{
    public class Cell : ICell
    {
        public Point Location { get; private set; }

        public bool IsAlive { get; set; }

        public Cell()
        {
        }

        public Cell(Point location, bool isAlive)
        {
            this.Location = location;
            this.IsAlive = isAlive;
        }
    }
}
