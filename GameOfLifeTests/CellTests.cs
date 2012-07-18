using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
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
                Point location = new Point(10, 0);
                bool isAlive = false;
                Cell cell = new Cell(location, isAlive);
                Assert.AreEqual(location.X, cell.Location.X);
            }

            [Test]
            public void SetsYPos()
            {
                Point location = new Point(0, 10);
                bool isAlive = false;
                Cell cell = new Cell(location, isAlive);
                Assert.AreEqual(location.Y, cell.Location.Y);
            }

            [Test]
            public void SetsIsAlive()
            {
                Point location = new Point();
                bool isAlive = true;
                Cell cell = new Cell(location, isAlive);
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