namespace AdventOfCode2018;

/*
--- Day 16: Chronal Classification ---

As you see the Elves defend their hot chocolate successfully, you go back to falling through time. This is going to become a problem.

If you're ever going to return to your own time, you need to understand how this device on your wrist works. You have a little while before you reach your next destination, and with a bit of trial and error, you manage to pull up a programming manual on the device's tiny screen.

According to the manual, the device has four registers (numbered 0 through 3) that can be manipulated by instructions containing one of 16 opcodes. The registers start with the value 0.

Every instruction consists of four values: an opcode, two inputs (named A and B), and an output (named C), in that order. The opcode specifies the behavior of the instruction and how the inputs are interpreted. The output, C, is always treated as a register.

In the opcode descriptions below, if something says "value A", it means to take the number given as A literally. (This is also called an "immediate" value.) If something says "register A", it means to use the number given as A to read from (or write to) the register with that number. So, if the opcode addi adds register A and value B, storing the result in register C, and the instruction addi 0 7 3 is encountered, it would add 7 to the value contained by register 0 and store the sum in register 3, never modifying registers 0, 1, or 2 in the process.

Many opcodes are similar except for how they interpret their arguments. The opcodes fall into seven general categories:

Addition:

    addr (add register) stores into register C the result of adding register A and register B.
    addi (add immediate) stores into register C the result of adding register A and value B.

Multiplication:

    mulr (multiply register) stores into register C the result of multiplying register A and register B.
    muli (multiply immediate) stores into register C the result of multiplying register A and value B.

Bitwise AND:

    banr (bitwise AND register) stores into register C the result of the bitwise AND of register A and register B.
    bani (bitwise AND immediate) stores into register C the result of the bitwise AND of register A and value B.

Bitwise OR:

    borr (bitwise OR register) stores into register C the result of the bitwise OR of register A and register B.
    bori (bitwise OR immediate) stores into register C the result of the bitwise OR of register A and value B.

Assignment:

    setr (set register) copies the contents of register A into register C. (Input B is ignored.)
    seti (set immediate) stores value A into register C. (Input B is ignored.)

Greater-than testing:

    gtir (greater-than immediate/register) sets register C to 1 if value A is greater than register B. Otherwise, register C is set to 0.
    gtri (greater-than register/immediate) sets register C to 1 if register A is greater than value B. Otherwise, register C is set to 0.
    gtrr (greater-than register/register) sets register C to 1 if register A is greater than register B. Otherwise, register C is set to 0.

Equality testing:

    eqir (equal immediate/register) sets register C to 1 if value A is equal to register B. Otherwise, register C is set to 0.
    eqri (equal register/immediate) sets register C to 1 if register A is equal to value B. Otherwise, register C is set to 0.
    eqrr (equal register/register) sets register C to 1 if register A is equal to register B. Otherwise, register C is set to 0.

Unfortunately, while the manual gives the name of each opcode, it doesn't seem to indicate the number. However, you can monitor the CPU to see the contents of the registers before and after instructions are executed to try to work them out. Each opcode has a number from 0 through 15, but the manual doesn't say which is which. For example, suppose you capture the following sample:

Before: [3, 2, 1, 1]
9 2 1 2
After:  [3, 2, 2, 1]

This sample shows the effect of the instruction 9 2 1 2 on the registers. Before the instruction is executed, register 0 has value 3, register 1 has value 2, and registers 2 and 3 have value 1. After the instruction is executed, register 2's value becomes 2.

The instruction itself, 9 2 1 2, means that opcode 9 was executed with A=2, B=1, and C=2. Opcode 9 could be any of the 16 opcodes listed above, but only three of them behave in a way that would cause the result shown in the sample:

    Opcode 9 could be mulr: register 2 (which has a value of 1) times register 1 (which has a value of 2) produces 2, which matches the value stored in the output register, register 2.
    Opcode 9 could be addi: register 2 (which has a value of 1) plus value 1 produces 2, which matches the value stored in the output register, register 2.
    Opcode 9 could be seti: value 2 matches the value stored in the output register, register 2; the number given for B is irrelevant.

None of the other opcodes produce the result captured in the sample. Because of this, the sample above behaves like three opcodes.

You collect many of these samples (the first section of your puzzle input). The manual also includes a small test program (the second section of your puzzle input) - you can ignore it for now.

Ignoring the opcode numbers, how many samples in your puzzle input behave like three or more opcodes?

--- Part Two ---

Using the samples you collected, work out the number of each opcode and execute the test program (the second section of your puzzle input).

What value is contained in register 0 after executing the test program?

*/

public class Day16 : IDay
{
    private static (int Index, int Count) MutationTestMachine(string[] inputs, ChronoMachine machine)
    {
        int count = 0;
        int i = 0;
        bool end = false;
        int[] beforeRegisters = null;
        int[] instruction = null;
        const string beforeKeyword = "Before: [";
        const string afterKeyword = "After:  [";
        while (inputs.Length > i)
        {
            if (string.IsNullOrEmpty(inputs[i]))
            {
                if (end) { break; }
                end = true;
                i++;
            }
            else if (inputs[i].StartsWith(beforeKeyword))
            {
                end = false;
                string strBeforeRegisters = inputs[i].Substring(beforeKeyword.Length, inputs[i].Length - (1 + beforeKeyword.Length));
                beforeRegisters = strBeforeRegisters.Split(", ").Select(s => Convert.ToInt32(s)).ToArray();
                i++;
            }
            else if (inputs[i].StartsWith(afterKeyword))
            {
                end = false;
                string strBeforeRegisters = inputs[i].Substring(afterKeyword.Length, inputs[i].Length - (1 + afterKeyword.Length));
                int[] afterRegisters = strBeforeRegisters.Split(", ").Select(s => Convert.ToInt32(s)).ToArray();
                i++;

                if (instruction == null || beforeRegisters == null) { continue; }

                int matches = machine.MutationCheck(instruction[0], instruction[1], instruction[2], instruction[3], beforeRegisters, afterRegisters);
                if (matches >= 3) { count++; }
            }
            else
            {
                end = false;
                instruction = inputs[i].Split(" ").Select(s => Convert.ToInt32(s)).ToArray();
                i++;
            }
        }
        return (i, count);
    }

    public string ResolvePart1(string[] inputs)
    {
        ChronoMachine machine = new();
        (_, int count) = MutationTestMachine(inputs, machine);

        return count.ToString();
    }

    public string ResolvePart2(string[] inputs)
    {
        ChronoMachine machine = new();
        (int i, _) = MutationTestMachine(inputs, machine);
        i++;
        machine.InitOpCodes();
        machine.ResetRegisters();
        while (inputs.Length > i)
        {
            string line = inputs[i];
            i++;
            if (string.IsNullOrEmpty(line)) { continue; }
            int[] instruction = line.Split(" ").Select(s => Convert.ToInt32(s)).ToArray();
            machine.ExecInstruction(instruction[0], instruction[1], instruction[2], instruction[3]);
        }
        return machine.GetRegister(0).ToString();
    }

    private class ChronoMachine
    {
        private readonly int[] _registers;

        private readonly List<ChronoInstruction> _instructions;

        private class ChronoInstruction
        {
            public int OpCode { get; set; } = -1;
            public string OpName { get; }
            public Action<int, int, int> OpFunc { get; }

            public ChronoInstruction(string opName, Action<int, int, int> opFunc)
            {
                OpName = opName;
                OpFunc = opFunc;
            }

            public Dictionary<int, int> OpCodeHistogram { get; } = new();

            public void AddPossibleOpCode(int opCode)
            {
                if (OpCodeHistogram.TryGetValue(opCode, out int value))
                {
                    value++;
                    OpCodeHistogram[opCode] = value;
                }
                else
                {
                    OpCodeHistogram.Add(opCode, 1);
                }
            }
        }

        public ChronoMachine()
        {
            _registers = new int[4];
            _instructions = new List<ChronoInstruction> {
                new("addr", Op_AddR),
                new("addi", Op_AddI),
                new("mulr", Op_MulR),
                new("muli", Op_MulI),
                new("banr", Op_BAnR),
                new("bani", Op_BAnI),
                new("borr", Op_BOrR),
                new("bori", Op_BOrI),
                new("setr", Op_SetR),
                new("seti", Op_SetI),
                new("gtir", Op_GTIR),
                new("gtri", Op_GTRI),
                new("gtrr", Op_GTRR),
                new("eqir", Op_EqIR),
                new("eqri", Op_EqRI),
                new("eqrr", Op_EqRR),
            };
        }

        public void ResetRegisters()
        {
            for (int i = 0; i < 4; i++)
            {
                _registers[i] = 0;
            }
        }

        private void SetRegisters(int[] registers)
        {
            for (int i = 0; i < 4; i++)
            {
                _registers[i] = registers[i];
            }
        }

        private bool CheckRegisters(int[] registers)
        {
            for (int i = 0; i < 4; i++)
            {
                if (registers[i] != _registers[i]) { return false; }
            }
            return true;
        }

        public int GetRegister(int r)
        {
            return _registers[r];
        }

        private void Op_AddR(int a, int b, int c)
        {
            _registers[c] = _registers[a] + _registers[b];
        }

        private void Op_AddI(int a, int b, int c)
        {
            _registers[c] = _registers[a] + b;
        }

        private void Op_MulR(int a, int b, int c)
        {
            _registers[c] = _registers[a] * _registers[b];
        }

        private void Op_MulI(int a, int b, int c)
        {
            _registers[c] = _registers[a] * b;
        }

        private void Op_BAnR(int a, int b, int c)
        {
            _registers[c] = _registers[a] & _registers[b];
        }

        private void Op_BAnI(int a, int b, int c)
        {
            _registers[c] = _registers[a] & b;
        }

        private void Op_BOrR(int a, int b, int c)
        {
            _registers[c] = _registers[a] | _registers[b];
        }

        private void Op_BOrI(int a, int b, int c)
        {
            _registers[c] = _registers[a] | b;
        }

        private void Op_SetR(int a, int b, int c)
        {
            _registers[c] = _registers[a];
        }

        private void Op_SetI(int a, int b, int c)
        {
            _registers[c] = a;
        }

        private void Op_GTIR(int a, int b, int c)
        {
            _registers[c] = (a > _registers[b]) ? 1 : 0;
        }

        private void Op_GTRI(int a, int b, int c)
        {
            _registers[c] = (_registers[a] > b) ? 1 : 0;
        }

        private void Op_GTRR(int a, int b, int c)
        {
            _registers[c] = (_registers[a] > _registers[b]) ? 1 : 0;
        }

        private void Op_EqIR(int a, int b, int c)
        {
            _registers[c] = (a == _registers[b]) ? 1 : 0;
        }

        private void Op_EqRI(int a, int b, int c)
        {
            _registers[c] = (_registers[a] == b) ? 1 : 0;
        }

        private void Op_EqRR(int a, int b, int c)
        {
            _registers[c] = (_registers[a] == _registers[b]) ? 1 : 0;
        }

        public int MutationCheck(int opCode, int a, int b, int c, int[] initialRegisters, int[] finalRegisters)
        {
            int count = 0;
            foreach (ChronoInstruction instruction in _instructions)
            {
                SetRegisters(initialRegisters);
                instruction.OpFunc(a, b, c);
                if (CheckRegisters(finalRegisters))
                {
                    instruction.AddPossibleOpCode(opCode);
                    count++;
                }
            }
            return count;
        }

        private readonly Dictionary<int, ChronoInstruction> _dictInstructions = new();

        public void InitOpCodes(bool debug = false)
        {
            if(debug)
            {
                foreach (ChronoInstruction instruction in _instructions)
                {
                    Console.Write($"{instruction.OpName}: ");
                    foreach (KeyValuePair<int, int> pair in instruction.OpCodeHistogram)
                    {
                        Console.Write($"{pair.Key}->{pair.Value} ");
                    }
                    Console.WriteLine(string.Empty);
                }
            }
            while (_instructions.Any(i => i.OpCode == -1))
            {
                foreach (ChronoInstruction instruction in _instructions)
                {
                    if (instruction.OpCode != -1) { continue; }
                    int opCode = -1;
                    foreach (KeyValuePair<int, int> pair in instruction.OpCodeHistogram)
                    {
                        if (_dictInstructions.ContainsKey(pair.Key)) { continue; }

                        if (opCode == -1) { opCode = pair.Key; }
                        else
                        {
                            opCode = -1;
                            break;
                        }
                    }
                    if (opCode == -1) { continue; }

                    instruction.OpCode = opCode;
                    _dictInstructions.Add(opCode, instruction);
                    if(debug) { Console.WriteLine($"{instruction.OpName}: {instruction.OpCode}"); }
                }
            }
        }

        public void ExecInstruction(int opCode, int a, int b, int c)
        {
            ChronoInstruction instruction = _dictInstructions[opCode];
            instruction.OpFunc(a, b, c);
        }
    }
}