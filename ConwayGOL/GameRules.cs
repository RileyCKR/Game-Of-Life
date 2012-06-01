using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConwayGOL
{
    public class GameRules
    {
        public int[] BirthRules;
        public int[] StableRules;

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