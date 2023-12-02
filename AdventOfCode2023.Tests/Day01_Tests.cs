namespace AdventOfCode2023.Tests;

public class Day01_Tests
{
    [Fact]
    public void ResolvePart1__Example()
    {
        var day = new Day01();

        string result = day.ResolvePart1(new[] {
            "1abc2",
            "pqr3stu8vwx",
            "a1b2c3d4e5f",
            "treb7uchet",
        });

        Assert.Equal("142", result);
    }
    
    [Fact]
    public void ResolvePart2__Example()
    {
        var day = new Day01();

        string result = day.ResolvePart2(new[] {
            "two1nine",
            "eightwothree",
            "abcone2threexyz",
            "xtwone3four",
            "4nineeightseven2",
            "zoneight234",
            "7pqrstsixteen",
        });

        Assert.Equal("281", result);
    }
}