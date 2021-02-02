using System;
using System.Linq;

namespace Lab_01_Recursive_Array_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Console.WriteLine(ArrayElementsSum(array, 0));
        }

        private static int ArrayElementsSum(int[] array, int index)
        {
            if (index == array.Length)
            {
                return 0;
            }

            return array[index] + ArrayElementsSum(array, index + 1);
        }
    }
}
