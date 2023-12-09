using System.Text;

namespace AdventOfCode2018;
/*

--- Day 7: The Sum of Its Parts ---

You find yourself standing on a snow-covered coastline; apparently, you landed a little off course. The region is too hilly to see the North Pole from here, but you do spot some Elves that seem to be trying to unpack something that washed ashore. It's quite cold out, so you decide to risk creating a paradox by asking them for directions.

"Oh, are you the search party?" Somehow, you can understand whatever Elves from the year 1018 speak; you assume it's Ancient Nordic Elvish. Could the device on your wrist also be a translator? "Those clothes don't look very warm; take this." They hand you a heavy coat.

"We do need to find our way back to the North Pole, but we have higher priorities at the moment. You see, believe it or not, this box contains something that will solve all of Santa's transportation problems - at least, that's what it looks like from the pictures in the instructions." It doesn't seem like they can read whatever language it's in, but you can: "Sleigh kit. Some assembly required."

"'Sleigh'? What a wonderful name! You must help us assemble this 'sleigh' at once!" They start excitedly pulling more parts out of the box.

The instructions specify a series of steps and requirements about which steps must be finished before others can begin (your puzzle input). Each step is designated by a single letter. For example, suppose you have the following instructions:

Step C must be finished before step A can begin.
Step C must be finished before step F can begin.
Step A must be finished before step B can begin.
Step A must be finished before step D can begin.
Step B must be finished before step E can begin.
Step D must be finished before step E can begin.
Step F must be finished before step E can begin.

Visually, these requirements look like this:


  -->A--->B--
 /    \      \
C      -->D----->E
 \           /
  ---->F-----

Your first goal is to determine the order in which the steps should be completed. If more than one step is ready, choose the step which is first alphabetically. In this example, the steps would be completed as follows:

    Only C is available, and so it is done first.
    Next, both A and F are available. A is first alphabetically, so it is done next.
    Then, even though F was available earlier, steps B and D are now also available, and B is the first alphabetically of the three.
    After that, only D and F are available. E is not available because only some of its prerequisites are complete. Therefore, D is completed next.
    F is the only choice, so it is done next.
    Finally, E is completed.

So, in this example, the correct order is CABDFE.

In what order should the steps in your instructions be completed?

--- Part Two ---

As you're about to begin construction, four of the Elves offer to help. "The sun will set soon; it'll go faster if we work together." Now, you need to account for multiple people working on steps simultaneously. If multiple steps are available, workers should still begin them in alphabetical order.

Each step takes 60 seconds plus an amount corresponding to its letter: A=1, B=2, C=3, and so on. So, step A takes 60+1=61 seconds, while step Z takes 60+26=86 seconds. No time is required between steps.

To simplify things for the example, however, suppose you only have help from one Elf (a total of two workers) and that each step takes 60 fewer seconds (so that step A takes 1 second and step Z takes 26 seconds). Then, using the same instructions as above, this is how each second would be spent:

Second   Worker 1   Worker 2   Done
   0        C          .
   1        C          .
   2        C          .
   3        A          F       C
   4        B          F       CA
   5        B          F       CA
   6        D          F       CAB
   7        D          F       CAB
   8        D          F       CAB
   9        D          .       CABF
  10        E          .       CABFD
  11        E          .       CABFD
  12        E          .       CABFD
  13        E          .       CABFD
  14        E          .       CABFD
  15        .          .       CABFDE

Each row represents one second of time. The Second column identifies how many seconds have passed as of the beginning of that second. Each worker column shows the step that worker is currently doing (or . if they are idle). The Done column shows completed steps.

Note that the order of the steps has changed; this is because steps now take time to finish and multiple workers can begin multiple steps simultaneously.

In this example, it would take 15 seconds for two workers to complete these steps.

With 5 workers and the 60+ second step durations described above, how long will it take to complete all of the steps?

*/

public class Day07 : IDay
{
    private static Instructions BuildInstructions(string[] inputs, int baseCost)
    {
        Instructions instructions = new();
        foreach (string input in inputs)
        {
            if (string.IsNullOrEmpty(input)) { continue; }
            string[] parts = input.Split(new[] {
                "Step ",
                " must be finished before step ",
                " can begin.",
            }, StringSplitOptions.RemoveEmptyEntries);
            instructions.AddNodeRelation(parts[1].ToUpper(), parts[0].ToUpper());
        }
        foreach (InstructionNode node in instructions.Nodes.Values)
        {
            char nodeID = node.NodeID[0];
            int nodeCost = baseCost + (nodeID - 'A') + 1;
            node.Cost = nodeCost;
        }

        return instructions;
    }

    public string ResolvePart1(string[] inputs)
    {
        Instructions instructions = BuildInstructions(inputs, 0);
        List<InstructionNode> finalInstructions = instructions.SortInstructions();
        StringBuilder sbInstructions = new();
        foreach (InstructionNode node in finalInstructions)
        {
            sbInstructions.Append(node.NodeID);
        }
        return sbInstructions.ToString();
    }

    public int BaseCost { get; set; } = 60;
    public int NumberOfWorkers { get; set; } = 5;

    public string ResolvePart2(string[] inputs)
    {
        Instructions instructions = BuildInstructions(inputs, BaseCost);
        int totalElapsedTime = instructions.SimulateInstructionsUsage(NumberOfWorkers);
        return totalElapsedTime.ToString();
    }

    public class InstructionNode
    {
        public string NodeID { get; set; }

        public List<string> PreviousNodeIDs { get; } = new();

        public int Cost { get; set; }

        public bool Running { get; set; }

        public bool Used { get; set; }

        public bool CanBeUsed(Dictionary<string, InstructionNode> allNodes)
        {
            if (PreviousNodeIDs.Count == 0) { return true; }
            bool allPreviousUsed = PreviousNodeIDs.All(nodeID => allNodes[nodeID].Used);
            return allPreviousUsed;
        }
    }

    public class Instructions
    {
        public Dictionary<string, InstructionNode> Nodes { get; } = new();

        public InstructionNode GetNode(string nodeID)
        {
            InstructionNode node = null;
            if (Nodes.ContainsKey(nodeID))
            {
                node = Nodes[nodeID];
            }
            else
            {
                node = new InstructionNode { NodeID = nodeID, };
                Nodes.Add(nodeID, node);
            }
            return node;
        }

        public void AddNodeRelation(string nodeID, string previousNodeID)
        {
            InstructionNode node = GetNode(nodeID);
            InstructionNode previousNode = GetNode(previousNodeID);
            node.PreviousNodeIDs.Add(previousNode.NodeID);
        }

        public List<InstructionNode> SortInstructions()
        {
            List<InstructionNode> finalNodes = new();

            foreach (InstructionNode node in Nodes.Values)
            {
                node.Used = false;
            }

            List<InstructionNode> unusedNodes;
            do
            {
                unusedNodes = Nodes.Values
                    .Where(n =>
                        n.Used == false &&
                        n.CanBeUsed(Nodes))
                    .OrderBy(n => n.NodeID)
                    .ToList();
                if (unusedNodes.Count > 0)
                {
                    InstructionNode node = unusedNodes.FirstOrDefault();
                    finalNodes.Add(node);
                    node.Used = true;
                }
            } while (unusedNodes.Count > 0);
            return finalNodes;
        }

        private class SimulatedWorker
        {
            public InstructionNode CurrentInstruction { get; set; }
            public int ElapsedTime { get; set; }

            public void SetInstruction(InstructionNode instruction)
            {
                CurrentInstruction = instruction;
                ElapsedTime = 0;
                instruction.Running = true;
            }

            public bool Work()
            {
                if (CurrentInstruction == null) { return false; }
                ElapsedTime++;
                if (CurrentInstruction.Cost <= ElapsedTime)
                {
                    CurrentInstruction.Running = false;
                    CurrentInstruction.Used = true;
                    CurrentInstruction = null;
                }
                return true;
            }
        }

        public int SimulateInstructionsUsage(int numberOfWorkers)
        {
            int totalElapsedTime = 0;
            foreach (InstructionNode node in Nodes.Values)
            {
                node.Used = false;
                node.Running = false;
            }
            List<SimulatedWorker> workers = new(numberOfWorkers);
            for (int i = 0; i < numberOfWorkers; i++)
            {
                workers.Add(new SimulatedWorker());
            }

            bool anyWorkerWitoutWork;
            do
            {
                bool anyWorkDone = false;
                foreach (SimulatedWorker worker in workers)
                {
                    if (worker.Work())
                    {
                        anyWorkDone = true;
                    }
                }
                if (anyWorkDone) { totalElapsedTime++; }

                anyWorkerWitoutWork = workers.Any(w => w.CurrentInstruction == null);
                if (anyWorkerWitoutWork)
                {
                    List<InstructionNode> unusedNodes = Nodes.Values
                        .Where(n =>
                            n.Used == false && n.Running == false &&
                            n.CanBeUsed(Nodes))
                        .OrderBy(n => n.NodeID)
                        .ToList();
                    if (unusedNodes.Count > 0)
                    {
                        List<SimulatedWorker> workersWithoutWork = workers.Where(w => w.CurrentInstruction == null).ToList();
                        for (int i = 0; i < workersWithoutWork.Count && i < unusedNodes.Count; i++)
                        {
                            workersWithoutWork[i].SetInstruction(unusedNodes[i]);
                        }
                    }
                }
            } while (workers.Any(w => w.CurrentInstruction != null));
            return totalElapsedTime;
        }
    }
}