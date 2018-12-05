using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2018.Tests
{
    [TestClass()]
    public class Day05_Tests
    {
        [TestMethod()]
        public void ResolvePart1__Test()
        {
            Day05 day05 = new Day05();

            string result = day05.ResolvePart1("dabAcCaCBAcCcaDA");

            Assert.AreEqual("10", result);
        }
    }
}