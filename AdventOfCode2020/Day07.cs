using System;
using System.Collections.Generic;
using System.Linq;

/*

--- Day 7: Handy Haversacks ---

You land at the regional airport in time for your next flight. In fact, it looks like you'll even have time to grab some food: all flights are currently delayed due to issues in luggage processing.

Due to recent aviation regulations, many rules (your puzzle input) are being enforced about bags and their contents; bags must be color-coded and must contain specific quantities of other color-coded bags. Apparently, nobody responsible for these regulations considered how long they would take to enforce!

For example, consider the following rules:

light red bags contain 1 bright white bag, 2 muted yellow bags.
dark orange bags contain 3 bright white bags, 4 muted yellow bags.
bright white bags contain 1 shiny gold bag.
muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.
shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.
dark olive bags contain 3 faded blue bags, 4 dotted black bags.
vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.
faded blue bags contain no other bags.
dotted black bags contain no other bags.

These rules specify the required contents for 9 bag types. In this example, every faded blue bag is empty, every vibrant plum bag contains 11 bags (5 faded blue and 6 dotted black), and so on.

You have a shiny gold bag. If you wanted to carry it in at least one other bag, how many different bag colors would be valid for the outermost bag? (In other words: how many colors can, eventually, contain at least one shiny gold bag?)

In the above rules, the following options would be available to you:

    A bright white bag, which can hold your shiny gold bag directly.
    A muted yellow bag, which can hold your shiny gold bag directly, plus some other bags.
    A dark orange bag, which can hold bright white and muted yellow bags, either of which could then hold your shiny gold bag.
    A light red bag, which can hold bright white and muted yellow bags, either of which could then hold your shiny gold bag.

So, in this example, the number of bag colors that can eventually contain at least one shiny gold bag is 4.

How many bag colors can eventually contain at least one shiny gold bag? (The list of rules is quite long; make sure you get all of it.)

--- Part Two ---

It's getting pretty expensive to fly these days - not because of ticket prices, but because of the ridiculous number of bags you need to buy!

Consider again your shiny gold bag and the rules from the above example:

    faded blue bags contain 0 other bags.
    dotted black bags contain 0 other bags.
    vibrant plum bags contain 11 other bags: 5 faded blue bags and 6 dotted black bags.
    dark olive bags contain 7 other bags: 3 faded blue bags and 4 dotted black bags.

So, a single shiny gold bag must contain 1 dark olive bag (and the 7 bags within it) plus 2 vibrant plum bags (and the 11 bags within each of those): 1 + 1*7 + 2 + 2*11 = 32 bags!

Of course, the actual rules have a small chance of going several levels deeper than this example; be sure to count all of the bags, even if the nesting becomes topologically impractical!

Here's another example:

shiny gold bags contain 2 dark red bags.
dark red bags contain 2 dark orange bags.
dark orange bags contain 2 dark yellow bags.
dark yellow bags contain 2 dark green bags.
dark green bags contain 2 dark blue bags.
dark blue bags contain 2 dark violet bags.
dark violet bags contain no other bags.

In this example, a single shiny gold bag must contain 126 other bags.

How many individual bags are required inside your single shiny gold bag?

*/

namespace AdventOfCode2020;

public class Day07 : IDay
{
    public string ResolvePart1(string[] inputs)
    {
        string myBagColor = "shiny gold";

        List<BaggageRule> rules = new();
        foreach (string input in inputs)
        {
            BaggageRule rule = BaggageRule_Parse(input);
            rules.Add(rule);
        }

        List<string> bagColorsToCheck = new() { myBagColor };
        List<string> bagColorsChecked = new() { myBagColor };
        int cntBagColors = 0;
        while (bagColorsToCheck.Count > 0)
        {
            string currentColor = bagColorsToCheck[0];
            bagColorsToCheck.RemoveAt(0);

            foreach (BaggageRule rule in rules)
            {
                if (rule.Contain.Any(r => r.BagColor == currentColor))
                {
                    if (bagColorsChecked.Contains(rule.BagColor) == false)
                    {
                        bagColorsToCheck.Add(rule.BagColor);
                        bagColorsChecked.Add(rule.BagColor);
                        cntBagColors++;
                    }
                }
            }
        }

        return cntBagColors.ToString();
    }

    public string ResolvePart2(string[] inputs)
    {
        string myBagColor = "shiny gold";

        List<BaggageRule> rules = new();
        foreach (string input in inputs)
        {
            BaggageRule rule = BaggageRule_Parse(input);
            rules.Add(rule);
        }
        Dictionary<string, BaggageRule> dictRules = rules.ToDictionary(x => x.BagColor);

        int cnt = BaggageRule_CountChilds(myBagColor, dictRules);

        return cnt.ToString();
    }

    public class BaggageContainRule
    {
        public string BagColor { get; set; }
        public int Count { get; set; }
    }

    public class BaggageRule
    {
        public string BagColor { get; set; }

        public List<BaggageContainRule> Contain { get; set; }
    }

    public BaggageRule BaggageRule_Parse(string input)
    {
        string[] words = input.Split(' ');
        string status = "Parse Color 1";
        BaggageRule rule = new();
        rule.Contain = new List<BaggageContainRule>();
        BaggageContainRule containRule = null;
        string color1 = string.Empty;

        foreach (string word in words)
        {
            switch (status)
            {
                case "Parse Color 1":
                    color1 = word;
                    status = "Parse Color 2";
                    break;
                case "Parse Color 2":
                    rule.BagColor = string.Concat(color1, " ", word);
                    status = "Expect bags";
                    break;
                case "Expect bags":
                    if (word != "bags") { throw new Exception("Expecting bags"); }
                    status = "Expect contain";
                    break;
                case "Expect contain":
                    if (word != "contain") { throw new Exception("Expecting contain"); }
                    status = "Parse Contain count";
                    break;
                case "Parse Contain count":
                    if (word == "no") { status = "End"; break; }
                    containRule = new BaggageContainRule();
                    containRule.Count = Convert.ToInt32(word);
                    status = "Parse Contain color 1";
                    break;
                case "Parse Contain color 1":
                    color1 = word;
                    status = "Parse Contain color 2";
                    break;
                case "Parse Contain color 2":
                    containRule.BagColor = string.Concat(color1, " ", word);
                    rule.Contain.Add(containRule);
                    status = "Parse Contain continue";
                    break;
                case "Parse Contain continue":
                    if (word == "bag," || word == "bags,") { status = "Parse Contain count"; break; }
                    status = "End";
                    break;
                case "End":
                    break;
            }
        }
        return rule;
    }

    public int BaggageRule_CountChilds(string color, Dictionary<string, BaggageRule> dictRules)
    {
        int cnt = 0;
        BaggageRule rule = dictRules[color];
        foreach (BaggageContainRule containRule in rule.Contain)
        {
            cnt += (BaggageRule_CountChilds(containRule.BagColor, dictRules) + 1) * containRule.Count;
        }
        return cnt;
    }
}