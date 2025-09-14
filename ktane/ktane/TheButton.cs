using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ktane
{
    internal class TheButton
    {
        protected enum Colors
        {
            red,
            blue,
            yellow,
            white
        };
        protected enum Texts
        {
            abort,
            detonate,
            hold,
            press
        }

        protected Colors color;
        protected Texts text;

        public TheButton(EdgeWork edge)
        {
            GetColor();
            GetText();
            EvaluateButton(edge);
        }

        private void GetColor()
        {
            Console.WriteLine("Color of the Button: ");
            bool redo;

            do
            {
                redo = false;
                string input = Console.ReadLine();
                switch (input)
                {
                    case "red":
                        this.color = Colors.red;
                        break;
                    case "blue":
                        this.color = Colors.blue;
                        break;
                    case "yellow":
                        this.color = Colors.yellow;
                        break;
                    case "white":
                        color = Colors.white;
                        break;
                    default:
                        Console.WriteLine("Invalid color!");
                        redo = true;
                        break;
                }
            } while (redo);
        }
        private void GetText()
        {
            Console.WriteLine("Text on the Button: ");
            bool redo;

            do
            {
                redo = false;
                string input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "abort":
                        this.text = Texts.abort;
                        break;
                    case "detonate":
                        this.text = Texts.detonate;
                        break;
                    case "hold":
                        this.text = Texts.hold;
                        break;
                    case "press":
                        this.text = Texts.press;
                        break;
                    default:
                        Console.WriteLine("Invalid color!");
                        redo = true;
                        break;
                }
            } while (redo);
        }
        private void EvaluateButton(EdgeWork edge)
        {
            if (this.color == Colors.blue && this.text == Texts.abort) Hold();
            else if (edge.batteries > 1 && this.text == Texts.detonate) Press();
            else if (this.color == Colors.white && edge.HasIndicator(new EdgeWork.Indicator("CAR", true))) Hold();
            else if (edge.batteries > 2 && edge.HasIndicator(new EdgeWork.Indicator("FRK", true))) Press();
            else if (this.color == Colors.yellow) Hold();
            else if (this.color == Colors.red && this.text == Texts.hold) Press();
            else Hold();
        }
        private static void Press()
        {
            Console.WriteLine("Press and immediately release the Button");
        }
        private static void Hold()
        {
            Console.WriteLine("Hold the button\nColor of the strip: ");
            Colors strip = Colors.white;
            bool redo;

            do
            {
                redo = false;
                string input = Console.ReadLine();
                switch (input)
                {
                    case "red":
                        strip = Colors.red;
                        break;
                    case "blue":
                        strip = Colors.blue;
                        break;
                    case "yellow":
                        strip = Colors.yellow;
                        break;
                    case "white":
                        strip = Colors.white;
                        break;
                    default:
                        Console.WriteLine("Invalid color!");
                        redo = true;
                        break;
                }
            } while (redo);

            Console.Write("Release it when the timer has a ");
            switch (strip)
            {
                case Colors.blue:
                    Console.Write(4);
                    break;
                case Colors.yellow:
                    Console.Write(5);
                    break;
                default:
                    Console.Write(1);
                    break;
            }
            Console.WriteLine(" in any position");
        }
    }
}
