namespace AdventOfCode2023.Tests;

public class Day09_Tests
{
    private readonly string[] _example = {
        "0 3 6 9 12 15",
        "1 3 6 10 15 21",
        "10 13 16 21 30 45",
    };

    [Fact]
    public void ResolvePart1__Example()
    {
        Day09 day = new();
        
        string result = day.ResolvePart1(_example);

        Assert.Equal("114", result);
    }

    [Fact]
    public void ResolvePart2__Example()
    {
        Day09 day = new();
        
        string result = day.ResolvePart2(_example);

        Assert.Equal("2", result);
    }

    [Fact]
    public void Extrapolator_Extrapolate__Example1()
    {
        Day09.Extrapolator extrapolator = new("0 3 6 9 12 15");
        long result = extrapolator.Extrapolate();
        Assert.Equal(18, result);
    }
    
    [Fact]
    public void Extrapolator_Extrapolate__Example2()
    {
        Day09.Extrapolator extrapolator = new("1 3 6 10 15 21");
        long result = extrapolator.Extrapolate();
        Assert.Equal(28, result);
    }
    
    [Fact]
    public void Extrapolator_Extrapolate__Example3()
    {
        Day09.Extrapolator extrapolator = new("10 13 16 21 30 45");
        long result = extrapolator.Extrapolate();
        Assert.Equal(68, result);
    }

    [Fact]
    public void Extrapolator_ExtrapolatePast__Example1()
    {
        Day09.Extrapolator extrapolator = new("0 3 6 9 12 15");
        long result = extrapolator.ExtrapolatePast();
        Assert.Equal(-3, result);
    }
    
    [Fact]
    public void Extrapolator_ExtrapolatePast__Example2()
    {
        Day09.Extrapolator extrapolator = new("1 3 6 10 15 21");
        long result = extrapolator.ExtrapolatePast();
        Assert.Equal(0, result);
    }
    
    [Fact]
    public void Extrapolator_ExtrapolatePast__Example3()
    {
        Day09.Extrapolator extrapolator = new("10 13 16 21 30 45");
        long result = extrapolator.ExtrapolatePast();
        Assert.Equal(5, result);
    }
}