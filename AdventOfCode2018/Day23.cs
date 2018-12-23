using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2018
{
    /*
    --- Day 23: Experimental Emergency Teleportation ---

    Using your torch to search the darkness of the rocky cavern, you finally locate the man's friend: a small reindeer.

    You're not sure how it got so far in this cave. It looks sick - too sick to walk - and too heavy for you to carry all the way back. Sleighs won't be invented for another 1500 years, of course.

    The only option is experimental emergency teleportation.

    You hit the "experimental emergency teleportation" button on the device and push I accept the risk on no fewer than 18 different warning messages. Immediately, the device deploys hundreds of tiny nanobots which fly around the cavern, apparently assembling themselves into a very specific formation. The device lists the X,Y,Z position (pos) for each nanobot as well as its signal radius (r) on its tiny screen (your puzzle input).

    Each nanobot can transmit signals to any integer coordinate which is a distance away from it less than or equal to its signal radius (as measured by Manhattan distance). Coordinates a distance away of less than or equal to a nanobot's signal radius are said to be in range of that nanobot.

    Before you start the teleportation process, you should determine which nanobot is the strongest (that is, which has the largest signal radius) and then, for that nanobot, the total number of nanobots that are in range of it, including itself.

    For example, given the following nanobots:

    pos=<0,0,0>, r=4
    pos=<1,0,0>, r=1
    pos=<4,0,0>, r=3
    pos=<0,2,0>, r=1
    pos=<0,5,0>, r=3
    pos=<0,0,3>, r=1
    pos=<1,1,1>, r=1
    pos=<1,1,2>, r=1
    pos=<1,3,1>, r=1

    The strongest nanobot is the first one (position 0,0,0) because its signal radius, 4 is the largest. Using that nanobot's location and signal radius, the following nanobots are in or out of range:

        The nanobot at 0,0,0 is distance 0 away, and so it is in range.
        The nanobot at 1,0,0 is distance 1 away, and so it is in range.
        The nanobot at 4,0,0 is distance 4 away, and so it is in range.
        The nanobot at 0,2,0 is distance 2 away, and so it is in range.
        The nanobot at 0,5,0 is distance 5 away, and so it is not in range.
        The nanobot at 0,0,3 is distance 3 away, and so it is in range.
        The nanobot at 1,1,1 is distance 3 away, and so it is in range.
        The nanobot at 1,1,2 is distance 4 away, and so it is in range.
        The nanobot at 1,3,1 is distance 5 away, and so it is not in range.

    In this example, in total, 7 nanobots are in range of the nanobot with the largest signal radius.

    Find the nanobot with the largest signal radius. How many nanobots are in range of its signals?

    */

    public class Day23 : IDay
    {
        public string ResolvePart1(string[] inputs)
        {
            List<NanoBot> nanoBots = inputs
                .Select(strInput => NanoBot.FromString(strInput))
                .Where(nanoBot => nanoBot != null)
                .ToList();
            NanoBot bestNanoBot = nanoBots.OrderBy(nanoBot => nanoBot.Range).LastOrDefault();
            int countInRange = nanoBots.Where(nanoBot => bestNanoBot.InRange(nanoBot)).Count();
            return countInRange.ToString();
        }

        public string ResolvePart2(string[] inputs)
        {
            return null;
        }

        public class NanoBot
        {
            public long X { get; set; }
            public long Y { get; set; }
            public long Z { get; set; }
            public long Range { get; set; }

            public static NanoBot FromString(string strInput)
            {
                string[] parts = strInput.Split(new string[] { "pos=<", ",", ">, r=", }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 4) { return null; }
                NanoBot nanoBot = new NanoBot
                {
                    X = Convert.ToInt64(parts[0]),
                    Y = Convert.ToInt64(parts[1]),
                    Z = Convert.ToInt64(parts[2]),
                    Range = Convert.ToInt64(parts[3]),
                };
                return nanoBot;
            }

            public long ManhattanDistance(NanoBot other)
            {
                long distance = Math.Abs(X - other.X) + Math.Abs(Y - other.Y) + Math.Abs(Z - other.Z);
                return distance;
            }

            public bool InRange(NanoBot other)
            {
                long distance = ManhattanDistance(other);
                return distance <= Range;
            }
        }
    }
}
