using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2018.Tests
{
    [TestClass()]
    public class Day01_Tests
    {
        #region ResolvePart1

        [TestMethod()]
        public void ResolvePart1__Test1()
        {
            Day01 day01 = new Day01();

            string result = day01.ResolvePart1(new string[] { "+1", "-2", "+3", "+1", });

            Assert.AreEqual("3", result);
        }

        [TestMethod()]
        public void ResolvePart1__Test2()
        {
            Day01 day01 = new Day01();

            string result = day01.ResolvePart1(new string[] { "+1", "+1", "+1", });

            Assert.AreEqual("3", result);
        }

        [TestMethod()]
        public void ResolvePart1__Test3()
        {
            Day01 day01 = new Day01();

            string result = day01.ResolvePart1(new string[] { "+1", "+1", "-2", });

            Assert.AreEqual("0", result);
        }

        [TestMethod()]
        public void ResolvePart1__Test4()
        {
            Day01 day01 = new Day01();

            string result = day01.ResolvePart1(new string[] { "-1", "-2", "-3", });

            Assert.AreEqual("-6", result);
        }

        #endregion ResolveDay01

        #region ResolvePart2

        [TestMethod()]
        public void ResolvePart2__Test1()
        {
            Day01 day01 = new Day01();

            string result = day01.ResolvePart2(new string[] { "+1", "-2", "+3", "+1", });

            Assert.AreEqual("2", result);
        }

        [TestMethod()]
        public void ResolvePart2__Test2()
        {
            Day01 day01 = new Day01();

            string result = day01.ResolvePart2(new string[] { "+1", "-1", });

            Assert.AreEqual("0", result);
        }

        [TestMethod()]
        public void ResolvePart2__Test3()
        {
            Day01 day01 = new Day01();

            string result = day01.ResolvePart2(new string[] { "+3", "+3", "+4", "-2", "-4", });

            Assert.AreEqual("10", result);
        }

        [TestMethod()]
        public void ResolvePart2__Test4()
        {
            Day01 day01 = new Day01();

            string result = day01.ResolvePart2(new string[] { "-6", "+3", "+8", "+5", "-6", });

            Assert.AreEqual("5", result);
        }

        [TestMethod()]
        public void ResolvePart2__Test5()
        {
            Day01 day01 = new Day01();

            string result = day01.ResolvePart2(new string[] { "+7", "+7", "-2", "-7", "-4", });

            Assert.AreEqual("14", result);
        }

        #endregion ResolvePart2
    }
}