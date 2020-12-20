using System;
using System.Collections.Generic;
using System.Linq;

namespace ReversePolishNotationCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] expression = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToArray();
            Stack<string> ellements = new Stack<string>(expression);

            PrintStack(ellements);

            while (ellements.Count > 1)
            {
                List<string> nums = new List<string>();

                var curEllement = ellements.Pop();

                while (IsOperator(curEllement) == false)
                {
                    nums.Add(curEllement);
                    curEllement = ellements.Pop();
                }

                int first = int.Parse(nums[nums.Count - 2]);
                int second = int.Parse(nums[nums.Count - 1]);

                int result = PerformOperation(curEllement, first, second);

                ellements.Push(result.ToString());

                for (int i = nums.Count - 3; i >= 0; i--)
                {
                    ellements.Push(nums[i]);
                }

                PrintStack(ellements);
            }

        }

        private static int PerformOperation(string item, int first, int second)
        {
            switch (item)
            {
                case "+":
                    return first + second;
                case "-":
                    return first - second;
                case "/":
                    return first / second;
                case "*":
                    return first * second;
            }
            throw new ArgumentException();
        }

        static bool IsOperator(string item)
        {
            switch (item)
            {
                case "+":
                    return true;
                case "-":
                    return true;
                case "/":
                    return true;
                case "*":
                    return true;
            }
            return false;
        }

        static void PrintStack(Stack<string> stack)
        {
            foreach (var item in stack)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }

}
