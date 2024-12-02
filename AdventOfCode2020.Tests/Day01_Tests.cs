namespace AdventOfCode2020.Tests;

public class Day01_Tests
{
    #region ResolvePart1

    [Fact]
    public void ResolvePart1__Example()
    {
        Day01 day = new();

        string result = day.ResolvePart1([
            "1721",
            "979",
            "366",
            "299",
            "675",
            "1456",
        ]);

        Assert.Equal("514579", result);
    }

    #endregion ResolvePart1

    #region ResolvePart2

    [Fact]
    public void ResolvePart2__Example()
    {
        Day01 day = new();

        string result = day.ResolvePart2([
            "1721",
            "979",
            "366",
            "299",
            "675",
            "1456",
        ]);

        Assert.Equal("241861950", result);
    }

    #endregion ResolvePart2
}