using System;
using System.IO;

namespace AdventOfCode2017;

public class Program
{
    private static void Main()
    {
        int currentDayNumber = 3;
        IDay currentDay = null;

        switch (currentDayNumber)
        {
            case 1: currentDay = new Day01(); break;
            case 2: currentDay = new Day02(); break;
            case 3: currentDay = new Day03(); break;
        }

        string[] linesDay = File.ReadAllLines($"inputs/Day{currentDayNumber:00}.txt");
        string resultPart1 = currentDay.ResolvePart1(linesDay);
        Console.WriteLine("Day{1:00} Result Part1: {0}", resultPart1, currentDayNumber);
        string resultPart2 = currentDay.ResolvePart2(linesDay);
        Console.WriteLine("Day{1:00} Result Part2: {0}", resultPart2, currentDayNumber);

        Console.Read();
    }
}