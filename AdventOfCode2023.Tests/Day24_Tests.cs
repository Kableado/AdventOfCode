namespace AdventOfCode2023.Tests;

/*
"19, 13, 30 @ -2,  1, -2",
"18, 19, 22 @ -1, -1, -2",
"20, 25, 34 @ -2, -2, -4",
"12, 31, 28 @ -1, -2, -1",
"20, 19, 15 @  1, -5, -3",
 */

public class Day24_Tests
{
    private string[] _example1 = {
        "19, 13, 30 @ -2,  1, -2",
        "18, 19, 22 @ -1, -1, -2",
        "20, 25, 34 @ -2, -2, -4",
        "12, 31, 28 @ -1, -2, -1",
        "20, 19, 15 @  1, -5, -3",
    };
    
    [Fact]
    public void ResolvePart1__Example1()
    {
        Day24 day = new();

        string result = day.ResolvePart1(_example1);

        Assert.Equal("2", result);
    }

    [Fact]
    public void Hail_Intersect2D__Examples1()
    {
        Day24.Hail hailA = new("19, 13, 30 @ -2,  1, -2");
        Day24.Hail hailB = new("18, 19, 22 @ -1, -1, -2");
        Day24.Hail hailC = new("20, 25, 34 @ -2, -2, -4");
        Day24.Hail hailD = new("12, 31, 28 @ -1, -2, -1");
        Day24.Hail hailE = new("20, 19, 15 @  1, -5, -3");
        
        (bool intersect_A_B, _, _, _) = hailA.Intersect2D(hailB);
        Assert.True(intersect_A_B);
        
        (bool intersect_A_C, _, _, _) = hailA.Intersect2D(hailC);
        Assert.True(intersect_A_C);
        
        (bool intersect_A_D, _, _, _) = hailA.Intersect2D(hailD);
        Assert.True(intersect_A_D);
        
        (bool intersect_A_E, _, _, _) = hailA.Intersect2D(hailE);
        Assert.True(intersect_A_E);
        
        (bool intersect_B_C, _, _, _) = hailB.Intersect2D(hailC);
        Assert.False(intersect_B_C);
        
        (bool intersect_B_D, _, _, _) = hailB.Intersect2D(hailD);
        Assert.True(intersect_B_D);
        
        (bool intersect_B_E, _, _, _) = hailB.Intersect2D(hailE);
        Assert.True(intersect_B_E);
        
        (bool intersect_C_D, _, _, _) = hailC.Intersect2D(hailD);
        Assert.True(intersect_C_D);
        
        (bool intersect_C_E, _, _, _) = hailC.Intersect2D(hailE);
        Assert.True(intersect_C_E);
        
        (bool intersect_D_E, _, _, _) = hailD.Intersect2D(hailE);
        Assert.True(intersect_D_E);
    }

}