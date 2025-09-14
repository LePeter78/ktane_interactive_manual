using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ktane
{
    internal class ComplicatedWires
    {
        internal class Wire(bool red, bool blue, bool star, bool led)
        {
            internal bool red = red;
            internal bool blue = blue;
            internal bool star = star;
            internal bool led = led;
            internal bool cut = false;
        }

        protected List<Wire> wires = [];

        public ComplicatedWires(EdgeWork edgeWork)
        {
            AddWires();
            foreach(Wire wire in this.wires)
                if (EvaluateWire(wire, edgeWork)) wire.cut = true;
            Cut();
        }

        private void AddWires()
        {
            Console.WriteLine("Number of wires:");
            ReadInt read = new(1, 6);
            int numOfWires = read.num;

            Console.WriteLine("\nAlways type 0 for no and 1 for yes");
            for (int i = 0; i < numOfWires; i++)
            {
                Console.WriteLine($"\nWire {i + 1}:");
                Console.WriteLine("Does it have red color?");
                read = new(0, 1);
                bool red = (read.num == 1);
                Console.WriteLine("Does it have blue color?");
                read = new(0, 1);
                bool blue = (read.num == 1);
                Console.WriteLine("Is there a star symbol?");
                read = new(0, 1);
                bool star = (read.num == 1);
                Console.WriteLine("Is the LED on?");
                read = new(0, 1);
                bool led = (read.num == 1);

                this.wires.Add(new(red, blue, star, led));
            }
        }
        private static bool EvaluateWire(Wire wire, EdgeWork edgeWork)
        {
            return
            (
                (//always cut
                    (!wire.red && !wire.blue && !wire.star && !wire.led) ||
                    (!wire.red && !wire.blue && wire.star && !wire.led) ||
                    (wire.red && !wire.blue && wire.star && !wire.led)
                )
                ||
                (//serial
                    edgeWork.IsSerialLastDigitEven() &&
                    (
                        (wire.red && !wire.blue && !wire.star && !wire.led) ||
                        (!wire.red && wire.blue && !wire.star && !wire.led) ||
                        (wire.red && wire.blue && !wire.star && !wire.led) ||
                        (wire.red && wire.blue && !wire.star && wire.led)
                    )
                )
                ||
                (//parallel
                    edgeWork.HasParallelPort() &&
                    (
                        (!wire.red && wire.blue && !wire.star && wire.led) ||
                        (!wire.red && wire.blue && wire.star && wire.led) ||
                        (wire.red && wire.blue && wire.star && !wire.led)
                    )
                )
                ||
                (//battery
                    edgeWork.batteries >= 2 &&
                    (
                        (!wire.red && !wire.blue && wire.star && wire.led) ||
                        (wire.red && !wire.blue && !wire.star && wire.led) ||
                        (wire.red && !wire.blue && wire.star && wire.led)
                    )
                )
            );
        }
        private void Cut()
        {
            Console.WriteLine("Cut the following wires:");
            for (int i = 0; i < this.wires.Count; i++)
            {
                if (this.wires[i].cut)
                {
                    Console.Write($"{i + 1} (");
                    if (!this.wires[i].red && this.wires[i].blue) Console.Write(" white");
                    if (this.wires[i].red) Console.Write(" red");
                    if (this.wires[i].blue) Console.Write(" blue");
                    if (this.wires[i].star) Console.Write(" star");
                    if (this.wires[i].led) Console.Write(" LED");
                    Console.WriteLine(" )");
                }
            }
        }
    }
}
