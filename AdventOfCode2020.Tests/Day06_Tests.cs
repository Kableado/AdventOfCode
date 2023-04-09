using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2020.Tests
{
    [TestClass()]
    public class Day06_Tests
    {
        [TestMethod()]
        public void ResolvePart1__Example()
        {
            var day = new Day06();

            string result = day.ResolvePart1(new string[] {
                "abc",
                "",
                "a",
                "b",
                "c",
                "",
                "ab",
                "ac",
                "",
                "a",
                "a",
                "a",
                "a",
                "",
                "b",
            });

            Assert.AreEqual("11", result);
        }

        [TestMethod()]
        public void ResolvePart2__Example()
        {
            var day = new Day06();

            string result = day.ResolvePart2(new string[] {
                "abc",
                "",
                "a",
                "b",
                "c",
                "",
                "ab",
                "ac",
                "",
                "a",
                "a",
                "a",
                "a",
                "",
                "b",
            });

            Assert.AreEqual("6", result);
        }
    }
}