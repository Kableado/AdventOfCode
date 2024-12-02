namespace AdventOfCode2020.Tests;

public class Day08_Tests
{
    [Fact]
    public void ResolvePart1__Example()
    {
        Day08 day = new();

        string result = day.ResolvePart1([
            "nop +0",
            "acc +1",
            "jmp +4",
            "acc +3",
            "jmp -3",
            "acc -99",
            "acc +1",
            "jmp -4",
            "acc +6",
        ]);

        Assert.Equal("5", result);
    }

    [Fact]
    public void ResolvePart2__Example()
    {
        Day08 day = new();

        string result = day.ResolvePart2([
            "nop +0",
            "acc +1",
            "jmp +4",
            "acc +3",
            "jmp -3",
            "acc -99",
            "acc +1",
            "jmp -4",
            "acc +6",
        ]);

        Assert.Equal("8", result);
    }
}