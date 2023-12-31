﻿namespace AdventOfCode2018.Tests;

public class Day15_Tests
{
    #region ResolvePart1

    [Fact]
    public void ResolvePart1__Test1()
    {
        Day15 day = new();

        string result = day.ResolvePart1(new[] {
            "#######",
            "#.G...#",
            "#...EG#",
            "#.#.#G#",
            "#..G#E#",
            "#.....#",
            "#######",
        });

        Assert.Equal("27730", result);
    }

    [Fact]
    public void ResolvePart1__Test2()
    {
        Day15 day = new();

        string result = day.ResolvePart1(new[] {
            "#######",
            "#G..#E#",
            "#E#E.E#",
            "#G.##.#",
            "#...#E#",
            "#...E.#",
            "#######",
        });

        Assert.Equal("36334", result);
    }
        
    [Fact]
    public void ResolvePart1__Test3()
    {
        Day15 day = new();

        string result = day.ResolvePart1(new[] {
            "#######",
            "#E..EG#",
            "#.#G.E#",
            "#E.##E#",
            "#G..#.#",
            "#..E#.#",
            "#######",
        });

        Assert.Equal("39514", result);
    }

    [Fact]
    public void ResolvePart1__Test4()
    {
        Day15 day = new();

        string result = day.ResolvePart1(new[] {
            "#######",
            "#E.G#.#",
            "#.#G..#",
            "#G.#.G#",
            "#G..#.#",
            "#...E.#",
            "#######",
        });

        Assert.Equal("27755", result);
    }

    [Fact]
    public void ResolvePart1__Test5()
    {
        Day15 day = new();

        string result = day.ResolvePart1(new[] {
            "#######",
            "#.E...#",
            "#.#..G#",
            "#.###.#",
            "#E#G#G#",
            "#...#G#",
            "#######",
        });

        Assert.Equal("28944", result);
    }

    [Fact]
    public void ResolvePart1__Test6()
    {
        Day15 day = new();

        string result = day.ResolvePart1(new[] {
            "#########",
            "#G......#",
            "#.E.#...#",
            "#..##..G#",
            "#...##..#",
            "#...#...#",
            "#.G...G.#",
            "#.....G.#",
            "#########",
        });

        Assert.Equal("18740", result);
    }

    #endregion ResolvePart1

    #region ResolvePart2

    [Fact]
    public void ResolvePart2__Test1()
    {
        Day15 day = new();

        string result = day.ResolvePart2(new[] {
            "#######",
            "#.G...#",
            "#...EG#",
            "#.#.#G#",
            "#..G#E#",
            "#.....#",
            "#######",
        });

        Assert.Equal("4988", result);
    }
        
    [Fact]
    public void ResolvePart2__Test3()
    {
        Day15 day = new();

        string result = day.ResolvePart2(new[] {
            "#######",
            "#E..EG#",
            "#.#G.E#",
            "#E.##E#",
            "#G..#.#",
            "#..E#.#",
            "#######",
        });

        Assert.Equal("31284", result);
    }

    [Fact]
    public void ResolvePart2__Test4()
    {
        Day15 day = new();

        string result = day.ResolvePart2(new[] {
            "#######",
            "#E.G#.#",
            "#.#G..#",
            "#G.#.G#",
            "#G..#.#",
            "#...E.#",
            "#######",
        });

        Assert.Equal("3478", result);
    }

    [Fact]
    public void ResolvePart2__Test5()
    {
        Day15 day = new();

        string result = day.ResolvePart2(new[] {
            "#######",
            "#.E...#",
            "#.#..G#",
            "#.###.#",
            "#E#G#G#",
            "#...#G#",
            "#######",
        });

        Assert.Equal("6474", result);
    }

    [Fact]
    public void ResolvePart2__Test6()
    {
        Day15 day = new();

        string result = day.ResolvePart2(new[] {
            "#########",
            "#G......#",
            "#.E.#...#",
            "#..##..G#",
            "#...##..#",
            "#...#...#",
            "#.G...G.#",
            "#.....G.#",
            "#########",
        });

        Assert.Equal("1140", result);
    }

    #endregion ResolvePart2
}