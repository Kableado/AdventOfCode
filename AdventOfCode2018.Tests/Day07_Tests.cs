namespace AdventOfCode2018.Tests;

public class Day07_Tests
{
    [Fact]
    public void ResolvePart1__Test()
    {
        Day07 day07 = new();

        string result = day07.ResolvePart1(new[] {
            "Step C must be finished before step A can begin.",
            "Step C must be finished before step F can begin.",
            "Step A must be finished before step B can begin.",
            "Step A must be finished before step D can begin.",
            "Step B must be finished before step E can begin.",
            "Step D must be finished before step E can begin.",
            "Step F must be finished before step E can begin.",
        });

        Assert.Equal("CABDFE", result);
    }

    [Fact]
    public void ResolvePart2__Test()
    {
        Day07 day07 = new() { BaseCost = 0, NumberOfWorkers = 2 };

        string result = day07.ResolvePart2(new[] {
            "Step C must be finished before step A can begin.",
            "Step C must be finished before step F can begin.",
            "Step A must be finished before step B can begin.",
            "Step A must be finished before step D can begin.",
            "Step B must be finished before step E can begin.",
            "Step D must be finished before step E can begin.",
            "Step F must be finished before step E can begin.",
        });

        Assert.Equal("15", result);
    }
}