using System;
using System.Collections.Generic;
using System.Linq;

namespace Loot_box
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> stack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int totalLoot = 0;

            while (queue.Count > 0 && stack.Count > 0)
            {
                int first = queue.Peek();
                int last = stack.Pop();
                int sum = first + last;

                if (sum % 2 == 0)
                {
                    totalLoot += sum;
                    queue.Dequeue();
                }
                else
                {
                    queue.Enqueue(last);
                }
            }

            string emptyBox = queue.Count > 0 ? "Second lootbox is empty" : "First lootbox is empty";
            string result = totalLoot >= 100 ? $"Your loot was epic! Value: {totalLoot}" : $"Your loot was poor... Value: {totalLoot}";
            Console.WriteLine(emptyBox);
            Console.WriteLine(result);
        }
    }
}
