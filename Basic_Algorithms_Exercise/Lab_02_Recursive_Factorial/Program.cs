using System;

namespace Lab_02_Recursive_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(Factorial(n)); 
        }

        private static int Factorial(int n)
        {
            if (n==0)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }
    }
}
