using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2020.Tests
{
    [TestClass()]
    public class Day09_Tests
    {
        [TestMethod()]
        public void ResolvePart1__Example()
        {
            var day = new Day09();

            string result = day.ResolvePart1(new string[] {
                "35",
                "20",
                "15",
                "25",
                "47",
                "40",
                "62",
                "55",
                "65",
                "95",
                "102",
                "117",
                "150",
                "182",
                "127",
                "219",
                "299",
                "277",
                "309",
                "576",
            });

            Assert.AreEqual("127", result);
        }

        [TestMethod()]
        public void ResolvePart2__Example()
        {
            var day = new Day09();

            string result = day.ResolvePart2(new string[] {
                "35",
                "20",
                "15",
                "25",
                "47",
                "40",
                "62",
                "55",
                "65",
                "95",
                "102",
                "117",
                "150",
                "182",
                "127",
                "219",
                "299",
                "277",
                "309",
                "576",
            });

            Assert.AreEqual("62", result);
        }
    }
}