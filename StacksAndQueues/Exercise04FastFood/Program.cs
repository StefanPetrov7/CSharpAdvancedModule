using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise04FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalFood = int.Parse(Console.ReadLine());
            Queue<int> orders = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            int ordersCount = orders.Count;

            Console.WriteLine(orders.Max());

            for (int i = 0; i < ordersCount; i++)
            {
                if (totalFood < orders.Peek()) break;

                int currentOrder = orders.Peek();
                totalFood -= currentOrder;
                orders.Dequeue();

            }

            if (orders.Count > 0)
            {
                Console.WriteLine("Orders left: " + string.Join(" ", orders));
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
