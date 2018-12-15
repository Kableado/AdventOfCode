using System;
using System.Collections.Generic;

namespace AdventOfCode2018
{
    /*
    --- Day 12: Subterranean Sustainability ---

    The year 518 is significantly more underground than your history books implied. Either that, or you've arrived in a vast cavern network under the North Pole.

    After exploring a little, you discover a long tunnel that contains a row of small pots as far as you can see to your left and right. A few of them contain plants - someone is trying to grow things in these geothermally-heated caves.

    The pots are numbered, with 0 in front of you. To the left, the pots are numbered -1, -2, -3, and so on; to the right, 1, 2, 3.... Your puzzle input contains a list of pots from 0 to the right and whether they do (#) or do not (.) currently contain a plant, the initial state. (No other pots currently contain plants.) For example, an initial state of #..##.... indicates that pots 0, 3, and 4 currently contain plants.

    Your puzzle input also contains some notes you find on a nearby table: someone has been trying to figure out how these plants spread to nearby pots. Based on the notes, for each generation of plants, a given pot has or does not have a plant based on whether that pot (and the two pots on either side of it) had a plant in the last generation. These are written as LLCRR => N, where L are pots to the left, C is the current pot being considered, R are the pots to the right, and N is whether the current pot will have a plant in the next generation. For example:

        A note like ..#.. => . means that a pot that contains a plant but with no plants within two pots of it will not have a plant in it during the next generation.
        A note like ##.## => . means that an empty pot with two plants on each side of it will remain empty in the next generation.
        A note like .##.# => # means that a pot has a plant in a given generation if, in the previous generation, there were plants in that pot, the one immediately to the left, and the one two pots to the right, but not in the ones immediately to the right and two to the left.

    It's not clear what these plants are for, but you're sure it's important, so you'd like to make sure the current configuration of plants is sustainable by determining what will happen after 20 generations.

    For example, given the following input:

    initial state: #..#.#..##......###...###

    ...## => #
    ..#.. => #
    .#... => #
    .#.#. => #
    .#.## => #
    .##.. => #
    .#### => #
    #.#.# => #
    #.### => #
    ##.#. => #
    ##.## => #
    ###.. => #
    ###.# => #
    ####. => #

    For brevity, in this example, only the combinations which do produce a plant are listed. (Your input includes all possible combinations.) Then, the next 20 generations will look like this:

                     1         2         3     
           0         0         0         0     
     0: ...#..#.#..##......###...###...........
     1: ...#...#....#.....#..#..#..#...........
     2: ...##..##...##....#..#..#..##..........
     3: ..#.#...#..#.#....#..#..#...#..........
     4: ...#.#..#...#.#...#..#..##..##.........
     5: ....#...##...#.#..#..#...#...#.........
     6: ....##.#.#....#...#..##..##..##........
     7: ...#..###.#...##..#...#...#...#........
     8: ...#....##.#.#.#..##..##..##..##.......
     9: ...##..#..#####....#...#...#...#.......
    10: ..#.#..#...#.##....##..##..##..##......
    11: ...#...##...#.#...#.#...#...#...#......
    12: ...##.#.#....#.#...#.#..##..##..##.....
    13: ..#..###.#....#.#...#....#...#...#.....
    14: ..#....##.#....#.#..##...##..##..##....
    15: ..##..#..#.#....#....#..#.#...#...#....
    16: .#.#..#...#.#...##...#...#.#..##..##...
    17: ..#...##...#.#.#.#...##...#....#...#...
    18: ..##.#.#....#####.#.#.#...##...##..##..
    19: .#..###.#..#.#.#######.#.#.#..#.#...#..
    20: .#....##....#####...#######....#.#..##.

    The generation is shown along the left, where 0 is the initial state. The pot numbers are shown along the top, where 0 labels the center pot, negative-numbered pots extend to the left, and positive pots extend toward the right. Remember, the initial state begins at pot 0, which is not the leftmost pot used in this example.

    After one generation, only seven plants remain. The one in pot 0 matched the rule looking for ..#.., the one in pot 4 matched the rule looking for .#.#., pot 9 matched .##.., and so on.

    In this example, after 20 generations, the pots shown as # contain plants, the furthest left of which is pot -2, and the furthest right of which is pot 34. Adding up all the numbers of plant-containing pots after the 20th generation produces 325.

    After 20 generations, what is the sum of the numbers of all pots which contain a plant?

    --- Part Two ---

    You realize that 20 generations aren't enough. After all, these plants will need to last another 1500 years to even reach your timeline, not to mention your future.

    After fifty billion (50000000000) generations, what is the sum of the numbers of all pots which contain a plant?

    */

    public class Day12 : IDay
    {
        public string ResolvePart1(string[] inputs)
        {
            Initialize(inputs);
            Simulate(20, true);
            return CalculateChecksum().ToString();
        }

        public string ResolvePart2(string[] inputs)
        {
            Initialize(inputs);
            Simulate(500, false);
            _offsetField -= (50000000000L - 500);
            return CalculateChecksum().ToString();
        }

        private class PlantRule
        {
            public bool Minus2 { get; set; }
            public bool Minus1 { get; set; }
            public bool Current { get; set; }
            public bool Plus1 { get; set; }
            public bool Plus2 { get; set; }

            public bool Result { get; set; }
        }

        private const int SideMargin = 5;
        private const int SideProcessMargin = 2;

        private List<bool> _initialState = new List<bool>();
        private List<PlantRule> _rules = new List<PlantRule>();
        private long _offsetField = 0;
        private bool[] _field;
        private bool[] _workField;

        private void Initialize(string[] inputs)
        {
            _initialState.Clear();
            foreach (char c in inputs[0].Substring("initial state: ".Length))
            {
                _initialState.Add(c == '#');
            }

            _rules.Clear();
            for (int i = 2; i < inputs.Length; i++)
            {
                if (string.IsNullOrEmpty(inputs[i])) { continue; }
                string[] parts = inputs[i].Split(new string[] { " => " }, StringSplitOptions.RemoveEmptyEntries);
                _rules.Add(new PlantRule
                {
                    Minus2 = (parts[0][0] == '#'),
                    Minus1 = (parts[0][1] == '#'),
                    Current = (parts[0][2] == '#'),
                    Plus1 = (parts[0][3] == '#'),
                    Plus2 = (parts[0][4] == '#'),

                    Result = (parts[1][0] == '#'),
                });
            }

            int maxSize = (SideMargin * 2) + _initialState.Count;
            _offsetField = SideMargin;
            _field = new bool[maxSize];
            _workField = new bool[maxSize];
            for (int i = 0; i < _initialState.Count; i++)
            {
                _field[i + _offsetField] = _initialState[i];
            }
        }

        private void SwapFields()
        {
            bool[] aux = _field;
            _field = _workField;
            _workField = aux;
        }

        private void RecenterField()
        {
            long leftSpace = 0;
            long rightSpace = 0;
            for (long i = 0; i < _field.Length; i++)
            {
                if (_field[i]) { break; }
                leftSpace++;
            }
            for (long i = _field.Length - 1; i >= 0; i--)
            {
                if (_field[i]) { break; }
                rightSpace++;
            }
            if (leftSpace == SideMargin && rightSpace == SideMargin) { return; }

            long oldSize = _field.Length;
            long newSize = oldSize + (SideMargin - leftSpace) + (SideMargin - rightSpace);
            long diffOffset = SideMargin - leftSpace;
            if (oldSize == newSize && diffOffset != 0)
            {
                if (diffOffset > 0)
                {
                    for (long i = 0; i < diffOffset; i++) { _workField[i] = false; }
                }
                else
                {
                    for (long i = 0; i < Math.Abs(diffOffset); i++) { _workField[(_workField.Length - 1) - i] = false; }
                }
                for (long i = 0; i < newSize; i++)
                {
                    long i2 = i - diffOffset;
                    if (i2 < 0 || i2 >= oldSize) { continue; }
                    _workField[i] = _field[i2];
                }
                SwapFields();
            }
            else
            {
                bool[] tempField = new bool[newSize];
                for (long i = 0; i < newSize; i++)
                {
                    long i2 = i - diffOffset;
                    if (i2 < 0 || i2 >= oldSize) { continue; }
                    tempField[i] = _field[i2];
                }
                _field = tempField;
                _workField = new bool[newSize];
            }
            _offsetField += diffOffset;
        }

        private void ShowField(long nGeneration)
        {
            Console.Write("({0:000}) [{1}]: ", nGeneration, _offsetField);
            foreach (bool plant in _field)
            {
                Console.Write(plant ? "#" : ".");
            }
            Console.WriteLine();
        }

        private static void SimulateGeneration(List<PlantRule> rules, bool[] field, bool[] finalField)
        {
            for (long i = SideProcessMargin; i < (field.Length - SideProcessMargin); i++)
            {
                bool minus2 = field[i - 2];
                bool minus1 = field[i - 1];
                bool current = field[i];
                bool plus1 = field[i + 1];
                bool plus2 = field[i + 2];

                bool result = false;
                foreach (PlantRule rule in rules)
                {
                    if (
                        rule.Minus2 == minus2 &&
                        rule.Minus1 == minus1 &&
                        rule.Current == current &&
                        rule.Plus1 == plus1 &&
                        rule.Plus2 == plus2 &&
                        true
                        )
                    {
                        result = rule.Result;
                        break;
                    }
                }
                finalField[i] = result;
            }
        }

        private void Simulate(long nGenerations, bool showEvolution = false)
        {
            for (int i = 0; i < nGenerations; i++)
            {
                RecenterField();
                if (showEvolution)
                {
                    ShowField(i);
                }
                SimulateGeneration(_rules, _field, _workField);
                SwapFields();
            }
            ShowField(nGenerations);
        }

        private long CalculateChecksum()
        {
            long sum = 0;
            for (long i = 0; i < _field.Length; i++)
            {
                if (_field[i])
                {
                    sum += (i - _offsetField);
                }
            }
            return sum;
        }
    }
}
