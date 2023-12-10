namespace AdventOfCode2023.Tests;

public class Day10_Tests
{
    private readonly string[] _example1 = {
        "7-F7-",
        ".FJ|7",
        "SJLL7",
        "|F--J",
        "LJ.LJ",
    };

    [Fact]
    public void ResolvePart1__Example1()
    {
        Day10 day = new();
        
        string result = day.ResolvePart1(_example1);

        Assert.Equal("8", result);
    }
    
    private readonly string[] _example2 = {
        "...........",
        ".S-------7.",
        ".|F-----7|.",
        ".||.....||.",
        ".||.....||.",
        ".|L-7.F-J|.",
        ".|..|.|..|.",
        ".L--J.L--J.",
        "...........",
    };

    [Fact]
    public void ResolvePart2__Example2()
    {
        Day10 day = new();
        
        string result = day.ResolvePart2(_example2);

        Assert.Equal("4", result);
    }

    
    private readonly string[] _example3 = {
        "FF7FSF7F7F7F7F7F---7",
        "L|LJ||||||||||||F--J",
        "FL-7LJLJ||||||LJL-77",
        "F--JF--7||LJLJ7F7FJ-",
        "L---JF-JLJ.||-FJLJJ7",
        "|F|F-JF---7F7-L7L|7|",
        "|FFJF7L7F-JF7|JL---7",
        "7-L-JL7||F7|L7F-7F7|",
        "L.L7LFJ|||||FJL7||LJ",
        "L7JLJL-JLJLJL--JLJ.L",
    };

    [Fact]
    public void ResolvePart2__Example3()
    {
        Day10 day = new();
        
        string result = day.ResolvePart2(_example3);

        Assert.Equal("10", result);
    }
}