using System;
using System.Linq;

namespace Exercise_03_Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> MyParse = x => int.Parse(x);

            Func<int[], int> MinFunc = nums =>
            {
                int smallest = int.MaxValue;

                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] < smallest)
                    {
                        smallest = nums[i];
                    }
                }

                return smallest;
            };

            int[] nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(MyParse)
                .ToArray();

            Action<int> Print = x => Console.WriteLine(x);

            Print(MinFunc(nums));

        }
    }
}
