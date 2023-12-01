using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2018.Tests
{
    [TestClass]
    public class ChronoPoint_Tests
    {
        #region FromString

        [TestMethod]
        public void FromString__Test1()
        {
            ChronoPoint point = ChronoPoint.FromString("1, 1");

            Assert.AreEqual(1, point.X);
            Assert.AreEqual(1, point.Y);
        }

        [TestMethod]
        public void FromString__Test2()
        {
            ChronoPoint point = ChronoPoint.FromString("1, 6");

            Assert.AreEqual(1, point.X);
            Assert.AreEqual(6, point.Y);
        }

        [TestMethod]
        public void FromString__Test3()
        {
            ChronoPoint point = ChronoPoint.FromString("8, 9");

            Assert.AreEqual(8, point.X);
            Assert.AreEqual(9, point.Y);
        }

        #endregion FromString

        #region ManhattanDistance

        [TestMethod]
        public void ManhattanDistance__Test1()
        {
            ChronoPoint p0 = ChronoPoint.FromString("8, 9");
            ChronoPoint p1 = ChronoPoint.FromString("1, 6");

            int distance = ChronoPoint.ManhattanDistance(p0, p1);

            Assert.AreEqual(10, distance);
        }

        [TestMethod]
        public void ManhattanDistance__Test2()
        {
            ChronoPoint p0 = ChronoPoint.FromString("1, 1");
            ChronoPoint p1 = ChronoPoint.FromString("1, 6");

            int distance = ChronoPoint.ManhattanDistance(p0, p1);

            Assert.AreEqual(5, distance);
        }

        #endregion ManhattanDistance
    }
}