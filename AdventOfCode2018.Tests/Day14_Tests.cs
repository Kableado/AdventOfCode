using Xunit;

namespace AdventOfCode2018.Tests
{
    public class Day14_Tests
    {
        #region ResolvePart1

        [Fact]
        public void ResolvePart1__Test1()
        {
            Day14 day = new Day14();

            string result = day.ResolvePart1(new string[] { "9", });

            Assert.Equal("5158916779", result);
        }

        [Fact]
        public void ResolvePart1__Test2()
        {
            Day14 day = new Day14();

            string result = day.ResolvePart1(new string[] { "5", });

            Assert.Equal("0124515891", result);
        }

        [Fact]
        public void ResolvePart1__Test3()
        {
            Day14 day = new Day14();

            string result = day.ResolvePart1(new string[] { "18", });

            Assert.Equal("9251071085", result);
        }

        [Fact]
        public void ResolvePart1__Test4()
        {
            Day14 day = new Day14();

            string result = day.ResolvePart1(new string[] { "2018", });

            Assert.Equal("5941429882", result);
        }

        #endregion ResolvePart1

        #region ResolvePart2

        [Fact]
        public void ResolvePart2__Test1()
        {
            Day14 day = new Day14();

            string result = day.ResolvePart2(new string[] { "51589", });

            Assert.Equal("9", result);
        }

        [Fact]
        public void ResolvePart2__Test2()
        {
            Day14 day = new Day14();

            string result = day.ResolvePart2(new string[] { "01245", });

            Assert.Equal("5", result);
        }

        [Fact]
        public void ResolvePart2__Test3()
        {
            Day14 day = new Day14();

            string result = day.ResolvePart2(new string[] { "92510", });

            Assert.Equal("18", result);
        }

        [Fact]
        public void ResolvePart2__Test4()
        {
            Day14 day = new Day14();

            string result = day.ResolvePart2(new string[] { "59414", });

            Assert.Equal("2018", result);
        }

        #endregion ResolvePart2
    }
}