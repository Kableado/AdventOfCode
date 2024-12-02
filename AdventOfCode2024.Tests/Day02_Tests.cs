namespace AdventOfCode2024.Tests;

public class Day02_Tests
{
    [Fact]
    public void ResolvePart1__Example()
    {
        Day02 day = new();

        string result = day.ResolvePart1([
            "7 6 4 2 1",
            "1 2 7 8 9",
            "9 7 6 2 1",
            "1 3 2 4 5",
            "8 6 4 4 1",
            "1 3 6 7 9",
        ]);

        Assert.Equal("2", result);
    }
    
    [Fact]
    public void ResolvePart2__Example()
    {
        Day02 day = new();

        string result = day.ResolvePart2([
            "7 6 4 2 1",
            "1 2 7 8 9",
            "9 7 6 2 1",
            "1 3 2 4 5",
            "8 6 4 4 1",
            "1 3 6 7 9",
        ]);

        Assert.Equal("4", result);
    }
}