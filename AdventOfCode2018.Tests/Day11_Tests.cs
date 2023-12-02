namespace AdventOfCode2018.Tests;

public class Day11_Tests
{
    [Fact]
    public void CalculatePowerLevelOfCell__Test1()
    {
        int powerLevel = Day11.CalculatePowerLevelOfCell(3, 5, 8);
        Assert.Equal(4, powerLevel);
    }

    [Fact]
    public void CalculatePowerLevelOfRegion__Test1()
    {
        int powerLevel = Day11.CalculatePowerLevelOfRegion(33, 45, 3, 18);
        Assert.Equal(29, powerLevel);
    }

    [Fact]
    public void CalculatePowerLevelOfRegion__Test2()
    {
        int powerLevel = Day11.CalculatePowerLevelOfRegion(21, 61, 3, 42);
        Assert.Equal(30, powerLevel);
    }

    [Fact]
    public void CalculatePowerLevelOfRegion__Test1_WithSumationField()
    {
        int[,] summationFiled = Day11.GenerateSumationField(300, 300, 18);
        int powerLevel = Day11.CalculatePowerLevelOfRegion(33, 45, 3, summationFiled);
        Assert.Equal(29, powerLevel);
    }

    [Fact]
    public void CalculatePowerLevelOfRegion__Test2_WithSumationField()
    {
        int[,] summationFiled = Day11.GenerateSumationField(300, 300, 42);
        int powerLevel = Day11.CalculatePowerLevelOfRegion(21, 61, 3, summationFiled);
        Assert.Equal(30, powerLevel);
    }

    [Fact]
    public void SearchBestRegionOfOneSize__Test1()
    {
        Day11.SearchBestRegionOfOneSize(300, 300, 3, 18, out int x, out int y);
        Assert.Equal(33, x);
        Assert.Equal(45, y);
    }

    [Fact]
    public void SearchBestRegionOfOneSize__Test2()
    {
        Day11.SearchBestRegionOfOneSize(300, 300, 3, 42, out int x, out int y);
        Assert.Equal(21, x);
        Assert.Equal(61, y);
    }

    [Fact]
    public void ResolvePart2__Test1()
    {
        Day11 day = new();
        string result = day.ResolvePart2(new[] { "18" });
        Assert.Equal("90,269,16", result);
    }

    [Fact]
    public void ResolvePart2__Test2()
    {
        Day11 day = new();
        string result = day.ResolvePart2(new[] { "42" });
        Assert.Equal("232,251,12", result);
    }
}