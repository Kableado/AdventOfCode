using System;
using System.IO;

namespace AdventOfCode2018
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int currentDay = 2;

            if (currentDay == 1)
            {
                // Resolve Day01
                Day01 day01 = new Day01();
                string[] linesDay01 = File.ReadAllLines("inputs/Day01.txt");
                string resultDay01 = day01.ResolveDay01(linesDay01);
                Console.WriteLine("Day01 Result: {0}", resultDay01);
                string resultDay01Part2 = day01.ResolveDay01_Part2(linesDay01);
                Console.WriteLine("Day01_Part2 Result: {0}", resultDay01Part2);
            }

            if (currentDay == 2)
            {
                // Resolve Day02
                Day02 day02 = new Day02();
                string[] linesDay02 = File.ReadAllLines("inputs/Day02.txt");
                string resultDay02 = day02.ResolveDay02(linesDay02);
                Console.WriteLine("Day02 Result: {0}", resultDay02);
            }

            Console.Read();
        }
    }
}
