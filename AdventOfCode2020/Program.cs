using System;
using System.IO;

namespace AdventOfCode2020;

class Program
{
    static void Main()
    {
        int currentDayNumber = 0;

        DateTime date = DateTime.UtcNow.AddHours(-5);
        if (date.Month == 12 && currentDayNumber == 0)
        {
            currentDayNumber = date.Day;
        }

        RunDay(currentDayNumber);

        Console.Read();
    }

    public static void RunDay(int currentDayNumber)
    {
        Console.WriteLine($"Day {currentDayNumber:00}");
        Console.WriteLine("------");
        Console.WriteLine();

        IDay currentDay = null;
        Type dayType = Type.GetType($"AdventOfCode2020.Day{currentDayNumber:00}");
        if (dayType != null)
        {
            currentDay = Activator.CreateInstance(dayType) as IDay;
        }
        if (currentDay == null)
        {
            Console.WriteLine("!!!!!!!");
            Console.WriteLine("Day implementation not found.");
            return;
        }

        string[] linesDay = File.ReadAllLines($"inputs/Day{currentDayNumber:00}.txt");
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
            Console.WriteLine("!!!!!!!");
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
        }
    }
}