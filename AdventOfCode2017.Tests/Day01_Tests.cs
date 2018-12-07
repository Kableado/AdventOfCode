using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2017;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017.Tests
{
    [TestClass()]
    public class Day01_Tests
    {
        [TestMethod()]
        public void ResolvePart1__Test1()
        {
            Day01 day01 = new Day01();

            string result = day01.ResolvePart1(new string[] { "1122", });

            Assert.AreEqual("3", result);
        }

        [TestMethod()]
        public void ResolvePart1__Test2()
        {
            Day01 day01 = new Day01();

            string result = day01.ResolvePart1(new string[] { "1111", });

            Assert.AreEqual("4", result);
        }

        [TestMethod()]
        public void ResolvePart1__Test3()
        {
            Day01 day01 = new Day01();

            string result = day01.ResolvePart1(new string[] { "1234", });

            Assert.AreEqual("0", result);
        }

        [TestMethod()]
        public void ResolvePart1__Test4()
        {
            Day01 day01 = new Day01();

            string result = day01.ResolvePart1(new string[] { "91212129", });

            Assert.AreEqual("9", result);
        }
    }
}