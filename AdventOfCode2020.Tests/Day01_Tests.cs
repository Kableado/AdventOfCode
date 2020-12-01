using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2020.Tests
{
    [TestClass()]
    public class Day01_Tests
    {
        #region ResolvePart1

        [TestMethod()]
        public void ResolvePart1__Example()
        {
            Day01 day01 = new Day01();

            string result = day01.ResolvePart1(new string[] {
                "1721",
                "979",
                "366",
                "299",
                "675",
                "1456",
            });

            Assert.AreEqual("514579", result);
        }

        #endregion ResolvePart1

        #region ResolvePart2

        [TestMethod()]
        public void ResolvePart2__Example()
        {
            Day01 day01 = new Day01();

            string result = day01.ResolvePart2(new string[] {
                "1721",
                "979",
                "366",
                "299",
                "675",
                "1456",
            });

            Assert.AreEqual("241861950", result);
        }

        #endregion ResolvePart2
    }
}