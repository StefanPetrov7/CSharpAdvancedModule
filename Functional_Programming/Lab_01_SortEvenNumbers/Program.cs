using System;
using System.Linq;

namespace Lab_01_SortEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(x => x % 2 == 0)
                .OrderBy(x => x)
                .ToArray();

            Console.WriteLine(string.Join(", ", nums));
        }
    }
}
