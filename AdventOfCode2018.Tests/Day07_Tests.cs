using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2018.Tests
{
    [TestClass()]
    public class Day07_Tests
    {
        [TestMethod()]
        public void ResolvePart1__Test()
        {
            Day07 day07 = new Day07();

            string result = day07.ResolvePart1(new string[] {
                "Step C must be finished before step A can begin.",
                "Step C must be finished before step F can begin.",
                "Step A must be finished before step B can begin.",
                "Step A must be finished before step D can begin.",
                "Step B must be finished before step E can begin.",
                "Step D must be finished before step E can begin.",
                "Step F must be finished before step E can begin.",
            });

            Assert.AreEqual("CABDFE", result);
        }

        [TestMethod()]
        public void ResolvePart2__Test()
        {
            Day07 day07 = new Day07 { BaseCost = 0, NumberOfWorkers = 2 };

            string result = day07.ResolvePart2(new string[] {
                "Step C must be finished before step A can begin.",
                "Step C must be finished before step F can begin.",
                "Step A must be finished before step B can begin.",
                "Step A must be finished before step D can begin.",
                "Step B must be finished before step E can begin.",
                "Step D must be finished before step E can begin.",
                "Step F must be finished before step E can begin.",
            });

            Assert.AreEqual("15", result);
        }
    }
}