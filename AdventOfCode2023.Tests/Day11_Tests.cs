namespace AdventOfCode2023.Tests;

public class Day11_Tests
{
    private readonly string[] _example1 = {
        "...#......",
        ".......#..",
        "#.........",
        "..........",
        "......#...",
        ".#........",
        ".........#",
        "..........",
        ".......#..",
        "#...#.....",
    };

    [Fact]
    public void ResolvePart1__Example1()
    {
        Day11 day = new();
        
        string result = day.ResolvePart1(_example1);

        Assert.Equal("374", result);
    }

}