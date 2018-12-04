using System;
using System.IO;

namespace AdventOfCode2018
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int currentDay = 3;

            if (currentDay == 1)
            {
                // Resolve Day01
                Day01 day01 = new Day01();
                string[] linesDay01 = File.ReadAllLines("inputs/Day01.txt");
                string resultPart1 = day01.ResolvePart1(linesDay01);
                Console.WriteLine("Day01 Result Part1: {0}", resultPart1);
                string resultPart2 = day01.ResolvePart2(linesDay01);
                Console.WriteLine("Day01 Result Part2: {0}", resultPart2);
            }

            if (currentDay == 2)
            {
                // Resolve Day02
                Day02 day02 = new Day02();
                string[] linesDay02 = File.ReadAllLines("inputs/Day02.txt");
                string resultPart1 = day02.ResolvePart1(linesDay02);
                Console.WriteLine("Day02 Result Part1: {0}", resultPart1);
                string resultPart2 = day02.ResolvePart2(linesDay02);
                Console.WriteLine("Day02 Result Part2: {0}", resultPart2);
            }

            if (currentDay == 3)
            {
                // Resolve Day03
                Day03 day03 = new Day03();
                string[] linesDay03 = File.ReadAllLines("inputs/Day03.txt");
                string resultPart1 = day03.ResolvePart1(linesDay03);
                Console.WriteLine("Day03 Result Part1: {0}", resultPart1);
                string resultPart2 = day03.ResolvePart2(linesDay03);
                Console.WriteLine("Day03 Result Part2: {0}", resultPart2);
            }

            Console.Read();
        }
    }
}
