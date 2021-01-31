using System;
using System.Linq;

namespace Exercise_03_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomStack<string> stack = new CustomStack<string>();

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] arg = input
                    .Split(new string[] { " ", ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string cmd = arg[0];

                switch (cmd)
                {
                    case "Push":
                        for (int i = 1; i < arg.Length; i++)
                        {
                            stack.Push(arg[i]);
                        }
                        break;
                    case "Pop":
                        try 
                        {
                            stack.Pop();
                        }
                        catch (InvalidOperationException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, stack));
            Console.WriteLine(string.Join(Environment.NewLine, stack));
        }
    }
}
