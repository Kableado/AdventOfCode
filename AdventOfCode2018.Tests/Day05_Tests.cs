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

        [TestMethod()]
        public void ResolvePart2__Test()
        {
            Day05 day05 = new Day05();

            string result = day05.ResolvePart2("dabAcCaCBAcCcaDA");

            Assert.AreEqual("4", result);
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

        #region RemoveUnitTypeFromPolymer

        [TestMethod()]
        public void RemoveUnitTypeFromPolymer__Remove_a()
        {
            Day05 day05 = new Day05();

            string result = day05.RemoveUnitTypeFromPolymer("dabAcCaCBAcCcaDA", 'a');

            Assert.AreEqual("dbcCCBcCcD", result);
        }

        [TestMethod()]
        public void RemoveUnitTypeFromPolymer__Remove_b()
        {
            Day05 day05 = new Day05();

            string result = day05.RemoveUnitTypeFromPolymer("dabAcCaCBAcCcaDA", 'b');

            Assert.AreEqual("daAcCaCAcCcaDA", result);
        }

        [TestMethod()]
        public void RemoveUnitTypeFromPolymer__Remove_c()
        {
            Day05 day05 = new Day05();

            string result = day05.RemoveUnitTypeFromPolymer("dabAcCaCBAcCcaDA", 'c');

            Assert.AreEqual("dabAaBAaDA", result);
        }

        [TestMethod()]
        public void RemoveUnitTypeFromPolymer__Remove_d()
        {
            Day05 day05 = new Day05();

            string result = day05.RemoveUnitTypeFromPolymer("dabAcCaCBAcCcaDA", 'd');

            Assert.AreEqual("abAcCaCBAcCcaA", result);
        }

        [TestMethod()]
        public void RemoveUnitTypeFromPolymer__Remove_A()
        {
            Day05 day05 = new Day05();

            string result = day05.RemoveUnitTypeFromPolymer("dabAcCaCBAcCcaDA", 'A');

            Assert.AreEqual("dbcCCBcCcD", result);
        }

        [TestMethod()]
        public void RemoveUnitTypeFromPolymer__Remove_B()
        {
            Day05 day05 = new Day05();

            string result = day05.RemoveUnitTypeFromPolymer("dabAcCaCBAcCcaDA", 'B');

            Assert.AreEqual("daAcCaCAcCcaDA", result);
        }

        [TestMethod()]
        public void RemoveUnitTypeFromPolymer__Remove_C()
        {
            Day05 day05 = new Day05();

            string result = day05.RemoveUnitTypeFromPolymer("dabAcCaCBAcCcaDA", 'C');

            Assert.AreEqual("dabAaBAaDA", result);
        }

        [TestMethod()]
        public void RemoveUnitTypeFromPolymer__Remove_D()
        {
            Day05 day05 = new Day05();

            string result = day05.RemoveUnitTypeFromPolymer("dabAcCaCBAcCcaDA", 'D');

            Assert.AreEqual("abAcCaCBAcCcaA", result);
        }

        #endregion RemoveUnitTypeFromPolymer
    }
}