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

        private bool _IsAlive;
        public bool IsAlive
        {
            get { return _IsAlive; }
            set
            {
                if (_IsAlive != value)
                {
                    if (_IsAlive)
                    {
                        //Reset counter when killing the cell
                        Generation = 0;
                    }

                    _IsAlive = value;
                }
            }
        }

        public int Generation { get; private set; }

        public Cell()
        {
        }

        public Cell(Point location, bool isAlive)
        {
            this.Location = location;
            this.IsAlive = isAlive;
        }

        public void Tick()
        {
            if (IsAlive)
            {
                Generation++;
            }
        }
    }
}
