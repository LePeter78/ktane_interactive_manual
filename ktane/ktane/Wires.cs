using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ktane
{
    internal class Wires
    {
        protected enum Colors
        {
            red,
            blue,
            yellow,
            white,
            black
        };

        protected int numOfWires;
        protected Colors[] wireColors;

        public Wires(EdgeWork edge)
        {
            GetNumOfWires();
            GetWireColors();
            EvaluateWires(edge);
        }

        private void GetNumOfWires()
        {
            Console.WriteLine("Number of wires:");
            ReadInt read = new(3, 6);
            this.numOfWires = read.num;
            this.wireColors = new Colors[this.numOfWires];
        }
        private void GetWireColors()
        {
            for (int i = 0; i < this.numOfWires; i++)
            {
                Console.WriteLine($"Color of wire {i + 1}:");
                bool redo;

                do
                {
                    redo = false;
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "red":
                            this.wireColors[i] = Colors.red;
                            break;
                        case "blue":
                            this.wireColors[i] = Colors.blue;
                            break;
                        case "yellow":
                            this.wireColors[i] = Colors.yellow;
                            break;
                        case "white":
                            this.wireColors[i] = Colors.white;
                            break;
                        case "black":
                            this.wireColors[i] = Colors.black;
                            break;
                        default:
                            Console.WriteLine("Invalid color!");
                            redo = true;
                            break;
                    }
                } while (redo);
            }
        }
        private void EvaluateWires(EdgeWork edge)
        {
            Console.Write("Cut the ");
            switch (this.numOfWires)
            {
                case 3:
                    if (NoneOf(Colors.red)) Console.Write("second");
                    else if (LastWire() == Colors.white) Console.Write("last");
                    else if (MoreThanOneOf(Colors.blue)) Console.Write("last blue");
                    else Console.Write("last");
                    break;
                case 4:
                    if (MoreThanOneOf(Colors.red) && edge.IsSerialLastDigitOdd())
                        Console.Write("last red");
                    else if (LastWire() == Colors.yellow && NoneOf(Colors.red))
                        Console.WriteLine("first");
                    else if (OneOf(Colors.blue)) Console.Write("first");
                    else if (MoreThanOneOf(Colors.yellow)) Console.Write("last");
                    else Console.Write("second");
                    break;
                case 5:
                    if (LastWire() == Colors.black && edge.IsSerialLastDigitOdd())
                        Console.Write("fourth");
                    if (OneOf(Colors.red) && MoreThanOneOf(Colors.yellow))
                        Console.Write("first");
                    if (NoneOf(Colors.black)) Console.Write("second");
                    else Console.Write("first");
                    break;
                case 6:
                    if (NoneOf(Colors.yellow) && edge.IsSerialLastDigitOdd())
                        Console.Write("third");
                    else if (OneOf(Colors.yellow) &&
                        MoreThanOneOf(Colors.white)) Console.Write("fourth");
                    else if (NoneOf(Colors.red)) Console.Write("last");
                    else Console.Write("fourth");
                    break;
            }
            Console.WriteLine(" wire");
        }
        private bool NoneOf(Colors check)
        {
            foreach (Colors color in this.wireColors)
            {
                if (color == check) return false;
            }

            return true;
        }
        private bool OneOf(Colors check)
        {
            int count = 0;

            foreach(Colors color in this.wireColors)
            {
                if (color == check) count++;
                if (count > 1) return false;
            }

            return count == 1;
        }
        private bool MoreThanOneOf(Colors check)
        {
            int count = 0;

            foreach(Colors color in this.wireColors)
            {
                if (color == check) count++;
                if (count > 1) return true;
            }

            return false;
        }
        private Colors LastWire()
        {
            return this.wireColors.Last();
        }
    }
}
