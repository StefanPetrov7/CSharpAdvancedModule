using System;
using System.Collections.Generic;
using System.Linq;

namespace StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            string input;

            while ((input = Console.ReadLine().ToLower()) != "end")
            {
                string[] cmd = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = cmd[0].ToLower();

                switch (command)
                {
                    case "add":
                        int one = int.Parse(cmd[1]);
                        int two = int.Parse(cmd[2]);
                        stack.Push(one);
                        stack.Push(two);
                        break;

                    case "remove":
                        int numbersToRemove = int.Parse(cmd[1]);
                        if (numbersToRemove <= stack.Count)
                        {
                            for (int i = 0; i < numbersToRemove; i++)
                            {
                                stack.Pop();
                            }
                        }
                        break;
                }
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
