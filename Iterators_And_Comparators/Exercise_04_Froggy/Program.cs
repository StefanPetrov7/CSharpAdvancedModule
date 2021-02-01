using System;
using System.Linq;

namespace Exercise_04_Froggy
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()?
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            
            Lake lake = new Lake();
            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
