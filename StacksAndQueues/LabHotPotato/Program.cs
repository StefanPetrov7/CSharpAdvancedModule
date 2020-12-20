using System;
using System.Linq;
using System.Collections.Generic;

namespace LabHotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> kids = new Queue<string>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray());
            int count = int.Parse(Console.ReadLine());

            while (kids.Count > 1 )
            {
                for (int i = 1; i < count; i++)
                {
                    kids.Enqueue(kids.Dequeue());
                }
                Console.WriteLine($"Remove {kids.Dequeue()}");
            }

            Console.WriteLine($"Last is {String.Join(" ",kids)}");
        }
    }
}
