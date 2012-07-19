using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameOfLife
{
    public class InfiniteMap : IMap
    {
        private Dictionary<Point, ICell> Cells;
        private Dictionary<Point, ICell> CellBuffer;
        private GameRules Rules;

        public InfiniteMap(GameRules rules)
        {
            Cells = new Dictionary<Point, ICell>();
            CellBuffer = new Dictionary<Point, ICell>();
            this.Rules = rules;
        }
        
        #region IMap Methods

        public int Generation { get; private set; }

        public void Tick()
        {
            CellBuffer.Clear();

            //Get Living Cells
            List<ICell> livingCells = new List<ICell>();
            foreach (ICell cell in Cells.Values)
            {
                if (cell.IsAlive)
                {
                    livingCells.Add(cell);
                    CellBuffer.Add(cell.Location, new Cell(cell.Location, cell.IsAlive));
                }
            }

            //Get Neigbors of Living cells
            foreach (ICell cell in livingCells)
            {
                Point key = new Point();
                ICell neighbor;

                //Top Left
                key.X = cell.Location.X - 1;
                key.Y = cell.Location.Y - 1;
                if (!CellBuffer.TryGetValue(key, out neighbor))
                {
                    CellBuffer.Add(key, new Cell(key, false));
                }
                //Top Center
                key.X = cell.Location.X;
                key.Y = cell.Location.Y - 1;
                if (!CellBuffer.TryGetValue(key, out neighbor))
                {
                    CellBuffer.Add(key, new Cell(key, false));
                }
                //Top Right
                key.X = cell.Location.X + 1;
                key.Y = cell.Location.Y - 1;
                if (!CellBuffer.TryGetValue(key, out neighbor))
                {
                    CellBuffer.Add(key, new Cell(key, false));
                }
                //Left
                key.X = cell.Location.X - 1;
                key.Y = cell.Location.Y;
                if (!CellBuffer.TryGetValue(key, out neighbor))
                {
                    CellBuffer.Add(key, new Cell(key, false));
                }
                //Right
                key.X = cell.Location.X + 1;
                key.Y = cell.Location.Y;
                if (!CellBuffer.TryGetValue(key, out neighbor))
                {
                    CellBuffer.Add(key, new Cell(key, false));
                }
                //Bottom Left
                key.X = cell.Location.X - 1;
                key.Y = cell.Location.Y + 1;
                if (!CellBuffer.TryGetValue(key, out neighbor))
                {
                    CellBuffer.Add(key, new Cell(key, false));
                }
                //Bottom Center
                key.X = cell.Location.X;
                key.Y = cell.Location.Y + 1;
                if (!CellBuffer.TryGetValue(key, out neighbor))
                {
                    CellBuffer.Add(key, new Cell(key, false));
                }
                //Bottom Right
                key.X = cell.Location.X + 1;
                key.Y = cell.Location.Y + 1;
                if (!CellBuffer.TryGetValue(key, out neighbor))
                {
                    CellBuffer.Add(key, new Cell(key, false));
                }
            }

            //Copy from Buffer
            CopyMapFromBuffer();

            //Run Rules
            foreach (Point key in Cells.Keys)
            {
                ICell cell = Cells[key];
                Rules.RunRules(cell, GetLivingNeighbors(CellBuffer, key));
            }

            Generation++;
        }

        public void FlipCell(int xRow, int yRow)
        {
            ICell cell = GetCell(xRow, yRow);
            cell.IsAlive = !cell.IsAlive;
        }

        public ICell GetCell(int xRow, int yRow)
        {
            Point point = new Point(xRow, yRow);
            if (Cells.ContainsKey(point))
            {
                return Cells[point];
            }
            else
            {
                Cells.Add(point, new Cell(point, false));
                return Cells[point];
            }
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle camera)
        {
            Point offset = new Point(-camera.Location.X, -camera.Location.Y);
            foreach (ICell cell in Cells.Values)
            {
                Vector2 location = new Vector2(offset.X + (cell.Location.X * 16), offset.Y + (cell.Location.Y * 16));

                Texture2D texture = cell.IsAlive ? GameTextures.CellAlive : GameTextures.CellDead;
                spriteBatch.Draw(texture, location, null, Color.White);
            }
        }

        #endregion

        private List<ICell> GetLivingNeighbors(Dictionary<Point, ICell> cellMap, Point coords)
        {
            List<ICell> livingNeighbors = new List<ICell>();
            Point key = new Point();
            ICell neighbor;

            //Top Left
            key.X = coords.X - 1;
            key.Y = coords.Y - 1;
            if (cellMap.TryGetValue(key, out neighbor) && neighbor.IsAlive)
            {
                livingNeighbors.Add(neighbor);
            }
            //Top Center
            key.X = coords.X;
            key.Y = coords.Y - 1;
            if (cellMap.TryGetValue(key, out neighbor) && neighbor.IsAlive)
            {
                livingNeighbors.Add(neighbor);
            }
            //Top Right
            key.X = coords.X + 1;
            key.Y = coords.Y - 1;
            if (cellMap.TryGetValue(key, out neighbor) && neighbor.IsAlive)
            {
                livingNeighbors.Add(neighbor);
            }
            //Left
            key.X = coords.X - 1;
            key.Y = coords.Y;
            if (cellMap.TryGetValue(key, out neighbor) && neighbor.IsAlive)
            {
                livingNeighbors.Add(neighbor);
            }
            //Right
            key.X = coords.X + 1;
            key.Y = coords.Y;
            if (cellMap.TryGetValue(key, out neighbor) && neighbor.IsAlive)
            {
                livingNeighbors.Add(neighbor);
            }
            //Bottom Left
            key.X = coords.X - 1;
            key.Y = coords.Y + 1;
            if (cellMap.TryGetValue(key, out neighbor) && neighbor.IsAlive)
            {
                livingNeighbors.Add(neighbor);
            }
            //Bottom Center
            key.X = coords.X;
            key.Y = coords.Y + 1;
            if (cellMap.TryGetValue(key, out neighbor) && neighbor.IsAlive)
            {
                livingNeighbors.Add(neighbor);
            }
            //Bottom Right
            key.X = coords.X + 1;
            key.Y = coords.Y + 1;
            if (cellMap.TryGetValue(key, out neighbor) && neighbor.IsAlive)
            {
                livingNeighbors.Add(neighbor);
            }

            return livingNeighbors;
        }

        private void CopyMapFromBuffer()
        {
            Cells.Clear();
            foreach (ICell cell in CellBuffer.Values)
            {
                Cells.Add(cell.Location, new Cell(cell.Location, cell.IsAlive));
            }
        }
    }
}