namespace AdventOfCode2023.Tests;

public class Day10_Tests
{
    private readonly string[] _example = {
        "7-F7-",
        ".FJ|7",
        "SJLL7",
        "|F--J",
        "LJ.LJ",
    };

    [Fact]
    public void ResolvePart1__Example()
    {
        Day10 day = new();
        
        string result = day.ResolvePart1(_example);

        Assert.Equal("8", result);
    }

}