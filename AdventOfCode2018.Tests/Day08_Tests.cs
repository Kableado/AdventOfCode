using Xunit;

namespace AdventOfCode2018.Tests
{
    public class Day08_Tests
    {
        [Fact]
        public void ResolvePart1__Test()
        {
            Day08 day = new Day08();

            string result = day.ResolvePart1(new string[] { "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2", });

            Assert.Equal("138", result);
        }

        [Fact]
        public void ResolvePart2__Test()
        {
            Day08 day = new Day08();

            string result = day.ResolvePart2(new string[] { "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2", });

            Assert.Equal("66", result);
        }
    }
}