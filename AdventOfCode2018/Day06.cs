using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2018
{
    /*
    --- Day 6: Chronal Coordinates ---

    The device on your wrist beeps several times, and once again you feel like you're falling.

    "Situation critical," the device announces. "Destination indeterminate. Chronal interference detected. Please specify new target coordinates."

    The device then produces a list of coordinates (your puzzle input). Are they places it thinks are safe or dangerous? It recommends you check manual page 729. The Elves did not give you a manual.

    If they're dangerous, maybe you can minimize the danger by finding the coordinate that gives the largest distance from the other points.

    Using only the Manhattan distance, determine the area around each coordinate by counting the number of integer X,Y locations that are closest to that coordinate (and aren't tied in distance to any other coordinate).

    Your goal is to find the size of the largest area that isn't infinite. For example, consider the following list of coordinates:

    1, 1
    1, 6
    8, 3
    3, 4
    5, 5
    8, 9

    If we name these coordinates A through F, we can draw them on a grid, putting 0,0 at the top left:

    ..........
    .A........
    ..........
    ........C.
    ...D......
    .....E....
    .B........
    ..........
    ..........
    ........F.

    This view is partial - the actual grid extends infinitely in all directions. Using the Manhattan distance, each location's closest coordinate can be determined, shown here in lowercase:

    aaaaa.cccc
    aAaaa.cccc
    aaaddecccc
    aadddeccCc
    ..dDdeeccc
    bb.deEeecc
    bBb.eeee..
    bbb.eeefff
    bbb.eeffff
    bbb.ffffFf

    Locations shown as . are equally far from two or more coordinates, and so they don't count as being closest to any.

    In this example, the areas of coordinates A, B, C, and F are infinite - while not shown here, their areas extend forever outside the visible grid. However, the areas of coordinates D and E are finite: D is closest to 9 locations, and E is closest to 17 (both including the coordinate's location itself). Therefore, in this example, the size of the largest area is 17.

    What is the size of the largest area that isn't infinite?

    */
    public class Day06
    {
        public string ResolvePart1(string[] inputs)
        {
            List<ChronoPoint> points = inputs
                .Where(input => string.IsNullOrEmpty(input) == false)
                .Select(input => ChronoPoint.FromString(input))
                .ToList();
            Dictionary<int, int> pointsAreas = new Dictionary<int, int>();
            for (int i = 0; i < points.Count; i++)
            {
                pointsAreas.Add(i, 0);
            }
            
            int minX = points.Min(p => p.X) - 1;
            int maxX = points.Max(p => p.X) + 1;
            int minY = points.Min(p => p.Y) - 1;
            int maxY = points.Max(p => p.Y) + 1;

            ChronoPoint samplingPoint = new ChronoPoint();
            for(int i=minX; i <= maxX; i++)
            {
                for(int j = minY; j <= maxY; j++)
                {
                    samplingPoint.X = i;
                    samplingPoint.Y = j;
                    bool isEdge = i == minX || i == maxX || j == minY || j == maxY;

                    int idxMin = -1;
                    int distanceMin = int.MaxValue;
                    for (int idx = 0; idx < points.Count; idx++)
                    {
                        int distance = ChronoPoint.ManhattanDistance(samplingPoint, points[idx]);
                        if (distance == distanceMin)
                        {
                            idxMin = -1;
                        }
                        else if (distance < distanceMin)
                        {
                            distanceMin = distance;
                            idxMin = idx;
                        }
                    }
                    if (idxMin < 0) { continue; }

                    if (isEdge)
                    {
                        pointsAreas[idxMin] = -1;
                    }
                    else
                    {
                        int previousArea = pointsAreas[idxMin];
                        if (previousArea >= 0)
                        {
                            pointsAreas[idxMin] = previousArea + 1;
                        }
                    }
                }
            }

            int maxArea = pointsAreas.Max(p => p.Value);
            return maxArea.ToString();
        }

        public string ResolvePart2(string[] inputs)
        {
            return null;
        }
    }

    public class ChronoPoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public static ChronoPoint FromString(string strPoint)
        {
            if (string.IsNullOrEmpty(strPoint)) { return null; }
            string[] parts = strPoint.Split(new string[] { ", ", }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2) { return null; }
            ChronoPoint point = new ChronoPoint
            {
                X = Convert.ToInt32(parts[0]),
                Y = Convert.ToInt32(parts[1]),
            };
            return point;
        }

        public static int ManhattanDistance(ChronoPoint p0, ChronoPoint p1)
        {
            int distance = Math.Abs(p1.X - p0.X) + Math.Abs(p1.Y - p0.Y);
            return distance;
        }
    }
}
