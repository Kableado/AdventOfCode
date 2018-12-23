using System;
using System.Linq;
using System.Text;

namespace AdventOfCode2018
{
    /*
     * 
    --- Day 14: Chocolate Charts ---

    You finally have a chance to look at all of the produce moving around. Chocolate, cinnamon, mint, chili peppers, nutmeg, vanilla... the Elves must be growing these plants to make hot chocolate! As you realize this, you hear a conversation in the distance. When you go to investigate, you discover two Elves in what appears to be a makeshift underground kitchen/laboratory.

    The Elves are trying to come up with the ultimate hot chocolate recipe; they're even maintaining a scoreboard which tracks the quality score (0-9) of each recipe.

    Only two recipes are on the board: the first recipe got a score of 3, the second, 7. Each of the two Elves has a current recipe: the first Elf starts with the first recipe, and the second Elf starts with the second recipe.

    To create new recipes, the two Elves combine their current recipes. This creates new recipes from the digits of the sum of the current recipes' scores. With the current recipes' scores of 3 and 7, their sum is 10, and so two new recipes would be created: the first with score 1 and the second with score 0. If the current recipes' scores were 2 and 3, the sum, 5, would only create one recipe (with a score of 5) with its single digit.

    The new recipes are added to the end of the scoreboard in the order they are created. So, after the first round, the scoreboard is 3, 7, 1, 0.

    After all new recipes are added to the scoreboard, each Elf picks a new current recipe. To do this, the Elf steps forward through the scoreboard a number of recipes equal to 1 plus the score of their current recipe. So, after the first round, the first Elf moves forward 1 + 3 = 4 times, while the second Elf moves forward 1 + 7 = 8 times. If they run out of recipes, they loop back around to the beginning. After the first round, both Elves happen to loop around until they land on the same recipe that they had in the beginning; in general, they will move to different recipes.

    Drawing the first Elf as parentheses and the second Elf as square brackets, they continue this process:

    (3)[7]
    (3)[7] 1  0 
     3  7  1 [0](1) 0 
     3  7  1  0 [1] 0 (1)
    (3) 7  1  0  1  0 [1] 2 
     3  7  1  0 (1) 0  1  2 [4]
     3  7  1 [0] 1  0 (1) 2  4  5 
     3  7  1  0 [1] 0  1  2 (4) 5  1 
     3 (7) 1  0  1  0 [1] 2  4  5  1  5 
     3  7  1  0  1  0  1  2 [4](5) 1  5  8 
     3 (7) 1  0  1  0  1  2  4  5  1  5  8 [9]
     3  7  1  0  1  0  1 [2] 4 (5) 1  5  8  9  1  6 
     3  7  1  0  1  0  1  2  4  5 [1] 5  8  9  1 (6) 7 
     3  7  1  0 (1) 0  1  2  4  5  1  5 [8] 9  1  6  7  7 
     3  7 [1] 0  1  0 (1) 2  4  5  1  5  8  9  1  6  7  7  9 
     3  7  1  0 [1] 0  1  2 (4) 5  1  5  8  9  1  6  7  7  9  2 

    The Elves think their skill will improve after making a few recipes (your puzzle input). However, that could take ages; you can speed this up considerably by identifying the scores of the ten recipes after that. For example:

        If the Elves think their skill will improve after making 9 recipes, the scores of the ten recipes after the first nine on the scoreboard would be 5158916779 (highlighted in the last line of the diagram).
        After 5 recipes, the scores of the next ten would be 0124515891.
        After 18 recipes, the scores of the next ten would be 9251071085.
        After 2018 recipes, the scores of the next ten would be 5941429882.

    What are the scores of the ten recipes immediately after the number of recipes in your puzzle input?

    --- Part Two ---

    As it turns out, you got the Elves' plan backwards. They actually want to know how many recipes appear on the scoreboard to the left of the first recipes whose scores are the digits from your puzzle input.

        51589 first appears after 9 recipes.
        01245 first appears after 5 recipes.
        92510 first appears after 18 recipes.
        59414 first appears after 2018 recipes.

    How many recipes appear on the scoreboard to the left of the score sequence in your puzzle input?

    */

    public class Day14 : IDay
    {
        private long _numRecipes = 0;
        private long _numRecipesAllocated = 0;
        private byte[] _recipes = null;
        private long _idxA = 0;
        private long _idxB = 0;
        private long _searchSkip = 0;

        private void Init(long hintAllocation = 128)
        {
            _numRecipes = 2;
            _numRecipesAllocated = hintAllocation;
            _recipes = new byte[_numRecipesAllocated];
            _recipes[0] = 3;
            _recipes[1] = 7;
            _idxA = 0;
            _idxB = 1;
            _searchSkip = 0;
        }

        private void Step()
        {
            if (_numRecipes + 2 >= _numRecipesAllocated)
            {
                _numRecipesAllocated *= 2;
                byte[] newRecipes = new byte[_numRecipesAllocated];
                for (int i = 0; i < _numRecipes; i++)
                {
                    newRecipes[i] = _recipes[i];
                }
                _recipes = newRecipes;
            }
            int newRecipe = _recipes[_idxA] + _recipes[_idxB];
            if (newRecipe >= 10)
            {
                _recipes[_numRecipes] = 1;
                _recipes[_numRecipes + 1] = (byte)(newRecipe % 10);
                _numRecipes += 2;
            }
            else
            {
                _recipes[_numRecipes] = (byte)(newRecipe % 10);
                _numRecipes += 1;
            }
            _idxA = (_idxA + _recipes[_idxA] + 1) % _numRecipes;
            _idxB = (_idxB + _recipes[_idxB] + 1) % _numRecipes;
        }

        private void Print()
        {
            Console.WriteLine();
            for (int i = 0; i < _numRecipes; i++)
            {
                if (i == _idxA)
                {
                    Console.Write(" ({0})", _recipes[i]);
                }
                else if (i == _idxB)
                {
                    Console.Write(" [{0}]", _recipes[i]);
                }
                else
                {
                    Console.Write("  {0} ", _recipes[i]);
                }
            }
        }

        private long SearchPattern(byte[] pattern)
        {
            long i;
            for (i = _searchSkip; i < (_numRecipes - pattern.Length); i++)
            {
                long j;
                for (j = 0; j < pattern.Length; j++)
                {
                    if (_recipes[i + j] != pattern[j])
                    {
                        break;
                    }
                }
                if (j == pattern.Length)
                {
                    return i;
                }
            }
            _searchSkip = i - 1;
            if (_searchSkip < 0) { _searchSkip = 0; }
            return -1;
        }

        private bool Show { get; set; } = false;

        public string ResolvePart1(string[] inputs)
        {
            int numSkipRecipes = Convert.ToInt32(inputs[0]);
            Init(numSkipRecipes + 20);
            do
            {
                if (Show) { Print(); }
                Step();
            } while (_numRecipes < (numSkipRecipes + 10));

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                sb.Append(_recipes[numSkipRecipes + i]);
            }
            return sb.ToString();
        }

        public string ResolvePart2(string[] inputs)
        {
            byte[] pattern = inputs[0].Select(c => (byte)(c - '0')).ToArray();
            Init();
            long position = -1;
            do
            {
                if (Show) { Print(); }
                Step();
                position = SearchPattern(pattern);
            } while (position < 0);
            return position.ToString();
        }
    }
}
