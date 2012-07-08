using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConwayGOL
{
    interface IMap
    {
        int Generation { get; }

        IEnumerable<ICell> Cells { get; }

        void Tick();

        void FlipCell(int xRow, int yRow);
    }
}