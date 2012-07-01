using System;
using System.Collections.Generic;
using System.Text;

namespace ConwayGOL
{
    /// <summary>
    /// Simple fixed size map
    /// </summary>
    public class SimpleMap //: IMap
    {
        public int Generation { get; private set; }

        public ICell[] CellMap { get; private set; }

        public GameRules Rules { get; private set; }

        public int SideSize { get; private set; }

        public SimpleMap(int sideSize, GameRules rules)
        {
            this.SideSize = sideSize;
            this.Rules = rules;

            int arraySize = SideSize * SideSize;
            CellMap = new Cell[arraySize];
            int effectiveX;
            int effectiveY;
            for (int x = 0; x < arraySize; x++)
            {
                //Translate x/y coordinates into 1Dimensional array index
                effectiveX = x % SideSize;
                effectiveY = x / SideSize;
                CellMap[x] = new Cell(effectiveX, effectiveY, false);
            }
        }

        public void Tick()
        {
            int effectiveX = 0;
            int effectiveY = 0;
            for (int index = 0; index < CellMap.Length; index++)
            {
                ICell cell = CellMap[index];
                effectiveX = index % SideSize;
                effectiveY = index / SideSize;
                Rules.RunRules(cell, GetLivingNeighbors(effectiveX, effectiveY));
            }

            Generation++;
        }

        public List<ICell> GetLivingNeighbors(int xpos, int ypos)
        {
            List<ICell> neighbors = new List<ICell>();
            int index = (ypos * SideSize) + xpos;

            ICell cell;
            if (ypos != 0)
            {
                if (xpos != 0)
                {
                    cell = CellMap[index - SideSize - 1];
                    if (cell.IsAlive) neighbors.Add(cell);
                }

                cell = CellMap[index - SideSize];
                if (cell.IsAlive) neighbors.Add(cell);

                if (xpos != SideSize - 1)
                {
                    cell = CellMap[index - SideSize + 1];
                    if (cell.IsAlive) neighbors.Add(cell);
                }
            }

            if (xpos != 0)
            {
                cell = CellMap[index - 1];
                if (cell.IsAlive) neighbors.Add(cell);
            }

            if (xpos != SideSize - 1)
            {
                cell = CellMap[index + 1];
                if (cell.IsAlive) neighbors.Add(cell);
            }

            if (ypos != SideSize - 1)
            {
                if (xpos != 0)
                {
                    cell = CellMap[index + SideSize - 1];
                    if (cell.IsAlive) neighbors.Add(cell);
                }

                cell = CellMap[index + SideSize];
                if (cell.IsAlive) neighbors.Add(cell);

                if (xpos != SideSize - 1)
                {
                    cell = CellMap[index + SideSize + 1];
                    if (cell.IsAlive) neighbors.Add(cell);
                }
            }

            return neighbors;
        }
    }
}