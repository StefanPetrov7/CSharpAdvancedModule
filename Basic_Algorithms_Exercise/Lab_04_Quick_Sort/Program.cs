using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_04_Quick_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToList();

            var sortedArr = QuickSortTwo(list);
            Console.WriteLine(string.Join(" ", sortedArr));

            // QuickSort(arr, 0, arr.Length-1); // need to be completed. 
        }

        static Random rand = new Random();

        static List<int> QuickSortTwo(List<int> list)
        {
            if (list.Count <= 1)  // to check if colllection is from one or less elements.
            {    
                return list;
            }

            int pivot = list[rand.Next(0, list.Count)];
            List<int> leftList = new List<int>();
            List<int> rightList = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] < pivot)
                {
                    leftList.Add(list[i]);
                }

                if (list[i] > pivot)
                {
                    rightList.Add(list[i]);
                }
            }

            List<int> leftSortedList = QuickSortTwo(leftList);
            List<int> rightSortedList = QuickSortTwo(rightList);
            return leftSortedList.Concat(new List<int>() { pivot }).Concat(rightSortedList).ToList();
        }

        // static void QuickSort(int[] arr, int hi, int lo)  // Need to be completed.
        // {
        //     int pivot = arr[hi];
        //     int leftIndex = hi;
        //     int rightIndex = lo;
        //
        //     for (int i = hi; i < lo; i++)
        //     {
        //         if (arr[hi] < pivot)
        //         {
        //             int temp = arr[leftIndex];    // swap elements  
        //             arr[leftIndex] = arr[i];
        //             arr[i] = temp;
        //             leftIndex++;
        //         }
        //
        //         if (arr[hi] > pivot)
        //         {
        //             int temp = arr[rightIndex];    // swap elements  
        //             arr[rightIndex] = arr[i];
        //             arr[i] = temp;
        //             rightIndex--;
        //         }
        //     }
        //
        //     QuickSort(arr, hi, leftIndex);      // recursion
        //     QuickSort(arr, rightIndex, lo);     // recursion
        // }
    }
}
