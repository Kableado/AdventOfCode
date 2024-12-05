
namespace AdventOfCode2024.Tests;

public class Day04_Tests
{
    [Fact]
    public void ResolvePart1_Example()
    {
        Day04 day = new();

        string result = day.ResolvePart1([
            "MMMSXXMASM",
            "MSAMXMSMSA",
            "AMXSXMAAMM",
            "MSAMASMSMX",
            "XMASAMXAMM",
            "XXAMMXXAMA",
            "SMSMSASXSS",
            "SAXAMASAAA",
            "MAMMMXMMMM",
            "MXMXAXMASX",
        ]);

        Assert.Equal("18", result);
    }
    
    [Fact]
    public void ResolvePart2_Example()
    {
        Day04 day = new();

        string result = day.ResolvePart2([
            "MMMSXXMASM",
            "MSAMXMSMSA",
            "AMXSXMAAMM",
            "MSAMASMSMX",
            "XMASAMXAMM",
            "XXAMMXXAMA",
            "SMSMSASXSS",
            "SAXAMASAAA",
            "MAMMMXMMMM",
            "MXMXAXMASX",
        ]);

        Assert.Equal("9", result);
    }
}