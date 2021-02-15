using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).
                ToArray());

            Queue<int> threads = new Queue<int>(Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse).
               ToArray());

            int target = int.Parse(Console.ReadLine());
            int task = 0;
            int thread = 0;

            while (true)
            {
                task = tasks.Peek();
                thread = threads.Peek();

                if (task == target)
                {
                    Console.WriteLine($"Thread with value {thread} killed task {task}");
                    break;
                }

                if (thread >= task)
                {
                    tasks.Pop();
                    threads.Dequeue();
                }
                else
                {
                    threads.Dequeue();
                }


            }

            while (threads.Count > 0)
            {
                Console.Write(threads.Dequeue() + " ");
            }
        }
    }
}
