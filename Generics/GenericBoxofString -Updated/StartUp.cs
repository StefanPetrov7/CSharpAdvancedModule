using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericBoxofString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<int>> boxes = new List<Box<int>>();

            for (int i = 0; i < n; i++)
            {
                Box<int> box = new Box<int>(int.Parse(Console.ReadLine()));
                boxes.Add(box);
            }

            int[] indexes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Swab(boxes, indexes[0], indexes[1]);

            boxes.ForEach(x => Console.WriteLine(x.ToString()));
        }


        public static void Swab<T>(List<Box<T>> list, int indexOne, int indexTwo)
        {
            Box<T> elementOne = list[indexOne];
            Box<T> elementTwo = list[indexTwo];
            list[indexOne] = elementTwo;
            list[indexTwo] = elementOne;
        }
    }
}
