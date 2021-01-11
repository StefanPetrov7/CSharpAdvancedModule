using System;
using System.Linq;

namespace Lab_02_SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();
            int[] result = new int[2] { nums.Length, nums.Sum() };

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}
