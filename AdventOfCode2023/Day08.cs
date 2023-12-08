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

--- Part Two ---

The sandstorm is upon you and you aren't any closer to escaping the wasteland. You had the camel follow the instructions, but you've barely left your starting position. It's going to take significantly more steps to escape!

What if the map isn't for people - what if the map is for ghosts? Are ghosts even bound by the laws of spacetime? Only one way to find out.

After examining the maps a bit longer, your attention is drawn to a curious fact: the number of nodes with names ending in A is equal to the number ending in Z! If you were a ghost, you'd probably just start at every node that ends with A and follow all of the paths at the same time until they all simultaneously end up at nodes that end with Z.

For example:

LR

11A = (11B, XXX)
11B = (XXX, 11Z)
11Z = (11B, XXX)
22A = (22B, XXX)
22B = (22C, 22C)
22C = (22Z, 22Z)
22Z = (22B, 22B)
XXX = (XXX, XXX)

Here, there are two starting nodes, 11A and 22A (because they both end with A). As you follow each left/right instruction, use that instruction to simultaneously navigate away from both nodes you're currently on. Repeat this process until all of the nodes you're currently on end with Z. (If only some of the nodes you're on end with Z, they act like any other node and you continue as normal.) In this example, you would proceed as follows:

    Step 0: You are at 11A and 22A.
    Step 1: You choose all of the left paths, leading you to 11B and 22B.
    Step 2: You choose all of the right paths, leading you to 11Z and 22C.
    Step 3: You choose all of the left paths, leading you to 11B and 22Z.
    Step 4: You choose all of the right paths, leading you to 11Z and 22B.
    Step 5: You choose all of the left paths, leading you to 11B and 22C.
    Step 6: You choose all of the right paths, leading you to 11Z and 22Z.

So, in this example, you end up entirely on nodes that end in Z after 6 steps.

Simultaneously start on every node that ends with A. How many steps does it take before you're only on nodes that end with Z?


*/

public class Day08 : IDay
{
    public string ResolvePart1(string[] inputs)
    {
        const string startNodeKey = "AAA";
        const string endNodeKey = "ZZZ";
        Map map = new(inputs);

        MapWalker walker = new(map, startNodeKey);
        walker.StepWhile(w => w.CurrentNode.Key != endNodeKey);
        return walker.Steps.ToString();
    }

    public string ResolvePart2(string[] inputs)
    {
        Map map = new(inputs);
        List<MapNode> startNodes = map.Nodes.Where(n => n.Key.EndsWith("A")).ToList();
        List<MapWalker> walkers = startNodes.Select(n => new MapWalker(map, n.Key)).ToList();
        foreach (MapWalker walker in walkers)
        {
            walker.StepWhile(w => w.CurrentNode.Key.EndsWith("Z") == false);
        }

        long steps = 1;
        foreach (MapWalker walker in walkers)
        {
            steps = LeastCommonMultiple(steps, walker.Steps);
        }

        return steps.ToString();
    }

    private class MapNode
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

    private class Map
    {
        private readonly List<MapNode> _mapNodes;
        private readonly Dictionary<string, MapNode> _dictMapNodes;
        private readonly string _strLeftRightInstructions;

        public Map(string[] inputs)
        {
            _mapNodes = new List<MapNode>();
            _dictMapNodes = new Dictionary<string, MapNode>();
            _strLeftRightInstructions = inputs[0];
            for (int i = 2; i < inputs.Length; i++)
            {
                MapNode node = new(inputs[i]);
                _mapNodes.Add(node);
                _dictMapNodes.Add(node.Key, node);
            }
        }

        public List<MapNode> Nodes
        {
            get { return _mapNodes; }
        }

        public MapNode? GetByKey(string key)
        {
            return _dictMapNodes.GetValueOrDefault(key);
        }

        public char GetInstruction(long step)
        {
            char leftRightInstruction = _strLeftRightInstructions[(int)(step % _strLeftRightInstructions.Length)];
            return leftRightInstruction;
        }
    }

    private class MapWalker
    {
        private readonly Map _map;

        private MapNode _currentNode;
        private long _steps;

        public MapWalker(Map map, string startKey)
        {
            _map = map;
            _currentNode = map.GetByKey(startKey) ?? map.Nodes.First();
            _steps = 0;
        }

        public void StepWhile(Func<MapWalker, bool> condition)
        {
            while (condition(this))
            {
                char leftRightInstruction = _map.GetInstruction(_steps);
                if (leftRightInstruction == 'L')
                {
                    _currentNode = _map.GetByKey(_currentNode.LeftKey) ?? _map.Nodes.First();
                }
                if (leftRightInstruction == 'R')
                {
                    _currentNode = _map.GetByKey(_currentNode.RightKey) ?? _map.Nodes.First();
                }
                _steps++;
            }
        }

        public MapNode CurrentNode
        {
            get { return _currentNode; }
        }

        public long Steps
        {
            get { return _steps; }
        }
    }
    
    // https://en.wikipedia.org/wiki/Euclidean_algorithm#Implementations
    private static long GreatestCommonDivisor(long a, long b)
    {
        while (b != 0)
        {
            long temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    // https://en.wikipedia.org/wiki/Least_common_multiple#Calculation
    private static long LeastCommonMultiple(long a, long b)
    {
        return (a / GreatestCommonDivisor(a, b)) * b;
    }
}