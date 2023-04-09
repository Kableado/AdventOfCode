using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2020.Tests
{
    [TestClass()]
    public class Day10_Tests
    {
        [TestMethod()]
        public void ResolvePart1__Example()
        {
            var day = new Day10();

            string result = day.ResolvePart1(new string[] {
                "XXXXXXXXXXXXXXX",
                "XXXXXXXXXXXXXXX",
                "XXXXXXXXXXXXXXX",
                "XXXXXXXXXXXXXXX",
                "XXXXXXXXXXXXXXX",
                "XXXXXXXXXXXXXXX",
                "XXXXXXXXXXXXXXX",
                "XXXXXXXXXXXXXXX",
            });

            Assert.AreEqual("YYY", result);
        }

        [TestMethod()]
        public void ResolvePart2__Example()
        {
            var day = new Day09();

            string result = day.ResolvePart2(new string[] {
                "XXXXXXXXXXXXXXX",
                "XXXXXXXXXXXXXXX",
                "XXXXXXXXXXXXXXX",
                "XXXXXXXXXXXXXXX",
                "XXXXXXXXXXXXXXX",
                "XXXXXXXXXXXXXXX",
                "XXXXXXXXXXXXXXX",
                "XXXXXXXXXXXXXXX",
            });

            Assert.AreEqual("YYY", result);
        }
    }
}