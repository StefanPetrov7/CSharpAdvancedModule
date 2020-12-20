using System;
using System.Linq;
using System.Collections.Generic;

namespace Lab05PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> evenNums = new Queue<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if(nums[i]%2==0)
                {
                    evenNums.Enqueue(nums[i]);
                }
            }

           Console.WriteLine(string.Join(", ", evenNums));

        }
    }
}
