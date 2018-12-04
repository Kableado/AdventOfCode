using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2018
{
    /*
    --- Day 3: No Matter How You Slice It ---

    The Elves managed to locate the chimney-squeeze prototype fabric for Santa's suit (thanks to someone who helpfully wrote its box IDs on the wall of the warehouse in the middle of the night). Unfortunately, anomalies are still affecting them - nobody can even agree on how to cut the fabric.

    The whole piece of fabric they're working on is a very large square - at least 1000 inches on each side.

    Each Elf has made a claim about which area of fabric would be ideal for Santa's suit. All claims have an ID and consist of a single rectangle with edges parallel to the edges of the fabric. Each claim's rectangle is defined as follows:

        The number of inches between the left edge of the fabric and the left edge of the rectangle.
        The number of inches between the top edge of the fabric and the top edge of the rectangle.
        The width of the rectangle in inches.
        The height of the rectangle in inches.

    A claim like #123 @ 3,2: 5x4 means that claim ID 123 specifies a rectangle 3 inches from the left edge, 2 inches from the top edge, 5 inches wide, and 4 inches tall. Visually, it claims the square inches of fabric represented by # (and ignores the square inches of fabric represented by .) in the diagram below:

    ...........
    ...........
    ...#####...
    ...#####...
    ...#####...
    ...#####...
    ...........
    ...........
    ...........

    The problem is that many of the claims overlap, causing two or more claims to cover part of the same areas. For example, consider the following claims:

    #1 @ 1,3: 4x4
    #2 @ 3,1: 4x4
    #3 @ 5,5: 2x2

    Visually, these claim the following areas:

    ........
    ...2222.
    ...2222.
    .11XX22.
    .11XX22.
    .111133.
    .111133.
    ........

    The four square inches marked with X are claimed by both 1 and 2. (Claim 3, while adjacent to the others, does not overlap either of them.)

    If the Elves all proceed with their own plans, none of them will have enough fabric. How many square inches of fabric are within two or more claims?

    --- Part Two ---

    Amidst the chaos, you notice that exactly one claim doesn't overlap by even a single square inch of fabric with any other claim. If you can somehow draw attention to it, maybe the Elves will be able to make Santa's suit after all!

    For example, in the claims above, only claim 3 is intact after all claims are made.

    What is the ID of the only claim that doesn't overlap?

    */

    public class Day03
    {
        public string ResolvePart1(string[] inputs)
        {
            List<Claim> claims = inputs.Select(i => Claim.FromString(i)).ToList();

            const int edgeSize = 1000;
            int[,] cells = new int[edgeSize, edgeSize];

            foreach (Claim claim in claims)
            {
                for (int j = 0; j < claim.Height; j++)
                {
                    for (int i = 0; i < claim.Width; i++)
                    {
                        cells[claim.Left + i, claim.Top + j]++;
                    }
                }
            }

            int overlappedArea = 0;
            for (int j = 0; j < edgeSize; j++)
            {
                for (int i = 0; i < edgeSize; i++)
                {
                    if (cells[i, j] > 1)
                    {
                        overlappedArea++;
                    }
                }
            }
            return overlappedArea.ToString();
        }

        public string ResolvePart2(string[] inputs)
        {
            List<Claim> claims = inputs.Select(i => Claim.FromString(i)).ToList();

            Claim unoverlappingClaim = null;
            for (int i = 0; i < claims.Count; i++)
            {
                bool overlaps = false;
                for (int j = 0; j < claims.Count; j++)
                {
                    if (i == j) { continue; }
                    if (Claim.Overlaps(claims[i], claims[j]))
                    {
                        overlaps = true;
                        break;
                    }
                }
                if (overlaps == false)
                {
                    unoverlappingClaim = claims[i];
                    break;
                }
            }
            return unoverlappingClaim.ID.ToString();

        }

        public class Claim
        {
            public int ID { get; set; }

            public int Left { get; set; }
            public int Top { get; set; }

            public int Width { get; set; }
            public int Height { get; set; }

            public int MinX { get { return Left; } }
            public int MaxX { get { return Left + Width; } }

            public int MinY { get { return Top; } }
            public int MaxY { get { return Top + Height; } }

            public int GetArea()
            {
                return Width * Height;
            }

            public static Claim FromString(string strClaim)
            {
                Claim claim = new Claim();
                string[] parts = strClaim.Split(new string[] { " @ ", ",", ": ", "x", }, StringSplitOptions.None);
                claim.ID = Convert.ToInt32(parts[0].Substring(1));
                claim.Left = Convert.ToInt32(parts[1]);
                claim.Top = Convert.ToInt32(parts[2]);
                claim.Width = Convert.ToInt32(parts[3]);
                claim.Height = Convert.ToInt32(parts[4]);
                return claim;
            }

            public static bool Overlaps(Claim claim1, Claim claim2)
            {
                if (claim1.MinX <= claim2.MaxX &&
                    claim2.MinX <= claim1.MaxX &&
                    claim1.MinY <= claim2.MaxY &&
                    claim2.MinY <= claim1.MaxY)
                {
                    int minX = Math.Max(claim1.MinX, claim2.MinX);
                    int maxX = Math.Min(claim1.MaxX, claim2.MaxX);
                    int minY = Math.Max(claim1.MinY, claim2.MinY);
                    int maxY = Math.Min(claim1.MaxY, claim2.MaxY);
                    int width = maxX - minX;
                    int height = maxY - minY;
                    if (width <= 0 || height <= 0) { return false; }
                    return true;
                }

                return false;
            }
        }
    }


}
