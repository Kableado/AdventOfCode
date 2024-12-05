namespace AdventOfCode2024;

/*
--- Day 4: Ceres Search ---

"Looks like the Chief's not here. Next!" One of The Historians pulls out a device and pushes the only button on it. After a brief flash, you recognize the interior of the Ceres monitoring station!

As the search for the Chief continues, a small Elf who lives on the station tugs on your shirt; she'd like to know if you could help her with her word search (your puzzle input). She only has to find one word: XMAS.

This word search allows words to be horizontal, vertical, diagonal, written backwards, or even overlapping other words. It's a little unusual, though, as you don't merely need to find one instance of XMAS - you need to find all of them. Here are a few ways XMAS might appear, where irrelevant characters have been replaced with .:

..X...
.SAMX.
.A..A.
XMAS.S
.X....

The actual word search will be full of letters instead. For example:

MMMSXXMASM
MSAMXMSMSA
AMXSXMAAMM
MSAMASMSMX
XMASAMXAMM
XXAMMXXAMA
SMSMSASXSS
SAXAMASAAA
MAMMMXMMMM
MXMXAXMASX

In this word search, XMAS occurs a total of 18 times; here's the same word search again, but where letters not involved in any XMAS have been replaced with .:

....XXMAS.
.SAMXMS...
...S..A...
..A.A.MS.X
XMASAMX.MM
X.....XA.A
S.S.S.S.SS
.A.A.A.A.A
..M.M.M.MM
.X.X.XMASX

Take a look at the little Elf's word search. How many times does XMAS appear?

*/
public class Day04 : IDay
{
    public string ResolvePart1(string[] inputs)
    {
        char[,] grid = ConvertToGrid(inputs);

        const string word = "XMAS";
        List<(int dx, int dy)> directions = [
            (0, -1),
            (1, 0),
            (0, 1),
            (-1, 0),
            (-1, -1),
            (1, -1),
            (-1, 1),
            (1, 1),
        ];

        int totalMatches = 0;
        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                for (int i = 0; i < directions.Count; i++)
                {
                    if (CheckMatch(grid, word, x, y, directions[i].dx, directions[i].dy))
                    {
                        totalMatches++;
                    }
                }
            }
        }
        return totalMatches.ToString();
    }

    private static char[,] ConvertToGrid(string[] inputs)
    {
        int height = inputs.Count(s => s.Length > 0);
        int width = inputs.Where(s => s.Length > 0).Select(s => s.Length).Min();
        char[,] grid = new char[width, height];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                grid[x, y] = inputs[y][x];
            }
        }

        return grid;
    }

    private static bool CheckMatch(char[,] grid, string word, int x, int y, int dx, int dy)
    {
        int matched = 0;
        if (x < 0 || x >= grid.GetLength(0) || y < 0 || y >= grid.GetLength(1)) { return false; }
        while (grid[x, y] == word[matched])
        {
            matched++;
            if (matched == word.Length) { return true; }
            x += dx;
            y += dy;
            if (x < 0 || x >= grid.GetLength(0) || y < 0 || y >= grid.GetLength(1)) { break; }
        }
        return false;
    }

    public string ResolvePart2(string[] inputs)
    {
        char[,] grid = ConvertToGrid(inputs);

        const string word = "MAS";

        int totalMatches = 0;
        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                if (
                    (CheckMatch(grid, word, x - 1, y - 1, 1, 1) && CheckMatch(grid, word, x - 1, y + 1, 1, -1)) ||
                    (CheckMatch(grid, word, x - 1, y - 1, 1, 1) && CheckMatch(grid, word, x + 1, y - 1, -1, 1)) ||
                    (CheckMatch(grid, word, x + 1, y + 1, -1, -1) && CheckMatch(grid, word, x - 1, y + 1, 1, -1)) ||
                    (CheckMatch(grid, word, x + 1, y + 1, -1, -1) && CheckMatch(grid, word, x + 1, y - 1, -1, 1))
                )
                {
                    totalMatches++;
                }
            }
        }
        return totalMatches.ToString();
    }
}