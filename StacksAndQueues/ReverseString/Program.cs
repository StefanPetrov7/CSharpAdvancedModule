using System;
using System.Collections.Generic;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<string> stack = new Stack<string>(input.Length);

            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i].ToString());
            }

            foreach (var item in stack)
            {
                Console.Write(item);
            }
        }
    }
}
