using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ktane
{
    internal class Menu
    {
        internal EdgeWork edge;

        public Menu()
        {
            this.edge = new();
            bool redo = true;
            do
            {
                Console.Clear();
                PrintModulesList();
                int moduleId = SelectModule();

                if (moduleId != 0)
                {
                    Console.Clear();
                    RunModule(moduleId);
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
                else redo = false;
            } while (redo);
        }

        public static void PrintModulesList()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("-1: Modify Edgework");
            Console.WriteLine("0: Exit");
            Console.WriteLine("1: Wires\t2: The Button");
            Console.WriteLine("3: Keypads\t4: Simon Says");
            Console.WriteLine("5: Who's on First\t6: Memory");
            Console.WriteLine("7: Morse Code\t8: Complicated Wires");
            Console.WriteLine("9: Wire Sequences\t10: Mazes");
            Console.WriteLine("11: Passwords\t12: Knobs");
        }
        public static int SelectModule()
        {
            ReadInt read = new(0, 12);
            return read.num;
        }
        public void RunModule(int moduleId)
        {
            switch (moduleId)
            {
                case -1:
                    this.edge = new();
                    break;
                case 1:
                    Wires wires = new(this.edge);
                    break;
                case 2:
                    TheButton theButton = new(this.edge);
                    break;
                case 3:
                    Keypads keypads = new();
                    break;
                case 4:
                    SimonSays simonSays = new(this.edge);
                    break;
                case 5:
                    WhosOnFirst whosOnFirst = new();
                    break;
                case 6:
                    Memory memory = new();
                    break;
                case 7:
                    MorseCode morseCode = new();
                    break;
                case 8:
                    ComplicatedWires complicatedWires = new(this.edge);
                    break;
                case 9:
                    WireSequences wireSequences = new();
                    break;
                case 10:
                    Mazes mazes = new();
                    break;
                case 11:
                    Passwords passwords = new();
                    break;
                case 12:
                    Knobs knobs = new();
                    break;
            }
        }
    }
}
