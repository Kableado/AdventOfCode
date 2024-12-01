namespace AdventOfCode2018.Tests;

public class Day12_Tests
{
    [Fact]
    public void ResolvePart1__Test()
    {
        Day12 day = new();

        string result = day.ResolvePart1([
            "initial state: #..#.#..##......###...###",
            "",
            "...## => #",
            "..#.. => #",
            ".#... => #",
            ".#.#. => #",
            ".#.## => #",
            ".##.. => #",
            ".#### => #",
            "#.#.# => #",
            "#.### => #",
            "##.#. => #",
            "##.## => #",
            "###.. => #",
            "###.# => #",
            "####. => #",
        ]);

        Assert.Equal("325", result);
    }
}