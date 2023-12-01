using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2020.Tests
{
    [TestClass]
    public class Day02_Tests
    {
        #region ResolvePart1

        [TestMethod]
        public void ResolvePart1__Example()
        {
            var day = new Day02();

            string result = day.ResolvePart1(new string[] {
                "1-3 a: abcde",
                "1-3 b: cdefg",
                "2-9 c: ccccccccc",
            });

            Assert.AreEqual("2", result);
        }

        #endregion ResolvePart1

        #region ResolvePart2

        [TestMethod]
        public void ResolvePart2__Example()
        {
            var day = new Day02();

            string result = day.ResolvePart2(new string[] {
                "1-3 a: abcde",
                "1-3 b: cdefg",
                "2-9 c: ccccccccc",
            });

            Assert.AreEqual("1", result);
        }

        #endregion ResolvePart1
    }
}