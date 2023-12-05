namespace AdventOfCode2018.Tests;

public class Day16_Tests
{
    [Fact]
    public void ResolvePart1__Test1()
    {
        Day16 day = new();

        string result = day.ResolvePart1(new[] {
            "Before: [3, 2, 1, 1]",
            "9 2 1 2",
            "After:  [3, 2, 2, 1]",
            "",
            "Before: [3, 2, 1, 1]",
            "9 2 1 2",
            "After:  [3, 2, 2, 1]",
            "",
            "",
            "Garbage",
        });

        Assert.Equal("2", result);
    }
}