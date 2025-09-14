using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ktane
{
    internal class WireSequences
    {
        internal enum Colors
        {
            red, blue, black
        }

        internal class Wire
        {
            internal char letter;
            internal Colors color;

            internal Wire(char letter, Colors color)
            {
                this.letter = letter;
                this.color = color;
            }
        }

        protected int redNum = 0;
        protected int blueNum = 0;
        protected int blackNum = 0;
        
        public WireSequences()
        {
            for (int i = 0; i < 9; i++)
            {
                Wire wire = ReadNextWire(i + 1);

                if (EvaluateWire(wire))
                    Console.WriteLine("Cut the wire\n");
                else Console.WriteLine("Do not cut the wire\n");

                IncreaseWireNum(wire.color);
            }
        }

        private static Wire ReadNextWire(int numOfWire)
        {
            Console.WriteLine("Color of wire " + numOfWire + ":");
            Colors color = Colors.red;

            bool redo;
            do
            {
                redo = false;
                try
                {
                    color = ReadColor();
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid color!");
                    redo = true;
                }
            } while (redo);

            Console.WriteLine("The letter it connects to:");
            char letter = '0';

            do
            {
                redo = false;
                try
                {
                    letter = ReadLetter();
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid letter!");
                    redo = true;
                }
            } while (redo);

            return new(letter, color);
        }
        private static Colors ReadColor()
        {
            string input = Console.ReadLine().ToLower();
            Colors color = input switch
            {
                "red" => Colors.red,
                "blue" => Colors.blue,
                "black" => Colors.black,
                _ => throw new ArgumentException()
            };
            return color;
        }
        private static char ReadLetter()
        {
            string input = Console.ReadLine().ToUpper();
            char letter = input switch
            {
                "A" => 'A',
                "B" => 'B',
                "C" => 'C',
                _ => throw new ArgumentException()
            };
            return letter;
        }
        private bool EvaluateWire(Wire wire)
        {
            List<List<char>> redLetters =
            [
                ['C'],
                ['B'],
                ['A'],
                ['A','C'],
                ['B'],
                ['A','C'],
                ['A','B','C'],
                ['A','B'],
                ['B']
            ];
            List<List<char>> blueLetters =
            [
                ['B'],
                ['A','C'],
                ['B'],
                ['A'],
                ['B'],
                ['B','C'],
                ['C'],
                ['A','C'],
                ['A']
            ];
            List<List<char>> blackLetters =
            [
                ['A','B','C'],
                ['A','C'],
                ['B'],
                ['A','C'],
                ['B'],
                ['B','C'],
                ['A','B'],
                ['C'],
                ['C']
            ];

            return wire.color switch
            {
                Colors.red => redLetters[redNum].Contains(wire.letter),
                Colors.blue => blueLetters[blueNum].Contains(wire.letter),
                Colors.black => blackLetters[blackNum].Contains(wire.letter),
                _ => throw new ArgumentException(),
            };
        }
        private void IncreaseWireNum(Colors color)
        {
            switch (color)
            {
                case Colors.red:
                    redNum++;
                    break;
                case Colors.blue:
                    blueNum++;
                    break;
                case Colors.black:
                    blackNum++;
                    break;
            }
        }
    }
}
