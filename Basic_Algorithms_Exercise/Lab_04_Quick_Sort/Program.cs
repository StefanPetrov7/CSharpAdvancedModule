﻿using System;
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

            // var sortedArr = QuickSortTwo(list);  // QuickSort 
            //Console.WriteLine(string.Join(" ", sortedArr));

            QuickSortImproved(list, 0, list.Count - 1);    // QuickSortImproved
            Console.WriteLine(string.Join(", ", list));

            // QuickSortTest(arr, 0, arr.Length-1); // need to be completed.
        }


        static Random rand = new Random();

        public static void QuickSortImproved(List<int> list, int left, int right)  // Another QuickSort Implementation
        {
            if (left < right)
            {
                int partitionIndex = Partition(list, left, right);
                QuickSortImproved(list, left, partitionIndex);
                QuickSortImproved(list, partitionIndex + 1, right);
            }
        }

        static int Partition(List<int> list, int left, int right)
        {
            int pivot = list[(left + right) / 2];
            int i = left - 1;
            int j = right - 1;

            while (true)
            {
                do
                {
                    i++;
                } while (list[i] < pivot);

                do
                {
                    j--;
                } while (list[j] > pivot);

                if (i >= j)
                {
                    return j;
                }

                int temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }

        static List<int> QuickSort(List<int> list)  // Another QuickSort Implementation
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

            List<int> leftSortedList = QuickSort(leftList);
            List<int> rightSortedList = QuickSort(rightList);
            return leftSortedList.Concat(new List<int>() { pivot }).Concat(rightSortedList).ToList();
        }

        // static void QuickSortTest(int[] arr, int hi, int lo)  // Need to be completed.
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
        //     QuickSortTest(arr, hi, leftIndex);      // recursion
        //     QuickSortTest(arr, rightIndex, lo);     // recursion
        // }
    }
}
