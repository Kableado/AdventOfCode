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

--- Part Two ---

Upon further analysis, it doesn't seem like any hailstones will naturally collide. It's up to you to fix that!

You find a rock on the ground nearby. While it seems extremely unlikely, if you throw it just right, you should be able to hit every hailstone in a single throw!

You can use the probably-magical winds to reach any integer position you like and to propel the rock at any integer velocity. Now including the Z axis in your calculations, if you throw the rock at time 0, where do you need to be so that the rock perfectly collides with every hailstone? Due to probably-magical inertia, the rock won't slow down or change direction when it collides with a hailstone.

In the example above, you can achieve this by moving to position 24, 13, 10 and throwing the rock at velocity -3, 1, 2. If you do this, you will hit every hailstone as follows:

Hailstone: 19, 13, 30 @ -2, 1, -2
Collision time: 5
Collision position: 9, 18, 20

Hailstone: 18, 19, 22 @ -1, -1, -2
Collision time: 3
Collision position: 15, 16, 16

Hailstone: 20, 25, 34 @ -2, -2, -4
Collision time: 4
Collision position: 12, 17, 18

Hailstone: 12, 31, 28 @ -1, -2, -1
Collision time: 6
Collision position: 6, 19, 22

Hailstone: 20, 19, 15 @ 1, -5, -3
Collision time: 1
Collision position: 21, 14, 12

Above, each hailstone is identified by its initial position and its velocity. Then, the time and position of that hailstone's collision with your rock are given.

After 1 nanosecond, the rock has exactly the same position as one of the hailstones, obliterating it into ice dust! Another hailstone is smashed to bits two nanoseconds after that. After a total of 6 nanoseconds, all of the hailstones have been destroyed.

So, at time 0, the rock needs to be at X position 24, Y position 13, and Z position 10. Adding these three coordinates together produces 47. (Don't add any coordinates from the rock's velocity.)

Determine the exact position and velocity the rock needs to have at time 0 so that it perfectly collides with every hailstone. What do you get if you add up the X, Y, and Z coordinates of that initial position?


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
                (bool intersects, double s, double t) = hails[i].Intersect2D(hails[j]);
                if (intersects && s > 0 && t > 0)
                {
                    long x = (long)(hails[i].Position.X + t * hails[i].Velocity.X);
                    long y = (long)(hails[i].Position.Y + t * hails[i].Velocity.Y);
                    if (x >= min && x <= max && y >= min && y <= max)
                    {
                        count++;
                    }
                }
            }
        }
        return count.ToString();
    }

    public string ResolvePart2(string[] inputs)
    {
        string result = ResolvePart2_SolutionInDataSet(inputs);
        if (string.IsNullOrEmpty(result) == false)
        {
            return result;
        }
        result = ResolvePart2_BruteForceXY(inputs);
        if (string.IsNullOrEmpty(result) == false)
        {
            return result;
        }
        return string.Empty;
    }


    public string ResolvePart2_BruteForceXY(string[] inputs)
    {
        Hail[] hails = inputs.Select(input => new Hail(input)).ToArray();

        // Brute force solution
        long absMax = hails
            .Select(h => new[] { h.Velocity.X, h.Velocity.Y, h.Velocity.Z, })
            .SelectMany(x => x).Select(Math.Abs)
            .Max();
        Console.WriteLine($"Velocity AbsMax: {absMax}");
        long minV = -absMax;
        long maxV = absMax;
        Vector3D? collisionPoint = null;
        for (long vy = minV; vy < maxV && collisionPoint == null; vy++)
        {
            for (long vx = minV; vx < maxV && collisionPoint == null; vx++)
            {
                Vector3D newVelocity0 = new(
                    x: hails[0].Velocity.X - vx,
                    y: hails[0].Velocity.Y - vy,
                    z: hails[0].Velocity.Z);
                Hail shiftedHail0 = new(hails[0].Position, newVelocity0);
                Vector3D newVelocity1 = new(
                    x: hails[1].Velocity.X - vx,
                    y: hails[1].Velocity.Y - vy,
                    z: hails[1].Velocity.Z);
                Hail shiftedHail1 = new(hails[1].Position, newVelocity1);
                (bool intersects, double s, double t) = shiftedHail0.Intersect2D(shiftedHail1);
                if (intersects == false || s < 0.0f || t < 0.0) { continue; }

                long x = (long)(shiftedHail0.Position.X + t * shiftedHail0.Velocity.X);
                long y = (long)(shiftedHail0.Position.Y + t * shiftedHail0.Velocity.Y);
                Vector3D firstCollisionPoint = new(x, y, 0);
                //Console.WriteLine($"Possible Rock: {vx} {vy} | {firstCollisionPoint.X}, {firstCollisionPoint.Y}, {firstCollisionPoint.Z} @ {vx}, {vy}, ?? | {s} {t}");
                Hail[] shiftedHails = hails.Select(h =>
                {
                    Vector3D newVelocity = new(
                        x: h.Velocity.X - vx,
                        y: h.Velocity.Y - vy,
                        z: h.Velocity.Z);
                    Hail newHail = new(h.Position, newVelocity);
                    return newHail;
                }).ToArray();
                Vector3D currentCollisionPoint = firstCollisionPoint;
                bool allCollided = true;
                for (int i = 2; i < shiftedHails.Length; i++)
                {
                    (bool intersectsIter, double sIter, double tIter) = shiftedHails[0].Intersect2D(shiftedHails[i]);
                    long xIter = (long)(shiftedHail0.Position.X + tIter * shiftedHail0.Velocity.X);
                    long yIter = (long)(shiftedHail0.Position.Y + tIter * shiftedHail0.Velocity.Y);
                    Vector3D collisionPointIter = new(xIter, yIter, 0);
                    if (
                        intersectsIter &&
                        currentCollisionPoint.Cmp2D(collisionPointIter) &&
                        true)
                    {
                        continue;
                    }

                    allCollided = false;
                    //Console.WriteLine($"... Invalid rock: {i}");
                    break;
                }
                if (allCollided)
                {
                    long xCollision = (long)(hails[0].Position.X + t * hails[0].Velocity.X);
                    long yCollision = (long)(hails[0].Position.Y + t * hails[0].Velocity.Y);
                    long zCollision = (long)(hails[0].Position.Z + t * hails[0].Velocity.Z);
                    Console.WriteLine($"Possible Rock: {xCollision}, {yCollision}, {zCollision} @ {vx}, {vy}, ?? | {t}");
                    collisionPoint = new Vector3D(xCollision, yCollision, zCollision);
                }
            }
        }
        if (collisionPoint == null)
        {
            return string.Empty;
        }

        return (collisionPoint.Value.X + collisionPoint.Value.Y + collisionPoint.Value.Z).ToString();
    }

    private string ResolvePart2_BruteForceXYZ(string[] inputs)
    {
        Hail[] hails = inputs.Select(input => new Hail(input)).ToArray();

        // Brute force solution
        long absMax = hails
            .Select(h => new[] { h.Velocity.X, h.Velocity.Y, h.Velocity.Z, })
            .SelectMany(x => x).Select(Math.Abs)
            .Max();
        Console.WriteLine($"Velocity AbsMax: {absMax}");
        long minV = -absMax;
        long maxV = absMax;
        Vector3D? collisionPoint = null;
        for (long vz = minV; vz < maxV && collisionPoint == null; vz++)
        {
            Console.WriteLine($"Brute forcing Z layer {vz}");
            for (long vy = minV; vy < maxV && collisionPoint == null; vy++)
            {
                for (long vx = minV; vx < maxV && collisionPoint == null; vx++)
                {
                    Vector3D newVelocity0 = new(
                        x: hails[0].Velocity.X - vx,
                        y: hails[0].Velocity.Y - vy,
                        z: hails[0].Velocity.Z - vz);
                    Hail shiftedHail0 = new(hails[0].Position, newVelocity0);
                    Vector3D newVelocity1 = new(
                        x: hails[1].Velocity.X - vx,
                        y: hails[1].Velocity.Y - vy,
                        z: hails[1].Velocity.Z - vz);
                    Hail shiftedHail1 = new(hails[1].Position, newVelocity1);
                    (bool intersects, double t, Vector3D? firstCollisionPoint) = shiftedHail0.Intersect3D(shiftedHail1, sameT: false);
                    if (intersects == false || firstCollisionPoint == null || t < 0.0) { continue; }

                    //Console.WriteLine($"Possible Rock: {firstCollisionPoint.Value.X}, {firstCollisionPoint.Value.Y}, {firstCollisionPoint.Value.Z} @ {vx}, {vy}, {vz} | {t}");
                    Hail[] shiftedHails = hails.Select(h =>
                    {
                        Vector3D newVelocity = new(
                            x: h.Velocity.X - vx,
                            y: h.Velocity.Y - vy,
                            z: h.Velocity.Z - vz);
                        Hail newHail = new(h.Position, newVelocity);
                        return newHail;
                    }).ToArray();
                    Vector3D currentCollisionPoint = firstCollisionPoint.Value;
                    bool allCollided = true;
                    for (int i = 2; i < shiftedHails.Length; i++)
                    {
                        (bool intersectsIter, double tIter, Vector3D? collisionPointIter) = shiftedHails[0].Intersect3D(shiftedHails[i], sameT: false);
                        if (
                            intersectsIter &&
                            tIter >= -0.001f &&
                            collisionPointIter != null &&
                            currentCollisionPoint.Cmp3D(collisionPointIter.Value) &&
                            true)
                        {
                            continue;
                        }

                        allCollided = false;
                        //Console.WriteLine($"... Invalid rock: {i}");
                        break;
                    }
                    if (allCollided)
                    {
                        collisionPoint = currentCollisionPoint;
                    }
                }
            }
        }
        return collisionPoint != null 
            ? (collisionPoint.Value.X + collisionPoint.Value.Y + collisionPoint.Value.Z).ToString() 
            : string.Empty;
    }

    private string ResolvePart2_SolutionInDataSet(string[] inputs)
    {
        Hail[] hails = inputs.Select(input => new Hail(input)).ToArray();

        // Check if any hail is doing the same as the rock
        Hail? bestMatch = null;
        for (int i = 0; i < hails.Length; i++)
        {
            bool allCollided = true;
            for (int j = 0; j < hails.Length; j++)
            {
                if (i == j) { continue; }
                (bool intersects, _, _) = hails[i].Intersect3D(hails[j]);
                if (intersects) { continue; }

                allCollided = false;
                break;
            }
            if (allCollided)
            {
                bestMatch = hails[i];
            }
        }
        if (bestMatch != null)
        {
            return (bestMatch.Value.Position.X + bestMatch.Value.Position.Y + bestMatch.Value.Position.Z).ToString();
        }

        return string.Empty;
    }

    public readonly struct Vector3D
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

        public bool Cmp2D(Vector3D other)
        {
            return X == other.X && Y == other.Y;
        }

        public bool Cmp3D(Vector3D other)
        {
            return X == other.X && Y == other.Y && Z == other.Z;
        }
    }

    public readonly struct Hail
    {
        public readonly Vector3D Position;
        public readonly Vector3D Velocity;

        public Hail(Vector3D position, Vector3D velocity)
        {
            Position = position;
            Velocity = velocity;
        }

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

        public (bool intersects, double s, double t) Intersect2D(Hail other)
        {
            long s_Div = (-other.Velocity.X * Velocity.Y + Velocity.X * other.Velocity.Y);
            if (s_Div == 0)
            {
                return (false, 0, 0);
            }
            double s = (-Velocity.Y * (Position.X - other.Position.X) + Velocity.X * (Position.Y - other.Position.Y)) / (double)s_Div;

            long t_Div = (-other.Velocity.X * Velocity.Y + Velocity.X * other.Velocity.Y);
            if (t_Div == 0)
            {
                return (false, 0, 0);
            }
            double t = (other.Velocity.X * (Position.Y - other.Position.Y) - other.Velocity.Y * (Position.X - other.Position.X)) / (double)t_Div;

            return (true, s, t);
        }

        public (bool intersects, double t, Vector3D? point) Intersect3D(Hail other, bool sameT = true)
        {
            (bool intersects, double s, double t) = Intersect2D(other);
            if (intersects == false || (sameT && Math.Abs(s - t) > 0.001))
            {
                return (false, 0, null);
            }

            long zThis = (long)(Position.Z + t * Velocity.Z);
            long zOther = (long)(other.Position.Z + s * other.Velocity.Z);
            if (Math.Abs(zThis - zOther) > 0.001)
            {
                return (false, 0, null);
            }
            long yThis = (long)(Position.Y + t * Velocity.Y);
            long xThis = (long)(Position.X + t * Velocity.X);

            return (true, t, new Vector3D(xThis, yThis, zThis));
        }
    }
}