using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2018.Tests
{
    [TestClass()]
    public class Day02_Tests
    {
        [TestMethod()]
        public void ResolveDay02__Test1()
        {
            Day02 day02 = new Day02();

            string result = day02.ResolveDay02(new string[] {
                "abcdef",
                "bababc",
                "abbcde",
                "abcccd",
                "aabcdd",
                "abcdee",
                "ababab",
            });

            Assert.AreEqual("12", result);
        }

        [TestMethod()]
        public void ResolveDay02_Part2__Test()
        {
            Day02 day02 = new Day02();

            string result = day02.ResolveDay02_Part2(new string[] {
                "abcde",
                "fghij",
                "klmno",
                "pqrst",
                "fguij",
                "axcye",
                "wvxyz",
            });

            Assert.AreEqual("fgij", result);
        }
    }
}