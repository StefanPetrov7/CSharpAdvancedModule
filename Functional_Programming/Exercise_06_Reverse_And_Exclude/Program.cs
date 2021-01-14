using System;
using System.Linq;
using System.Collections.Generic;

namespace Exercise_06_Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse()
                .ToArray();

            int n = int.Parse(Console.ReadLine());

            Predicate<int> isDevisabele = x => x % n == 0;

            Func<int[], List<int>> process = nums =>
            {
                List<int> listNums = new List<int>();

                for (int i = 0; i < nums.Length; i++)
                {
                    if (isDevisabele(nums[i]) == false)
                    {
                        listNums.Add(nums[i]);
                    }
                }
                return listNums;
            };

            List<int> excludedNums = process(numbers);

            Console.WriteLine(string.Join(" ", excludedNums));

        }
    }
}
