using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2018.Tests
{
    [TestClass()]
    public class Day09_Tests
    {
        [TestMethod()]
        public void ResolvePart1__Test1()
        {
            Day09 day = new Day09();

            string result = day.ResolvePart1(new string[] { "9 players; last marble is worth 25 points" });

            Assert.AreEqual("32", result);
        }

        [TestMethod()]
        public void ResolvePart1__Test2()
        {
            Day09 day = new Day09();

            string result = day.ResolvePart1(new string[] { "10 players; last marble is worth 1618 points" });

            Assert.AreEqual("8317", result);
        }

        [TestMethod()]
        public void ResolvePart1__Test3()
        {
            Day09 day = new Day09();

            string result = day.ResolvePart1(new string[] { "13 players; last marble is worth 7999 points" });

            Assert.AreEqual("146373", result);
        }

        [TestMethod()]
        public void ResolvePart1__Test4()
        {
            Day09 day = new Day09();

            string result = day.ResolvePart1(new string[] { "17 players; last marble is worth 1104 points" });

            Assert.AreEqual("2764", result);
        }

        [TestMethod()]
        public void ResolvePart1__Test5()
        {
            Day09 day = new Day09();

            string result = day.ResolvePart1(new string[] { "21 players; last marble is worth 6111 points" });

            Assert.AreEqual("54718", result);
        }

        [TestMethod()]
        public void ResolvePart1__Test6()
        {
            Day09 day = new Day09();

            string result = day.ResolvePart1(new string[] { "30 players; last marble is worth 5807 points" });

            Assert.AreEqual("37305", result);
        }
    }
}