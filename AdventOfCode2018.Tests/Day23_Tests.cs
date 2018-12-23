using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2018.Tests
{
    [TestClass()]
    public class Day23_Tests
    {
        [TestMethod()]
        public void ResolvePart1__Test()
        {
            Day23 day = new Day23();

            string result = day.ResolvePart1(new string[] {
                "pos=<0,0,0>, r=4",
                "pos=<1,0,0>, r=1",
                "pos=<4,0,0>, r=3",
                "pos=<0,2,0>, r=1",
                "pos=<0,5,0>, r=3",
                "pos=<0,0,3>, r=1",
                "pos=<1,1,1>, r=1",
                "pos=<1,1,2>, r=1",
                "pos=<1,3,1>, r=1",
            });

            Assert.AreEqual("7", result);
        }
    }
}