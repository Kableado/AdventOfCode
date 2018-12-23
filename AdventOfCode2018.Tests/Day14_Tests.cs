using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2018.Tests
{
    [TestClass()]
    public class Day14_Tests
    {
        #region ResolvePart1

        [TestMethod()]
        public void ResolvePart1__Test1()
        {
            Day14 day = new Day14();

            string result = day.ResolvePart1(new string[] { "9", });

            Assert.AreEqual("5158916779", result);
        }

        [TestMethod()]
        public void ResolvePart1__Test2()
        {
            Day14 day = new Day14();

            string result = day.ResolvePart1(new string[] { "5", });

            Assert.AreEqual("0124515891", result);
        }

        [TestMethod()]
        public void ResolvePart1__Test3()
        {
            Day14 day = new Day14();

            string result = day.ResolvePart1(new string[] { "18", });

            Assert.AreEqual("9251071085", result);
        }

        [TestMethod()]
        public void ResolvePart1__Test4()
        {
            Day14 day = new Day14();

            string result = day.ResolvePart1(new string[] { "2018", });

            Assert.AreEqual("5941429882", result);
        }

        #endregion ResolvePart1

        #region ResolvePart2

        [TestMethod()]
        public void ResolvePart2__Test1()
        {
            Day14 day = new Day14();

            string result = day.ResolvePart2(new string[] { "51589", });

            Assert.AreEqual("9", result);
        }

        [TestMethod()]
        public void ResolvePart2__Test2()
        {
            Day14 day = new Day14();

            string result = day.ResolvePart2(new string[] { "01245", });

            Assert.AreEqual("5", result);
        }

        [TestMethod()]
        public void ResolvePart2__Test3()
        {
            Day14 day = new Day14();

            string result = day.ResolvePart2(new string[] { "92510", });

            Assert.AreEqual("18", result);
        }

        [TestMethod()]
        public void ResolvePart2__Test4()
        {
            Day14 day = new Day14();

            string result = day.ResolvePart2(new string[] { "59414", });

            Assert.AreEqual("2018", result);
        }

        #endregion ResolvePart2
    }
}