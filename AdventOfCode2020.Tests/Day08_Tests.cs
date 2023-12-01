using Xunit;

namespace AdventOfCode2020.Tests
{
    public class Day08_Tests
    {
        [Fact]
        public void ResolvePart1__Example()
        {
            var day = new Day08();

            string result = day.ResolvePart1(new string[] {
                "nop +0",
                "acc +1",
                "jmp +4",
                "acc +3",
                "jmp -3",
                "acc -99",
                "acc +1",
                "jmp -4",
                "acc +6",
            });

            Assert.Equal("5", result);
        }

        [Fact]
        public void ResolvePart2__Example()
        {
            var day = new Day08();

            string result = day.ResolvePart2(new string[] {
                "nop +0",
                "acc +1",
                "jmp +4",
                "acc +3",
                "jmp -3",
                "acc -99",
                "acc +1",
                "jmp -4",
                "acc +6",
            });

            Assert.Equal("8", result);
        }
    }
}