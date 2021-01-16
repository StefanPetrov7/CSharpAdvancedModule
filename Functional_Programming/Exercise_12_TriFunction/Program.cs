using System;
using System.Linq;
using System.Collections.Generic;

namespace Exercise_12_TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Func<string, int> charSum = name =>
            {
                int sum = name.ToCharArray().Sum(x => x);
                return sum;
            };

            Func<string[], int, string> getName = (names, num) =>
            {
                string name = null;

                for (int i = 0; i < names.Length; i++)
                {
                    if (charSum(names[i]) > num)
                    {
                        name = names[i];
                        break;
                    }
                }
                return name;
            };

            Console.WriteLine(getName(names, n)); 
        }
    }
}
