namespace AdventOfCode2023;

public interface IDay
{
    string ResolvePart1(string[] inputs);
    string ResolvePart2(string[] inputs);
}

public static class DayHelper
{
    public static void RunDay(int currentDayNumber)
    {
        Console.WriteLine($"Day {currentDayNumber:00}");
        Console.WriteLine("------");
        Console.WriteLine();

        IDay? currentDay = null;
        Type? dayType = Type.GetType($"AdventOfCode2023.Day{currentDayNumber:00}");
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