using System;
using System.Linq;

namespace Exercise_08_Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();


            // <below is returning soreted Array in ascending order using comparison>
            // Array.Sort(numbers, comparison: (x, y) => x.CompareTo(y));

            //**********************************************************

            // <below return same as above, detailed code>
            //  Array.Sort(numbers, comparison: (x, y) =>
            //  {
            //      int comparer = 0;
            //      if (x > y)
            //      {
            //          comparer = 1;
            //      }
            //      else if (x < y)
            //      {
            //          comparer = -1;
            //      }
            //
            //      return comparer;
            //  });

            //**********************************************************

            //< sort by first even ascending, then by odd ascending>
            // Array.Sort(numbers, comparison: (x, y) =>
            // {
            //     int sorted = 0;
            //
            //     if (x % 2 == 0 && y % 2 != 0)
            //     {
            //         sorted = -1;
            //     }
            //     else if (x % 2 != 0 && y % 2 == 0)
            //     {
            //         sorted = 1;
            //     }
            //     else
            //     {
            //         sorted = x - y;
            //         //sorted = x.CompareTo(y);
            //     }
            //     return sorted;
            // });

            //**********************************************************

            Array.Sort(numbers, comparison: (x, y) =>
            (x % 2 == 0 && y % 2 != 0) ? -1 :
            (x % 2 != 0 && y % 2 == 0) ? 1 :
            x.CompareTo(y));

            Console.WriteLine(string.Join(" ", numbers));

        }
    }
}
