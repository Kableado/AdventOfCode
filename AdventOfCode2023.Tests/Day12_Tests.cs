namespace AdventOfCode2023.Tests;

public class Day12_Tests
{
    private readonly string[] _example1 = {
        "???.### 1,1,3",
        ".??..??...?##. 1,1,3",
        "?#?#?#?#?#?#?#? 1,3,1,6",
        "????.#...#... 4,1,1",
        "????.######..#####. 1,6,5",
        "?###???????? 3,2,1",
    };

    [Fact]
    public void ResolvePart1__Example1()
    {
        Day12 day = new();

        string result = day.ResolvePart1(_example1);

        Assert.Equal("21", result);
    }

    [Fact]
    public void ResolvePart2__Example1()
    {
        Day12 day = new();

        string result = day.ResolvePart2(_example1);

        Assert.Equal("525152", result);
    }

    private static void HotSpring_CountPossibleArrangements__Test(string input, int expected, bool unFold = false)
    {
        Day12.HotSpring hotSpring = new(input, unFold);
        long count = hotSpring.CountPossibleArrangements();
        Assert.Equal(expected, count);
    }

    [Fact]
    public void HotSpring_CountPossibleArrangements__Tests1()
    {
        HotSpring_CountPossibleArrangements__Test("???.### 1,1,3", 1);
        HotSpring_CountPossibleArrangements__Test(".??..??...?##. 1,1,3", 4);
        HotSpring_CountPossibleArrangements__Test("?#?#?#?#?#?#?#? 1,3,1,6", 1);
        HotSpring_CountPossibleArrangements__Test("????.#...#... 4,1,1", 1);
        HotSpring_CountPossibleArrangements__Test("????.######..#####. 1,6,5", 4);
        HotSpring_CountPossibleArrangements__Test("?###???????? 3,2,1", 10);
    }

    [Fact]
    public void HotSpring_CountPossibleArrangements__Tests2_1()
    {
        HotSpring_CountPossibleArrangements__Test("???.### 1,1,3", 1, true);
    }

    [Fact]
    public void HotSpring_CountPossibleArrangements__Tests2_2()
    {
        HotSpring_CountPossibleArrangements__Test(".??..??...?##. 1,1,3", 16384, true);
    }

    [Fact]
    public void HotSpring_CountPossibleArrangements__Tests2_3()
    {
        HotSpring_CountPossibleArrangements__Test("?#?#?#?#?#?#?#? 1,3,1,6", 1, true);
    }

    [Fact]
    public void HotSpring_CountPossibleArrangements__Tests2_4()
    {
        HotSpring_CountPossibleArrangements__Test("????.#...#... 4,1,1", 16, true);
    }

    [Fact]
    public void HotSpring_CountPossibleArrangements__Tests2_5()
    {
        HotSpring_CountPossibleArrangements__Test("????.######..#####. 1,6,5", 2500, true);
    }

    [Fact]
    public void HotSpring_CountPossibleArrangements__Tests2_6()
    {
        HotSpring_CountPossibleArrangements__Test("?###???????? 3,2,1", 506250, true);
    }
}