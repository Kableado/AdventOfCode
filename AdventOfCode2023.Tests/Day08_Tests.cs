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

    private readonly string[] _example3 = {
        "LR",
        "",
        "11A = (11B, XXX)",
        "11B = (XXX, 11Z)",
        "11Z = (11B, XXX)",
        "22A = (22B, XXX)",
        "22B = (22C, 22C)",
        "22C = (22Z, 22Z)",
        "22Z = (22B, 22B)",
        "XXX = (XXX, XXX)",
    };

    [Fact]
    public void ResolvePart2__Example3()
    {
        Day08 day = new();
        
        string result = day.ResolvePart2(_example3);

        Assert.Equal("6", result);
    }

}