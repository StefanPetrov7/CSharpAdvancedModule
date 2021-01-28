using System;
using System.Collections.Generic;

namespace Generic_Swap_Method_Strings_Double
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<double> elements = new List<double>();

            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());
                elements.Add(input);
            }

            Box<double> box = new Box<double>(elements);
            double elementToCompare = double.Parse(Console.ReadLine());
            int result = box.GetCountGraterElements(box.Value, elementToCompare);
            Console.WriteLine(result);
        }
    }
}
