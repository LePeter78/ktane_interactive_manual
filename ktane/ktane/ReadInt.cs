using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ktane
{
    internal class ReadInt
    {
        public int num;
        public ReadInt(int min, int max)
        {
            bool b;
            do
            {
                b = int.TryParse(Console.ReadLine(), out this.num);
                if(!b || this.num < min || this.num > max)
                    Console.WriteLine("Must be between " + min + " and " + max + "!");
            } while (!b || this.num < min || this.num > max);
        }

        public ReadInt(int min)
        {
            bool b;
            do
            {
                b = int.TryParse(Console.ReadLine(), out this.num);
                if (!b || this.num < min)
                    Console.WriteLine("Can't be lower than " + min + "!");
            } while (!b || this.num < min);
        }
    }
}
