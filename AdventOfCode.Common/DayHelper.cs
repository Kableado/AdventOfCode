namespace AdventOfCode.Common;

public static class DayHelper
{
    public static void RunDay(string eventName, int dayNumber)
    {
        Console.WriteLine($"Day {dayNumber:00}");
        Console.WriteLine("------");
        Console.WriteLine();

        IDay? currentDay = null;
        Type? dayType = Type.GetType($"{eventName}.Day{dayNumber:00}");
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

        string[] linesDay = File.ReadAllLines($"inputs/Day{dayNumber:00}.txt");
        try
        {
            string resultPart1 = currentDay.ResolvePart1(linesDay);
            Console.WriteLine("Day{1:00} Result Part1: {0}", resultPart1, dayNumber);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
        }
        try
        {
            string resultPart2 = currentDay.ResolvePart2(linesDay);
            Console.WriteLine("Day{1:00} Result Part2: {0}", resultPart2, dayNumber);
        }
        catch (Exception ex)
        {
            Console.WriteLine("!!!!!!!");
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
        }
    }
}