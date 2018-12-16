using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2018.Tests
{
    [TestClass()]
    public class Day13_Tests
    {
        [TestMethod()]
        public void ResolvePart1__Test1()
        {
            Day13 day = new Day13();

            string result = day.ResolvePart1(new string[] {
                "|",
                "v",
                "|",
                "|",
                "|",
                "^",
                "|",
            });

            Assert.AreEqual("0,3", result);
        }

        [TestMethod()]
        public void ResolvePart1__Test2()
        {
            Day13 day = new Day13();

            string result = day.ResolvePart1(new string[] {
                @"/->-\        ",
                @"|   |  /----\",
                @"| /-+--+-\  |",
                @"| | |  | v  |",
                @"\-+-/  \-+--/",
                @"  \------/   ",
            });

            Assert.AreEqual("7,3", result);
        }

        [TestMethod()]
        public void ResolvePart2__Test()
        {
            Day13 day = new Day13();

            string result = day.ResolvePart2(new string[] {
                @"/>-<\  ",
                @"|   |  ",
                @"| /<+-\",
                @"| | | v",
                @"\>+</ |",
                @"  |   ^",
                @"  \<->/",
            });

            Assert.AreEqual("6,4", result);
        }
    }
}