using System;
using System.Linq;

namespace Exercise_05_Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Action<int[]> print = nums => Console.WriteLine(string.Join(" ",nums));

            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                switch (input)
                {
                    case "add":
                        Operation(numbers, x => x + 1);
                        break;
                    case "multiply":
                        Operation(numbers, x => x * 2);
                        break;
                    case "subtract":
                        Operation(numbers, x => x - 1);
                        break;
                    case "print":
                        print(numbers);
                        break;
                }
            }
        }

        public static int[] Operation(int[] nums, Func<int, int> func)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = func(nums[i]);
            }
            return nums;
        }
    }
}
