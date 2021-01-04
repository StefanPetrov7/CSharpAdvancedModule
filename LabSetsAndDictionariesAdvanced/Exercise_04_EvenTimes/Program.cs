using System;
using System.Linq;
using System.Collections.Generic;

namespace Exercise_04_EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, int> numbers = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (numbers.ContainsKey(number) == false)
                {
                    numbers.Add(number, 1);
                }
                else
                {
                    numbers[number] += 1;
                }
            }

            foreach (var num in numbers.Where(x => x.Value % 2 == 0))
            {
                Console.WriteLine(num.Key);
            }
        }
    }
}
