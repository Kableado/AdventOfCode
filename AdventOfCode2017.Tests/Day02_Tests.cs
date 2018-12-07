using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Tests
{
    [TestClass()]
    public class Day02_Tests
    {
        [TestMethod()]
        public void ResolvePart1__Test()
        {
            Day02 day02 = new Day02();

            string result = day02.ResolvePart1(new string[] {
                "5 1 9 5",
                "7 5 3",
                "2 4 6 8",
            });

            Assert.AreEqual("18", result);
        }
    }
}