namespace AdventOfCode2020.Tests;

public class Day09_Tests
{
    [Fact]
    public void ResolvePart1__Example()
    {
        var day = new Day09();

        string result = day.ResolvePart1(new[] {
            "35",
            "20",
            "15",
            "25",
            "47",
            "40",
            "62",
            "55",
            "65",
            "95",
            "102",
            "117",
            "150",
            "182",
            "127",
            "219",
            "299",
            "277",
            "309",
            "576",
        });

        Assert.Equal("127", result);
    }

    [Fact]
    public void ResolvePart2__Example()
    {
        var day = new Day09();

        string result = day.ResolvePart2(new[] {
            "35",
            "20",
            "15",
            "25",
            "47",
            "40",
            "62",
            "55",
            "65",
            "95",
            "102",
            "117",
            "150",
            "182",
            "127",
            "219",
            "299",
            "277",
            "309",
            "576",
        });

        Assert.Equal("62", result);
    }
}