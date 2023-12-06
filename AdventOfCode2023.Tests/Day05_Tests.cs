namespace AdventOfCode2023.Tests;

public class Day05_Tests
{
    private readonly string[] _example = {
        "seeds: 79 14 55 13",
        "",
        "seed-to-soil map:",
        "50 98 2",
        "52 50 48",
        "",
        "soil-to-fertilizer map:",
        "0 15 37",
        "37 52 2",
        "39 0 15",
        "",
        "fertilizer-to-water map:",
        "49 53 8",
        "0 11 42",
        "42 0 7",
        "57 7 4",
        "",
        "water-to-light map:",
        "88 18 7",
        "18 25 70",
        "",
        "light-to-temperature map:",
        "45 77 23",
        "81 45 19",
        "68 64 13",
        "",
        "temperature-to-humidity map:",
        "0 69 1",
        "1 0 69",
        "",
        "humidity-to-location map:",
        "60 56 37",
        "56 93 4",
    };

    [Fact]
    public void ResolvePart1__Example()
    {
        Day05 day = new();
        
        string result = day.ResolvePart1(_example);

        Assert.Equal("35", result);
    }

    [Fact]
    public void ResolvePart2__Example()
    {
        Day05 day = new();
        
        string result = day.ResolvePart2(_example);

        Assert.Equal("46", result);
    }

    [Fact]
    public void AlamanacMapping_ParseNext__Empty__Null()
    {
        Day05.LinesReader reader = new(Array.Empty<string>());
        Day05.AlmanacMapping? mapping = Day05.AlmanacMapping.ParseNext(reader);
        
        Assert.Null(mapping);
    }
    
    [Fact]
    public void AlamanacMapping_ParseNext__Example1()
    {
        Day05.LinesReader reader = new(new[] { 
            "seed-to-soil map:",
            "50 98 2",
            "52 50 48",
        });
        Day05.AlmanacMapping? mapping = Day05.AlmanacMapping.ParseNext(reader);
        
        Assert.NotNull(mapping);
        Assert.Equal("seed-to-soil", mapping.Name);
        Assert.Equal(2, mapping.RangeMappings.Count);
        Assert.Equal(50, mapping.RangeMappings[0].DestinationStart);
        Assert.Equal(98, mapping.RangeMappings[0].OriginStart);
        Assert.Equal(2, mapping.RangeMappings[0].Lenght);
        Assert.Equal(52, mapping.RangeMappings[1].DestinationStart);
        Assert.Equal(50, mapping.RangeMappings[1].OriginStart);
        Assert.Equal(48, mapping.RangeMappings[1].Lenght);

        long value1 = 100;
        long valueMapped1 = mapping.Apply(value1);
        Assert.Equal(100, valueMapped1);
        
        long value2 = 99;
        long valueMapped2 = mapping.Apply(value2);
        Assert.Equal(51, valueMapped2);
        
        long value3 = 45;
        long valueMapped3 = mapping.Apply(value3);
        Assert.Equal(45, valueMapped3);
    }
}