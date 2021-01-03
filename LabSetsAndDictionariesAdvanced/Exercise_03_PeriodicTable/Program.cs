using System;
using System.Collections.Generic;

namespace Exercise_03_PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> elements = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int k = 0; k < input.Length; k++)
                {
                    elements.Add(input[k]);
                }
            }

            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
