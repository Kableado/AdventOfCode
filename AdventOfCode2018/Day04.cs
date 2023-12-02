using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2018;

/*
--- Day 4: Repose Record ---

You've sneaked into another supply closet - this time, it's across from the prototype suit manufacturing lab. You need to sneak inside and fix the issues with the suit, but there's a guard stationed outside the lab, so this is as close as you can safely get.

As you search the closet for anything that might help, you discover that you're not the first person to want to sneak in. Covering the walls, someone has spent an hour starting every midnight for the past few months secretly observing this guard post! They've been writing down the ID of the one guard on duty that night - the Elves seem to have decided that one guard was enough for the overnight shift - as well as when they fall asleep or wake up while at their post (your puzzle input).

For example, consider the following records, which have already been organized into chronological order:

[1518-11-01 00:00] Guard #10 begins shift
[1518-11-01 00:05] falls asleep
[1518-11-01 00:25] wakes up
[1518-11-01 00:30] falls asleep
[1518-11-01 00:55] wakes up
[1518-11-01 23:58] Guard #99 begins shift
[1518-11-02 00:40] falls asleep
[1518-11-02 00:50] wakes up
[1518-11-03 00:05] Guard #10 begins shift
[1518-11-03 00:24] falls asleep
[1518-11-03 00:29] wakes up
[1518-11-04 00:02] Guard #99 begins shift
[1518-11-04 00:36] falls asleep
[1518-11-04 00:46] wakes up
[1518-11-05 00:03] Guard #99 begins shift
[1518-11-05 00:45] falls asleep
[1518-11-05 00:55] wakes up

Timestamps are written using year-month-day hour:minute format. The guard falling asleep or waking up is always the one whose shift most recently started. Because all asleep/awake times are during the midnight hour (00:00 - 00:59), only the minute portion (00 - 59) is relevant for those events.

Visually, these records show that the guards are asleep at these times:

Date   ID   Minute
            000000000011111111112222222222333333333344444444445555555555
            012345678901234567890123456789012345678901234567890123456789
11-01  #10  .....####################.....#########################.....
11-02  #99  ........................................##########..........
11-03  #10  ........................#####...............................
11-04  #99  ....................................##########..............
11-05  #99  .............................................##########.....

The columns are Date, which shows the month-day portion of the relevant day; ID, which shows the guard on duty that day; and Minute, which shows the minutes during which the guard was asleep within the midnight hour. (The Minute column's header shows the minute's ten's digit in the first row and the one's digit in the second row.) Awake is shown as ., and asleep is shown as #.

Note that guards count as asleep on the minute they fall asleep, and they count as awake on the minute they wake up. For example, because Guard #10 wakes up at 00:25 on 1518-11-01, minute 25 is marked as awake.

If you can figure out the guard most likely to be asleep at a specific time, you might be able to trick that guard into working tonight so you can have the best chance of sneaking in. You have two strategies for choosing the best guard/minute combination.

Strategy 1: Find the guard that has the most minutes asleep. What minute does that guard spend asleep the most?

In the example above, Guard #10 spent the most minutes asleep, a total of 50 minutes (20+25+5), while Guard #99 only slept for a total of 30 minutes (10+10+10). Guard #10 was asleep most during minute 24 (on two days, whereas any other minute the guard was asleep was only seen on one day).

While this example listed the entries in chronological order, your entries are in the order you found them. You'll need to organize them before they can be analyzed.

What is the ID of the guard you chose multiplied by the minute you chose? (In the above example, the answer would be 10 * 24 = 240.)

--- Part Two ---

Strategy 2: Of all guards, which guard is most frequently asleep on the same minute?

In the example above, Guard #99 spent minute 45 asleep more than any other guard or minute - three times in total. (In all other cases, any guard spent any minute asleep at most twice.)

What is the ID of the guard you chose multiplied by the minute you chose? (In the above example, the answer would be 99 * 45 = 4455.)

*/
public class Day04 : IDay
{
    public string ResolvePart1(string[] inputs)
    {
        List<GuardEvent> guardEvents = GuardEvent.FromStringArray(inputs);
        Dictionary<int, GuardSleepHistogram> dictFullHistogram = BuildFullHistorgram(guardEvents);

        // Find sleepier guard
        GuardSleepHistogram highestSleeperHistogram = null;
        long highestTotalSleep = long.MinValue;
        foreach (GuardSleepHistogram guardHistogram in dictFullHistogram.Values)
        {
            int totalSleep = guardHistogram.SleepOnMunute.Sum();

            if (totalSleep > highestTotalSleep)
            {
                highestSleeperHistogram = guardHistogram;
                highestTotalSleep = totalSleep;
            }
        }

        // Find sleepier minute
        int maxSleepMinute = int.MinValue;
        int maxSleepMinuteValue = int.MinValue;
        for (int i = 0; i < GuardSleepHistogram.MinutesOnHour; i++)
        {
            if (highestSleeperHistogram.SleepOnMunute[i] > maxSleepMinuteValue)
            {
                maxSleepMinute = i;
                maxSleepMinuteValue = highestSleeperHistogram.SleepOnMunute[i];
            }
        }

        int result = highestSleeperHistogram.ID * maxSleepMinute;
        return result.ToString();
    }

    public string ResolvePart2(string[] inputs)
    {
        List<GuardEvent> guardEvents = GuardEvent.FromStringArray(inputs);
        Dictionary<int, GuardSleepHistogram> dictFullHistogram = BuildFullHistorgram(guardEvents);

        int selectedGuardID = int.MinValue;
        int selectedMinute = int.MinValue;
        int maxSleepMinuteValue = int.MinValue;
        for (int i = 0; i < GuardSleepHistogram.MinutesOnHour; i++)
        {
            foreach (GuardSleepHistogram guardHistogram in dictFullHistogram.Values)
            {
                if (guardHistogram.SleepOnMunute[i] > maxSleepMinuteValue)
                {
                    maxSleepMinuteValue = guardHistogram.SleepOnMunute[i];
                    selectedGuardID = guardHistogram.ID;
                    selectedMinute = i;
                }
            }
        }

        int result = selectedGuardID * selectedMinute;
        return result.ToString();
    }

    private static Dictionary<int, GuardSleepHistogram> BuildFullHistorgram(List<GuardEvent> guardEvents)
    {
        Dictionary<int, GuardSleepHistogram> dictFullHistogram = new();
        foreach (IGrouping<int, GuardEvent> group in guardEvents.GroupBy(guardEvent => guardEvent.Date.DayOfYear))
        {
            Dictionary<int, GuardSleepHistogram> dictDayHistogram = new();
            foreach (GuardEvent guardEvent in group)
            {
                if (guardEvent.ID == null) { continue; }
                GuardSleepHistogram dayGuardHistogram;
                if (dictDayHistogram.ContainsKey((int)guardEvent.ID))
                {
                    dayGuardHistogram = dictDayHistogram[(int)guardEvent.ID];
                }
                else
                {
                    dayGuardHistogram = new GuardSleepHistogram { ID = (int)guardEvent.ID };
                    dictDayHistogram.Add(dayGuardHistogram.ID, dayGuardHistogram);
                }
                if (guardEvent.Type == GuardEventType.FallSleep)
                {
                    dayGuardHistogram.FallSleep(guardEvent.Date.Minute);
                }
                if (guardEvent.Type == GuardEventType.WakeUp)
                {
                    dayGuardHistogram.WakeUp(guardEvent.Date.Minute);
                }
            }

            foreach (GuardSleepHistogram dayGuardHistogram in dictDayHistogram.Values)
            {
                GuardSleepHistogram guardHistogram;
                if (dictFullHistogram.ContainsKey(dayGuardHistogram.ID))
                {
                    guardHistogram = dictFullHistogram[dayGuardHistogram.ID];
                    guardHistogram.AddHistogram(dayGuardHistogram);
                }
                else
                {
                    dictFullHistogram.Add(dayGuardHistogram.ID, dayGuardHistogram);
                }
            }
        }

        return dictFullHistogram;
    }
}

public enum GuardEventType
{
    ShiftBegin,
    FallSleep,
    WakeUp,
}

public class GuardEvent
{
    public DateTime Date { get; set; }
    public int? ID { get; set; }
    public GuardEventType Type { get; set; }

    public static GuardEvent FromString(string strEvent)
    {
        GuardEvent guardEvent = new();
        string[] parts = strEvent.Split(new[] { "[", "-", " ", ":", "]", "#", }, StringSplitOptions.RemoveEmptyEntries);
        guardEvent.Date = new DateTime(
            Convert.ToInt32(parts[0]),
            Convert.ToInt32(parts[1]),
            Convert.ToInt32(parts[2]),
            Convert.ToInt32(parts[3]),
            Convert.ToInt32(parts[4]),
            0
        );
        if (parts[5] == "Guard")
        {
            guardEvent.ID = Convert.ToInt32(parts[6]);
            guardEvent.Type = GuardEventType.ShiftBegin;
        }
        if (parts[5] == "falls")
        {
            guardEvent.Type = GuardEventType.FallSleep;
        }
        if (parts[5] == "wakes")
        {
            guardEvent.Type = GuardEventType.WakeUp;
        }
        return guardEvent;
    }

    public static List<GuardEvent> FromStringArray(string[] strEvents)
    {
        List<GuardEvent> guardEvents = strEvents
            .Select(strEvent => FromString(strEvent))
            .OrderBy(guardEvent => guardEvent.Date)
            .ToList();

        int? guardID = null;
        foreach (GuardEvent guardEvent in guardEvents)
        {
            if (guardEvent.Type == GuardEventType.ShiftBegin)
            {
                guardID = guardEvent.ID;
            }
            else
            {
                guardEvent.ID = guardID;
            }
        }

        return guardEvents;
    }
}

public class GuardSleepHistogram
{
    public const int MinutesOnHour = 60;
    public int ID { get; set; }
    public int[] SleepOnMunute { get; } = new int[MinutesOnHour];

    public void FallSleep(int minute)
    {
        for (int i = minute; i < MinutesOnHour; i++)
        {
            SleepOnMunute[i] = 1;
        }
    }

    public void WakeUp(int minute)
    {
        for (int i = minute; i < MinutesOnHour; i++)
        {
            SleepOnMunute[i] = 0;
        }
    }

    public void AddHistogram(GuardSleepHistogram histogram)
    {
        for (int i = 0; i < MinutesOnHour; i++)
        {
            SleepOnMunute[i] += histogram.SleepOnMunute[i];
        }
    }
}