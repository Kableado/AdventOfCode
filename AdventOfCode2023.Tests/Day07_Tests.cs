namespace AdventOfCode2023.Tests;

public class Day07_Tests
{
    private readonly string[] _example = {
        "32T3K 765",
        "T55J5 684",
        "KK677 28",
        "KTJJT 220",
        "QQQJA 483",
    };

    [Fact]
    public void ResolvePart1__Example()
    {
        Day07 day = new();
        
        string result = day.ResolvePart1(_example);

        Assert.Equal("6440", result);
    }

    [Fact]
    public void ResolvePart2__Example()
    {
        Day07 day = new();
        
        string result = day.ResolvePart2(_example);

        Assert.Equal("5905", result);
    }

    [Fact]
    public void CamelCard_Type__Examples()
    {
        Day07.CamelCard card_FiveOfAKind = new("AAAAA");
        Assert.Equal(Day07.CamelCard.Types.FiveOfAKind, card_FiveOfAKind.Type);
        
        Day07.CamelCard card_FourOfAKind = new("AA8AA");
        Assert.Equal(Day07.CamelCard.Types.FourOfAKind, card_FourOfAKind.Type);
        
        Day07.CamelCard card_FullHouse = new("23332");
        Assert.Equal(Day07.CamelCard.Types.FullHouse, card_FullHouse.Type);
        
        Day07.CamelCard card_ThreeOfAKind = new("TTT98");
        Assert.Equal(Day07.CamelCard.Types.ThreeOfAKind, card_ThreeOfAKind.Type);
        
        Day07.CamelCard card_TwoPair = new("23432");
        Assert.Equal(Day07.CamelCard.Types.TwoPair, card_TwoPair.Type);
        
        Day07.CamelCard card_OnePair = new("A23A4");
        Assert.Equal(Day07.CamelCard.Types.OnePair, card_OnePair.Type);
        
        Day07.CamelCard card_HighCard = new("23456");
        Assert.Equal(Day07.CamelCard.Types.HighCard, card_HighCard.Type);
    }
    
    [Fact]
    public void CamelCard_CompareTo__Examples()
    {
        Day07.CamelCard card_01 = new("33332");
        Day07.CamelCard card_02 = new("2AAAA");
        Assert.Equal(-1, card_01.CompareTo(card_02));
        Assert.Equal(1, card_02.CompareTo(card_01));
        
        Day07.CamelCard card_77888 = new("77888");
        Day07.CamelCard card_77788 = new("77788");
        Assert.Equal(-1, card_77888.CompareTo(card_77788));
        Assert.Equal(1, card_77788.CompareTo(card_77888));
    }
}