namespace AdventOfCode2018.Tests;

public class Day04_Tests
{
    #region GuardEvent_FromString

    [Fact]
    public void GuardEvent_FromString__ShiftBegin()
    {
        Day04.GuardEvent guardEvent = Day04.GuardEvent.FromString("[1518-11-01 00:00] Guard #10 begins shift");

        Assert.Equal(10, guardEvent.ID);
        Assert.Equal(11, guardEvent.Date.Month);
        Assert.Equal(1, guardEvent.Date.Day);
        Assert.Equal(0, guardEvent.Date.Hour);
        Assert.Equal(0, guardEvent.Date.Minute);
        Assert.Equal(Day04.GuardEventType.ShiftBegin, guardEvent.Type);
    }

    [Fact]
    public void GuardEvent_FromString__FallSleep()
    {
        Day04.GuardEvent guardEvent = Day04.GuardEvent.FromString("[1518-11-02 00:40] falls asleep");

        Assert.Null(guardEvent.ID);
        Assert.Equal(11, guardEvent.Date.Month);
        Assert.Equal(2, guardEvent.Date.Day);
        Assert.Equal(0, guardEvent.Date.Hour);
        Assert.Equal(40, guardEvent.Date.Minute);
        Assert.Equal(Day04.GuardEventType.FallSleep, guardEvent.Type);
    }

    [Fact]
    public void GuardEvent_FromString__WakeUp()
    {
        Day04.GuardEvent guardEvent = Day04.GuardEvent.FromString("[1518-11-03 00:29] wakes up");

        Assert.Null(guardEvent.ID);
        Assert.Equal(11, guardEvent.Date.Month);
        Assert.Equal(3, guardEvent.Date.Day);
        Assert.Equal(0, guardEvent.Date.Hour);
        Assert.Equal(29, guardEvent.Date.Minute);
        Assert.Equal(Day04.GuardEventType.WakeUp, guardEvent.Type);
    }

    #endregion GuardEvent_FromString

    #region GuardEvent_FromStringArray

    [Fact]
    public void GuardEvent_FromStringArray__TestBase()
    {
        List<Day04.GuardEvent> guardEvents = Day04.GuardEvent.FromStringArray(new[] {
            "[1518-11-01 00:00] Guard #10 begins shift",
            "[1518-11-01 00:05] falls asleep",
            "[1518-11-01 00:25] wakes up",
            "[1518-11-01 00:30] falls asleep",
            "[1518-11-01 00:55] wakes up",
            "[1518-11-01 23:58] Guard #99 begins shift",
            "[1518-11-02 00:40] falls asleep",
            "[1518-11-02 00:50] wakes up",
        });

        Assert.Equal(10, guardEvents[0].ID);
        Assert.Equal(Day04.GuardEventType.ShiftBegin, guardEvents[0].Type);

        Assert.Equal(10, guardEvents[1].ID);
        Assert.Equal(Day04.GuardEventType.FallSleep, guardEvents[1].Type);

        Assert.Equal(10, guardEvents[2].ID);
        Assert.Equal(Day04.GuardEventType.WakeUp, guardEvents[2].Type);

        Assert.Equal(10, guardEvents[3].ID);
        Assert.Equal(Day04.GuardEventType.FallSleep, guardEvents[3].Type);

        Assert.Equal(10, guardEvents[4].ID);
        Assert.Equal(Day04.GuardEventType.WakeUp, guardEvents[4].Type);

        Assert.Equal(99, guardEvents[5].ID);
        Assert.Equal(Day04.GuardEventType.ShiftBegin, guardEvents[5].Type);

        Assert.Equal(99, guardEvents[6].ID);
        Assert.Equal(Day04.GuardEventType.FallSleep, guardEvents[6].Type);

        Assert.Equal(99, guardEvents[7].ID);
        Assert.Equal(Day04.GuardEventType.WakeUp, guardEvents[7].Type);
    }

    [Fact]
    public void GuardEvent_FromStringArray__TestBaseUnsorted()
    {
        List<Day04.GuardEvent> guardEvents = Day04.GuardEvent.FromStringArray(new[] {
            "[1518-11-01 00:00] Guard #10 begins shift",
            "[1518-11-01 23:58] Guard #99 begins shift",
            "[1518-11-01 00:30] falls asleep",
            "[1518-11-02 00:40] falls asleep",
            "[1518-11-01 00:05] falls asleep",
            "[1518-11-02 00:50] wakes up",
            "[1518-11-01 00:55] wakes up",
            "[1518-11-01 00:25] wakes up",
        });

        Assert.Equal(10, guardEvents[0].ID);
        Assert.Equal(Day04.GuardEventType.ShiftBegin, guardEvents[0].Type);

        Assert.Equal(10, guardEvents[1].ID);
        Assert.Equal(Day04.GuardEventType.FallSleep, guardEvents[1].Type);

        Assert.Equal(10, guardEvents[2].ID);
        Assert.Equal(Day04.GuardEventType.WakeUp, guardEvents[2].Type);

        Assert.Equal(10, guardEvents[3].ID);
        Assert.Equal(Day04.GuardEventType.FallSleep, guardEvents[3].Type);

        Assert.Equal(10, guardEvents[4].ID);
        Assert.Equal(Day04.GuardEventType.WakeUp, guardEvents[4].Type);

        Assert.Equal(99, guardEvents[5].ID);
        Assert.Equal(Day04.GuardEventType.ShiftBegin, guardEvents[5].Type);

        Assert.Equal(99, guardEvents[6].ID);
        Assert.Equal(Day04.GuardEventType.FallSleep, guardEvents[6].Type);

        Assert.Equal(99, guardEvents[7].ID);
        Assert.Equal(Day04.GuardEventType.WakeUp, guardEvents[7].Type);
    }

    #endregion GuardEvent_FromStringArray
    
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