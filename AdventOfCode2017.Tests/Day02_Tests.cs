namespace AdventOfCode2017.Tests;

public class Day02_Tests
{
    [Fact]
    public void ResolvePart1__Test()
    {
        Day02 day02 = new();

        string result = day02.ResolvePart1(new[] {
            "5 1 9 5",
            "7 5 3",
            "2 4 6 8",
        });

        Assert.Equal("18", result);
    }

    [Fact]
    public void ResolvePart2__Test()
    {
        Day02 day02 = new();

        string result = day02.ResolvePart2(new[] {
            "5 9 2 8",
            "9 4 7 3",
            "3 8 6 5",
        });

        Assert.Equal("9", result);
    }
}