using Xunit;

namespace AdventOfCode2018.Tests
{
    public class Day02_Tests
    {
        [Fact]
        public void ResolvePart1__Test1()
        {
            Day02 day02 = new Day02();

            string result = day02.ResolvePart1(new string[] {
                "abcdef",
                "bababc",
                "abbcde",
                "abcccd",
                "aabcdd",
                "abcdee",
                "ababab",
            });

            Assert.Equal("12", result);
        }

        [Fact]
        public void ResolvePart2__Test()
        {
            Day02 day02 = new Day02();

            string result = day02.ResolvePart2(new string[] {
                "abcde",
                "fghij",
                "klmno",
                "pqrst",
                "fguij",
                "axcye",
                "wvxyz",
            });

            Assert.Equal("fgij", result);
        }
    }
}