namespace AdventOfCode2018.Tests;

public class Day03_Tests
{
    #region Claim_FromString

    [Fact]
    public void Claim_FromString__Test1()
    {
        Day03.Claim claim = Day03.Claim.FromString("#123 @ 3,2: 5x4");

        Assert.Equal(123, claim.ID);
        Assert.Equal(3, claim.Left);
        Assert.Equal(2, claim.Top);
        Assert.Equal(5, claim.Width);
        Assert.Equal(4, claim.Height);
    }

    [Fact]
    public void Claim_FromString__Test2()
    {
        Day03.Claim claim = Day03.Claim.FromString("#1 @ 1,3: 4x4");

        Assert.Equal(1, claim.ID);
        Assert.Equal(1, claim.Left);
        Assert.Equal(3, claim.Top);
        Assert.Equal(4, claim.Width);
        Assert.Equal(4, claim.Height);
    }

    [Fact]
    public void Claim_FromString__Test3()
    {
        Day03.Claim claim = Day03.Claim.FromString("#2 @ 3,1: 4x4");

        Assert.Equal(2, claim.ID);
        Assert.Equal(3, claim.Left);
        Assert.Equal(1, claim.Top);
        Assert.Equal(4, claim.Width);
        Assert.Equal(4, claim.Height);
    }

    [Fact]
    public void Claim_FromString__Test4()
    {
        Day03.Claim claim = Day03.Claim.FromString("#3 @ 5,5: 2x2");

        Assert.Equal(3, claim.ID);
        Assert.Equal(5, claim.Left);
        Assert.Equal(5, claim.Top);
        Assert.Equal(2, claim.Width);
        Assert.Equal(2, claim.Height);
    }

    #endregion Claim_FromString

    #region Claim_Overlaps

    [Fact]
    public void Claim_Overlaps__Test1()
    {
        Day03.Claim claim1 = Day03.Claim.FromString("#1 @ 1,3: 4x4");
        Day03.Claim claim2 = Day03.Claim.FromString("#3 @ 5,5: 2x2");

        bool result = Day03.Claim.Overlaps(claim1, claim2);

        Assert.False(result);
    }

    [Fact]
    public void Claim_Overlaps__Test2()
    {
        Day03.Claim claim1 = Day03.Claim.FromString("#2 @ 3,1: 4x4");
        Day03.Claim claim2 = Day03.Claim.FromString("#3 @ 5,5: 2x2");

        bool result = Day03.Claim.Overlaps(claim1, claim2);

        Assert.False(result);
    }

    [Fact]
    public void Claim_Overlaps__Test3()
    {
        Day03.Claim claim1 = Day03.Claim.FromString("#1 @ 1,3: 4x4");
        Day03.Claim claim2 = Day03.Claim.FromString("#2 @ 3,1: 4x4");

        bool result = Day03.Claim.Overlaps(claim1, claim2);

        Assert.True(result);
    }

    #endregion Claim_Overlaps
    
    [Fact]
    public void ResolvePart1__Test()
    {
        Day03 day03 = new();

        string result = day03.ResolvePart1(new[] {
            "#1 @ 1,3: 4x4",
            "#2 @ 3,1: 4x4",
            "#3 @ 5,5: 2x2",
        });

        Assert.Equal("4", result);
    }

    [Fact]
    public void ResolvePart2__Test()
    {
        Day03 day03 = new();

        string result = day03.ResolvePart2(new[] {
            "#1 @ 1,3: 4x4",
            "#2 @ 3,1: 4x4",
            "#3 @ 5,5: 2x2",
        });

        Assert.Equal("3", result);
    }
}