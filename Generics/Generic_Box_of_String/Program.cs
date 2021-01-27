using System;
using System.Collections.Generic;

namespace Generic_Box_of_String
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<int>> list = new List<Box<int>>();

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                Box<int> box = new Box<int>(input);
                list.Add(box);
            }

            foreach (var box in list)
            {
                Console.WriteLine(box.ToString());
            }
        }
    }
}
