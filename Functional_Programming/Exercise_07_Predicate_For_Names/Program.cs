using System;
using System.Linq;
using System.Collections.Generic;

namespace Exercise_07_Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Predicate<string> legthPredicat = x => x.Length <= n;

            List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            Console.WriteLine(string.Join(Environment.NewLine, names.Where(x => legthPredicat(x))));

        }
    }
}
