using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ktane
{
    internal class WhosOnFirst
    {
        protected string display;

        public WhosOnFirst()
        {
            bool redo;
            string position = "";

            do
            {
                redo = false;
                SetDisplay();
                try
                {
                    position = GetPosition();
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Word not found!");
                    redo = true;
                }
            } while (redo);

            string words = "";
            do
            {
                redo = false;
                try
                {
                    words = GetResult(position);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Word not found!");
                    redo = true;
                }
            } while (redo);

            Console.WriteLine("Press the first word out of these:");
            Console.WriteLine(words);
        }

        private void SetDisplay()
        {
            Console.WriteLine("The display at the top of the module: (Type \"empty\" if the display is empty)");
            this.display = Console.ReadLine().ToUpper();
        }
        private string GetPosition()
        {
            if (this.display == "UR") return "top left";
            if (new List<string> { "FIRST", "OKAY", "C" }.Contains(this.display)) return "top right";
            if (new List<string> { "YES", "NOTHING", "LED", "THEY ARE" }.Contains(this.display)) return "middle left";
            if (new List<string> { "BLANK", "READ", "RED", "YOU", "YOUR", "YOU'RE", "THEIR" }.Contains(this.display)) return "middle right";
            if (new List<string> { "EMPTY", "REED", "LEED", "THEY'RE" }.Contains(this.display)) return "bottom left";
            if (new List<string> { "DISPLAY", "SAYS", "NO", "LEAD", "HOLD ON", "YOU ARE", "THERE", "SEE", "CEE" }.Contains(this.display)) return "bottom right";

            throw new ArgumentException();
        }
        private static string GetResult(string pos)
        {
            List<string> wordbank =
            [
                "UHHH, RIGHT, OKAY, MIDDLE, YES, BLANK, NO, PRESS, LEFT, WHAT, WAIT, FIRST, NOTHING",
                "LEFT, OKAY, YES, MIDDLE, NO, RIGHT, NOTHING, UHHH, WAIT, READY, BLANK, WHAT, PRESS, FIRST",
                "BLANK, UHHH, WAIT, FIRST, WHAT, READY, RIGHT, YES, NOTHING, LEFT, PRESS, OKAY, NO",
                "WAIT, RIGHT, OKAY, MIDDLE, BLANK",
                "UHHH, RIGHT, OKAY, MIDDLE, YES, BLANK, NO, PRESS, LEFT, WHAT, WAIT, FIRST, NOTHING",
                "OKAY, RIGHT, UHHH, MIDDLE, FIRST, WHAT, PRESS, READY, NOTHING, YES",
                "UHHH, WHAT",
                "READY, NOTHING, LEFT, WHAT, OKAY, YES, RIGHT, NO, PRESS, BLANK, UHHH",
                "RIGHT, LEFT",
                "YES, NOTHING, READY, PRESS, NO, WAIT, WHAT, RIGHT",
                "BLANK, READY, OKAY, WHAT, NOTHING, PRESS, NO, WAIT, LEFT, MIDDLE",
                "MIDDLE, NO, FIRST, YES, UHHH, NOTHING, WAIT, OKAY",

                "UHHH, NO, BLANK, OKAY, YES, LEFT, FIRST, PRESS, WHAT, WAIT",
                "RIGHT, MIDDLE, YES, READY, PRESS",
                "SURE, YOU ARE, YOUR, YOU'RE, NEXT, UH HUH, UR, HOLD, WHAT?, YOU",
                "YOUR, NEXT, LIKE, UH HUH, WHAT?, DONE, UH UH, HOLD, YOU, U, YOU'RE, SURE, UR, YOU ARE",
                "UH UH, YOU ARE, UH HUH, YOUR",
                "YOU, YOU'RE",
                "DONE, U, UR",
                "UH HUH, SURE, NEXT, WHAT?, YOU'RE, UR, UH UH, DONE, U",
                "UH HUH",
                "UR, U, YOU ARE, YOU'RE, NEXT, UH UH",
                "YOU, HOLD, YOU'RE, YOUR, U, DONE, UH UH, LIKE, YOU ARE, UH HUH, UR, NEXT, WHAT?",
                "SURE, UH HUH, NEXT, WHAT?, YOUR, UR, YOU'RE, HOLD, LIKE, YOU, U, YOU ARE, UH UH, DONE",
                "WHAT?, UH HUH, UH UH, YOUR, HOLD, SURE, NEXT",
                "YOU ARE, U, DONE, UH UH, YOU, UR, SURE, WHAT?, YOU'RE, NEXT, HOLD",
                "YOU ARE, DONE, LIKE, YOU'RE, YOU, HOLD, UH HUH, UR, SURE",
                "YOU'RE, NEXT, U, UR, HOLD, DONE, UH UH, WHAT?, UH HUH, YOU, LIKE"
            ];

            Console.WriteLine("The text on the button at the " + pos + ":");
            string word = Console.ReadLine().ToUpper();

            foreach (string row in wordbank)
                if(IsLast(word, row)) return row;

            throw new ArgumentException();
        }
        private static bool IsLast(string word, string row)
        {
            return word == row.Substring(row.Length - word.Length);
        }
    }
}
