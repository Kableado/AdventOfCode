namespace AdventOfCode2020;

/*

--- Day 5: Binary Boarding ---

You board your plane only to discover a new problem: you dropped your boarding pass! You aren't sure which seat is yours, and all of the flight attendants are busy with the flood of people that suddenly made it through passport control.

You write a quick program to use your phone's camera to scan all of the nearby boarding passes (your puzzle input); perhaps you can find your seat through process of elimination.

Instead of zones or groups, this airline uses binary space partitioning to seat people. A seat might be specified like FBFBBFFRLR, where F means "front", B means "back", L means "left", and R means "right".

The first 7 characters will either be F or B; these specify exactly one of the 128 rows on the plane (numbered 0 through 127). Each letter tells you which half of a region the given seat is in. Start with the whole list of rows; the first letter indicates whether the seat is in the front (0 through 63) or the back (64 through 127). The next letter indicates which half of that region the seat is in, and so on until you're left with exactly one row.

For example, consider just the first seven characters of FBFBBFFRLR:

    Start by considering the whole range, rows 0 through 127.
    F means to take the lower half, keeping rows 0 through 63.
    B means to take the upper half, keeping rows 32 through 63.
    F means to take the lower half, keeping rows 32 through 47.
    B means to take the upper half, keeping rows 40 through 47.
    B keeps rows 44 through 47.
    F keeps rows 44 through 45.
    The final F keeps the lower of the two, row 44.

The last three characters will be either L or R; these specify exactly one of the 8 columns of seats on the plane (numbered 0 through 7). The same process as above proceeds again, this time with only three steps. L means to keep the lower half, while R means to keep the upper half.

For example, consider just the last 3 characters of FBFBBFFRLR:

    Start by considering the whole range, columns 0 through 7.
    R means to take the upper half, keeping columns 4 through 7.
    L means to take the lower half, keeping columns 4 through 5.
    The final R keeps the upper of the two, column 5.

So, decoding FBFBBFFRLR reveals that it is the seat at row 44, column 5.

Every seat also has a unique seat ID: multiply the row by 8, then add the column. In this example, the seat has ID 44 * 8 + 5 = 357.

Here are some other boarding passes:

    BFFFBBFRRR: row 70, column 7, seat ID 567.
    FFFBBBFRRR: row 14, column 7, seat ID 119.
    BBFFBBFRLL: row 102, column 4, seat ID 820.

As a sanity check, look through your list of boarding passes. What is the highest seat ID on a boarding pass?

--- Part Two ---

Ding! The "fasten seat belt" signs have turned on. Time to find your seat.

It's a completely full flight, so your seat should be the only missing boarding pass in your list. However, there's a catch: some of the seats at the very front and back of the plane don't exist on this aircraft, so they'll be missing from your list as well.

Your seat wasn't at the very front or back, though; the seats with IDs +1 and -1 from yours will be in your list.

What is the ID of your seat?


*/

public class Day05 : IDay
{
    public string ResolvePart1(string[] inputs)
    {
        int maxSerialNumber = 0;
        foreach (string input in inputs)
        {
            Seat seat = Seat_Parse(input);
            if (seat == null) { continue; }
            int newSerialNumber = seat.GetSerialNumber();
            if (newSerialNumber > maxSerialNumber) { maxSerialNumber = newSerialNumber; }
        }
        return maxSerialNumber.ToString();
    }

    public string ResolvePart2(string[] inputs)
    {
        // Fill the seats
        char[][] seats = new char[8][];
        for (int i = 0; i < 8; i++)
        {
            seats[i] = new char[128];
            for (int j = 0; j < 128; j++) { seats[i][j] = '.'; }
        }
        foreach (string input in inputs)
        {
            Seat seat = Seat_Parse(input);
            if (seat == null) { continue; }

            seats[seat.Column][seat.Row] = 'X';
        }

        // Show seats
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 128; j++)
            {
                Console.Write(seats[i][j]);
            }
            Console.WriteLine();
        }

        // Find my seat
        int mySeatSerialNumber = -1;
        for (int i = 0; i < 8 && mySeatSerialNumber < 0; i++)
        {
            for (int j = 0; j < 128 && mySeatSerialNumber < 0; j++)
            {
                if (seats[i][j] == '.')
                {
                    int neighbourCount = 0;
                    for (int k = -1; k < 2; k++)
                    {
                        for (int l = -1; l < 2; l++)
                        {
                            int col = (i + k);
                            if (col < 0) { col += 8; }
                            if (col >= 8) { col -= 8; }
                            int row = (j + l);
                            if (row < 0) { row += 128; }
                            if (row >= 128) { row -= 128; }
                            if (seats[col][row] == 'X')
                            {
                                neighbourCount++;
                            }
                        }
                    }
                    if (neighbourCount == 8)
                    {
                        Seat mySeat = new() { Row = j, Column = i, };
                        mySeatSerialNumber = mySeat.GetSerialNumber();
                    }
                }
            }
        }
        return mySeatSerialNumber.ToString();
    }

    private class Range
    {
        public int Start { get; set; }
        public int End { get; set; }

        public void SplitLeft()
        {
            int len = End - Start;
            int half = (len + 1) / 2;
            End -= half;
        }

        public void SplitRight()
        {
            int len = End - Start;
            int half = (len + 1) / 2;
            Start += half;
        }
    }

    private class Seat
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public int GetSerialNumber()
        {
            return (Row * 8) + Column;
        }
    }

    private Seat Seat_Parse(string input)
    {
        if (input.Length != 10 ||
            input.All(c => c == 'F' || c == 'B' || c == 'L' || c == 'R') == false ||
            false)
        {
            return null;
        }
        Seat seat = new();

        Range row = new() { Start = 0, End = 127, };
        for (int i = 0; i < 7; i++)
        {
            if (input[i] == 'F')
            {
                row.SplitLeft();
            }
            if (input[i] == 'B')
            {
                row.SplitRight();
            }
        }
        seat.Row = row.Start;

        Range column = new() { Start = 0, End = 7, };
        for (int i = 7; i < 10; i++)
        {
            if (input[i] == 'L')
            {
                column.SplitLeft();
            }
            if (input[i] == 'R')
            {
                column.SplitRight();
            }
        }
        seat.Column = column.Start;

        return seat;
    }
}