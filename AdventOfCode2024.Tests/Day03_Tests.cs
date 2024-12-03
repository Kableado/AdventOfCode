namespace AdventOfCode2024.Tests;

public class Day03_Tests
{
    [Fact]
    public void ResolvePart1__Example()
    {
        Day03 day = new();

        string result = day.ResolvePart1([
            "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))",
        ]);

        Assert.Equal("161", result);
    }
}