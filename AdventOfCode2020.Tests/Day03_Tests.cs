namespace AdventOfCode2020.Tests;

public class Day03_Tests
{
    [Fact]
    public void ResolvePart1__Example()
    {
        Day03 day = new();

        string result = day.ResolvePart1([
            "..##.......",
            "#...#...#..",
            ".#....#..#.",
            "..#.#...#.#",
            ".#...##..#.",
            "..#.##.....",
            ".#.#.#....#",
            ".#........#",
            "#.##...#...",
            "#...##....#",
            ".#..#...#.#",
        ]);

        Assert.Equal("7", result);
    }

    [Fact]
    public void ResolvePart2__Example()
    {
        Day03 day = new();

        string result = day.ResolvePart2([
            "..##.......",
            "#...#...#..",
            ".#....#..#.",
            "..#.#...#.#",
            ".#...##..#.",
            "..#.##.....",
            ".#.#.#....#",
            ".#........#",
            "#.##...#...",
            "#...##....#",
            ".#..#...#.#",
        ]);

        Assert.Equal("336", result);
    }
}