using Xunit;

namespace AdventOfCode2017.Tests
{
    public class Day01_Tests
    {
        #region ResolvePart1

        [Fact]
        public void ResolvePart1__Test1()
        {
            Day01 day01 = new Day01();

            string result = day01.ResolvePart1(new string[] { "1122", });

            Assert.Equal("3", result);
        }

        [Fact]
        public void ResolvePart1__Test2()
        {
            Day01 day01 = new Day01();

            string result = day01.ResolvePart1(new string[] { "1111", });

            Assert.Equal("4", result);
        }

        [Fact]
        public void ResolvePart1__Test3()
        {
            Day01 day01 = new Day01();

            string result = day01.ResolvePart1(new string[] { "1234", });

            Assert.Equal("0", result);
        }

        [Fact]
        public void ResolvePart1__Test4()
        {
            Day01 day01 = new Day01();

            string result = day01.ResolvePart1(new string[] { "91212129", });

            Assert.Equal("9", result);
        }

        #endregion ResolvePart1

        #region ResolvePart2
        
        [Fact]
        public void ResolvePart2__Test1()
        {
            Day01 day01 = new Day01();

            string result = day01.ResolvePart2(new string[] { "1212", });

            Assert.Equal("6", result);
        }

        [Fact]
        public void ResolvePart2__Test2()
        {
            Day01 day01 = new Day01();

            string result = day01.ResolvePart2(new string[] { "1221", });

            Assert.Equal("0", result);
        }

        [Fact]
        public void ResolvePart2__Test3()
        {
            Day01 day01 = new Day01();

            string result = day01.ResolvePart2(new string[] { "123425", });

            Assert.Equal("4", result);
        }

        [Fact]
        public void ResolvePart2__Test4()
        {
            Day01 day01 = new Day01();

            string result = day01.ResolvePart2(new string[] { "123123", });

            Assert.Equal("12", result);
        }

        [Fact]
        public void ResolvePart2__Test5()
        {
            Day01 day01 = new Day01();

            string result = day01.ResolvePart2(new string[] { "12131415", });

            Assert.Equal("4", result);
        }

        #endregion ResolvePart2
    }
}