namespace AdventOfCode2018.Tests;

public class Day06_Tests
{
    [Fact]
    public void ResolvePart1__Test()
    {
        Day06 day06 = new();

        string result = day06.ResolvePart1(new[] {
            "1, 1",
            "1, 6",
            "8, 3",
            "3, 4",
            "5, 5",
            "8, 9",
        });

        Assert.Equal("17", result);
    }
        
    [Fact]
    public void ResolvePart2__Test()
    {
        Day06 day06 = new() { DistanceThresold = 32, };

        string result = day06.ResolvePart2(new[] {
            "1, 1",
            "1, 6",
            "8, 3",
            "3, 4",
            "5, 5",
            "8, 9",
        });

        Assert.Equal("16", result);
    }
}