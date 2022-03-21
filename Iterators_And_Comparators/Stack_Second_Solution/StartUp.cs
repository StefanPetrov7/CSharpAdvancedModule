using System;
using System.Linq;

namespace Stack_Second_Solution
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input;
            CustomStack<string> stack = new CustomStack<string>();

            while ((input = Console.ReadLine()) != "END")
            {
                string[] arg = input.Split(new string[] { " ", ", " }, StringSplitOptions.RemoveEmptyEntries);

                if (arg.Length > 1)
                {
                    string[] elements = arg.Skip(1).ToArray();

                    for (int i = 0; i < elements.Length; i++)
                    {
                        stack.Push(elements[i]);
                    }
                }
                else
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    } 
                }
            }

            if (stack.Count() > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, stack));
                Console.WriteLine(string.Join(Environment.NewLine, stack));
            }
        }
    }
}
