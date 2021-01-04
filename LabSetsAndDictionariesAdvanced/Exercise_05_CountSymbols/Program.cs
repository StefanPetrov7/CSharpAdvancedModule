using System;
using System.Linq;
using System.Collections.Generic;

namespace Exercise_05_CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Dictionary<char, int> dict = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (dict.ContainsKey((char)text[i]) == false)
                {
                    dict.Add((char)text[i], 0);
                }
                dict[(char)text[i]] += 1;
            }

            foreach (var letter in dict.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{letter.Key}: {letter.Value} time/s");
            }
        }
    }
}
