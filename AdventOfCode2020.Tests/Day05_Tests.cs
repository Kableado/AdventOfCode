namespace AdventOfCode2020.Tests;

public class Day05_Tests
{
    [Fact]
    public void ResolvePart1__Example1()
    {
        Day05 day = new();

        string result = day.ResolvePart1([
            "FBFBBFFRLR",
        ]);

        Assert.Equal("357", result);
    }

    [Fact]
    public void ResolvePart1__Example2()
    {
        Day05 day = new();

        string result = day.ResolvePart1([
            "BFFFBBFRRR",
        ]);

        Assert.Equal("567", result);
    }

    [Fact]
    public void ResolvePart1__Example3()
    {
        Day05 day = new();

        string result = day.ResolvePart1([
            "FFFBBBFRRR",
        ]);

        Assert.Equal("119", result);
    }

    [Fact]
    public void ResolvePart1__Example4()
    {
        Day05 day = new();

        string result = day.ResolvePart1([
            "BBFFBBFRLL",
        ]);

        Assert.Equal("820", result);
    }
}