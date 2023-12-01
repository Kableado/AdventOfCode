using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2020.Tests
{
    [TestClass]
    public class Day11_Tests
    {
        [TestMethod]
        [Ignore]
        public void ResolvePart1__Example()
        {
            var day = new Day11();

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

        [TestMethod]
        [Ignore]
        public void ResolvePart2__Example()
        {
            var day = new Day11();

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