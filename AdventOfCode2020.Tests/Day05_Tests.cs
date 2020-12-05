using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2020.Tests
{
    [TestClass()]
    public class Day05_Tests
    {
        [TestMethod()]
        public void ResolvePart1__Example1()
        {
            var day = new Day05();

            string result = day.ResolvePart1(new string[] {
                "FBFBBFFRLR",
            });

            Assert.AreEqual("357", result);
        }

        [TestMethod()]
        public void ResolvePart1__Example2()
        {
            var day = new Day05();

            string result = day.ResolvePart1(new string[] {
                "BFFFBBFRRR",
            });

            Assert.AreEqual("567", result);
        }

        [TestMethod()]
        public void ResolvePart1__Example3()
        {
            var day = new Day05();

            string result = day.ResolvePart1(new string[] {
                "FFFBBBFRRR",
            });

            Assert.AreEqual("119", result);
        }

        [TestMethod()]
        public void ResolvePart1__Example4()
        {
            var day = new Day05();

            string result = day.ResolvePart1(new string[] {
                "BBFFBBFRLL",
            });

            Assert.AreEqual("820", result);
        }
    }
}