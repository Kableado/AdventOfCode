using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2018.Tests
{
    [TestClass()]
    public class Day11_Tests
    {
        [TestMethod()]
        public void CalculatePowerLevelOfCell__Test1()
        {
            int powerLevel = Day11.CalculatePowerLevelOfCell(3, 5, 8);
            Assert.AreEqual(4, powerLevel);
        }

        [TestMethod()]
        public void CalculatePowerLevelOfRegion__Test1()
        {
            int powerLevel = Day11.CalculatePowerLevelOfRegion(33, 45, 3, 18);
            Assert.AreEqual(29, powerLevel);
        }

        [TestMethod()]
        public void CalculatePowerLevelOfRegion__Test2()
        {
            int powerLevel = Day11.CalculatePowerLevelOfRegion(21, 61, 3, 42);
            Assert.AreEqual(30, powerLevel);
        }

        [TestMethod()]
        public void CalculatePowerLevelOfRegion__Test1_WithSumationField()
        {
            int[,] summationFiled = Day11.GenerateSumationField(300, 300, 18);
            int powerLevel = Day11.CalculatePowerLevelOfRegion(33, 45, 3, summationFiled);
            Assert.AreEqual(29, powerLevel);
        }

        [TestMethod()]
        public void CalculatePowerLevelOfRegion__Test2_WithSumationField()
        {
            int[,] summationFiled = Day11.GenerateSumationField(300, 300, 42);
            int powerLevel = Day11.CalculatePowerLevelOfRegion(21, 61, 3, summationFiled);
            Assert.AreEqual(30, powerLevel);
        }

        [TestMethod()]
        public void SearchBestRegionOfOneSize__Test1()
        {
            Day11.SearchBestRegionOfOneSize(300, 300, 3, 18, out int x, out int y);
            Assert.AreEqual(33, x);
            Assert.AreEqual(45, y);
        }

        [TestMethod()]
        public void SearchBestRegionOfOneSize__Test2()
        {
            Day11.SearchBestRegionOfOneSize(300, 300, 3, 42, out int x, out int y);
            Assert.AreEqual(21, x);
            Assert.AreEqual(61, y);
        }

        [TestMethod()]
        public void ResolvePart2__Test1()
        {
            Day11 day = new Day11();
            string result = day.ResolvePart2(new string[] { "18" });
            Assert.AreEqual("90,269,16", result);
        }

        [TestMethod()]
        public void ResolvePart2__Test2()
        {
            Day11 day = new Day11();
            string result = day.ResolvePart2(new string[] { "42" });
            Assert.AreEqual("232,251,12", result);
        }
    }
}