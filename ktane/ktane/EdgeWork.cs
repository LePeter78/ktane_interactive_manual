using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ktane
{
    internal class EdgeWork
    {
        public enum Port
        {
            dvi_d,
            parallel,
            ps_2,
            rj_45,
            serial,
            stereo_rca
        };

        internal class Indicator(string label, bool isLit)
        {
            public string label = label.ToUpper();
            public bool isLit = isLit;
        }

        public string serial;
        public int batteries;
        public List<Port> ports = [];
        public List<Indicator> indicators = [];

        public EdgeWork() { SetEdgeWork(); }
        
        public void SetEdgeWork()
        {
            SetSerial();
            SetBatteries();
            SetPorts();
            SetIndicators();
        }
        private void SetSerial()
        {
            Console.WriteLine("Serial number:");
            string newSerial;
            do
            {
                newSerial = Console.ReadLine();
            } while (!IsSerialCorrect(newSerial));

            this.serial = newSerial.ToUpper();
        }
        private static bool IsSerialCorrect(string newSerial)
        {
            if (newSerial.Length != 6)
            {
                Console.WriteLine("Must be 6 characters long!");
                return false;
            }
            if (!char.IsDigit(newSerial, newSerial.Length - 1))
            {
                Console.WriteLine("Must end with a digit!");
                return false;
            }
            for (int i = 0; i < newSerial.Length; i++)
            {
                if (char.IsLetter(newSerial, i)) return true;
            }
            Console.WriteLine("Must have a letter!");
            return false;
        }
        private void SetBatteries()
        {
            Console.WriteLine("\nNumber of batteries:");
            ReadInt read = new(0);
            this.batteries = read.num;
        }
        private void SetPorts()
        {
            Console.WriteLine("\nPorts:");
            Console.WriteLine("List of possible ports:");
            Console.WriteLine("dvi_d\nparallel");
            Console.WriteLine("ps_2\nrj_45");
            Console.WriteLine("serial\nstereo_rca");
            Console.WriteLine("Type 0 if there are no more ports");

            string input;
            do
            {
                input = Console.ReadLine();
                switch (input)
                {
                    case "dvi_d":
                        this.ports.Add(Port.dvi_d);
                        break;
                    case "parallel":
                        this.ports.Add(Port.parallel);
                        break;
                    case "ps_2":
                        this.ports.Add(Port.ps_2);
                        break;
                    case "rj_45":
                        this.ports.Add(Port.rj_45);
                        break;
                    case "serial":
                        this.ports.Add(Port.serial);
                        break;
                    case "stereo_rca":
                        this.ports.Add(Port.stereo_rca);
                        break;
                    default:
                        if (input != "0") Console.WriteLine("Invalid port!");
                        break;
                }
            } while (input != "0");
        }
        private void SetIndicators()
        {
            int select;
            do
            {
                Console.WriteLine("\n0: finish edgework");
                Console.WriteLine("1: add indicator");
                ReadInt read = new(0, 1);
                select = read.num;

                if(select == 1)
                {
                    Console.WriteLine("Label:");
                    string label;
                    do
                    {
                        label = Console.ReadLine();
                    } while (!IsPortLabelCorrect(label));

                    bool isLit = false;
                    Console.WriteLine("Is it lit?");
                    Console.WriteLine("0: no\t1: yes");
                    read = new(0, 1);
                    if(read.num == 1)  isLit = true;

                    this.indicators.Add(new(label.ToUpper(), isLit));
                }
            } while (select != 0);
        }
        private static bool IsPortLabelCorrect(string label)
        {
            if(label.Length != 3)
            {
                Console.WriteLine("Must be 3 letters!");
                return false;
            }
            foreach (char letter in label)
            {
                if (!char.IsLetter(letter))
                {
                    Console.WriteLine("Must contain letters only!");
                }
            }
            return true;
        }
        /*public void PrintEdgeWork()
        {
            Console.WriteLine("\nSerial number: " + this.serial);
            Console.WriteLine("Batteries: " + this.batteries);
            Console.Write("Ports:");
            foreach (Port port in this.ports)
            {
                Console.Write(" " + port);
            }
            Console.Write("\nIndicators:");
            foreach (Indicator indicator in this.indicators)
            {
                if(indicator.isLit) Console.Write(" Lit ");
                else Console.Write(" Unlit ");
                Console.Write(indicator.label);
            }
            Console.WriteLine();
        }*/
        //Added functions below
        public bool IsSerialLastDigitOdd()
        {
            return this.serial.Last() % 2 == 1;
        }
        public bool IsSerialLastDigitEven()
        {
            return this.serial.Last() % 2 == 0;
        }
        public bool HasIndicator(Indicator check)
        {
            return this.indicators.Contains(check);
        }
        public bool SerialHasVowel()
        {
            foreach (char letter in this.serial)
                if (char.IsLetter(letter) && IsVowel(letter)) return true;

            return false;
        }
        static private bool IsVowel(char letter)
        {
            return (letter == 'A' || letter == 'E' || letter == 'I' || letter == 'O' || letter == 'U');
        }
        public bool HasParallelPort()
        {
            return this.ports.Contains(Port.parallel);
        }
    }
}
