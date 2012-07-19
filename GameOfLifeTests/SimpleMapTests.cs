using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using GameOfLife;

namespace GameOfLifeTests
{
    [TestFixture]
    public class SimpleMapTests
    {
        //TODO: Expand tick method testing
        [Test]
        public void Tick()
        {
            SimpleMap map = new SimpleMap(2, GameRules.Standard());
            map.Tick();
        }

        [Test]
        public void GetCell()
        {
            SimpleMap map = new SimpleMap(2, GameRules.Standard());
            Assert.AreEqual(0, map.GetCell(0, 0).Location.X);
            Assert.AreEqual(0, map.GetCell(0, 0).Location.Y);

            Assert.AreEqual(1, map.GetCell(1, 0).Location.X);
            Assert.AreEqual(0, map.GetCell(1, 0).Location.Y);

            Assert.AreEqual(0, map.GetCell(0, 1).Location.X);
            Assert.AreEqual(1, map.GetCell(0, 1).Location.Y);

            Assert.AreEqual(1, map.GetCell(1, 1).Location.X);
            Assert.AreEqual(1, map.GetCell(1, 1).Location.Y);
        }

        [Test]
        public void FlipCell()
        {
            SimpleMap map = new SimpleMap(2, GameRules.Standard());
            map.FlipCell(0, 0);
            map.FlipCell(1, 0);

            Assert.AreEqual(true, map.GetCell(0, 0).IsAlive);
            Assert.AreEqual(true, map.GetCell(1, 0).IsAlive);
            Assert.AreEqual(false, map.GetCell(0, 1).IsAlive);
            Assert.AreEqual(false, map.GetCell(1, 1).IsAlive);
        }
    }
}
