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

                GameRules.Standard().RunRules(cell, neighbors);

                Assert.AreEqual(true, cell.IsAlive);
            }

            [Test]
            public void MultipleBirthCondition()
            {
                GameRules rules = new GameRules(new int[] { 2, 3 }, new int[0]);
                Cell cell = new Cell();
                Cell[] neighbors = GetCellArray(2);

                rules.RunRules(cell, neighbors);
                Assert.AreEqual(true, cell.IsAlive);

                cell = new Cell();
                neighbors = GetCellArray(3);

                rules.RunRules(cell, neighbors);
                Assert.AreEqual(true, cell.IsAlive);
            }
        }

        [TestFixture]
        public class Constructor
        {
            [Test]
            public void SetsRules()
            {
                int[] birthCondition = new int[] { 2, 4, 6 };
                int[] stableCondition = new int[] { 2, 3, 5 };
                GameRules rules = new GameRules(birthCondition, stableCondition);
                
                Assert.AreEqual(birthCondition, rules.BirthRules);
                Assert.AreEqual(stableCondition, rules.StableRules);
            }
        }

        [TestFixture]
        public class StandardRulesGetter
        {
            [Test]
            public void HasCorrectRules()
            {
                GameRules rules = GameRules.Standard();

                Assert.AreEqual(new int[] { 3 }, rules.BirthRules);
                Assert.AreEqual(new int[] { 2, 3 }, rules.StableRules);
            }
        }
    }
}