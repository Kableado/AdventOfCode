namespace AdventOfCode2018.Tests;

public class Day01_Tests
{
    #region ResolvePart1

    [Fact]
    public void ResolvePart1__Test1()
    {
        Day01 day01 = new();

        string result = day01.ResolvePart1(new[] { "+1", "-2", "+3", "+1", });

        Assert.Equal("3", result);
    }

    [Fact]
    public void ResolvePart1__Test2()
    {
        Day01 day01 = new();

        string result = day01.ResolvePart1(new[] { "+1", "+1", "+1", });

        Assert.Equal("3", result);
    }

    [Fact]
    public void ResolvePart1__Test3()
    {
        Day01 day01 = new();

        string result = day01.ResolvePart1(new[] { "+1", "+1", "-2", });

        Assert.Equal("0", result);
    }

    [Fact]
    public void ResolvePart1__Test4()
    {
        Day01 day01 = new();

        string result = day01.ResolvePart1(new[] { "-1", "-2", "-3", });

        Assert.Equal("-6", result);
    }

    #endregion ResolveDay01

    #region ResolvePart2

    [Fact]
    public void ResolvePart2__Test1()
    {
        Day01 day01 = new();

        string result = day01.ResolvePart2(new[] { "+1", "-2", "+3", "+1", });

        Assert.Equal("2", result);
    }

    [Fact]
    public void ResolvePart2__Test2()
    {
        Day01 day01 = new();

        string result = day01.ResolvePart2(new[] { "+1", "-1", });

        Assert.Equal("0", result);
    }

    [Fact]
    public void ResolvePart2__Test3()
    {
        Day01 day01 = new();

        string result = day01.ResolvePart2(new[] { "+3", "+3", "+4", "-2", "-4", });

        Assert.Equal("10", result);
    }

    [Fact]
    public void ResolvePart2__Test4()
    {
        Day01 day01 = new();

        string result = day01.ResolvePart2(new[] { "-6", "+3", "+8", "+5", "-6", });

        Assert.Equal("5", result);
    }

    [Fact]
    public void ResolvePart2__Test5()
    {
        Day01 day01 = new();

        string result = day01.ResolvePart2(new[] { "+7", "+7", "-2", "-7", "-4", });

        Assert.Equal("14", result);
    }

    #endregion ResolvePart2
}