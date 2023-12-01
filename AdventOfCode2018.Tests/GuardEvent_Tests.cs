using System.Collections.Generic;
using Xunit;

namespace AdventOfCode2018.Tests
{
    public class GuardEvent_Tests
    {
        #region FromString

        [Fact]
        public void FromString__ShiftBegin()
        {
            GuardEvent guardEvent = GuardEvent.FromString("[1518-11-01 00:00] Guard #10 begins shift");

            Assert.Equal(10, guardEvent.ID);
            Assert.Equal(11, guardEvent.Date.Month);
            Assert.Equal(1, guardEvent.Date.Day);
            Assert.Equal(0, guardEvent.Date.Hour);
            Assert.Equal(0, guardEvent.Date.Minute);
            Assert.Equal(GuardEventType.ShiftBegin, guardEvent.Type);
        }

        [Fact]
        public void FromString__FallSleep()
        {
            GuardEvent guardEvent = GuardEvent.FromString("[1518-11-02 00:40] falls asleep");

            Assert.Equal(null, guardEvent.ID);
            Assert.Equal(11, guardEvent.Date.Month);
            Assert.Equal(2, guardEvent.Date.Day);
            Assert.Equal(0, guardEvent.Date.Hour);
            Assert.Equal(40, guardEvent.Date.Minute);
            Assert.Equal(GuardEventType.FallSleep, guardEvent.Type);
        }

        [Fact]
        public void FromString__WakeUp()
        {
            GuardEvent guardEvent = GuardEvent.FromString("[1518-11-03 00:29] wakes up");

            Assert.Equal(null, guardEvent.ID);
            Assert.Equal(11, guardEvent.Date.Month);
            Assert.Equal(3, guardEvent.Date.Day);
            Assert.Equal(0, guardEvent.Date.Hour);
            Assert.Equal(29, guardEvent.Date.Minute);
            Assert.Equal(GuardEventType.WakeUp, guardEvent.Type);
        }

        #endregion FromString

        #region FromStringArray

        [Fact]
        public void FromStringArray__TestBase()
        {
            List<GuardEvent> guardEvents = GuardEvent.FromStringArray(new string[] {
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
            Assert.Equal(GuardEventType.ShiftBegin, guardEvents[0].Type);

            Assert.Equal(10, guardEvents[1].ID);
            Assert.Equal(GuardEventType.FallSleep, guardEvents[1].Type);

            Assert.Equal(10, guardEvents[2].ID);
            Assert.Equal(GuardEventType.WakeUp, guardEvents[2].Type);

            Assert.Equal(10, guardEvents[3].ID);
            Assert.Equal(GuardEventType.FallSleep, guardEvents[3].Type);

            Assert.Equal(10, guardEvents[4].ID);
            Assert.Equal(GuardEventType.WakeUp, guardEvents[4].Type);

            Assert.Equal(99, guardEvents[5].ID);
            Assert.Equal(GuardEventType.ShiftBegin, guardEvents[5].Type);

            Assert.Equal(99, guardEvents[6].ID);
            Assert.Equal(GuardEventType.FallSleep, guardEvents[6].Type);

            Assert.Equal(99, guardEvents[7].ID);
            Assert.Equal(GuardEventType.WakeUp, guardEvents[7].Type);
        }

        [Fact]
        public void FromStringArray__TestBaseUnsorted()
        {
            List<GuardEvent> guardEvents = GuardEvent.FromStringArray(new string[] {
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
            Assert.Equal(GuardEventType.ShiftBegin, guardEvents[0].Type);

            Assert.Equal(10, guardEvents[1].ID);
            Assert.Equal(GuardEventType.FallSleep, guardEvents[1].Type);

            Assert.Equal(10, guardEvents[2].ID);
            Assert.Equal(GuardEventType.WakeUp, guardEvents[2].Type);

            Assert.Equal(10, guardEvents[3].ID);
            Assert.Equal(GuardEventType.FallSleep, guardEvents[3].Type);

            Assert.Equal(10, guardEvents[4].ID);
            Assert.Equal(GuardEventType.WakeUp, guardEvents[4].Type);

            Assert.Equal(99, guardEvents[5].ID);
            Assert.Equal(GuardEventType.ShiftBegin, guardEvents[5].Type);

            Assert.Equal(99, guardEvents[6].ID);
            Assert.Equal(GuardEventType.FallSleep, guardEvents[6].Type);

            Assert.Equal(99, guardEvents[7].ID);
            Assert.Equal(GuardEventType.WakeUp, guardEvents[7].Type);
        }

        #endregion FromStringArray
    }
}