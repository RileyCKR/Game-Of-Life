using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using GameOfLife;

namespace GameOfLifeTests
{
    [TestFixture]
    public class CellTests
    {
        [TestFixture]
        public class Constructor
        {
            [Test]
            public void SetsXPos()
            {
                int xpos = 10;
                int ypos = 0;
                bool isAlive = false;
                Cell cell = new Cell(xpos, ypos, isAlive);
                Assert.AreEqual(xpos, cell.XPos);
            }

            [Test]
            public void SetsYPos()
            {
                int xpos = 0;
                int ypos = 10;
                bool isAlive = false;
                Cell cell = new Cell(xpos, ypos, isAlive);
                Assert.AreEqual(ypos, cell.YPos);
            }

            [Test]
            public void SetsIsAlive()
            {
                int xpos = 0;
                int ypos = 0;
                bool isAlive = true;
                Cell cell = new Cell(xpos, ypos, isAlive);
                Assert.AreEqual(isAlive, cell.IsAlive);
            }
        }

        [TestFixture]
        public class TickMethod
        {
            [Test]
            public void TickLivingIncrementsGeneration()
            {
                Cell cell = new Cell();
                cell.IsAlive = true;
                cell.Tick();
                Assert.AreEqual(1, cell.Generation);
                cell.Tick();
                Assert.AreEqual(2, cell.Generation);
            }

            [Test]
            public void TickDeadDoesNothing()
            {
                Cell cell = new Cell();
                cell.Tick();
                Assert.AreEqual(0, cell.Generation);
            }
        }

        [TestFixture]
        public class IsAliveGetter
        {
            [Test]
            public void SetAliveDoesNotBeginGeneration()
            {
                Cell cell = new Cell();
                cell.IsAlive = true;
                Assert.AreEqual(0, cell.Generation);
            }

            [Test]
            public void KillCellResetsGeneration()
            {
                Cell cell = new Cell();
                cell.IsAlive = true;
                cell.Tick();
                cell.Tick();
                cell.Tick();
                cell.IsAlive = false;
                Assert.AreEqual(0, cell.Generation);
            }
        }
    }
}