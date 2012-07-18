using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{
    public interface ICell
    {
        int XPos { get; }
        int YPos { get; }
        bool IsAlive { get; set; }

        int Generation { get; }

        void Tick();

    }
}