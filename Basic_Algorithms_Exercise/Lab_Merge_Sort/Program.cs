using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_Merge_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            List<int> sorted = MergeSort(arr.ToList());
            Console.WriteLine(string.Join(" ", sorted));
        }

        private static List<int> MergeSort(List<int> list)
        {
            if (list.Count<=1)
            {
                return list;
            }

            int middle = list.Count / 2;
            List<int> leftList = MergeSort(list.GetRange(0, middle));
            List<int> rightList = MergeSort(list.GetRange(middle, list.Count - middle));

            return Combine(leftList, rightList);
        }

        private static List<int> Combine(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();
            int leftIndex = 0;
            int rightIndex = 0;

            while (leftIndex < left.Count && rightIndex < right.Count)
            {
                if (left[leftIndex] < right[rightIndex])
                {
                    result.Add(left[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    result.Add(right[rightIndex]);
                    rightIndex++;
                }
            }

            for (int i = leftIndex; i < left.Count; i++)
            {
                result.Add(left[i]);
            }

            for (int i = rightIndex; i < right.Count; i++)
            {
                result.Add(right[i]);
            }

            return result;
        }
    }
}
