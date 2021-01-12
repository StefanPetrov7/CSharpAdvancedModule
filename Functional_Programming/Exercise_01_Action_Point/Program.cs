using System;

namespace Exercise_01_Action_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Action<string[]> printName = x => Console.WriteLine(string.Join(Environment.NewLine, names)); 

            printName(names);

        }
    }
}
