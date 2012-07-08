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

        private ICell[] CellBuffer;

        public GameRules Rules { get; private set; }

        public int SideSize { get; private set; }

        public SimpleMap(int sideSize, GameRules rules)
        {
            this.SideSize = sideSize;
            this.Rules = rules;

            int arraySize = SideSize * SideSize;
            CellMap = new Cell[arraySize];
            CellBuffer = new Cell[arraySize];

            int effectiveX;
            int effectiveY;
            for (int x = 0; x < arraySize; x++)
            {
                //Translate x/y coordinates into 1Dimensional array index
                effectiveX = x % SideSize;
                effectiveY = x / SideSize;
                CellMap[x] = new Cell(effectiveX, effectiveY, false);
                CellBuffer[x] = new Cell(effectiveX, effectiveY, false);
            }
        }

        public void Tick()
        {
            CopyMapToBuffer(CellMap, CellBuffer);

            int effectiveX = 0;
            int effectiveY = 0;
            for (int index = 0; index < CellMap.Length; index++)
            {
                ICell cell = CellMap[index];
                effectiveX = index % SideSize;
                effectiveY = index / SideSize;
                Rules.RunRules(cell, GetLivingNeighbors(CellBuffer, effectiveX, effectiveY));
            }

            Generation++;
        }

        public void FlipCell(int xRow, int yRow)
        {
            int index = SideSize * yRow + xRow;
            CellMap[index].IsAlive = !CellMap[index].IsAlive;
        }

        public List<ICell> GetLivingNeighbors(ICell[] map, int xpos, int ypos)
        {
            List<ICell> neighbors = new List<ICell>();
            int index = (ypos * SideSize) + xpos;

            ICell cell;
            if (ypos != 0)
            {
                if (xpos != 0)
                {
                    cell = map[index - SideSize - 1];
                    if (cell.IsAlive) neighbors.Add(cell);
                }

                cell = map[index - SideSize];
                if (cell.IsAlive) neighbors.Add(cell);

                if (xpos != SideSize - 1)
                {
                    cell = map[index - SideSize + 1];
                    if (cell.IsAlive) neighbors.Add(cell);
                }
            }

            if (xpos != 0)
            {
                cell = map[index - 1];
                if (cell.IsAlive) neighbors.Add(cell);
            }

            if (xpos != SideSize - 1)
            {
                cell = map[index + 1];
                if (cell.IsAlive) neighbors.Add(cell);
            }

            if (ypos != SideSize - 1)
            {
                if (xpos != 0)
                {
                    cell = map[index + SideSize - 1];
                    if (cell.IsAlive) neighbors.Add(cell);
                }

                cell = map[index + SideSize];
                if (cell.IsAlive) neighbors.Add(cell);

                if (xpos != SideSize - 1)
                {
                    cell = map[index + SideSize + 1];
                    if (cell.IsAlive) neighbors.Add(cell);
                }
            }

            return neighbors;
        }

        private void CopyMapToBuffer(ICell[] source, ICell[] buffer)
        {
            for (int index = 0; index < source.Length; index++)
            {
                ICell sCell = source[index];
                ICell bCell = buffer[index];
                bCell.IsAlive = sCell.IsAlive;
            }
        }
    }
}