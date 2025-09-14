using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ktane
{
    internal class SimonSays
    {
        protected enum Colors
        {
            red,
            green,
            blue,
            yellow
        };

        protected int strikes;
        protected bool hasVowel;
        protected List<Colors> colorSequence = [];

        public SimonSays(EdgeWork edge)
        {
            this.hasVowel = edge.SerialHasVowel();

            SetStrikes();
            Console.WriteLine();
            AddColor();
            Menu();
        }

        private void Menu()
        {
            bool redo;

            do
            {
                redo = true;
                Console.Clear();
                GetOutput();
                Console.WriteLine();

                Console.WriteLine("Choose an option:");
                Console.WriteLine("0: exit");
                Console.WriteLine("1: add new color");
                Console.WriteLine("2: update number of strikes");
                Console.WriteLine("3: remove last color");
                Console.WriteLine("4: clear color sequence");

                ReadInt read = new(0, 4);
                int selection = read.num;

                switch (selection)
                {
                    case 1:
                        AddColor();
                        break;
                    case 2:
                        SetStrikes();
                        break;
                    case 3:
                        RemoveLastColor();
                        break;
                    case 4:
                        ClearColors();
                        break;
                    case 0:
                        redo = false;
                        break;
                }
            } while (redo);
        }
        private void AddColor()
        {
            Colors color = Colors.red;
            bool redo;

            Console.WriteLine("Color:");
            do
            {
                string input = Console.ReadLine().ToLower();
                redo = false;
                switch (input)
                {
                    case "red":
                        color = Colors.red;
                        break;
                    case "green":
                        color = Colors.green;
                        break;
                    case "blue":
                        color = Colors.blue;
                        break;
                    case "yellow":
                        color = Colors.yellow;
                        break;
                    default:
                        Console.WriteLine("Invalid color!");
                        redo = true;
                        break;
                }
            } while (redo);

            this.colorSequence.Add(color);
        }
        private void SetStrikes()
        {
            Console.WriteLine("Number of strikes:");

            ReadInt read = new(0, 2);
            this.strikes = read.num;
        }
        private void RemoveLastColor()
        {
            this.colorSequence.RemoveAt(colorSequence.Count - 1);
        }
        private void ClearColors()
        {
            this.colorSequence.Clear();
        }
        private void GetOutput()
        {
            if(this.colorSequence.Count == 0) return;

            Console.Write("Press");
            foreach(Colors color in this.colorSequence)
            {
                InputToOutput(color);
            }
            Console.WriteLine();
        }
        private void InputToOutput(Colors input)
        {
            if (this.hasVowel)
            {
                Colors[,] colorTable =
                {
                    { Colors.blue, Colors.yellow, Colors.red, Colors.green },
                    { Colors.yellow, Colors.blue, Colors.green, Colors.red },
                    { Colors.green, Colors.yellow, Colors.red, Colors.blue }
                };
                Console.Write(" " + colorTable[this.strikes, ColorToNum(input)]);
            }
            else
            {
                Colors[,] colorTable =
                {
                    { Colors.blue, Colors.green, Colors.yellow, Colors.red },
                    { Colors.red, Colors.yellow, Colors.blue, Colors.green },
                    { Colors.yellow, Colors.blue, Colors.green, Colors.red }
                };
                Console.Write(" " + colorTable[this.strikes, ColorToNum(input)]);
            }
        }
        private int ColorToNum(Colors input)
        {
            switch (input)
            {
                case Colors.red:
                    return 0;
                case Colors.green:
                    return 1;
                case Colors.blue:
                    return 2;
                case Colors.yellow:
                    return 3;
                default:
                    return -1;
            }
        }
    }
}
