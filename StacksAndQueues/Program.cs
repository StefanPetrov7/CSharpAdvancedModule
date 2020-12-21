using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise01BasicStackOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();


            int[] arrEllements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int ellementCount = input[0];
            int ellementToTake = input[1];
            int ellementX = input[2];

            Stack<int> stack = new Stack<int>(arrEllements);

            for (int i = 0; i < ellementToTake; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(ellementX))
            {
                Console.WriteLine(true);
            }

            if (stack.Count>0)
            {
                Console.WriteLine(stack.Min());
            }
            else 
            {
                Console.WriteLine(stack.Count);
            }

 


        }
    }
}
