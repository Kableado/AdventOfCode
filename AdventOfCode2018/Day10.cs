using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2018;
/*
--- Day 10: The Stars Align ---

It's no use; your navigation system simply isn't capable of providing walking directions in the arctic circle, and certainly not in 1018.

The Elves suggest an alternative. In times like these, North Pole rescue operations will arrange points of light in the sky to guide missing Elves back to base. Unfortunately, the message is easy to miss: the points move slowly enough that it takes hours to align them, but have so much momentum that they only stay aligned for a second. If you blink at the wrong time, it might be hours before another message appears.

You can see these points of light floating in the distance, and record their position in the sky and their velocity, the relative change in position per second (your puzzle input). The coordinates are all given from your perspective; given enough time, those positions and velocities will move the points into a cohesive message!

Rather than wait, you decide to fast-forward the process and calculate what the points will eventually spell.

For example, suppose you note the following points:

position=< 9,  1> velocity=< 0,  2>
position=< 7,  0> velocity=<-1,  0>
position=< 3, -2> velocity=<-1,  1>
position=< 6, 10> velocity=<-2, -1>
position=< 2, -4> velocity=< 2,  2>
position=<-6, 10> velocity=< 2, -2>
position=< 1,  8> velocity=< 1, -1>
position=< 1,  7> velocity=< 1,  0>
position=<-3, 11> velocity=< 1, -2>
position=< 7,  6> velocity=<-1, -1>
position=<-2,  3> velocity=< 1,  0>
position=<-4,  3> velocity=< 2,  0>
position=<10, -3> velocity=<-1,  1>
position=< 5, 11> velocity=< 1, -2>
position=< 4,  7> velocity=< 0, -1>
position=< 8, -2> velocity=< 0,  1>
position=<15,  0> velocity=<-2,  0>
position=< 1,  6> velocity=< 1,  0>
position=< 8,  9> velocity=< 0, -1>
position=< 3,  3> velocity=<-1,  1>
position=< 0,  5> velocity=< 0, -1>
position=<-2,  2> velocity=< 2,  0>
position=< 5, -2> velocity=< 1,  2>
position=< 1,  4> velocity=< 2,  1>
position=<-2,  7> velocity=< 2, -2>
position=< 3,  6> velocity=<-1, -1>
position=< 5,  0> velocity=< 1,  0>
position=<-6,  0> velocity=< 2,  0>
position=< 5,  9> velocity=< 1, -2>
position=<14,  7> velocity=<-2,  0>
position=<-3,  6> velocity=< 2, -1>

Each line represents one point. Positions are given as <X, Y> pairs: X represents how far left (negative) or right (positive) the point appears, while Y represents how far up (negative) or down (positive) the point appears.

At 0 seconds, each point has the position given. Each second, each point's velocity is added to its position. So, a point with velocity <1, -2> is moving to the right, but is moving upward twice as quickly. If this point's initial position were <3, 9>, after 3 seconds, its position would become <6, 3>.

Over time, the points listed above would move like this:

Initially:
........#.............
................#.....
.........#.#..#.......
......................
#..........#.#.......#
...............#......
....#.................
..#.#....#............
.......#..............
......#...............
...#...#.#...#........
....#..#..#.........#.
.......#..............
...........#..#.......
#...........#.........
...#.......#..........

After 1 second:
......................
......................
..........#....#......
........#.....#.......
..#.........#......#..
......................
......#...............
....##.........#......
......#.#.............
.....##.##..#.........
........#.#...........
........#...#.....#...
..#...........#.......
....#.....#.#.........
......................
......................

After 2 seconds:
......................
......................
......................
..............#.......
....#..#...####..#....
......................
........#....#........
......#.#.............
.......#...#..........
.......#..#..#.#......
....#....#.#..........
.....#...#...##.#.....
........#.............
......................
......................
......................

After 3 seconds:
......................
......................
......................
......................
......#...#..###......
......#...#...#.......
......#...#...#.......
......#####...#.......
......#...#...#.......
......#...#...#.......
......#...#...#.......
......#...#..###......
......................
......................
......................
......................

After 4 seconds:
......................
......................
......................
............#.........
........##...#.#......
......#.....#..#......
.....#..##.##.#.......
.......##.#....#......
...........#....#.....
..............#.......
....#......#...#......
.....#.....##.........
...............#......
...............#......
......................
......................

After 3 seconds, the message appeared briefly: HI. Of course, your message will be much longer and will take many more seconds to appear.

What message will eventually appear in the sky?

--- Part Two ---

Good thing you didn't have to wait, because that would have taken a long time - much longer than the 3 seconds in the example above.

Impressed by your sub-hour communication capabilities, the Elves are curious: exactly how many seconds would they have needed to wait for that message to appear?

*/

public class Day10 : IDay
{
    public int Width { get; set; } = 65;
    public int Height { get; set; } = 12;

    public string ResolvePart1(string[] inputs)
    {
        LightField lightField = new(inputs);
        int t = lightField.SearchSmallerBoundindBox();
        string result = lightField.Render(t, Width, Height);
        return result;
    }

    public string ResolvePart2(string[] inputs)
    {
        LightField lightField = new(inputs);
        int t = lightField.SearchSmallerBoundindBox();
        return t.ToString();
    }

    public class LightPoint
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int VX { get; set; }
        public int VY { get; set; }

        public static LightPoint FromString(string strPoint)
        {
            string[] parts = strPoint.Split(new[] { "position=<", " ", ",", "> velocity=<", ">" }, StringSplitOptions.RemoveEmptyEntries);
            LightPoint point = new() {
                X = Convert.ToInt32(parts[0]),
                Y = Convert.ToInt32(parts[1]),
                VX = Convert.ToInt32(parts[2]),
                VY = Convert.ToInt32(parts[3]),
            };
            return point;
        }

        public int GetX(int t)
        {
            return X + (VX * t);
        }

        public int GetY(int t)
        {
            return Y + (VY * t);
        }
    }

    public class LightField
    {
        private readonly List<LightPoint> _points;

        public LightField(string[] strPoints)
        {
            _points = strPoints.Select(strPoint => LightPoint.FromString(strPoint)).ToList();
        }

        public int SearchSmallerBoundindBox()
        {
            int minHeight = int.MaxValue;
            int minT = 0;
            int missCount = 0;
            int t = 0;
            do
            {
                int minY = int.MaxValue;
                int maxY = int.MinValue;
                foreach (LightPoint point in _points)
                {
                    int y = point.GetY(t);
                    if (y < minY) { minY = y; }
                    if (y > maxY) { maxY = y; }
                }
                int height = (maxY - minY);
                if (height < minHeight)
                {
                    minHeight = height;
                    minT = t;
                    missCount = 0;
                }
                else
                {
                    missCount++;
                }

                t++;
            } while (missCount < 1000);
            return minT;
        }

        public string Render(int t, int width, int height)
        {
            int minX = int.MaxValue;
            int minY = int.MaxValue;
            int maxX = int.MinValue;
            int maxY = int.MinValue;

            foreach (LightPoint point in _points)
            {
                int x = point.GetX(t);
                int y = point.GetY(t);
                if (x < minX) { minX = x; }
                if (y < minY) { minY = y; }
                if (x > maxX) { maxX = x; }
                if (y > maxY) { maxY = y; }
            }
            minX--;
            minY--;
            maxX += 2;
            maxY += 2;

            double scaleX = (maxX - minX) / (double)width;
            double scaleY = (maxY - minY) / (double)height;

            int[,] field = new int[width, height];
            foreach (LightPoint point in _points)
            {
                int x = point.GetX(t);
                int y = point.GetY(t);
                x = (int)(((x - minX) / scaleX) + 0.5);
                y = (int)(((y - minY) / scaleY) + 0.5);
                if (x < 0 || x >= width) { continue; }
                if (y < 0 || y >= height) { continue; }
                field[x, y]++;
            }

            StringBuilder sb = new();
            for (int j = 0; j < height; j++)
            {
                sb.AppendLine();
                for (int i = 0; i < width; i++)
                {
                    if (field[i, j] > 0)
                    {
                        sb.Append("#");
                    }
                    else
                    {
                        sb.Append(".");
                    }
                }
            }
            return sb.ToString();
        }
    }
}