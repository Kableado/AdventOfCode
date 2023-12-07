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
    public void AlmanacMapping_ParseNext__Empty__Null()
    {
        Day05.LinesReader reader = new(Array.Empty<string>());
        Day05.AlmanacMapping? mapping = Day05.AlmanacMapping.ParseNext(reader);
        
        Assert.Null(mapping);
    }
    
    [Fact]
    public void AlmanacMapping_ParseNext__Example1()
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
        Assert.Equal(2, mapping.RangeMappings[0].Length);
        Assert.Equal(52, mapping.RangeMappings[1].DestinationStart);
        Assert.Equal(50, mapping.RangeMappings[1].OriginStart);
        Assert.Equal(48, mapping.RangeMappings[1].Length);

        const long value1 = 100;
        long valueMapped1 = mapping.Apply(value1);
        Assert.Equal(100, valueMapped1);
        
        const long value2 = 99;
        long valueMapped2 = mapping.Apply(value2);
        Assert.Equal(51, valueMapped2);
        
        const long value3 = 45;
        long valueMapped3 = mapping.Apply(value3);
        Assert.Equal(45, valueMapped3);
    }

    [Fact]
    public void AlmanacRangeMapping_Clip__Examples()
    {
        // ..........■■■■■■■■■■..........
        Day05.AlmanacRangeMapping rangeMapping = new() {
            OriginStart = 10,
            DestinationStart = 1000,
            Length = 10,
        };
        
        // ..........■■■■■■■■■■..........
        // #####.........................
        Day05.AlmanacRangeMapping range_Lower = new() {
            OriginStart = 0,
            DestinationStart = 0,
            Length = 5,
        };
        Day05.AlmanacRangeMapping.ClipResult range_Lower_Result = rangeMapping.Clip(range_Lower);
        Assert.NotNull(range_Lower_Result.PreClip);
        Assert.Equal(0, range_Lower_Result.PreClip.Value.OriginStart);
        Assert.Equal(0, range_Lower_Result.PreClip.Value.DestinationStart);
        Assert.Equal(5, range_Lower_Result.PreClip.Value.Length);
        Assert.Null(range_Lower_Result.Clipped);
        Assert.Null(range_Lower_Result.PostClip);
        
        // ..........■■■■■■■■■■..........
        // ##########....................
        Day05.AlmanacRangeMapping range_LowerTouching = new() {
            OriginStart = 0,
            DestinationStart = 0,
            Length = 10,
        };
        Day05.AlmanacRangeMapping.ClipResult range_LowerTouching_Result = rangeMapping.Clip(range_LowerTouching);
        Assert.NotNull(range_LowerTouching_Result.PreClip);
        Assert.Equal(0, range_LowerTouching_Result.PreClip.Value.OriginStart);
        Assert.Equal(0, range_LowerTouching_Result.PreClip.Value.DestinationStart);
        Assert.Equal(10, range_LowerTouching_Result.PreClip.Value.Length);
        Assert.Null(range_LowerTouching_Result.Clipped);
        Assert.Null(range_LowerTouching_Result.PostClip);
        
        // ..........■■■■■■■■■■..........
        // .........................#####
        Day05.AlmanacRangeMapping range_Upper = new() {
            OriginStart = 25,
            DestinationStart = 25,
            Length = 5,
        };
        Day05.AlmanacRangeMapping.ClipResult range_Upper_Result = rangeMapping.Clip(range_Upper);
        Assert.Null(range_Upper_Result.PreClip);
        Assert.Null(range_Upper_Result.Clipped);
        Assert.NotNull(range_Upper_Result.PostClip);
        Assert.Equal(25, range_Upper_Result.PostClip.Value.OriginStart);
        Assert.Equal(25, range_Upper_Result.PostClip.Value.DestinationStart);
        Assert.Equal(5, range_Upper_Result.PostClip.Value.Length);
        
        // ..........■■■■■■■■■■..........
        // ....................##########
        Day05.AlmanacRangeMapping range_UpperTouching = new() {
            OriginStart = 20,
            DestinationStart = 20,
            Length = 10,
        };
        Day05.AlmanacRangeMapping.ClipResult range_UpperTouching_Result = rangeMapping.Clip(range_UpperTouching);
        Assert.Null(range_UpperTouching_Result.PreClip);
        Assert.Null(range_UpperTouching_Result.Clipped);
        Assert.NotNull(range_UpperTouching_Result.PostClip);
        Assert.Equal(20, range_UpperTouching_Result.PostClip.Value.OriginStart);
        Assert.Equal(20, range_UpperTouching_Result.PostClip.Value.DestinationStart);
        Assert.Equal(10, range_UpperTouching_Result.PostClip.Value.Length);
        
        // ..........■■■■■■■■■■..........
        // ..........$$$$$$$$$$..........
        Day05.AlmanacRangeMapping range_IntersectCover = new() {
            OriginStart = 10,
            DestinationStart = 10,
            Length = 10,
        };
        Day05.AlmanacRangeMapping.ClipResult range_IntersectCover_Result = rangeMapping.Clip(range_IntersectCover);
        Assert.Null(range_IntersectCover_Result.PreClip);
        Assert.NotNull(range_IntersectCover_Result.Clipped);
        Assert.Equal(10, range_IntersectCover_Result.Clipped.Value.OriginStart);
        Assert.Equal(1000, range_IntersectCover_Result.Clipped.Value.DestinationStart);
        Assert.Equal(10, range_IntersectCover_Result.Clipped.Value.Length);
        Assert.Null(range_IntersectCover_Result.PostClip);
        
        // ..........■■■■■■■■■■..........
        // ...............$$$$$..........
        Day05.AlmanacRangeMapping range_IntersectInsideToEnd = new() {
            OriginStart = 15,
            DestinationStart = 15,
            Length = 5,
        };
        Day05.AlmanacRangeMapping.ClipResult range_IntersectInsideToEnd_Result = rangeMapping.Clip(range_IntersectInsideToEnd);
        Assert.Null(range_IntersectInsideToEnd_Result.PreClip);
        Assert.NotNull(range_IntersectInsideToEnd_Result.Clipped);
        Assert.Equal(15, range_IntersectInsideToEnd_Result.Clipped.Value.OriginStart);
        Assert.Equal(1005, range_IntersectInsideToEnd_Result.Clipped.Value.DestinationStart);
        Assert.Equal(5, range_IntersectInsideToEnd_Result.Clipped.Value.Length);
        Assert.Null(range_IntersectInsideToEnd_Result.PostClip);
        
        // ..........■■■■■■■■■■..........
        // ...............$$$$$#####.....
        Day05.AlmanacRangeMapping range_IntersectInsideToOutside = new() {
            OriginStart = 15,
            DestinationStart = 15,
            Length = 10,
        };
        Day05.AlmanacRangeMapping.ClipResult range_IntersectInsideToOutside_Result = rangeMapping.Clip(range_IntersectInsideToOutside);
        Assert.Null(range_IntersectInsideToOutside_Result.PreClip);
        Assert.NotNull(range_IntersectInsideToOutside_Result.Clipped);
        Assert.Equal(15, range_IntersectInsideToOutside_Result.Clipped.Value.OriginStart);
        Assert.Equal(1005, range_IntersectInsideToOutside_Result.Clipped.Value.DestinationStart);
        Assert.Equal(5, range_IntersectInsideToOutside_Result.Clipped.Value.Length);
        Assert.NotNull(range_IntersectInsideToOutside_Result.PostClip);
        Assert.Equal(20, range_IntersectInsideToOutside_Result.PostClip.Value.OriginStart);
        Assert.Equal(20, range_IntersectInsideToOutside_Result.PostClip.Value.DestinationStart);
        Assert.Equal(5, range_IntersectInsideToOutside_Result.PostClip.Value.Length);
        
        // ..........■■■■■■■■■■..........
        // .....#####$$$$$...............
        Day05.AlmanacRangeMapping range_IntersectOutsideToInside = new() {
            OriginStart = 5,
            DestinationStart = 5,
            Length = 10,
        };
        Day05.AlmanacRangeMapping.ClipResult range_IntersectOutsideToInside_Result = rangeMapping.Clip(range_IntersectOutsideToInside);
        Assert.NotNull(range_IntersectOutsideToInside_Result.PreClip);
        Assert.Equal(5, range_IntersectOutsideToInside_Result.PreClip.Value.OriginStart);
        Assert.Equal(5, range_IntersectOutsideToInside_Result.PreClip.Value.DestinationStart);
        Assert.Equal(5, range_IntersectOutsideToInside_Result.PreClip.Value.Length);
        Assert.NotNull(range_IntersectOutsideToInside_Result.Clipped);
        Assert.Equal(10, range_IntersectOutsideToInside_Result.Clipped.Value.OriginStart);
        Assert.Equal(1000, range_IntersectOutsideToInside_Result.Clipped.Value.DestinationStart);
        Assert.Equal(5, range_IntersectOutsideToInside_Result.Clipped.Value.Length);
        Assert.Null(range_IntersectOutsideToInside_Result.PostClip);
        
        // ..........■■■■■■■■■■..........
        // .....#####$$$$$$$$$$..........
        Day05.AlmanacRangeMapping range_IntersectOutsideToEnd = new() {
            OriginStart = 5,
            DestinationStart = 5,
            Length = 15,
        };
        Day05.AlmanacRangeMapping.ClipResult range_IntersectOutsideToEnd_Result = rangeMapping.Clip(range_IntersectOutsideToEnd);
        Assert.NotNull(range_IntersectOutsideToEnd_Result.PreClip);
        Assert.Equal(5, range_IntersectOutsideToEnd_Result.PreClip.Value.OriginStart);
        Assert.Equal(5, range_IntersectOutsideToEnd_Result.PreClip.Value.DestinationStart);
        Assert.Equal(5, range_IntersectOutsideToEnd_Result.PreClip.Value.Length);
        Assert.NotNull(range_IntersectOutsideToEnd_Result.Clipped);
        Assert.Equal(10, range_IntersectOutsideToEnd_Result.Clipped.Value.OriginStart);
        Assert.Equal(1000, range_IntersectOutsideToEnd_Result.Clipped.Value.DestinationStart);
        Assert.Equal(10, range_IntersectOutsideToEnd_Result.Clipped.Value.Length);
        Assert.Null(range_IntersectOutsideToEnd_Result.PostClip);
        
        // ..........■■■■■■■■■■..........
        // .....#####$$$$$$$$$$#####.....
        Day05.AlmanacRangeMapping range_IntersectOutsideToOutside = new() {
            OriginStart = 5,
            DestinationStart = 5,
            Length = 20,
        };
        Day05.AlmanacRangeMapping.ClipResult range_IntersectOutsideToOutside_Result = rangeMapping.Clip(range_IntersectOutsideToOutside);
        Assert.NotNull(range_IntersectOutsideToOutside_Result.PreClip);
        Assert.Equal(5, range_IntersectOutsideToOutside_Result.PreClip.Value.OriginStart);
        Assert.Equal(5, range_IntersectOutsideToOutside_Result.PreClip.Value.DestinationStart);
        Assert.Equal(5, range_IntersectOutsideToOutside_Result.PreClip.Value.Length);
        Assert.NotNull(range_IntersectOutsideToOutside_Result.Clipped);
        Assert.Equal(10, range_IntersectOutsideToOutside_Result.Clipped.Value.OriginStart);
        Assert.Equal(1000, range_IntersectOutsideToOutside_Result.Clipped.Value.DestinationStart);
        Assert.Equal(10, range_IntersectOutsideToOutside_Result.Clipped.Value.Length);
        Assert.NotNull(range_IntersectOutsideToOutside_Result.PostClip);
        Assert.Equal(20, range_IntersectOutsideToOutside_Result.PostClip.Value.OriginStart);
        Assert.Equal(20, range_IntersectOutsideToOutside_Result.PostClip.Value.DestinationStart);
        Assert.Equal(5, range_IntersectOutsideToOutside_Result.PostClip.Value.Length);
    }
}