using AdventOfCode2020;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2020.Tests
{
    [TestClass()]
    public class Day03_Tests
    {
        [TestMethod()]
        public void ResolvePart1__Example()
        {
            IDay day03 = new Day03();

            string result = day03.ResolvePart1(new string[] {
                "..##.......",
                "#...#...#..",
                ".#....#..#.",
                "..#.#...#.#",
                ".#...##..#.",
                "..#.##.....",
                ".#.#.#....#",
                ".#........#",
                "#.##...#...",
                "#...##....#",
                ".#..#...#.#",
            });

            Assert.AreEqual("7", result);
        }

        [TestMethod()]
        public void ResolvePart2__Example()
        {
            IDay day03 = new Day03();

            string result = day03.ResolvePart2(new string[] {
                "..##.......",
                "#...#...#..",
                ".#....#..#.",
                "..#.#...#.#",
                ".#...##..#.",
                "..#.##.....",
                ".#.#.#....#",
                ".#........#",
                "#.##...#...",
                "#...##....#",
                ".#..#...#.#",
            });

            Assert.AreEqual("336", result);
        }
    }
}