namespace AdventOfCode2023;

/*
--- Day 8: Haunted Wasteland ---

You're still riding a camel across Desert Island when you spot a sandstorm quickly approaching. When you turn to warn the Elf, she disappears before your eyes! To be fair, she had just finished warning you about ghosts a few minutes ago.

One of the camel's pouches is labeled "maps" - sure enough, it's full of documents (your puzzle input) about how to navigate the desert. At least, you're pretty sure that's what they are; one of the documents contains a list of left/right instructions, and the rest of the documents seem to describe some kind of network of labeled nodes.

It seems like you're meant to use the left/right instructions to navigate the network. Perhaps if you have the camel follow the same instructions, you can escape the haunted wasteland!

After examining the maps for a bit, two nodes stick out: AAA and ZZZ. You feel like AAA is where you are now, and you have to follow the left/right instructions until you reach ZZZ.

This format defines each node of the network individually. For example:

RL

AAA = (BBB, CCC)
BBB = (DDD, EEE)
CCC = (ZZZ, GGG)
DDD = (DDD, DDD)
EEE = (EEE, EEE)
GGG = (GGG, GGG)
ZZZ = (ZZZ, ZZZ)

Starting with AAA, you need to look up the next element based on the next left/right instruction in your input. In this example, start with AAA and go right (R) by choosing the right element of AAA, CCC. Then, L means to choose the left element of CCC, ZZZ. By following the left/right instructions, you reach ZZZ in 2 steps.

Of course, you might not find ZZZ right away. If you run out of left/right instructions, repeat the whole sequence of instructions as necessary: RL really means RLRLRLRLRLRLRLRL... and so on. For example, here is a situation that takes 6 steps to reach ZZZ:

LLR

AAA = (BBB, BBB)
BBB = (AAA, ZZZ)
ZZZ = (ZZZ, ZZZ)

Starting at AAA, follow the left/right instructions. How many steps are required to reach ZZZ?


*/

public class Day08 : IDay
{
    public string ResolvePart1(string[] inputs)
    {
        string startNodeKey = "AAA";
        string endNodeKey = "ZZZ";
        string strLeftRightInstructions = inputs[0];
        Dictionary<string, MapNode> dictNodes = new();
        for (int i = 2; i < inputs.Length; i++)
        {
            MapNode node = new(inputs[i]);
            dictNodes.Add(node.Key, node);
        }

        MapNode currentNode = dictNodes[startNodeKey];
        int steps = 0;
        while (currentNode.Key != endNodeKey)
        {
            char leftRightInstruction = strLeftRightInstructions[steps % strLeftRightInstructions.Length];
            if (leftRightInstruction == 'L')
            {
                currentNode = dictNodes[currentNode.LeftKey];
            }
            if (leftRightInstruction == 'R')
            {
                currentNode = dictNodes[currentNode.RightKey];
            }
            steps++;
        }
        return steps.ToString();
    }

    public string ResolvePart2(string[] inputs)
    {
        throw new NotImplementedException();
    }

    public class MapNode
    {
        public string Key { get; set; }
        public string LeftKey { get; set; }
        public string RightKey { get; set; }

        public MapNode(string strMapNode)
        {
            Key = strMapNode.Substring(0, 3);
            LeftKey = strMapNode.Substring(7, 3);
            RightKey = strMapNode.Substring(12, 3);
        }
    }
}