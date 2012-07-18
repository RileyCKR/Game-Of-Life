using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
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

        /// <summary>
        /// Creates a new GameRules object with the given rules.
        /// </summary>
        /// <param name="birthRules">A cell will be born if it has this many living neighbors.</param>
        /// <param name="stableRules">A living cell will survice if it has this many living neighbors.</param>
        public GameRules(int[] birthRules, int[] stableRules)
        {
            this.BirthRules = birthRules;
            this.StableRules = stableRules;
        }

        /// <summary>
        /// Runs the game rules to determine wether a cell will still be alive.
        /// </summary>
        /// <param name="cell">Cell to run rules on.</param>
        /// <param name="livingNeighbors">The cell's living neighbors.</param>
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