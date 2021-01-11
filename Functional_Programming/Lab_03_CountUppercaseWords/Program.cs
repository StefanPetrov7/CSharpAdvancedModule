using System;
using System.Linq;

namespace Lab_03_CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> IsFirstLetterCapitol = str => str[0] == str.ToUpper()[0];

            Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(x => IsFirstLetterCapitol(x))
                .ToList()
                .ForEach(x => Console.WriteLine(x));

        }
    }
}
