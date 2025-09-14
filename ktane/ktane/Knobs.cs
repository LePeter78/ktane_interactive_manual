using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ktane
{
    internal class Knobs
    {
        public Knobs()
        {
            int leftLEDS = GetNumOfLeftLEDs();
            if (leftLEDS == 4)
                Console.WriteLine("Turn up");
            else if (leftLEDS <= 1)
                Console.WriteLine("Turn left");
            else if (leftLEDS == 3)
                Console.WriteLine("Turn down");
            else if (leftLEDS == 5)
                if (AreLEDsInUShape()) Console.WriteLine("Turn right");
                else Console.WriteLine("Turn down");
            else Console.WriteLine("No position found!");
        }

        private static int GetNumOfLeftLEDs()
        {
            Console.WriteLine("Number of lit LEDs on the left side:");
            ReadInt read = new(0, 6);
            return read.num;
        }
        private bool AreLEDsInUShape()
        {
            Console.WriteLine("Are the lit LEDs form a U-shape?");
            Console.WriteLine("0: no\t1: yes");
            ReadInt read = new(0, 1);
            return read.num == 1;
        }
    }
}
