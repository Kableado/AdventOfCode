﻿namespace AdventOfCode2020.Tests;

public class Day05_Tests
{
    [Fact]
    public void ResolvePart1__Example1()
    {
        var day = new Day05();

        string result = day.ResolvePart1(new[] {
            "FBFBBFFRLR",
        });

        Assert.Equal("357", result);
    }

    [Fact]
    public void ResolvePart1__Example2()
    {
        var day = new Day05();

        string result = day.ResolvePart1(new[] {
            "BFFFBBFRRR",
        });

        Assert.Equal("567", result);
    }

    [Fact]
    public void ResolvePart1__Example3()
    {
        var day = new Day05();

        string result = day.ResolvePart1(new[] {
            "FFFBBBFRRR",
        });

        Assert.Equal("119", result);
    }

    [Fact]
    public void ResolvePart1__Example4()
    {
        var day = new Day05();

        string result = day.ResolvePart1(new[] {
            "BBFFBBFRLL",
        });

        Assert.Equal("820", result);
    }
}