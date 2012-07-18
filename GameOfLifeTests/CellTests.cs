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
            public void SetsLocation()
            {
                Point location = new Point(10, 15);
                bool isAlive = false;
                Cell cell = new Cell(location, isAlive);
                Assert.AreEqual(location.X, cell.Location.X);
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
    }
}