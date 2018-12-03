using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2018.Tests
{
    [TestClass()]
    public class Day01_Tests
    {
        [TestMethod()]
        public void ResolveDay01__Test1()
        {
            Day01 day01 = new Day01();

            string result = day01.ResolveDay01(new string[] { "+1", "-2", "+3", "+1", });

            Assert.AreEqual("3", result);
        }

        [TestMethod()]
        public void ResolveDay01__Test2()
        {
            Day01 day01 = new Day01();

            string result = day01.ResolveDay01(new string[] { "+1", "+1", "+1", });

            Assert.AreEqual("3", result);
        }

        [TestMethod()]
        public void ResolveDay01__Test3()
        {
            Day01 day01 = new Day01();

            string result = day01.ResolveDay01(new string[] { "+1", "+1", "-2", });

            Assert.AreEqual("0", result);
        }

        [TestMethod()]
        public void ResolveDay01__Test4()
        {
            Day01 day01 = new Day01();

            string result = day01.ResolveDay01(new string[] { "-1", "-2", "-3", });

            Assert.AreEqual("-6", result);
        }
    }
}