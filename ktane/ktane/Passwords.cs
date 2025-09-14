using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ktane
{
    internal class Passwords
    {
        protected List<char[]> columns = [];

        public Passwords()
        {
            bool redoPassword = false;
            string word;
            do
            {
                word = "";
                do
                {
                    AddColumn();
                    try
                    {
                        word = SearchWordBank();
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Password not found!");
                        redoPassword = true;
                        this.columns.Clear();
                    }
                } while (word == "-1");
            } while(redoPassword);

            Console.WriteLine("The password is " + word);
        }

        private void AddColumn()
        {
            Console.WriteLine("Letters in column " + (this.columns.Count + 1) + ":");
            this.columns.Add(ReadColumn());
        }
        private char[] ReadColumn()
        {
            char[] column = new char[6];

            for (int i = 0; i < column.Length; i++)
            {
                Console.WriteLine($"Letter {i + 1}:");
                try
                {
                    column[i] = ReadLetter();
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid letter!");
                    i--;
                }
            }

            return column;
        }
        private static char ReadLetter()
        {
            bool b = char.TryParse(Console.ReadLine(), out char letter);
            if (!b || !char.IsLetter(letter)) throw new ArgumentException();
            return letter;
        }
        private string SearchWordBank()
        {
            List<string> wordBank = [
                "about", "after", "again", "below", "could",
                "every", "first", "found", "great", "house",
                "large", "learn", "never", "other", "place",
                "plant", "point", "right", "small", "sound",
                "spell", "still", "study", "their", "there",
                "these", "thing", "think", "three", "water",
                "where", "which", "world", "would", "write"
            ];
            int numOfWords = 0;
            string output = "";

            foreach (string word in wordBank)
            {
                if (CheckForLetters(word))
                {
                    output = word;
                    numOfWords++;
                }
                if (numOfWords > 1) return "-1";
            }

            if (numOfWords == 1) return output;
            throw new ArgumentException();
        }
        private bool CheckForLetters(string word)
        {
            for (int i = 0; i < this.columns.Count; i++)
                if (!this.columns[i].Contains(word[i])) return false;
            return true;
        }
    }
}
