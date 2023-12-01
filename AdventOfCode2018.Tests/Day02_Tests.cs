using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2018.Tests
{
    [TestClass]
    public class Day02_Tests
    {
        [TestMethod]
        public void ResolvePart1__Test1()
        {
            Day02 day02 = new Day02();

            string result = day02.ResolvePart1(new string[] {
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

        [TestMethod]
        public void ResolvePart2__Test()
        {
            Day02 day02 = new Day02();

            string result = day02.ResolvePart2(new string[] {
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