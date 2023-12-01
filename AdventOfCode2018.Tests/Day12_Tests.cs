using Xunit;

namespace AdventOfCode2018.Tests
{
    public class Day12_Tests
    {
        [Fact]
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

            Assert.Equal("325", result);
        }
    }
}