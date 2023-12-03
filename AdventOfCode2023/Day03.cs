namespace AdventOfCode2023;

/*
--- Day 3: Gear Ratios ---

You and the Elf eventually reach a gondola lift station; he says the gondola lift will take you up to the water source, but this is as far as he can bring you. You go inside.

It doesn't take long to find the gondolas, but there seems to be a problem: they're not moving.

"Aaah!"

You turn around to see a slightly-greasy Elf with a wrench and a look of surprise. "Sorry, I wasn't expecting anyone! The gondola lift isn't working right now; it'll still be a while before I can fix it." You offer to help.

The engineer explains that an engine part seems to be missing from the engine, but nobody can figure out which one. If you can add up all the part numbers in the engine schematic, it should be easy to work out which part is missing.

The engine schematic (your puzzle input) consists of a visual representation of the engine. There are lots of numbers and symbols you don't really understand, but apparently any number adjacent to a symbol, even diagonally, is a "part number" and should be included in your sum. (Periods (.) do not count as a symbol.)

Here is an example engine schematic:

467..114..
...*......
..35..633.
......#...
617*......
.....+.58.
..592.....
......755.
...$.*....
.664.598..

In this schematic, two numbers are not part numbers because they are not adjacent to a symbol: 114 (top right) and 58 (middle right). Every other number is adjacent to a symbol and so is a part number; their sum is 4361.

Of course, the actual engine schematic is much larger. What is the sum of all of the part numbers in the engine schematic?

--- Part Two ---

The engineer finds the missing part and installs it in the engine! As the engine springs to life, you jump in the closest gondola, finally ready to ascend to the water source.

You don't seem to be going very fast, though. Maybe something is still wrong? Fortunately, the gondola has a phone labeled "help", so you pick it up and the engineer answers.

Before you can explain the situation, she suggests that you look out the window. There stands the engineer, holding a phone in one hand and waving with the other. You're going so slowly that you haven't even left the station. You exit the gondola.

The missing part wasn't the only issue - one of the gears in the engine is wrong. A gear is any * symbol that is adjacent to exactly two part numbers. Its gear ratio is the result of multiplying those two numbers together.

This time, you need to find the gear ratio of every gear and add them all up so that the engineer can figure out which gear needs to be replaced.

Consider the same engine schematic again:

467..114..
...*......
..35..633.
......#...
617*......
.....+.58.
..592.....
......755.
...$.*....
.664.598..

In this schematic, there are two gears. The first is in the top left; it has part numbers 467 and 35, so its gear ratio is 16345. The second gear is in the lower right; its gear ratio is 451490. (The * adjacent to 617 is not a gear because it is only adjacent to one part number.) Adding up all of the gear ratios produces 467835.
*/

public class Day03 : IDay
{
    public string ResolvePart1(string[] inputs)
    {
        int row = 0;
        int column = 0;
        int sum = 0;
        do
        {
            SchemaNumber? number = SearchNextSchemaNumber(inputs, row, column);
            if (number == null) { break; }
            row = number.Value.Row;
            column = number.Value.Column + number.Value.Lenght;

            if (SchemaNumberAdjacentToSymbol(number.Value) == false) { continue; }

            sum += number.Value.Value;
        } while (true);
        return sum.ToString();
    }

    public string ResolvePart2(string[] inputs)
    {
        List<SchemaNumber> numbers = new();
        int row = 0;
        int column = 0;
        do
        {
            SchemaNumber? number = SearchNextSchemaNumber(inputs, row, column);
            if (number == null) { break; }
            row = number.Value.Row;
            column = number.Value.Column + number.Value.Lenght;

            numbers.Add(number.Value);
        } while (true);

        int sum = 0;
        for (row = 0; row < inputs.Length; row++)
        {
            for (column = 0; column < inputs[row].Length; column++)
            {
                if (inputs[row][column] != '*') { continue; }
                
                List<SchemaNumber> adjacentNumbers = numbers.Where(n => CellAdjacentToSchemaNumber(row, column, n)).ToList();
                if (adjacentNumbers.Count != 2) { continue; }

                int gearRatio = adjacentNumbers.Aggregate(1, (current, number) => current * number.Value);
                sum += gearRatio;
            }
        }
        return sum.ToString();
    }

    public struct SchemaNumber
    {
        public string[] Schema { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public int Lenght { get; set; }
        public int Value { get; set; }
    }

    public static SchemaNumber? SearchNextSchemaNumber(string[] schema, int initialRow, int initialColumn)
    {
        int auxInitialColumn = initialColumn;
        for (int j = initialRow; j < schema.Length; j++)
        {
            for (int i = auxInitialColumn; i < schema[j].Length; i++)
            {
                if (char.IsDigit(schema[j][i]) == false) { continue; }

                int sum = 0;
                int k = i;
                for (; k < schema[j].Length; k++)
                {
                    if (char.IsDigit(schema[j][k]) == false) { break; }
                    sum *= 10;
                    sum += (schema[j][k] - '0');
                }

                return new SchemaNumber {
                    Schema = schema,
                    Row = j,
                    Column = i,
                    Lenght = k - i,
                    Value = sum,
                };
            }
            auxInitialColumn = 0;
        }
        return null;
    }

    private static bool CellContainSymbol(string[] schema, int row, int column)
    {
        if (row < 0 || row >= schema.Length) { return false; }
        if (column < 0 || column >= schema[row].Length) { return false; }

        return schema[row][column] != '.' && char.IsDigit(schema[row][column]) == false;
    }

    private static bool SchemaNumberAdjacentToSymbol(SchemaNumber number)
    {
        if (CellContainSymbol(number.Schema, number.Row, number.Column - 1)) { return true; }
        if (CellContainSymbol(number.Schema, number.Row + 1, number.Column - 1)) { return true; }
        if (CellContainSymbol(number.Schema, number.Row - 1, number.Column - 1)) { return true; }
        if (CellContainSymbol(number.Schema, number.Row, number.Column + number.Lenght)) { return true; }
        if (CellContainSymbol(number.Schema, number.Row + 1, number.Column + number.Lenght)) { return true; }
        if (CellContainSymbol(number.Schema, number.Row - 1, number.Column + number.Lenght)) { return true; }
        for (int i = 0; i < number.Lenght; i++)
        {
            if (CellContainSymbol(number.Schema, number.Row + 1, number.Column + i)) { return true; }
            if (CellContainSymbol(number.Schema, number.Row - 1, number.Column + i)) { return true; }
        }
        return false;
    }
    
    private static bool CellAdjacentToSchemaNumber(int row, int column, SchemaNumber number)
    {
        int minRow = number.Row - 1;
        int maxRow = number.Row + 1;
        int minColumn = number.Column - 1;
        int maxColumn = number.Column + number.Lenght;

        if (row >= minRow && row <= maxRow && column >= minColumn && column <= maxColumn)
        {
            return true;
        }
        
        return false;
    }

}