namespace AdventOfCode2023.Tests;

public class Day02_Tests
{
    [Fact]
    public void Game_FromString__ValidExample1()
    {
        Day02.Game game = Day02.Game.FromString("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green");
        Assert.Equal(1, game.GameNumber);
        Assert.Equal(3, game.Sets.Count);
        Assert.Equal(4, game.Sets[0].Red);
        Assert.Equal(3, game.Sets[0].Blue);
        Assert.Equal(0, game.Sets[0].Green);
        Assert.Equal(1, game.Sets[1].Red);
        Assert.Equal(6, game.Sets[1].Blue);
        Assert.Equal(2, game.Sets[1].Green);
        Assert.Equal(0, game.Sets[2].Red);
        Assert.Equal(0, game.Sets[2].Blue);
        Assert.Equal(2, game.Sets[2].Green);
    }
    
    [Fact]
    public void Game_FromString__ValidExample2()
    {
        Day02.Game game = Day02.Game.FromString("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red");
        Assert.Equal(3, game.GameNumber);
        Assert.Equal(3, game.Sets.Count);
        Assert.Equal(20, game.Sets[0].Red);
        Assert.Equal(6, game.Sets[0].Blue);
        Assert.Equal(8, game.Sets[0].Green);
        Assert.Equal(4, game.Sets[1].Red);
        Assert.Equal(5, game.Sets[1].Blue);
        Assert.Equal(13, game.Sets[1].Green);
        Assert.Equal(1, game.Sets[2].Red);
        Assert.Equal(0, game.Sets[2].Blue);
        Assert.Equal(5, game.Sets[2].Green);
    }
    
    [Fact]
    public void ResolvePart1__Example()
    {
        Day02 day = new();
        
        string result = day.ResolvePart1(new[] {
            "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
            "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
            "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
            "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
            "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green",
        });

        Assert.Equal("8", result);
    }
    
    [Fact]
    public void ResolvePart2__Example()
    {
        Day02 day = new();
        
        string result = day.ResolvePart2(new[] {
            "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
            "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
            "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
            "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
            "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green",
        });

        Assert.Equal("2286", result);
    }
}