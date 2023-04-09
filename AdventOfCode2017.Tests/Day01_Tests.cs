using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Tests
{
    [TestClass()]
    public class Day01_Tests
    {
        #region ResolvePart1

        [TestMethod()]
        public void ResolvePart1__Test1()
        {
            Day01 day01 = new Day01();

            string result = day01.ResolvePart1(new string[] { "1122", });

            Assert.AreEqual("3", result);
        }

        [TestMethod()]
        public void ResolvePart1__Test2()
        {
            Day01 day01 = new Day01();

            string result = day01.ResolvePart1(new string[] { "1111", });

            Assert.AreEqual("4", result);
        }

        [TestMethod()]
        public void ResolvePart1__Test3()
        {
            Day01 day01 = new Day01();

            string result = day01.ResolvePart1(new string[] { "1234", });

            Assert.AreEqual("0", result);
        }

        [TestMethod()]
        public void ResolvePart1__Test4()
        {
            Day01 day01 = new Day01();

            string result = day01.ResolvePart1(new string[] { "91212129", });

            Assert.AreEqual("9", result);
        }

        #endregion ResolvePart1

        #region ResolvePart2
        
        [TestMethod()]
        public void ResolvePart2__Test1()
        {
            Day01 day01 = new Day01();

            string result = day01.ResolvePart2(new string[] { "1212", });

            Assert.AreEqual("6", result);
        }

        [TestMethod()]
        public void ResolvePart2__Test2()
        {
            Day01 day01 = new Day01();

            string result = day01.ResolvePart2(new string[] { "1221", });

            Assert.AreEqual("0", result);
        }

        [TestMethod()]
        public void ResolvePart2__Test3()
        {
            Day01 day01 = new Day01();

            string result = day01.ResolvePart2(new string[] { "123425", });

            Assert.AreEqual("4", result);
        }

        [TestMethod()]
        public void ResolvePart2__Test4()
        {
            Day01 day01 = new Day01();

            string result = day01.ResolvePart2(new string[] { "123123", });

            Assert.AreEqual("12", result);
        }

        [TestMethod()]
        public void ResolvePart2__Test5()
        {
            Day01 day01 = new Day01();

            string result = day01.ResolvePart2(new string[] { "12131415", });

            Assert.AreEqual("4", result);
        }

        #endregion ResolvePart2
    }
}