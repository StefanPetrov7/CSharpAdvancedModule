using System;
using System.Linq;

namespace Lab_05_Binary_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(BinarySearch(arr, number, 0, arr.Length)); 
        }

        private static int BinarySearch(int[] arr, int number, int start, int end)
        {
            if (start > end)
            {
                return -1;
            }

            int middle = (start + end) / 2;

            if (number < arr[middle])
            {
                return BinarySearch(arr, number, start, middle - 1);
            }
            else if (number > arr[middle])
            {
                return BinarySearch(arr, number, middle + 1, end);
            }
            else
            {
                return middle;
            }
        }
    }
}
