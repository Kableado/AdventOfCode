using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2018
{
    /*

    --- Day 13: Mine Cart Madness ---

    A crop of this size requires significant logistics to transport produce, soil, fertilizer, and so on. The Elves are very busy pushing things around in carts on some kind of rudimentary system of tracks they've come up with.

    Seeing as how cart-and-track systems don't appear in recorded history for another 1000 years, the Elves seem to be making this up as they go along. They haven't even figured out how to avoid collisions yet.

    You map out the tracks (your puzzle input) and see where you can help.

    Tracks consist of straight paths (| and -), curves (/ and \), and intersections (+). Curves connect exactly two perpendicular pieces of track; for example, this is a closed loop:

    /----\
    |    |
    |    |
    \----/

    Intersections occur when two perpendicular paths cross. At an intersection, a cart is capable of turning left, turning right, or continuing straight. Here are two loops connected by two intersections:

    /-----\
    |     |
    |  /--+--\
    |  |  |  |
    \--+--/  |
       |     |
       \-----/

    Several carts are also on the tracks. Carts always face either up (^), down (v), left (<), or right (>). (On your initial map, the track under each cart is a straight path matching the direction the cart is facing.)

    Each time a cart has the option to turn (by arriving at any intersection), it turns left the first time, goes straight the second time, turns right the third time, and then repeats those directions starting again with left the fourth time, straight the fifth time, and so on. This process is independent of the particular intersection at which the cart has arrived - that is, the cart has no per-intersection memory.

    Carts all move at the same speed; they take turns moving a single step at a time. They do this based on their current location: carts on the top row move first (acting from left to right), then carts on the second row move (again from left to right), then carts on the third row, and so on. Once each cart has moved one step, the process repeats; each of these loops is called a tick.

    For example, suppose there are two carts on a straight track:

    |  |  |  |  |
    v  |  |  |  |
    |  v  v  |  |
    |  |  |  v  X
    |  |  ^  ^  |
    ^  ^  |  |  |
    |  |  |  |  |

    First, the top cart moves. It is facing down (v), so it moves down one square. Second, the bottom cart moves. It is facing up (^), so it moves up one square. Because all carts have moved, the first tick ends. Then, the process repeats, starting with the first cart. The first cart moves down, then the second cart moves up - right into the first cart, colliding with it! (The location of the crash is marked with an X.) This ends the second and last tick.

    Here is a longer example:

    /->-\        
    |   |  /----\
    | /-+--+-\  |
    | | |  | v  |
    \-+-/  \-+--/
      \------/   

    /-->\        
    |   |  /----\
    | /-+--+-\  |
    | | |  | |  |
    \-+-/  \->--/
      \------/   

    /---v        
    |   |  /----\
    | /-+--+-\  |
    | | |  | |  |
    \-+-/  \-+>-/
      \------/   

    /---\        
    |   v  /----\
    | /-+--+-\  |
    | | |  | |  |
    \-+-/  \-+->/
      \------/   

    /---\        
    |   |  /----\
    | /->--+-\  |
    | | |  | |  |
    \-+-/  \-+--^
      \------/   

    /---\        
    |   |  /----\
    | /-+>-+-\  |
    | | |  | |  ^
    \-+-/  \-+--/
      \------/   

    /---\        
    |   |  /----\
    | /-+->+-\  ^
    | | |  | |  |
    \-+-/  \-+--/
      \------/   

    /---\        
    |   |  /----<
    | /-+-->-\  |
    | | |  | |  |
    \-+-/  \-+--/
      \------/   

    /---\        
    |   |  /---<\
    | /-+--+>\  |
    | | |  | |  |
    \-+-/  \-+--/
      \------/   

    /---\        
    |   |  /--<-\
    | /-+--+-v  |
    | | |  | |  |
    \-+-/  \-+--/
      \------/   

    /---\        
    |   |  /-<--\
    | /-+--+-\  |
    | | |  | v  |
    \-+-/  \-+--/
      \------/   

    /---\        
    |   |  /<---\
    | /-+--+-\  |
    | | |  | |  |
    \-+-/  \-<--/
      \------/   

    /---\        
    |   |  v----\
    | /-+--+-\  |
    | | |  | |  |
    \-+-/  \<+--/
      \------/   

    /---\        
    |   |  /----\
    | /-+--v-\  |
    | | |  | |  |
    \-+-/  ^-+--/
      \------/   

    /---\        
    |   |  /----\
    | /-+--+-\  |
    | | |  X |  |
    \-+-/  \-+--/
      \------/   

    After following their respective paths for a while, the carts eventually crash. To help prevent crashes, you'd like to know the location of the first crash. Locations are given in X,Y coordinates, where the furthest left column is X=0 and the furthest top row is Y=0:

               111
     0123456789012
    0/---\        
    1|   |  /----\
    2| /-+--+-\  |
    3| | |  X |  |
    4\-+-/  \-+--/
    5  \------/   

    In this example, the location of the first crash is 7,3.

    --- Part Two ---

    There isn't much you can do to prevent crashes in this ridiculous system. However, by predicting the crashes, the Elves know where to be in advance and instantly remove the two crashing carts the moment any crash occurs.

    They can proceed like this for a while, but eventually, they're going to run out of carts. It could be useful to figure out where the last cart that hasn't crashed will end up.

    For example:

    />-<\  
    |   |  
    | /<+-\
    | | | v
    \>+</ |
      |   ^
      \<->/

    /---\  
    |   |  
    | v-+-\
    | | | |
    \-+-/ |
      |   |
      ^---^

    /---\  
    |   |  
    | /-+-\
    | v | |
    \-+-/ |
      ^   ^
      \---/

    /---\  
    |   |  
    | /-+-\
    | | | |
    \-+-/ ^
      |   |
      \---/

    After four very expensive crashes, a tick ends with only one cart remaining; its final location is 6,4.

    What is the location of the last cart at the end of the first tick where it is the only cart left?

    */

    public class Day13 : IDay
    {
        private bool ShowProgress { get; set; } = false;

        public string ResolvePart1(string[] inputs)
        {
            Initialize(inputs);
            Train colidingTrain = null;
            do
            {
                if (ShowProgress) { ShowGrid(); }
                colidingTrain = SimulateForFirstCollision();
            } while (colidingTrain == null);
            return string.Format("{0},{1}", colidingTrain.X, colidingTrain.Y);
        }

        public string ResolvePart2(string[] inputs)
        {
            Initialize(inputs);
            Train lastCart = null;
            do
            {
                if (ShowProgress) { ShowGrid(); }
                lastCart = SimulateForLastCart();
            } while (lastCart == null);
            return string.Format("{0},{1}", lastCart.X, lastCart.Y);
        }

        private enum TrainDirection
        {
            North,
            South,
            East,
            West,
        };

        private enum TrainTurning
        {
            Left,
            Right,
            None,
        }

        private class Train
        {
            public int X { get; set; }
            public int Y { get; set; }

            public TrainDirection Direction { get; set; }
            public TrainTurning NextIntersectionTurn { get; set; }

            public void Simulate(char[,] grid)
            {
                if (Direction == TrainDirection.North)
                {
                    Y--;
                }
                if (Direction == TrainDirection.South)
                {
                    Y++;
                }
                if (Direction == TrainDirection.East)
                {
                    X++;
                }
                if (Direction == TrainDirection.West)
                {
                    X--;
                }

                char cell = grid[X, Y];
                if (cell == '/')
                {
                    if (Direction == TrainDirection.North)
                    {
                        Direction = TrainDirection.East;
                    }
                    else if (Direction == TrainDirection.South)
                    {
                        Direction = TrainDirection.West;
                    }
                    else if (Direction == TrainDirection.East)
                    {
                        Direction = TrainDirection.North;
                    }
                    else if (Direction == TrainDirection.West)
                    {
                        Direction = TrainDirection.South;
                    }
                }
                if (cell == '\\')
                {
                    if (Direction == TrainDirection.North)
                    {
                        Direction = TrainDirection.West;
                    }
                    else if (Direction == TrainDirection.South)
                    {
                        Direction = TrainDirection.East;
                    }
                    else if (Direction == TrainDirection.East)
                    {
                        Direction = TrainDirection.South;
                    }
                    else if (Direction == TrainDirection.West)
                    {
                        Direction = TrainDirection.North;
                    }
                }
                if (cell == '+')
                {
                    if (NextIntersectionTurn == TrainTurning.Left)
                    {
                        if (Direction == TrainDirection.North)
                        {
                            Direction = TrainDirection.West;
                        }
                        else if (Direction == TrainDirection.South)
                        {
                            Direction = TrainDirection.East;
                        }
                        else if (Direction == TrainDirection.East)
                        {
                            Direction = TrainDirection.North;
                        }
                        else if (Direction == TrainDirection.West)
                        {
                            Direction = TrainDirection.South;
                        }
                        NextIntersectionTurn = TrainTurning.None;
                    }
                    else if (NextIntersectionTurn == TrainTurning.None)
                    {
                        NextIntersectionTurn = TrainTurning.Right;
                    }
                    else if (NextIntersectionTurn == TrainTurning.Right)
                    {
                        if (Direction == TrainDirection.North)
                        {
                            Direction = TrainDirection.East;
                        }
                        else if (Direction == TrainDirection.South)
                        {
                            Direction = TrainDirection.West;
                        }
                        else if (Direction == TrainDirection.East)
                        {
                            Direction = TrainDirection.South;
                        }
                        else if (Direction == TrainDirection.West)
                        {
                            Direction = TrainDirection.North;
                        }
                        NextIntersectionTurn = TrainTurning.Left;
                    }
                }
            }
        }

        private int _width;
        private int _height;
        private char[,] _grid = null;
        private List<Train> _trains = new List<Train>();

        private void Initialize(string[] inputs)
        {
            _width = inputs.Max(s => s.Length);
            _height = inputs.Length;
            _grid = new char[_width, _height];
            _trains.Clear();
            for (int j = 0; j < inputs.Length; j++)
            {
                for (int i = 0; i < inputs[j].Length; i++)
                {
                    char cell = inputs[j][i];
                    if (cell == '^')
                    {
                        _trains.Add(new Train
                        {
                            X = i,
                            Y = j,
                            Direction = TrainDirection.North,
                            NextIntersectionTurn = TrainTurning.Left,
                        });
                        cell = '|';
                    }
                    if (cell == 'v')
                    {
                        _trains.Add(new Train
                        {
                            X = i,
                            Y = j,
                            Direction = TrainDirection.South,
                            NextIntersectionTurn = TrainTurning.Left,
                        });
                        cell = '|';
                    }
                    if (cell == '<')
                    {
                        _trains.Add(new Train
                        {
                            X = i,
                            Y = j,
                            Direction = TrainDirection.West,
                            NextIntersectionTurn = TrainTurning.Left,
                        });
                        cell = '-';
                    }
                    if (cell == '>')
                    {
                        _trains.Add(new Train
                        {
                            X = i,
                            Y = j,
                            Direction = TrainDirection.East,
                            NextIntersectionTurn = TrainTurning.Left,
                        });
                        cell = '-';
                    }
                    _grid[i, j] = cell;
                }
            }
        }

        private Train SimulateForFirstCollision()
        {
            Train collidingTrain = null;
            IEnumerable<Train> orderedTrains = _trains.OrderBy(t => t.X + (t.Y * _width));
            foreach (Train t in orderedTrains)
            {
                t.Simulate(_grid);
                collidingTrain = _trains.FirstOrDefault(x => x.X == t.X && x.Y == t.Y && t != x);
                if (collidingTrain != null) { break; }
            }
            return collidingTrain;
        }

        private Train SimulateForLastCart()
        {
            List<Train> orderedTrains = _trains.OrderBy(t => t.X + (t.Y * _width)).ToList();
            foreach (Train t in orderedTrains)
            {
                t.Simulate(_grid);
                Train collidingTrain = _trains.FirstOrDefault(x => x.X == t.X && x.Y == t.Y && t != x);
                if (collidingTrain != null)
                {
                    _trains.Remove(t);
                    _trains.Remove(collidingTrain);
                }
            }
            if (_trains.Count == 1)
            {
                return _trains[0];
            }
            return null;
        }

        private void ShowGrid()
        {
            Console.WriteLine();
            for (int j = 0; j < _height; j++)
            {
                for (int i = 0; i < _width; i++)
                {
                    Train t = _trains.FirstOrDefault(x => x.X == i && x.Y == j);
                    if (t != null)
                    {
                        if (t.Direction == TrainDirection.North)
                        {
                            Console.Write("^");
                        }
                        if (t.Direction == TrainDirection.East)
                        {
                            Console.Write(">");
                        }
                        if (t.Direction == TrainDirection.South)
                        {
                            Console.Write("v");
                        }
                        if (t.Direction == TrainDirection.West)
                        {
                            Console.Write("<");
                        }
                    }
                    else
                    {
                        Console.Write(_grid[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }

    }
}
