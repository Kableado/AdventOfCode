namespace AdventOfCode2018.Tests;

public class Day09_Tests
{
    [Fact]
    public void ResolvePart1__Test1()
    {
        Day09 day = new();

        string result = day.ResolvePart1(new[] { "9 players; last marble is worth 25 points" });

        Assert.Equal("32", result);
    }

    [Fact]
    public void ResolvePart1__Test2()
    {
        Day09 day = new();

        string result = day.ResolvePart1(new[] { "10 players; last marble is worth 1618 points" });

        Assert.Equal("8317", result);
    }

    [Fact]
    public void ResolvePart1__Test3()
    {
        Day09 day = new();

        string result = day.ResolvePart1(new[] { "13 players; last marble is worth 7999 points" });

        Assert.Equal("146373", result);
    }

    [Fact]
    public void ResolvePart1__Test4()
    {
        Day09 day = new();

        string result = day.ResolvePart1(new[] { "17 players; last marble is worth 1104 points" });

        Assert.Equal("2764", result);
    }

    [Fact]
    public void ResolvePart1__Test5()
    {
        Day09 day = new();

        string result = day.ResolvePart1(new[] { "21 players; last marble is worth 6111 points" });

        Assert.Equal("54718", result);
    }

    [Fact]
    public void ResolvePart1__Test6()
    {
        Day09 day = new();

        string result = day.ResolvePart1(new[] { "30 players; last marble is worth 5807 points" });

        Assert.Equal("37305", result);
    }
}