using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise05FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothes = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            int rackCapacity = int.Parse(Console.ReadLine());
            int totalRacksUsed = 1;
            int sum = 0;

            while (clothes.Count>0)
            {
                int curItem = clothes.Peek();
                sum += curItem;

                if (sum<=rackCapacity)
                {
                    clothes.Pop();
                }
                else
                {
                    totalRacksUsed++;
                    sum = 0;
                    sum += curItem;
                    clothes.Pop();
                }

            }

            Console.WriteLine(totalRacksUsed);

        }
    }
}
