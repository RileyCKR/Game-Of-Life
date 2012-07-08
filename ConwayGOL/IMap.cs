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

        void Tick();

        void FlipCell(int xRow, int yRow);

        ICell GetCell(int xRow, int yRow);
    }
}