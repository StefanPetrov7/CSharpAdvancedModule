using System;
using System.Linq;
using System.Collections.Generic;

namespace Exercise_09_ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] deviders = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, int[], List<int>> devidedArr = (y, deviders) =>
             {
                 List<int> newList = new List<int>();

                 for (int i = 1; i < y; i++)
                 {
                     bool flag = true;

                     Predicate<int> isDevisible = x => i % x == 0;

                     for (int j = 0; j < deviders.Length; j++)
                     {
                         if (!isDevisible(deviders[j]))
                         {
                             flag = false;
                             break;
                         }
                     }
                     if (flag)
                     {
                         newList.Add(i);
                     }
                 }
                 return newList;
             };

            List<int> resultNums = devidedArr(n, deviders);

            Console.WriteLine(string.Join(" ", resultNums));

        }
    }
}
