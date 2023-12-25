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
    private readonly string[] _example1 = {
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
    public void ResolvePart2__Example1()
    {
        Day24 day = new();

        string result = day.ResolvePart2(_example1);

        Assert.Equal("47", result);
    }

    private readonly string[] _example2 = {
        "19, 13, 30 @ -2,  1, -2",
        "18, 19, 22 @ -1, -1, -2",
        "20, 25, 34 @ -2, -2, -4",
        "12, 31, 28 @ -1, -2, -1",
        "20, 19, 15 @  1, -5, -3",
        "24, 13, 10 @ -3,  1,  2",
    };
    
    [Fact]
    public void ResolvePart2__Example2()
    {
        Day24 day = new();

        string result = day.ResolvePart2(_example2);

        Assert.Equal("47", result);
    }

    [Fact]
    public void Hail_Intersect2D__Examples1()
    {
        Day24.Hail hailA = new("19, 13, 30 @ -2,  1, -2");
        Day24.Hail hailB = new("18, 19, 22 @ -1, -1, -2");
        Day24.Hail hailC = new("20, 25, 34 @ -2, -2, -4");
        Day24.Hail hailD = new("12, 31, 28 @ -1, -2, -1");
        Day24.Hail hailE = new("20, 19, 15 @  1, -5, -3");
        
        (bool intersect_A_B, _, _) = hailA.Intersect2D(hailB);
        Assert.True(intersect_A_B);
        
        (bool intersect_A_C, _, _) = hailA.Intersect2D(hailC);
        Assert.True(intersect_A_C);
        
        (bool intersect_A_D, _, _) = hailA.Intersect2D(hailD);
        Assert.True(intersect_A_D);
        
        (bool intersect_A_E, _, _) = hailA.Intersect2D(hailE);
        Assert.True(intersect_A_E);
        
        (bool intersect_B_C, _, _) = hailB.Intersect2D(hailC);
        Assert.False(intersect_B_C);
        
        (bool intersect_B_D, _, _) = hailB.Intersect2D(hailD);
        Assert.True(intersect_B_D);
        
        (bool intersect_B_E, _, _) = hailB.Intersect2D(hailE);
        Assert.True(intersect_B_E);
        
        (bool intersect_C_D, _, _) = hailC.Intersect2D(hailD);
        Assert.True(intersect_C_D);
        
        (bool intersect_C_E, _, _) = hailC.Intersect2D(hailE);
        Assert.True(intersect_C_E);
        
        (bool intersect_D_E, _, _) = hailD.Intersect2D(hailE);
        Assert.True(intersect_D_E);
    }

    [Fact]
    public void Hail_Intersect3D__Examples1()
    {
        Day24.Hail rock = new("24, 13, 10 @ -3,  1,  2");
        
        Day24.Hail hailA = new("19, 13, 30 @ -2,  1, -2");
        Day24.Hail hailB = new("18, 19, 22 @ -1, -1, -2");
        Day24.Hail hailC = new("20, 25, 34 @ -2, -2, -4");
        Day24.Hail hailD = new("12, 31, 28 @ -1, -2, -1");
        Day24.Hail hailE = new("20, 19, 15 @  1, -5, -3");
        
        (bool intersect_A, double t_A, _) = rock.Intersect3D(hailA);
        Assert.True(intersect_A);
        Assert.Equal(5, t_A);
        
        (bool intersect_B, double t_B, _) = rock.Intersect3D(hailB);
        Assert.True(intersect_B);
        Assert.Equal(3, t_B);
        
        (bool intersect_C, double t_C, _) = rock.Intersect3D(hailC);
        Assert.True(intersect_C);
        Assert.Equal(4, t_C);
        
        (bool intersect_D, double t_D, _) = rock.Intersect3D(hailD);
        Assert.True(intersect_D);
        Assert.Equal(6, t_D);
        
        (bool intersect_E, double t_E, _) = rock.Intersect3D(hailE);
        Assert.True(intersect_E);
        Assert.Equal(1, t_E);
    }
}