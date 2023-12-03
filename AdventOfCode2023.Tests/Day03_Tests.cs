namespace AdventOfCode2023.Tests;

public class Day03_Tests
{
    [Fact]
    public void SearchNextSchemaNumber__NoNumbers__Null()
    {
        string[] inputs = new[] {
            "..........",
            "..........",
            "..........",
        };
        Day03.SchemaNumber? number = Day03.SearchNextSchemaNumber(inputs, 0, 0);
        
        Assert.Null(number);
    }

    [Fact]
    public void SearchNextSchemaNumber__OneNumber__Valid()
    {
        string[] inputs = new[] {
            "..........",
            "....420...",
            "..........",
        };
        Day03.SchemaNumber? number = Day03.SearchNextSchemaNumber(inputs, 0, 0);
        
        Assert.NotNull(number);
        Assert.Equal(1, number.Value.Row);
        Assert.Equal(4, number.Value.Column);
        Assert.Equal(3, number.Value.Lenght);
        Assert.Equal(420, number.Value.Value);
    }

    [Fact]
    public void SearchNextSchemaNumber__TwoNumbersSkipFirst__ValidSecond()
    {
        string[] inputs = new[] {
            "69........",
            "....420...",
            "..........",
        };
        Day03.SchemaNumber? number = Day03.SearchNextSchemaNumber(inputs, 0, 4);
        
        Assert.NotNull(number);
        Assert.Equal(1, number.Value.Row);
        Assert.Equal(4, number.Value.Column);
        Assert.Equal(3, number.Value.Lenght);
        Assert.Equal(420, number.Value.Value);
    }

    private string[] _example = new[] {
        "467..114..",
        "...*......",
        "..35..633.",
        "......#...",
        "617*......",
        ".....+.58.",
        "..592.....",
        "......755.",
        "...$.*....",
        ".664.598..",
    };
    
    [Fact]
    public void ResolvePart1__Example()
    {
        Day03 day = new();
        
        string result = day.ResolvePart1(_example);

        Assert.Equal("4361", result);
    }
    
    
    [Fact]
    public void ResolvePart2__Example()
    {
        Day03 day = new();
        
        string result = day.ResolvePart2(_example);

        Assert.Equal("467835", result);
    }
}