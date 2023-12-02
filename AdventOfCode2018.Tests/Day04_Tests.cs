namespace AdventOfCode2018.Tests;

public class Day04_Tests
{
    [Fact]
    public void ResolvePart1__BaseStatement()
    {
        Day04 day04 = new();

        string result = day04.ResolvePart1(new[] {
            "[1518-11-01 00:00] Guard #10 begins shift",
            "[1518-11-01 00:05] falls asleep",
            "[1518-11-01 00:25] wakes up",
            "[1518-11-01 00:30] falls asleep",
            "[1518-11-01 00:55] wakes up",
            "[1518-11-01 23:58] Guard #99 begins shift",
            "[1518-11-02 00:40] falls asleep",
            "[1518-11-02 00:50] wakes up",
            "[1518-11-03 00:05] Guard #10 begins shift",
            "[1518-11-03 00:24] falls asleep",
            "[1518-11-03 00:29] wakes up",
            "[1518-11-04 00:02] Guard #99 begins shift",
            "[1518-11-04 00:36] falls asleep",
            "[1518-11-04 00:46] wakes up",
            "[1518-11-05 00:03] Guard #99 begins shift",
            "[1518-11-05 00:45] falls asleep",
            "[1518-11-05 00:55] wakes up",
        });

        Assert.Equal("240", result);
    }

    [Fact]
    public void ResolvePart1__BaseStatementUnsorted()
    {
        Day04 day04 = new();

        string result = day04.ResolvePart1(new[] {
            "[1518-11-04 00:36] falls asleep",
            "[1518-11-04 00:46] wakes up",
            "[1518-11-05 00:03] Guard #99 begins shift",
            "[1518-11-01 00:05] falls asleep",
            "[1518-11-01 00:25] wakes up",
            "[1518-11-02 00:40] falls asleep",
            "[1518-11-01 00:30] falls asleep",
            "[1518-11-03 00:29] wakes up",
            "[1518-11-02 00:50] wakes up",
            "[1518-11-03 00:05] Guard #10 begins shift",
            "[1518-11-03 00:24] falls asleep",
            "[1518-11-01 00:00] Guard #10 begins shift",
            "[1518-11-04 00:02] Guard #99 begins shift",
            "[1518-11-05 00:45] falls asleep",
            "[1518-11-01 00:55] wakes up",
            "[1518-11-01 23:58] Guard #99 begins shift",
            "[1518-11-05 00:55] wakes up",
        });

        Assert.Equal("240", result);
    }


    [Fact]
    public void ResolvePart2__BaseStatement()
    {
        Day04 day04 = new();

        string result = day04.ResolvePart2(new[] {
            "[1518-11-01 00:00] Guard #10 begins shift",
            "[1518-11-01 00:05] falls asleep",
            "[1518-11-01 00:25] wakes up",
            "[1518-11-01 00:30] falls asleep",
            "[1518-11-01 00:55] wakes up",
            "[1518-11-01 23:58] Guard #99 begins shift",
            "[1518-11-02 00:40] falls asleep",
            "[1518-11-02 00:50] wakes up",
            "[1518-11-03 00:05] Guard #10 begins shift",
            "[1518-11-03 00:24] falls asleep",
            "[1518-11-03 00:29] wakes up",
            "[1518-11-04 00:02] Guard #99 begins shift",
            "[1518-11-04 00:36] falls asleep",
            "[1518-11-04 00:46] wakes up",
            "[1518-11-05 00:03] Guard #99 begins shift",
            "[1518-11-05 00:45] falls asleep",
            "[1518-11-05 00:55] wakes up",
        });

        Assert.Equal("4455", result);
    }

    [Fact]
    public void ResolvePart2__BaseStatementUnsorted()
    {
        Day04 day04 = new();

        string result = day04.ResolvePart2(new[] {
            "[1518-11-04 00:36] falls asleep",
            "[1518-11-04 00:46] wakes up",
            "[1518-11-05 00:03] Guard #99 begins shift",
            "[1518-11-01 00:05] falls asleep",
            "[1518-11-01 00:25] wakes up",
            "[1518-11-02 00:40] falls asleep",
            "[1518-11-01 00:30] falls asleep",
            "[1518-11-03 00:29] wakes up",
            "[1518-11-02 00:50] wakes up",
            "[1518-11-03 00:05] Guard #10 begins shift",
            "[1518-11-03 00:24] falls asleep",
            "[1518-11-01 00:00] Guard #10 begins shift",
            "[1518-11-04 00:02] Guard #99 begins shift",
            "[1518-11-05 00:45] falls asleep",
            "[1518-11-01 00:55] wakes up",
            "[1518-11-01 23:58] Guard #99 begins shift",
            "[1518-11-05 00:55] wakes up",
        });

        Assert.Equal("4455", result);
    }
}