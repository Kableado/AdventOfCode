using System;
using System.Collections.Generic;
using System.Linq;

/*

--- Day 6: Custom Customs ---

As your flight approaches the regional airport where you'll switch to a much larger plane, customs declaration forms are distributed to the passengers.

The form asks a series of 26 yes-or-no questions marked a through z. All you need to do is identify the questions for which anyone in your group answers "yes". Since your group is just you, this doesn't take very long.

However, the person sitting next to you seems to be experiencing a language barrier and asks if you can help. For each of the people in their group, you write down the questions for which they answer "yes", one per line. For example:

abcx
abcy
abcz

In this group, there are 6 questions to which anyone answered "yes": a, b, c, x, y, and z. (Duplicate answers to the same question don't count extra; each question counts at most once.)

Another group asks for your help, then another, and eventually you've collected answers from every group on the plane (your puzzle input). Each group's answers are separated by a blank line, and within each group, each person's answers are on a single line. For example:

abc

a
b
c

ab
ac

a
a
a
a

b

This list represents answers from five groups:

    The first group contains one person who answered "yes" to 3 questions: a, b, and c.
    The second group contains three people; combined, they answered "yes" to 3 questions: a, b, and c.
    The third group contains two people; combined, they answered "yes" to 3 questions: a, b, and c.
    The fourth group contains four people; combined, they answered "yes" to only 1 question, a.
    The last group contains one person who answered "yes" to only 1 question, b.

In this example, the sum of these counts is 3 + 3 + 3 + 1 + 1 = 11.

For each group, count the number of questions to which anyone answered "yes". What is the sum of those counts?



*/

namespace AdventOfCode2020
{
    public class Day06 : IDay
    {
        public string ResolvePart1(string[] inputs)
        {
            Dictionary<char, bool> groupMap = new Dictionary<char, bool>();
            List<Dictionary<char, bool>> groupMaps = new List<Dictionary<char, bool>>();
            foreach (string input in inputs)
            {
                if (string.IsNullOrEmpty(input) && groupMap.Count > 0)
                {
                    groupMaps.Add(groupMap);
                    groupMap = new Dictionary<char, bool>();
                    continue;
                }

                foreach (char c in input)
                {
                    if (groupMap.ContainsKey(c) == false)
                    {
                        groupMap.Add(c, true);
                    }
                }
            }
            if (groupMap.Count > 0)
            {
                groupMaps.Add(groupMap);
            }

            int total = groupMaps.Sum(groupMap => groupMap.Count);
            return total.ToString();

        }

        public string ResolvePart2(string[] inputs)
        {
            int groupCount = 0;
            Dictionary<char, int> groupMap = new Dictionary<char, int>();
            List<Tuple<int, Dictionary<char, int>>> groupMaps = new List<Tuple<int, Dictionary<char, int>>>();
            foreach (string input in inputs)
            {
                if (string.IsNullOrEmpty(input) && groupCount > 0)
                {
                    groupMaps.Add(new Tuple<int, Dictionary<char, int>>(groupCount, groupMap));
                    groupCount = 0;
                    groupMap = new Dictionary<char, int>();
                    continue;
                }

                groupCount++;
                foreach (char c in input)
                {
                    if (groupMap.ContainsKey(c) == false)
                    {
                        groupMap.Add(c, 1);
                    }
                    else
                    {
                        groupMap[c] = groupMap[c] + 1;
                    }
                }
            }
            if (groupCount > 0)
            {
                groupMaps.Add(new Tuple<int, Dictionary<char, int>>(groupCount, groupMap));
            }

            int total = groupMaps.Sum(group =>
            {
                return group.Item2.Count(p => p.Value == group.Item1);
            });
            return total.ToString();
        }
    }
}
