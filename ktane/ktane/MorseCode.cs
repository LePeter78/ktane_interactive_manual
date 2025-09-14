using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ktane
{
    internal class MorseCode
    {
        protected string word = "";

        public MorseCode()
        {
            PrintInstructions();

            string output = "-1";
            do
            {
                PrintWord();
                AddInput();
                try
                {
                    output = SearchWordBank();
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Word not found!");
                    Console.WriteLine("The module is reset\n\n");
                    this.word = "";
                }
            } while (output == "-1" || this.word != "");

            Console.WriteLine("The word is " + output);
            Console.WriteLine("Transmit at frequency 3." + WordToFrequency(output));
        }

        private static void PrintInstructions()
        {
            Console.WriteLine("Enter the morse code flashing on the module, letter by letter");
            Console.WriteLine("You don't neccesarily have to start from the beginning, just type the letters in order");
            Console.WriteLine("If the word starts over, type \"*\"");
            Console.WriteLine("Type \"0\" to start over");
            Console.WriteLine("For a short input, type \".\" and for a long one, type \"-\"");
            Console.WriteLine();
        }
        private void PrintWord()
        {
            if (this.word == "" || this.word == "*") return;
            Console.Write("The word is ");

            if(!this.word.Contains('*')) Console.WriteLine("..." + this.word + "...");
            else
            {
                foreach (char letter in word)
                {
                    if (letter == '*') Console.Write("...");
                    else Console.Write(letter);
                }
                Console.WriteLine();
            }
        }
        private void AddInput()
        {
            bool redo;
            string newLetter = "";
            Console.Write("Next letter: ");

            do
            {
                string input = Console.ReadLine();
                redo = false;

                if (input == "*")
                {
                    this.word = "*" + this.word;
                    return;
                }
                if (input == "0")
                {
                    this.word = "";
                    return;
                }

                try
                {
                    newLetter = MorseToLetter(input);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid input!");
                    redo = true;
                }
            } while (redo);

            if(word.Contains('*')) this.word = this.word.Insert(FindStar(), newLetter);
            else this.word = this.word.Insert(this.word.Length, newLetter);
        }
        private static string MorseToLetter(string input)
        {
            return input switch
            {
                ".-" => "a",
                "-..." => "b",
                "-.-." => "c",
                "-.." => "d",
                "." => "e",
                "..-." => "f",
                "--." => "g",
                "...." => "h",
                ".." => "i",
                ".---" => "j",
                "-.-" => "k",
                ".-.." => "l",
                "--" => "m",
                "-." => "n",
                "---" => "o",
                ".--." => "p",
                "--.-" => "q",
                ".-." => "r",
                "..." => "s",
                "-" => "t",
                "..-" => "u",
                "...-" => "v",
                ".--" => "w",
                "-..-" => "x",
                "-.--" => "y",
                "--.." => "z",
                _ => throw new ArgumentException()
            };
        }
        private int FindStar()
        {
            for (int i = 0; i < this.word.Length; i++)
            {
                if (this.word[i] == '*') return i;
            }
            return 0;
        }
        private string SearchWordBank()
        {
            int numOfMatches = 0;
            string output = "";
            string[] wordBank =
            [
                "shell", "halls", "slick", "trick", "boxes", "leaks", "strobe", "bistro",
                "flick","bombs", "break", "brick", "steak", "sting", "vector", "beats"
            ];
            foreach (string entry in wordBank) 
            {
                if (WordsMatch(entry))
                {
                    output = entry;
                    numOfMatches++;
                }
                if (numOfMatches > 1) return "-1";
            }

            if (numOfMatches == 1)
            {
                this.word = "";
                return output;
            }
            throw new ArgumentException();
        }
        private bool WordsMatch(string entry)
        {
            if (this.word.Contains('*'))
            {
                for (int i = 0; this.word[i] != '*'; i++)
                    if (this.word[i] != entry[i]) return false;
                for (int i = this.word.Length - 1; this.word[i] != '*'; i--)
                    if (this.word[i] != entry[i - this.word.Length + entry.Length]) return false;
                return true;
            }
            else return entry.Contains(this.word);
        }
        private static int WordToFrequency(string output)
        {
            return output switch
            {
                "shell" => 505,
                "halls" => 515,
                "slick" => 522,
                "trick" => 532,
                "boxes" => 535,
                "leaks" => 542,
                "strobe" => 545,
                "bistro" => 552,
                "flick" => 555,
                "bombs" => 565,
                "break" => 572,
                "brick" => 575,
                "steak" => 582,
                "sting" => 592,
                "vector" => 595,
                "beats" => 600
            };
        }
    }
}
