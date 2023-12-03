namespace AdventOfCode2018.Tests;

public class Day06_Tests
{
    #region ChronoPoint_FromString

    [Fact]
    public void ChronoPoint_FromString__Test1()
    {
        Day06.ChronoPoint point = Day06.ChronoPoint.FromString("1, 1");

        Assert.Equal(1, point.X);
        Assert.Equal(1, point.Y);
    }

    [Fact]
    public void ChronoPoint_FromString__Test2()
    {
        Day06.ChronoPoint point = Day06.ChronoPoint.FromString("1, 6");

        Assert.Equal(1, point.X);
        Assert.Equal(6, point.Y);
    }

    [Fact]
    public void ChronoPoint_FromString__Test3()
    {
        Day06.ChronoPoint point = Day06.ChronoPoint.FromString("8, 9");

        Assert.Equal(8, point.X);
        Assert.Equal(9, point.Y);
    }

    #endregion ChronoPoint_FromString

    #region ChronoPoint_ManhattanDistance

    [Fact]
    public void ChronoPoint_ManhattanDistance__Test1()
    {
        Day06.ChronoPoint p0 = Day06.ChronoPoint.FromString("8, 9");
        Day06.ChronoPoint p1 = Day06.ChronoPoint.FromString("1, 6");

        int distance = Day06.ChronoPoint.ManhattanDistance(p0, p1);

        Assert.Equal(10, distance);
    }

    [Fact]
    public void ChronoPoint_ManhattanDistance__Test2()
    {
        Day06.ChronoPoint p0 = Day06.ChronoPoint.FromString("1, 1");
        Day06.ChronoPoint p1 = Day06.ChronoPoint.FromString("1, 6");

        int distance = Day06.ChronoPoint.ManhattanDistance(p0, p1);

        Assert.Equal(5, distance);
    }

    #endregion ChronoPoint_ManhattanDistance

    [Fact]
    public void ResolvePart1__Test()
    {
        Day06 day06 = new();

        string result = day06.ResolvePart1(new[] {
            "1, 1",
            "1, 6",
            "8, 3",
            "3, 4",
            "5, 5",
            "8, 9",
        });

        Assert.Equal("17", result);
    }

    [Fact]
    public void ResolvePart2__Test()
    {
        Day06 day06 = new() { DistanceThresold = 32, };

        string result = day06.ResolvePart2(new[] {
            "1, 1",
            "1, 6",
            "8, 3",
            "3, 4",
            "5, 5",
            "8, 9",
        });

        Assert.Equal("16", result);
    }
}