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

        #region ReducePolymer

        [TestMethod()]
        public void ReducePolymer__Remove_cC()
        {
            Day05 day05 = new Day05();

            string result = day05.ReducePolymer("dabAcCaCBA");

            Assert.AreEqual("dabAaCBA", result);
        }

        [TestMethod()]
        public void ReducePolymer__Remove_cC_AtEnd()
        {
            Day05 day05 = new Day05();

            string result = day05.ReducePolymer("dabAcC");

            Assert.AreEqual("dabA", result);
        }

        [TestMethod()]
        public void ReducePolymer__Remove_Only_cC()
        {
            Day05 day05 = new Day05();

            string result = day05.ReducePolymer("cC");

            Assert.AreEqual("", result);
        }

        [TestMethod()]
        public void ReducePolymer__Remove_cC_AtStart()
        {
            Day05 day05 = new Day05();

            string result = day05.ReducePolymer("cCAAAA");

            Assert.AreEqual("AAAA", result);
        }

        [TestMethod()]
        public void ReducePolymer__Remove_Aa()
        {
            Day05 day05 = new Day05();

            string result = day05.ReducePolymer("dabAaCBA");

            Assert.AreEqual("dabCBA", result);
        }

        [TestMethod()]
        public void ReducePolymer__Remove_cCc()
        {
            Day05 day05 = new Day05();

            string result = day05.ReducePolymer("dabCBAcCcaDA");

            Assert.AreEqual("dabCBAcaDA", result);
        }

        [TestMethod()]
        public void ReducePolymer__Irreductible()
        {
            Day05 day05 = new Day05();

            string result = day05.ReducePolymer("dabCBAcaDA");

            Assert.AreEqual("dabCBAcaDA", result);
        }

        #endregion ReducePolymer

        #region FullyReducePolymer

        [TestMethod()]
        public void FullyReducePolymer__Test()
        {
            Day05 day05 = new Day05();

            string result = day05.FullyReducePolymer("dabAcCaCBAcCcaDA");

            Assert.AreEqual("dabCBAcaDA", result);
        }

        #endregion FullyReducePolymer
    }
}