namespace AdventOfCode2020.Tests;

public class Day06_Tests
{
    [Fact]
    public void ResolvePart1__Example()
    {
        Day06 day = new Day06();

        string result = day.ResolvePart1([
            "abc",
            "",
            "a",
            "b",
            "c",
            "",
            "ab",
            "ac",
            "",
            "a",
            "a",
            "a",
            "a",
            "",
            "b",
        ]);

        Assert.Equal("11", result);
    }

    [Fact]
    public void ResolvePart2__Example()
    {
        Day06 day = new Day06();

        string result = day.ResolvePart2([
            "abc",
            "",
            "a",
            "b",
            "c",
            "",
            "ab",
            "ac",
            "",
            "a",
            "a",
            "a",
            "a",
            "",
            "b",
        ]);

        Assert.Equal("6", result);
    }
}