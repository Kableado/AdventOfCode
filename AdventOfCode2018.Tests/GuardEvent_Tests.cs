using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2018.Tests
{
    [TestClass]
    public class GuardEvent_Tests
    {
        #region FromString

        [TestMethod]
        public void FromString__ShiftBegin()
        {
            GuardEvent guardEvent = GuardEvent.FromString("[1518-11-01 00:00] Guard #10 begins shift");

            Assert.AreEqual(10, guardEvent.ID);
            Assert.AreEqual(11, guardEvent.Date.Month);
            Assert.AreEqual(1, guardEvent.Date.Day);
            Assert.AreEqual(0, guardEvent.Date.Hour);
            Assert.AreEqual(0, guardEvent.Date.Minute);
            Assert.AreEqual(GuardEventType.ShiftBegin, guardEvent.Type);
        }

        [TestMethod]
        public void FromString__FallSleep()
        {
            GuardEvent guardEvent = GuardEvent.FromString("[1518-11-02 00:40] falls asleep");

            Assert.AreEqual(null, guardEvent.ID);
            Assert.AreEqual(11, guardEvent.Date.Month);
            Assert.AreEqual(2, guardEvent.Date.Day);
            Assert.AreEqual(0, guardEvent.Date.Hour);
            Assert.AreEqual(40, guardEvent.Date.Minute);
            Assert.AreEqual(GuardEventType.FallSleep, guardEvent.Type);
        }

        [TestMethod]
        public void FromString__WakeUp()
        {
            GuardEvent guardEvent = GuardEvent.FromString("[1518-11-03 00:29] wakes up");

            Assert.AreEqual(null, guardEvent.ID);
            Assert.AreEqual(11, guardEvent.Date.Month);
            Assert.AreEqual(3, guardEvent.Date.Day);
            Assert.AreEqual(0, guardEvent.Date.Hour);
            Assert.AreEqual(29, guardEvent.Date.Minute);
            Assert.AreEqual(GuardEventType.WakeUp, guardEvent.Type);
        }

        #endregion FromString

        #region FromStringArray

        [TestMethod]
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

            Assert.AreEqual(10, guardEvents[0].ID);
            Assert.AreEqual(GuardEventType.ShiftBegin, guardEvents[0].Type);

            Assert.AreEqual(10, guardEvents[1].ID);
            Assert.AreEqual(GuardEventType.FallSleep, guardEvents[1].Type);

            Assert.AreEqual(10, guardEvents[2].ID);
            Assert.AreEqual(GuardEventType.WakeUp, guardEvents[2].Type);

            Assert.AreEqual(10, guardEvents[3].ID);
            Assert.AreEqual(GuardEventType.FallSleep, guardEvents[3].Type);

            Assert.AreEqual(10, guardEvents[4].ID);
            Assert.AreEqual(GuardEventType.WakeUp, guardEvents[4].Type);

            Assert.AreEqual(99, guardEvents[5].ID);
            Assert.AreEqual(GuardEventType.ShiftBegin, guardEvents[5].Type);

            Assert.AreEqual(99, guardEvents[6].ID);
            Assert.AreEqual(GuardEventType.FallSleep, guardEvents[6].Type);

            Assert.AreEqual(99, guardEvents[7].ID);
            Assert.AreEqual(GuardEventType.WakeUp, guardEvents[7].Type);
        }

        [TestMethod]
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

            Assert.AreEqual(10, guardEvents[0].ID);
            Assert.AreEqual(GuardEventType.ShiftBegin, guardEvents[0].Type);

            Assert.AreEqual(10, guardEvents[1].ID);
            Assert.AreEqual(GuardEventType.FallSleep, guardEvents[1].Type);

            Assert.AreEqual(10, guardEvents[2].ID);
            Assert.AreEqual(GuardEventType.WakeUp, guardEvents[2].Type);

            Assert.AreEqual(10, guardEvents[3].ID);
            Assert.AreEqual(GuardEventType.FallSleep, guardEvents[3].Type);

            Assert.AreEqual(10, guardEvents[4].ID);
            Assert.AreEqual(GuardEventType.WakeUp, guardEvents[4].Type);

            Assert.AreEqual(99, guardEvents[5].ID);
            Assert.AreEqual(GuardEventType.ShiftBegin, guardEvents[5].Type);

            Assert.AreEqual(99, guardEvents[6].ID);
            Assert.AreEqual(GuardEventType.FallSleep, guardEvents[6].Type);

            Assert.AreEqual(99, guardEvents[7].ID);
            Assert.AreEqual(GuardEventType.WakeUp, guardEvents[7].Type);
        }

        #endregion FromStringArray
    }
}