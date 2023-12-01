using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2018.Tests
{
    [TestClass]
    public class Day03_Tests
    {
        [TestMethod]
        public void ResolvePart1__Test()
        {
            Day03 day03 = new Day03();

            string result = day03.ResolvePart1(new string[] {
                "#1 @ 1,3: 4x4",
                "#2 @ 3,1: 4x4",
                "#3 @ 5,5: 2x2",
            });

            Assert.AreEqual("4", result);
        }

        [TestMethod]
        public void ResolvePart2__Test()
        {
            Day03 day03 = new Day03();

            string result = day03.ResolvePart2(new string[] {
                "#1 @ 1,3: 4x4",
                "#2 @ 3,1: 4x4",
                "#3 @ 5,5: 2x2",
            });

            Assert.AreEqual("3", result);
        }
    }
}