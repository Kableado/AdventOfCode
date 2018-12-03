using System;
using System.IO;

namespace AdventOfCode2018
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            // Resolve Day01 input data
            Day01 day01 = new Day01();
            string[] lines = File.ReadAllLines("inputs/Day01.txt");
            string result = day01.ResolveDay01(lines);
            Console.WriteLine("Day01 Result: {0}", result);
            string resultPart2 = day01.ResolveDay01_Part2(lines);
            Console.WriteLine("Day01_Part2 Result: {0}", resultPart2);

            Console.Read();
        }
    }
}
