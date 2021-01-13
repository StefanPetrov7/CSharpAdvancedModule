using System;

namespace Exercise_02_Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Func<string[], string[]> AddTitle = x =>
            {
                for (int i = 0; i < input.Length; i++)
                {
                    input[i] = "Sir " + input[i];
                }

                return input;

            };

            Action<string[]> print = x => Console.WriteLine(string.Join(Environment.NewLine,input));

            print(AddTitle(input));
        }

    }
}