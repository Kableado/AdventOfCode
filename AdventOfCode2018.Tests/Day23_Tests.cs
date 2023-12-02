namespace AdventOfCode2018.Tests;

public class Day23_Tests
{
    [Fact]
    public void ResolvePart1__Test()
    {
        Day23 day = new();

        string result = day.ResolvePart1(new[] {
            "pos=<0,0,0>, r=4",
            "pos=<1,0,0>, r=1",
            "pos=<4,0,0>, r=3",
            "pos=<0,2,0>, r=1",
            "pos=<0,5,0>, r=3",
            "pos=<0,0,3>, r=1",
            "pos=<1,1,1>, r=1",
            "pos=<1,1,2>, r=1",
            "pos=<1,3,1>, r=1",
        });

        Assert.Equal("7", result);
    }

    [Fact]
    public void ResolvePart2__Test()
    {
        Day23 day = new();

        string result = day.ResolvePart2(new[] {
            "pos=<10,12,12>, r=2",
            "pos=<12,14,12>, r=2",
            "pos=<16,12,12>, r=4",
            "pos=<14,14,14>, r=6",
            "pos=<50,50,50>, r=200",
            "pos=<10,10,10>, r=5",
        });

        Assert.Equal("36", result);
    }
}