using System;
using System.IO;

namespace AdventOfCode2017
{
    public class Program
    {
        private static void Main(string[] args)
        {
            int currentDayNumber = 1;
            IDay currentDay = null;

            switch (currentDayNumber)
            {
                case 1: currentDay = new Day01(); break;
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
