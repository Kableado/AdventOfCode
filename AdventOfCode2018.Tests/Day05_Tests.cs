namespace AdventOfCode2018.Tests;

public class Day05_Tests
{
    [Fact]
    public void ResolvePart1__Test()
    {
        Day05 day05 = new();

        string result = day05.ResolvePart1(new[] { "dabAcCaCBAcCcaDA" });

        Assert.Equal("10", result);
    }

    [Fact]
    public void ResolvePart2__Test()
    {
        Day05 day05 = new();

        string result = day05.ResolvePart2(new[] { "dabAcCaCBAcCcaDA" });

        Assert.Equal("4", result);
    }

    #region ReducePolymer

    [Fact]
    public void ReducePolymer__Remove_cC()
    {
        Day05 day05 = new();

        string result = day05.ReducePolymer("dabAcCaCBA");

        Assert.Equal("dabAaCBA", result);
    }

    [Fact]
    public void ReducePolymer__Remove_cC_AtEnd()
    {
        Day05 day05 = new();

        string result = day05.ReducePolymer("dabAcC");

        Assert.Equal("dabA", result);
    }

    [Fact]
    public void ReducePolymer__Remove_Only_cC()
    {
        Day05 day05 = new();

        string result = day05.ReducePolymer("cC");

        Assert.Equal("", result);
    }

    [Fact]
    public void ReducePolymer__Remove_cC_AtStart()
    {
        Day05 day05 = new();

        string result = day05.ReducePolymer("cCAAAA");

        Assert.Equal("AAAA", result);
    }

    [Fact]
    public void ReducePolymer__Remove_Aa()
    {
        Day05 day05 = new();

        string result = day05.ReducePolymer("dabAaCBA");

        Assert.Equal("dabCBA", result);
    }

    [Fact]
    public void ReducePolymer__Remove_cCc()
    {
        Day05 day05 = new();

        string result = day05.ReducePolymer("dabCBAcCcaDA");

        Assert.Equal("dabCBAcaDA", result);
    }

    [Fact]
    public void ReducePolymer__Irreductible()
    {
        Day05 day05 = new();

        string result = day05.ReducePolymer("dabCBAcaDA");

        Assert.Equal("dabCBAcaDA", result);
    }

    #endregion ReducePolymer

    #region FullyReducePolymer

    [Fact]
    public void FullyReducePolymer__Test()
    {
        Day05 day05 = new();

        string result = day05.FullyReducePolymer("dabAcCaCBAcCcaDA");

        Assert.Equal("dabCBAcaDA", result);
    }

    #endregion FullyReducePolymer

    #region RemoveUnitTypeFromPolymer

    [Fact]
    public void RemoveUnitTypeFromPolymer__Remove_a()
    {
        Day05 day05 = new();

        string result = day05.RemoveUnitTypeFromPolymer("dabAcCaCBAcCcaDA", 'a');

        Assert.Equal("dbcCCBcCcD", result);
    }

    [Fact]
    public void RemoveUnitTypeFromPolymer__Remove_b()
    {
        Day05 day05 = new();

        string result = day05.RemoveUnitTypeFromPolymer("dabAcCaCBAcCcaDA", 'b');

        Assert.Equal("daAcCaCAcCcaDA", result);
    }

    [Fact]
    public void RemoveUnitTypeFromPolymer__Remove_c()
    {
        Day05 day05 = new();

        string result = day05.RemoveUnitTypeFromPolymer("dabAcCaCBAcCcaDA", 'c');

        Assert.Equal("dabAaBAaDA", result);
    }

    [Fact]
    public void RemoveUnitTypeFromPolymer__Remove_d()
    {
        Day05 day05 = new();

        string result = day05.RemoveUnitTypeFromPolymer("dabAcCaCBAcCcaDA", 'd');

        Assert.Equal("abAcCaCBAcCcaA", result);
    }

    [Fact]
    public void RemoveUnitTypeFromPolymer__Remove_A()
    {
        Day05 day05 = new();

        string result = day05.RemoveUnitTypeFromPolymer("dabAcCaCBAcCcaDA", 'A');

        Assert.Equal("dbcCCBcCcD", result);
    }

    [Fact]
    public void RemoveUnitTypeFromPolymer__Remove_B()
    {
        Day05 day05 = new();

        string result = day05.RemoveUnitTypeFromPolymer("dabAcCaCBAcCcaDA", 'B');

        Assert.Equal("daAcCaCAcCcaDA", result);
    }

    [Fact]
    public void RemoveUnitTypeFromPolymer__Remove_C()
    {
        Day05 day05 = new();

        string result = day05.RemoveUnitTypeFromPolymer("dabAcCaCBAcCcaDA", 'C');

        Assert.Equal("dabAaBAaDA", result);
    }

    [Fact]
    public void RemoveUnitTypeFromPolymer__Remove_D()
    {
        Day05 day05 = new();

        string result = day05.RemoveUnitTypeFromPolymer("dabAcCaCBAcCcaDA", 'D');

        Assert.Equal("abAcCaCBAcCcaA", result);
    }

    #endregion RemoveUnitTypeFromPolymer
}