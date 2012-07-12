using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConwayGOL
{
    /// <summary>
    /// Runs the logic for the game board.
    /// </summary>
    public class GameRules
    {
        /// <summary>
        /// The standard rules for Conway's Game of Life.  Cells are born with three
        /// neighbors and are stable with two or three neighbors.
        /// </summary>
        /// <returns></returns>
        public static GameRules Standard()
        {
            return new GameRules(new int[] { 3 }, new int[] { 2, 3 });
        }

        public int[] BirthRules { get; private set; }
        public int[] StableRules { get; private set; }

        public GameRules(int[] birthRules, int[] stableRules)
        {
            this.BirthRules = birthRules;
            this.StableRules = stableRules;
        }

        public void RunRules(ICell cell, IEnumerable<ICell> livingNeighbors)
        {
            if (cell.IsAlive)
            {
                cell.IsAlive = StableRules.Contains(livingNeighbors.Count());
            }
            else
            {
                cell.IsAlive = BirthRules.Contains(livingNeighbors.Count());
            }
        }
    }
}