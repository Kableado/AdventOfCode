using Xunit;

namespace AdventOfCode2020.Tests
{
    public class Day02_Tests
    {
        #region ResolvePart1

        [Fact]
        public void ResolvePart1__Example()
        {
            var day = new Day02();

            string result = day.ResolvePart1(new string[] {
                "1-3 a: abcde",
                "1-3 b: cdefg",
                "2-9 c: ccccccccc",
            });

            Assert.Equal("2", result);
        }

        #endregion ResolvePart1

        #region ResolvePart2

        [Fact]
        public void ResolvePart2__Example()
        {
            var day = new Day02();

            string result = day.ResolvePart2(new string[] {
                "1-3 a: abcde",
                "1-3 b: cdefg",
                "2-9 c: ccccccccc",
            });

            Assert.Equal("1", result);
        }

        #endregion ResolvePart1
    }
}