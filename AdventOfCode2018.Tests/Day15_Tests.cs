using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2018;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2018.Tests
{
    [TestClass()]
    public class Day15_Tests
    {
        #region ResolvePart1

        [TestMethod()]
        public void ResolvePart1__Test1()
        {
            Day15 day = new Day15();

            string result = day.ResolvePart1(new string[] {
                "#######",
                "#.G...#",
                "#...EG#",
                "#.#.#G#",
                "#..G#E#",
                "#.....#",
                "#######",
            });

            Assert.AreEqual("27730", result);
        }

        [TestMethod()]
        public void ResolvePart1__Test2()
        {
            Day15 day = new Day15();

            string result = day.ResolvePart1(new string[] {
                "#######",
                "#G..#E#",
                "#E#E.E#",
                "#G.##.#",
                "#...#E#",
                "#...E.#",
                "#######",
            });

            Assert.AreEqual("36334", result);
        }
        
        [TestMethod()]
        public void ResolvePart1__Test3()
        {
            Day15 day = new Day15();

            string result = day.ResolvePart1(new string[] {
                "#######",
                "#E..EG#",
                "#.#G.E#",
                "#E.##E#",
                "#G..#.#",
                "#..E#.#",
                "#######",
            });

            Assert.AreEqual("39514", result);
        }

        [TestMethod()]
        public void ResolvePart1__Test4()
        {
            Day15 day = new Day15();

            string result = day.ResolvePart1(new string[] {
                "#######",
                "#E.G#.#",
                "#.#G..#",
                "#G.#.G#",
                "#G..#.#",
                "#...E.#",
                "#######",
            });

            Assert.AreEqual("27755", result);
        }

        [TestMethod()]
        public void ResolvePart1__Test5()
        {
            Day15 day = new Day15();

            string result = day.ResolvePart1(new string[] {
                "#######",
                "#.E...#",
                "#.#..G#",
                "#.###.#",
                "#E#G#G#",
                "#...#G#",
                "#######",
            });

            Assert.AreEqual("28944", result);
        }

        [TestMethod()]
        public void ResolvePart1__Test6()
        {
            Day15 day = new Day15();

            string result = day.ResolvePart1(new string[] {
                "#########",
                "#G......#",
                "#.E.#...#",
                "#..##..G#",
                "#...##..#",
                "#...#...#",
                "#.G...G.#",
                "#.....G.#",
                "#########",
            });

            Assert.AreEqual("18740", result);
        }

        #endregion ResolvePart1

        #region ResolvePart2

        [TestMethod()]
        public void ResolvePart2__Test1()
        {
            Day15 day = new Day15();

            string result = day.ResolvePart2(new string[] {
                "#######",
                "#.G...#",
                "#...EG#",
                "#.#.#G#",
                "#..G#E#",
                "#.....#",
                "#######",
            });

            Assert.AreEqual("4988", result);
        }
        
        [TestMethod()]
        public void ResolvePart2__Test3()
        {
            Day15 day = new Day15();

            string result = day.ResolvePart2(new string[] {
                "#######",
                "#E..EG#",
                "#.#G.E#",
                "#E.##E#",
                "#G..#.#",
                "#..E#.#",
                "#######",
            });

            Assert.AreEqual("31284", result);
        }

        [TestMethod()]
        public void ResolvePart2__Test4()
        {
            Day15 day = new Day15();

            string result = day.ResolvePart2(new string[] {
                "#######",
                "#E.G#.#",
                "#.#G..#",
                "#G.#.G#",
                "#G..#.#",
                "#...E.#",
                "#######",
            });

            Assert.AreEqual("3478", result);
        }

        [TestMethod()]
        public void ResolvePart2__Test5()
        {
            Day15 day = new Day15();

            string result = day.ResolvePart2(new string[] {
                "#######",
                "#.E...#",
                "#.#..G#",
                "#.###.#",
                "#E#G#G#",
                "#...#G#",
                "#######",
            });

            Assert.AreEqual("6474", result);
        }

        [TestMethod()]
        public void ResolvePart2__Test6()
        {
            Day15 day = new Day15();

            string result = day.ResolvePart2(new string[] {
                "#########",
                "#G......#",
                "#.E.#...#",
                "#..##..G#",
                "#...##..#",
                "#...#...#",
                "#.G...G.#",
                "#.....G.#",
                "#########",
            });

            Assert.AreEqual("1140", result);
        }

        #endregion ResolvePart2
    }
}