using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2018.Tests
{
    [TestClass()]
    public class Day12_Tests
    {
        [TestMethod()]
        public void ResolvePart1__Test()
        {
            Day12 day = new Day12();

            string result = day.ResolvePart1(new string[]
            {
                "initial state: #..#.#..##......###...###",
                "",
                "...## => #",
                "..#.. => #",
                ".#... => #",
                ".#.#. => #",
                ".#.## => #",
                ".##.. => #",
                ".#### => #",
                "#.#.# => #",
                "#.### => #",
                "##.#. => #",
                "##.## => #",
                "###.. => #",
                "###.# => #",
                "####. => #",
            });

            Assert.AreEqual("325", result);
        }
    }
}