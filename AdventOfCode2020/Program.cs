using System;
using System.IO;

namespace AdventOfCode2020
{
    class Program
    {
        static void Main(string[] args)
        {
            int currentDayNumber = 2;
            IDay currentDay = null;

            switch (currentDayNumber)
            {
                case 1: currentDay = new Day01(); break;
                case 2: currentDay = new Day02(); break;
            }

            Console.WriteLine(string.Format("Day {0:00}", currentDayNumber));
            Console.WriteLine("------");
            Console.WriteLine();
            string[] linesDay = File.ReadAllLines(string.Format("inputs/Day{0:00}.txt", currentDayNumber));
            try
            {
                string resultPart1 = currentDay.ResolvePart1(linesDay);
                Console.WriteLine("Day{1:00} Result Part1: {0}", resultPart1, currentDayNumber);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            try
            {
                string resultPart2 = currentDay.ResolvePart2(linesDay);
                Console.WriteLine("Day{1:00} Result Part2: {0}", resultPart2, currentDayNumber);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            Console.Read();
        }
    }
}
