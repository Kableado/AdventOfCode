using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2018.Tests
{
    [TestClass]
    public class Day06_Tests
    {
        [TestMethod]
        public void ResolvePart1__Test()
        {
            Day06 day06 = new Day06();

            string result = day06.ResolvePart1(new string[] {
                "1, 1",
                "1, 6",
                "8, 3",
                "3, 4",
                "5, 5",
                "8, 9",
            });

            Assert.AreEqual("17", result);
        }
        
        [TestMethod]
        public void ResolvePart2__Test()
        {
            Day06 day06 = new Day06 { DistanceThresold = 32, };

            string result = day06.ResolvePart2(new string[] {
                "1, 1",
                "1, 6",
                "8, 3",
                "3, 4",
                "5, 5",
                "8, 9",
            });

            Assert.AreEqual("16", result);
        }
    }
}