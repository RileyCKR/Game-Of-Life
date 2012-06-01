using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConwayGOL
{
    public class Cell : ICell
    {
        public int XPos { get; private set; }

        public int YPos { get; private set; }

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

        public Cell(int xpos, int ypos, bool isAlive)
        {
            this.XPos = xpos;
            this.YPos = ypos;
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
