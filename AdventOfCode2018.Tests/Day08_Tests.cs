namespace AdventOfCode2018.Tests;

public class Day08_Tests
{
    [Fact]
    public void ChronoLicenceNode_BuildFromIntStream__Test()
    {
        Day08.IntStream values = new("2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2");
        Day08.ChronoLicenceNode result = Day08.ChronoLicenceNode.BuildFromIntStream(values);

        Assert.Equal(2, result.Childs.Count);
        Assert.Equal(3, result.Metadata.Count);
        Assert.Equal(1, result.Metadata[0]);
        Assert.Equal(1, result.Metadata[1]);
        Assert.Equal(2, result.Metadata[2]);

        Assert.Empty(result.Childs[0].Childs);
        Assert.Equal(3, result.Childs[0].Metadata.Count);
        Assert.Equal(10, result.Childs[0].Metadata[0]);
        Assert.Equal(11, result.Childs[0].Metadata[1]);
        Assert.Equal(12, result.Childs[0].Metadata[2]);

        Assert.Single(result.Childs[1].Childs);
        Assert.Single(result.Childs[1].Metadata);
        Assert.Equal(2, result.Childs[1].Metadata[0]);

        Assert.Empty(result.Childs[1].Childs[0].Childs);
        Assert.Single(result.Childs[1].Childs[0].Metadata);
        Assert.Equal(99, result.Childs[1].Childs[0].Metadata[0]);
    }
    
    [Fact]
    public void ResolvePart1__Test()
    {
        Day08 day = new();

        string result = day.ResolvePart1(new[] { "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2", });

        Assert.Equal("138", result);
    }

    [Fact]
    public void ResolvePart2__Test()
    {
        Day08 day = new();

        string result = day.ResolvePart2(new[] { "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2", });

        Assert.Equal("66", result);
    }
}