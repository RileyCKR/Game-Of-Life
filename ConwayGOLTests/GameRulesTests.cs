using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ConwayGOL;

namespace ConwayGOLTests
{
    public class GameRulesTests
    {
        [TestFixture]
        public class RunRulesMethod
        {
            public GameRules GetConwayClassicRules()
            {
                int[] birthRules = new int[] { 3 };
                int[] stableRules = new int[] { 2, 3 };
                return new GameRules(birthRules, stableRules);
            }

            public Cell[] GetCellArray(int count)
            {
                Cell[] array = new Cell[count];
                for (int x = 0; x < count; x++)
                {
                    array[x] = new Cell();
                }
                return array;
            }

            [Test]
            public void SingleBirthCondition()
            {
                Cell cell = new Cell();
                Cell[] neighbors = GetCellArray(3);

                GetConwayClassicRules().RunRules(cell, neighbors);

                Assert.AreEqual(true, cell.IsAlive);
            }
        }
    }
}