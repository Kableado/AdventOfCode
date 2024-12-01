namespace AdventOfCode2024.Tests;

public class Day01_Tests
{
    [Fact]
    public void ResolvePart1__Example()
    {
        var day = new Day01();

        string result = day.ResolvePart1(new[] {
            "3   4",
            "4   3",
            "2   5",
            "1   3",
            "3   9",
            "3   3",
        });

        Assert.Equal("11", result);
    }
    
    [Fact]
    public void ResolvePart2__Example()
    {
        var day = new Day01();

        string result = day.ResolvePart2(new[] {
            "3   4",
            "4   3",
            "2   5",
            "1   3",
            "3   9",
            "3   3",
        });

        Assert.Equal("31", result);
    }
}