namespace AdventOfCode2023;

/*

--- Day 24: Never Tell Me The Odds ---

It seems like something is going wrong with the snow-making process. Instead of forming snow, the water that's been absorbed into the air seems to be forming hail!

Maybe there's something you can do to break up the hailstones?

Due to strong, probably-magical winds, the hailstones are all flying through the air in perfectly linear trajectories. You make a note of each hailstone's position and velocity (your puzzle input). For example:

19, 13, 30 @ -2,  1, -2
18, 19, 22 @ -1, -1, -2
20, 25, 34 @ -2, -2, -4
12, 31, 28 @ -1, -2, -1
20, 19, 15 @  1, -5, -3

Each line of text corresponds to the position and velocity of a single hailstone. The positions indicate where the hailstones are right now (at time 0). The velocities are constant and indicate exactly how far each hailstone will move in one nanosecond.

Each line of text uses the format px py pz @ vx vy vz. For instance, the hailstone specified by 20, 19, 15 @ 1, -5, -3 has initial X position 20, Y position 19, Z position 15, X velocity 1, Y velocity -5, and Z velocity -3. After one nanosecond, the hailstone would be at 21, 14, 12.

Perhaps you won't have to do anything. How likely are the hailstones to collide with each other and smash into tiny ice crystals?

To estimate this, consider only the X and Y axes; ignore the Z axis. Looking forward in time, how many of the hailstones' paths will intersect within a test area? (The hailstones themselves don't have to collide, just test for intersections between the paths they will trace.)

In this example, look for intersections that happen with an X and Y position each at least 7 and at most 27; in your actual data, you'll need to check a much larger test area. Comparing all pairs of hailstones' future paths produces the following results:

Hailstone A: 19, 13, 30 @ -2, 1, -2
Hailstone B: 18, 19, 22 @ -1, -1, -2
Hailstones' paths will cross inside the test area (at x=14.333, y=15.333).

Hailstone A: 19, 13, 30 @ -2, 1, -2
Hailstone B: 20, 25, 34 @ -2, -2, -4
Hailstones' paths will cross inside the test area (at x=11.667, y=16.667).

Hailstone A: 19, 13, 30 @ -2, 1, -2
Hailstone B: 12, 31, 28 @ -1, -2, -1
Hailstones' paths will cross outside the test area (at x=6.2, y=19.4).

Hailstone A: 19, 13, 30 @ -2, 1, -2
Hailstone B: 20, 19, 15 @ 1, -5, -3
Hailstones' paths crossed in the past for hailstone A.

Hailstone A: 18, 19, 22 @ -1, -1, -2
Hailstone B: 20, 25, 34 @ -2, -2, -4
Hailstones' paths are parallel; they never intersect.

Hailstone A: 18, 19, 22 @ -1, -1, -2
Hailstone B: 12, 31, 28 @ -1, -2, -1
Hailstones' paths will cross outside the test area (at x=-6, y=-5).

Hailstone A: 18, 19, 22 @ -1, -1, -2
Hailstone B: 20, 19, 15 @ 1, -5, -3
Hailstones' paths crossed in the past for both hailstones.

Hailstone A: 20, 25, 34 @ -2, -2, -4
Hailstone B: 12, 31, 28 @ -1, -2, -1
Hailstones' paths will cross outside the test area (at x=-2, y=3).

Hailstone A: 20, 25, 34 @ -2, -2, -4
Hailstone B: 20, 19, 15 @ 1, -5, -3
Hailstones' paths crossed in the past for hailstone B.

Hailstone A: 12, 31, 28 @ -1, -2, -1
Hailstone B: 20, 19, 15 @ 1, -5, -3
Hailstones' paths crossed in the past for both hailstones.

So, in this example, 2 hailstones' future paths cross inside the boundaries of the test area.

However, you'll need to search a much larger test area if you want to see if any hailstones might collide. Look for intersections that happen with an X and Y position each at least 200000000000000 and at most 400000000000000. Disregard the Z axis entirely.

Considering only the X and Y axes, check all pairs of hailstones' future paths for intersections. How many of these intersections occur within the test area?


*/

public class Day24 : IDay
{
    public string ResolvePart1(string[] inputs)
    {
        Hail[] hails = inputs.Select(input => new Hail(input)).ToArray();
        bool isInputData = hails.Any(h => h.Position.X > 100000);
        long min = isInputData ? 200000000000000 : 7;
        long max = isInputData ? 400000000000000 : 27;
        long count = 0;
        for (int i = 0; i < hails.Length - 1; i++)
        {
            for (int j = i + 1; j < hails.Length; j++)
            {
                (bool intersects, double s, double t, Vector3D point) = hails[i].Intersect2D(hails[j]);
                if (intersects && s > 0 && t > 0 && point.X >= min && point.X <= max && point.Y >= min && point.Y <= max)
                {
                    count++;
                }
            }
        }
        return count.ToString();
    }

    public string ResolvePart2(string[] inputs)
    {
        throw new NotImplementedException();
    }

    public struct Vector3D
    {
        public readonly long X;
        public readonly long Y;
        public readonly long Z;

        public Vector3D(long x, long y, long z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }

    public readonly struct Hail
    {
        public readonly Vector3D Position;
        public readonly Vector3D Velocity;

        public Hail(string input)
        {
            string[] parts = input.Split(" @ ");
            string[] strPosition = parts[0].Split(", ");
            Position = new Vector3D(
                x: Convert.ToInt64(strPosition[0]),
                y: Convert.ToInt64(strPosition[1]),
                z: Convert.ToInt64(strPosition[2]));
            string[] strVelocity = parts[1].Split(", ");
            Velocity = new Vector3D(
                x: Convert.ToInt64(strVelocity[0]),
                y: Convert.ToInt64(strVelocity[1]),
                z: Convert.ToInt64(strVelocity[2]));
        }

        public (bool intersects, double s, double t, Vector3D point) Intersect2D(Hail other)
        {
            long s_Div = (-other.Velocity.X * Velocity.Y + Velocity.X * other.Velocity.Y);
            if (s_Div == 0)
            {
                return (false, 0, 0, new Vector3D());
            }
            double s = (-Velocity.Y * (Position.X - other.Position.X) + Velocity.X * (Position.Y - other.Position.Y)) / (double)s_Div;

            long t_Div = (-other.Velocity.X * Velocity.Y + Velocity.X * other.Velocity.Y);
            if (t_Div == 0)
            {
                return (false, 0, 0, new Vector3D());
            }
            double t = (other.Velocity.X * (Position.Y - other.Position.Y) - other.Velocity.Y * (Position.X - other.Position.X)) / (double)t_Div;

            Vector3D intersection = new((long)(Position.X + t * Velocity.X), (long)(Position.Y + t * Velocity.Y), 0);
            return (true, s, t, intersection);
        }
    }
}