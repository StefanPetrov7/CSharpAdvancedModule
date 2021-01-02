using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise_02_SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] setLength = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < setLength[0]; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < setLength[1]; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }

            var unique = firstSet.Intersect(secondSet);

            Console.WriteLine(string.Join(" ", unique));
        }
    }
}
