using Xunit;

namespace AdventOfCode2020.Tests
{
    public class Day03_Tests
    {
        [Fact]
        public void ResolvePart1__Example()
        {
            var day = new Day03();

            string result = day.ResolvePart1(new string[] {
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

            Assert.Equal("7", result);
        }

        [Fact]
        public void ResolvePart2__Example()
        {
            var day = new Day03();

            string result = day.ResolvePart2(new string[] {
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

            Assert.Equal("336", result);
        }
    }
}