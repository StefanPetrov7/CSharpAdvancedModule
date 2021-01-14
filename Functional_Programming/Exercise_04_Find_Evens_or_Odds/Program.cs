using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise_04_Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();

           switch (command)
           {
               case "odd":
                   GetRange(input, RemoveEven);
                   break;
               case "even":
                   GetRange(input, RemoveOdd);
                   break;
           }

          // Func<int, int, List<int>> generateList = (start, end) =>
          // {
          //     List<int> nums = new List<int>();
          //
          //     for (int i = start; i <= end; i++)
          //     {
          //         nums.Add(i);
          //     }
          //
          //     return nums;
          //
          // };

        }

        static List<int> RemoveOdd(List<int> nums)
        {
            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] % 2 != 0)
                {
                    nums.Remove(nums[i]);
                }
            }

            return nums;
        }

        static List<int> RemoveEven(List<int> nums)
        {
            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] % 2 == 0)
                {
                    nums.Remove(nums[i]);
                }
            }

            return nums;
        }

        public static void GetRange(int[] range, Func<List<int>, List<int>> operation)
        {
            List<int> nums = new List<int>();

            for (int i = range[0]; i <= range[1]; i++)
            {
                nums.Add(i);
            }

            List<int> result = operation(nums);
            Console.WriteLine(string.Join(" ", result));

        }
    }
}
