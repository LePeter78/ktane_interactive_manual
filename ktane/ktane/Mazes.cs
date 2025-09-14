using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ktane
{
    internal class Mazes
    {
        internal class Cell
        {
            internal List<int> neighbours;

            internal Cell(List<int> neighbours)
            {
                this.neighbours = neighbours;
            }
        }
        internal class Maze
        {
            internal Cell[] cells;

            internal Maze(Cell[] cells)
            {
                this.cells = cells;
            }
        }

        protected int circle;
        protected int mazeId;
        protected int start;
        protected int goal;

        public Mazes()
        {
            PrintInstructions();
            GetCircle();
            GetStartAndGoal();

            Maze maze = FindMaze();
            List<int> route = [];

            FindRoute(maze, this.start, this.goal, [], ref route);
            PrintRoute(route);
        }

        private static void PrintInstructions()
        {
            Console.WriteLine("Position handling in this module is as follows:");
            Console.WriteLine("Columns are letters (a-f), ascending from left to right");
            Console.WriteLine("Rows are numbers (1-6), ascending from top to bottom\n\n");
        }
        private void GetCircle()
        {
            Console.WriteLine("Coordinates of a circle:");

            bool redo;
            do
            {
                redo = false;
                try
                {
                    this.circle = CoordinatesToNum(GetCoordinates());
                    this.mazeId = FindMazeIndex();
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Maze not found!");
                    redo = true;
                }
            } while (redo);
        }
        private void GetStartAndGoal()
        {
            Console.WriteLine("Starting position:");
            this.start = CoordinatesToNum(GetCoordinates());
            Console.WriteLine("Finishing position:");
            this.goal = CoordinatesToNum(GetCoordinates());
        }
        private static (char, int) GetCoordinates()
        {
            char column;
            int row;

            Console.WriteLine("Column (a-f):");
            do
            {
                string input = Console.ReadLine();
                column = input[0];
                if(!IsColumnValid(column)) Console.WriteLine("Invalid Input!");
            } while (!IsColumnValid(column));

            Console.WriteLine("Row (1-6):");
            ReadInt read = new(1, 6);
            row = read.num;

            return (column, row);
        }
        private static bool IsColumnValid(char column)
        {
            return column >= 97 && column <= 102;
        }
        private static int CoordinatesToNum((char, int) coords)
        {
            char column = coords.Item1;
            int row = coords.Item2;
            return column - 97 + (row - 1) * 6;
        }
        private int FindMazeIndex()
        {
            if (CircleAtEither(6, 17)) return 0;
            if (CircleAtEither(10, 19)) return 1;
            if (CircleAtEither(21, 23)) return 2;
            if (CircleAtEither(0, 18)) return 3;
            if (CircleAtEither(19, 33)) return 4;
            if (CircleAtEither(4, 26)) return 5;
            if (CircleAtEither(1, 31)) return 6;
            if (CircleAtEither(3, 20)) return 7;
            if (CircleAtEither(8, 24)) return 8;
            throw new ArgumentException();
        }
        private Maze FindMaze()
        {
            List<Maze> AllMazes =
            [
                new
                ([//1
                    new([1, 6]), new([0, 2]), new([1, 8]), new([4, 9]), new([3, 5]), new([4]),
                    new([0, 12]), new([8, 13]), new([2, 7]), new([3, 10]), new([9, 11]), new([10, 17]),
                    new([6, 18]), new([7, 14]), new([13, 20]), new([16, 21]), new([15, 17]), new([11, 16, 23]),
                    new([12, 24]), new([20]), new([14, 19, 21]), new([15, 20]), new([23]), new([17, 22, 29]),
                    new([18, 25, 30]), new([24, 26]), new([25, 32]), new([28, 33]), new([27]), new([23, 35]),
                    new([24, 31]), new([30]), new([26, 33]), new([27, 32]), new([35]), new([29, 34])
                ]),
                new
                ([//2
                    new([1]), new([0, 2, 7]), new([1]), new([4, 9]), new([3, 5, 10]), new([4]),
                    new([7, 12]), new([1, 6]), new([9, 14]), new([3, 8]), new([4, 11]), new([10, 17]),
                    new([6, 18]), new([14, 19]), new([8, 13]), new([16, 21]), new([15, 17]), new([11, 16, 23]),
                    new([12, 19, 24]), new([13, 18]), new([21, 26]), new([15, 20]), new([28]), new([17, 29]),
                    new([18, 30]), new([31]), new([20, 32]), new([28, 33]), new([22, 27]), new([23, 35]),
                    new([24]), new([25, 32]), new([26, 31]), new([27, 34]), new([33, 35]), new([29, 34])
                ]),
                new
                ([//3
                    new([1, 6]), new([0, 2]), new([1, 8]), new([9]), new([5, 10]), new([4, 11]),
                    new([0]), new([13]), new([2, 14]), new([3, 10]), new([9, 4]), new([5, 17]),
                    new([13, 18]), new([7, 12, 19]), new([8, 20]), new([16, 21]), new([15, 22]), new([11, 23]),
                    new([12, 24]), new([13, 25]), new([14, 26]), new([15, 27]), new([16, 28]), new([17, 29]),
                    new([18, 30]), new([19, 26]), new([20, 25]), new([21, 33]), new([22, 34]), new([23, 35]),
                    new([24, 31]), new([30, 32]), new([31, 33]), new([27, 32]), new([28, 35]), new([29, 34])
                ]),
                new
                ([//4
                    new([1, 6]), new([0, 7]), new([3]), new([2, 4]), new([3, 5]), new([4, 11]),
                    new([0, 12]), new([1, 13]), new([9, 14]), new([8, 10]), new([9, 11]), new([5, 10, 17]),
                    new([6, 18]), new([7, 14]), new([8, 13]), new([16, 21]), new([15]), new([11, 23]),
                    new([12, 24]), new([20]), new([19, 21]), new([15, 20, 22]), new([21, 23]), new([17, 22, 29]),
                    new([18, 25, 30]), new([24, 26]), new([25, 27]), new([26, 28]), new([27, 34]), new([23, 35]),
                    new([24, 31]), new([30, 32]), new([31]), new([34]), new([28, 33]), new([29])
                ]),
                new
                ([//5
                    new([0]), new([0, 2]), new([1, 3]), new([2, 4]), new([3, 5, 10]), new([4, 11]),
                    new([7, 12]), new([6, 8]), new([7, 9]), new([8, 10, 15]), new([4, 9]), new([5]),
                    new([6, 13, 18]), new([12, 19]), new([15]), new([9, 14]), new([17, 22]), new([16, 23]),
                    new([12, 24]), new([13, 20]), new([19, 21]), new([20, 27]), new([16]), new([17, 29]),
                    new([18, 30]), new([26, 31]), new([25, 27]), new([21, 26, 28]), new([27]), new([23, 35]),
                    new([24]), new([25, 32]), new([31, 33]), new([32, 34]), new([33, 35]), new([29, 34])
                ]),
                new
                ([//6
                    new([6]), new([2, 7]), new([1, 8]), new([4]), new([3, 5, 10]), new([4, 11]),
                    new([0, 12]), new([1, 13]), new([2, 14]), new([10, 15]), new([4, 9]), new([5, 17]),
                    new([6, 13, 18]), new([7, 12]), new([8]), new([9, 21]), new([17, 22]), new([11, 16]),
                    new([12, 19]), new([18, 25]), new([21, 26]), new([15, 20, 27]), new([16, 28]), new([29]),
                    new([25, 30]), new([19, 24]), new([20]), new([21, 33]), new([22, 29]), new([23, 28, 35]),
                    new([24, 31]), new([30, 32]), new([31, 33]), new([27, 32]), new([35]), new([29, 34])
                ]),
                new
                ([//7
                    new([1, 6]), new([0, 2]), new([1, 3]), new([2, 9]), new([5, 10]), new([4, 11]),
                    new([0, 12]), new([8, 13]), new([7]), new([3, 10]), new([4, 9]), new([5, 17]),
                    new([6, 13]), new([7, 12]), new([15, 20]), new([14]), new([17, 22]), new([11, 16]),
                    new([19, 24]), new([18, 25]), new([14, 21, 26]), new([20, 22]), new([16, 21]), new([29]),
                    new([18, 30]), new([19]), new([20, 27]), new([26, 28]), new([27, 34]), new([23, 35]),
                    new([24, 31]), new([30, 32]), new([31, 33]), new([32, 34]), new([28, 33, 35]), new([29, 34])
                ]),
                new
                ([//8
                    new([6]), new([2, 7]), new([1, 3]), new([2, 9]), new([5, 10]), new([4, 11]),
                    new([0, 7, 12]), new([1, 6, 8]), new([7]), new([3, 10]), new([4, 9]), new([5, 17]),
                    new([6, 18]), new([14, 19]), new([13, 15]), new([14, 16]), new([15, 22]), new([11, 23]),
                    new([12, 24]), new([13, 20]), new([19, 26]), new([22]), new([16, 21, 23]), new([17, 22]),
                    new([18, 30]), new([31]), new([20, 27]), new([26, 28]), new([27, 29]), new([28]),
                    new([24, 31]), new([25, 30, 32]), new([31, 33]), new([32, 34]), new([33, 35]), new([34])
                ]),
                new
                ([//9
                    new([6]), new([2, 7]), new([1, 3]), new([2, 4]), new([3, 5, 10]), new([4, 11]),
                    new([0, 12]), new([1, 13]), new([9, 14]), new([8]), new([4, 16]), new([5, 17]),
                    new([6, 13, 18]), new([7, 12, 14]), new([8, 13]), new([16, 21]), new([10, 15]), new([11, 23]),
                    new([12, 24]), new([25]), new([21, 26]), new([15, 20]), new([23]), new([17, 22, 29]),
                    new([18, 30]), new([19, 31]), new([20, 32]), new([28, 33]), new([27, 34]), new([23]),
                    new([24, 31]), new([25, 30]), new([26, 33]), new([27, 32]), new([28, 35]), new([34])
                ])
            ];
            return AllMazes[this.mazeId];
        }
        private bool CircleAtEither(int a, int b)
        {
            return this.circle == a || this.circle == b;
        }
        private static bool FindRoute(Maze maze, int current, int goal, List<int> visited, ref List<int> route)
        {
            if (current == goal)
            {
                route.Add(current);
                return true;
            }

            visited.Add(current);

            foreach (int neighbour in maze.cells[current].neighbours)
            {
                if(!IsVisited(visited, neighbour))
                {
                    if(FindRoute(maze, neighbour, goal, visited, ref route))
                    {
                        route.Add(current);
                        return true;
                    }
                }
            }
            
            return false;
        }
        private static bool IsVisited(List<int> visited, int cell)
        {
            return visited.Contains(cell);
        }
        private static void PrintRoute(List<int> route)
        {
            Console.WriteLine();
            for(int i = route.Count - 1; i > 0; i--)
            {
                Console.Write(GetPosition(route[i] - route[i - 1]));
                if(i != 1) Console.Write(", ");
            }
        }
        private static string GetPosition(int difference)
        {
            return difference switch
            {
                6 => "up",
                1 => "left",
                -1 => "right",
                -6 => "down",
                _ => throw new ArgumentException(),
            };
        }
    }
}
