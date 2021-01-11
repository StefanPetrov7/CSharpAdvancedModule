using System;
using System.Linq;

namespace Lab_04_Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<double, double> addVat = x => x * 1.20;

            //Console.WriteLine((string.Join(Environment.NewLine, Console.ReadLine()
            //    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            //    .Select(double.Parse)
            //    .Select(addVat)
            //    .ToArray())));

            Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x =>
                {
                    double num = double.Parse(x);
                    return num * 1.20;
                })
                .ToList()
                .ForEach(x => Console.WriteLine($"{x:f2}"));
        }
    }
}
