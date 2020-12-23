using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise11KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int magazineSize = int.Parse(Console.ReadLine());
            Queue<int> bullets = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse()
                .ToArray());
            Stack<int> locks = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse()
                .ToArray());
            int prize = int.Parse(Console.ReadLine());
            int magazine = magazineSize;
            int cost = 0;

            while (locks.Count>0)
            {
                if (bullets.Count == 0) break;

                int curBullet = bullets.Dequeue();
                cost += bulletPrice;
                magazine--;

                if (locks.Count == 0) break;

                if (curBullet <= locks.Peek())
                {
                    Console.WriteLine("Bang!");
                    locks.Pop();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (magazine == 0 && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    magazine = magazineSize;
                }
            }

            if (locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${prize - cost}");
            }
        }
    }
}
