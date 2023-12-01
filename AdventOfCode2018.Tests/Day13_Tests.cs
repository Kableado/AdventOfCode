using Xunit;

namespace AdventOfCode2018.Tests
{
    public class Day13_Tests
    {
        [Fact]
        public void ResolvePart1__Test1()
        {
            Day13 day = new Day13();

            string result = day.ResolvePart1(new string[] {
                "|",
                "v",
                "|",
                "|",
                "|",
                "^",
                "|",
            });

            Assert.Equal("0,3", result);
        }

        [Fact]
        public void ResolvePart1__Test2()
        {
            Day13 day = new Day13();

            string result = day.ResolvePart1(new string[] {
                @"/->-\        ",
                @"|   |  /----\",
                @"| /-+--+-\  |",
                @"| | |  | v  |",
                @"\-+-/  \-+--/",
                @"  \------/   ",
            });

            Assert.Equal("7,3", result);
        }

        [Fact]
        public void ResolvePart2__Test()
        {
            Day13 day = new Day13();

            string result = day.ResolvePart2(new string[] {
                @"/>-<\  ",
                @"|   |  ",
                @"| /<+-\",
                @"| | | v",
                @"\>+</ |",
                @"  |   ^",
                @"  \<->/",
            });

            Assert.Equal("6,4", result);
        }
    }
}