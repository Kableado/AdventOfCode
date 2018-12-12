using System;
using System.IO;

namespace AdventOfCode2018
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int currentDayNumber = 10;
            IDay currentDay = null;

            switch (currentDayNumber)
            {
                case 1: currentDay = new Day01(); break;
                case 2: currentDay = new Day02(); break;
                case 3: currentDay = new Day03(); break;
                case 4: currentDay = new Day04(); break;
                case 5: currentDay = new Day05(); break;
                case 6: currentDay = new Day06(); break;
                case 7: currentDay = new Day07(); break;
                case 8: currentDay = new Day08(); break;
                case 9: currentDay = new Day09(); break;
                case 10: currentDay = new Day10(); break;
            }

            string[] linesDay = File.ReadAllLines(string.Format("inputs/Day{0:00}.txt", currentDayNumber));
            string resultPart1 = currentDay.ResolvePart1(linesDay);
            Console.WriteLine("Day{1:00} Result Part1: {0}", resultPart1, currentDayNumber);
            string resultPart2 = currentDay.ResolvePart2(linesDay);
            Console.WriteLine("Day{1:00} Result Part2: {0}", resultPart2, currentDayNumber);

            Console.Read();
        }
    }
}
