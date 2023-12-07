namespace AdventOfCode2023.Tests;

public class Day06_Tests
{
    private readonly string[] _example = {
        "Time:      7  15   30",
        "Distance:  9  40  200",
    };

    [Fact]
    public void ResolvePart1__Example()
    {
        Day06 day = new();
        
        string result = day.ResolvePart1(_example);

        Assert.Equal("288", result);
    }

    [Fact]
    public void ResolvePart2__Example()
    {
        Day06 day = new();
        
        string result = day.ResolvePart2(_example);

        Assert.Equal("71503", result);
    }
}