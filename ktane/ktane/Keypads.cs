using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ktane
{
    internal class Keypads
    {
        public Keypads()
        {
            List<int> symbols = [];
            List<int> column;

            Console.WriteLine("Refer to keypads.txt");
            Console.WriteLine("Enter the number of each smybol:");

            AddSymbols(ref symbols);
            try
            {
                column = SearchColumn(symbols);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("These symbols are not in the same column!");
                return;
            }
            PrintOrder(symbols, column);
        }

        private static void AddSymbols(ref List<int> symbols)
        {
            do
            {
                ReadInt read = new(1, 27);
                int input = read.num;

                if (symbols.Contains(input)) Console.WriteLine("Already in the list!");
                else symbols.Add(input);
            } while (symbols.Count != 4);
        }
        private static List<int> SearchColumn(List<int> symbols)
        {
            List<List<int>> columns =
            [
                [1, 2, 3, 4, 5, 6, 7],
                [8, 1, 7, 9, 10, 7, 11],
                [12, 13, 9, 14, 15, 3, 10],
                [16, 17, 18, 5, 14, 11, 19],
                [20, 19, 18, 21, 17, 22, 23],
                [16, 8, 24, 25, 20, 26, 27]
            ];

            foreach (List<int> column in columns)
                if (ContainsAll(symbols, column))
                    return column;

            throw new ArgumentException();
        }
        private static bool ContainsAll(List<int> symbols, List<int> column)
        {
            foreach (int symbol in symbols)
                if(!column.Contains(symbol)) return false;
            return true;
        }
        private static void PrintOrder(List<int> symbols, List<int> column)
        {
            Console.Write("Press the symbols in this order:");
            foreach (int num in column)
            {
                if(symbols.Contains(num)) Console.Write(" " + num);
            }
            Console.WriteLine();
        }
    }
}
