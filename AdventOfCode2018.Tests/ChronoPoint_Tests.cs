namespace AdventOfCode2018.Tests;

public class ChronoPoint_Tests
{
    #region FromString

    [Fact]
    public void FromString__Test1()
    {
        ChronoPoint point = ChronoPoint.FromString("1, 1");

        Assert.Equal(1, point.X);
        Assert.Equal(1, point.Y);
    }

    [Fact]
    public void FromString__Test2()
    {
        ChronoPoint point = ChronoPoint.FromString("1, 6");

        Assert.Equal(1, point.X);
        Assert.Equal(6, point.Y);
    }

    [Fact]
    public void FromString__Test3()
    {
        ChronoPoint point = ChronoPoint.FromString("8, 9");

        Assert.Equal(8, point.X);
        Assert.Equal(9, point.Y);
    }

    #endregion FromString

    #region ManhattanDistance

    [Fact]
    public void ManhattanDistance__Test1()
    {
        ChronoPoint p0 = ChronoPoint.FromString("8, 9");
        ChronoPoint p1 = ChronoPoint.FromString("1, 6");

        int distance = ChronoPoint.ManhattanDistance(p0, p1);

        Assert.Equal(10, distance);
    }

    [Fact]
    public void ManhattanDistance__Test2()
    {
        ChronoPoint p0 = ChronoPoint.FromString("1, 1");
        ChronoPoint p1 = ChronoPoint.FromString("1, 6");

        int distance = ChronoPoint.ManhattanDistance(p0, p1);

        Assert.Equal(5, distance);
    }

    #endregion ManhattanDistance
}