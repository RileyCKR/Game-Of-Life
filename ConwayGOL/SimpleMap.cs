using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConwayGOL
{
    /// <summary>
    /// 100 x 100 grid of cells
    /// </summary>
    public class SimpleMap : IMap
    {
        public int Generation { get; private set; }

        public IEnumerable<ICell> Cells
        {
            get { return CellMap; }
        }

        public ICell[] CellMap { get; private set; }

        public SimpleMap(int sideSize)
        {
            int arraySize = sideSize * sideSize;
            CellMap = new Cell[arraySize];
            int effectiveX;
            int effectiveY;
            for (int x = 0; x < arraySize; x++)
            {
                //Translate x/y coordinates into 1Dimensional array index
                effectiveX = x % sideSize;
                effectiveY = x / sideSize;
                CellMap[x] = new Cell(effectiveX, effectiveY, false);
            }
        }

        public void Tick()
        {
            foreach (ICell cell in Cells)
            {

            }


            Generation++;
        }

        List<ICell> GetNeighbors(int xpos, int ypos)
        {
            return null;
        }
    }
}
