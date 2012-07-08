using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ConwayGOL
{
    /// <summary>
    /// Simple fixed size map
    /// </summary>
    public class SimpleMap : IMap
    {
        /// <summary>
        /// Number of Ticks that have elapsed
        /// </summary>
        public int Generation { get; private set; }

        private ICell[] CellMap;

        private ICell[] CellBuffer;

        /// <summary>
        /// Rules that will be used on the cells
        /// </summary>
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

        /// <summary>
        /// Runs the rules on all cells, advancing the game by one generation.
        /// </summary>
        public void Tick()
        {
            CopyMapToBuffer(CellMap, CellBuffer);

            for (int index = 0; index < CellMap.Length; index++)
            {
                ICell cell = CellMap[index];
                Point coords = GetCoordsFromIndex(index);
                Rules.RunRules(cell, GetLivingNeighbors(CellBuffer, coords));
            }

            Generation++;
        }

        /// <summary>
        /// Gets the cell at the given coordinates
        /// </summary>
        /// <param name="xRow"></param>
        /// <param name="yRow"></param>
        /// <returns></returns>
        public ICell GetCell(int xRow, int yRow)
        {
            int index = GetIndexFromCoords(xRow, yRow);
            return CellMap[index];
        }

        /// <summary>
        /// Flips the living status of the cell at the given coordinates
        /// </summary>
        /// <param name="xRow"></param>
        /// <param name="yRow"></param>
        public void FlipCell(int xRow, int yRow)
        {
            int index = GetIndexFromCoords(xRow, yRow);
            CellMap[index].IsAlive = !CellMap[index].IsAlive;
        }

        public List<ICell> GetLivingNeighbors(ICell[] map, Point cellCoords)
        {
            List<ICell> neighbors = new List<ICell>();
            int index = GetIndexFromCoords(cellCoords.X, cellCoords.Y);

            ICell cell;
            if (cellCoords.Y != 0)
            {
                if (cellCoords.X != 0)
                {
                    cell = map[index - SideSize - 1];
                    if (cell.IsAlive) neighbors.Add(cell);
                }

                cell = map[index - SideSize];
                if (cell.IsAlive) neighbors.Add(cell);

                if (cellCoords.X != SideSize - 1)
                {
                    cell = map[index - SideSize + 1];
                    if (cell.IsAlive) neighbors.Add(cell);
                }
            }

            if (cellCoords.X != 0)
            {
                cell = map[index - 1];
                if (cell.IsAlive) neighbors.Add(cell);
            }

            if (cellCoords.X != SideSize - 1)
            {
                cell = map[index + 1];
                if (cell.IsAlive) neighbors.Add(cell);
            }

            if (cellCoords.Y != SideSize - 1)
            {
                if (cellCoords.X != 0)
                {
                    cell = map[index + SideSize - 1];
                    if (cell.IsAlive) neighbors.Add(cell);
                }

                cell = map[index + SideSize];
                if (cell.IsAlive) neighbors.Add(cell);

                if (cellCoords.X != SideSize - 1)
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

        private int GetIndexFromCoords(int xRow, int yRow)
        {
            return SideSize * yRow + xRow;
        }

        private Point GetCoordsFromIndex(int index)
        {
            return new Point(index % SideSize, index / SideSize);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (ICell cell in CellMap)
            {
                Vector2 location = new Vector2(cell.XPos * 16, cell.YPos * 16);

                if (cell.IsAlive)
                {
                    spriteBatch.Draw(GameTextures.CellAlive, location, null, Color.White);
                }
                else
                {
                    spriteBatch.Draw(GameTextures.CellDead, location, null, Color.White);
                }
            }
        }
    }
}