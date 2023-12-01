using Xunit;

namespace AdventOfCode2018.Tests
{
    public class Day03_Tests
    {
        [Fact]
        public void ResolvePart1__Test()
        {
            Day03 day03 = new Day03();

            string result = day03.ResolvePart1(new string[] {
                "#1 @ 1,3: 4x4",
                "#2 @ 3,1: 4x4",
                "#3 @ 5,5: 2x2",
            });

            Assert.Equal("4", result);
        }

        [Fact]
        public void ResolvePart2__Test()
        {
            Day03 day03 = new Day03();

            string result = day03.ResolvePart2(new string[] {
                "#1 @ 1,3: 4x4",
                "#2 @ 3,1: 4x4",
                "#3 @ 5,5: 2x2",
            });

            Assert.Equal("3", result);
        }
    }
}