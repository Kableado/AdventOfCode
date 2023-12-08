namespace AdventOfCode2023.Tests;

public class Day08_Tests
{
    private readonly string[] _example1 = {
        "RL",
        "",
        "AAA = (BBB, CCC)",
        "BBB = (DDD, EEE)",
        "CCC = (ZZZ, GGG)",
        "DDD = (DDD, DDD)",
        "EEE = (EEE, EEE)",
        "GGG = (GGG, GGG)",
        "ZZZ = (ZZZ, ZZZ)",
    };
    
    [Fact]
    public void ResolvePart1__Example1()
    {
        Day08 day = new();
        
        string result = day.ResolvePart1(_example1);

        Assert.Equal("2", result);
    }

    private readonly string[] _example2 = {
        "LLR",
        "",
        "AAA = (BBB, BBB)",
        "BBB = (AAA, ZZZ)",
        "ZZZ = (ZZZ, ZZZ)",
    };

    [Fact]
    public void ResolvePart1__Example2()
    {
        Day08 day = new();
        
        string result = day.ResolvePart1(_example2);

        Assert.Equal("6", result);
    }

}