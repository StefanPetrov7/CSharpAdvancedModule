using System;

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            // int[] arr = new int[] { 1, 2, 3, 4, 5 }; // array sum 
            // int sum = Sum(arr, 0);

            // int n = int.Parse(Console.ReadLine()); // factorial
            // Console.WriteLine(Factorial(n));

            // int fib = int.Parse(Console.ReadLine());
            // Console.WriteLine(Fibonacci(fib));

            // Console.WriteLine(Pow(2, 3));

            // int[] array = new int[] { 0, 0, 0 };   // all numbers
            // ArrayManipulator(array, array.Length - 1);

        }

        static void ArrayManipulator(int[] array, int index) // all numbers
        {
            if (index == -1)
            {
                Console.WriteLine(string.Join(" ", array));
                return;
            }
            for (int i = 0; i <= 9; i++)
            {
                array[index] = i;
                Console.WriteLine(string.Join(" ", array));
            }
            ArrayManipulator(array, index - 1);
        }

        static int Division(int x, int n, int d) // division 
        {
            if (n == 1)
            {
                return x / d;
            }

            return Division(x, n - 1, d) / d;
        }

        private static int Pow(int x, int n) // Pow method 
        {
            if (n == 1)
            {
                return x;
            }
            return x * Pow(x, n - 1);
        }

        private static int Fibonacci(int fib) // fibonacci 
        {

            if (fib == 0)
            {
                return 0;
            }

            if (fib == 1 || fib == 2)
            {
                return 1;
            }

            int first = Fibonacci(fib - 1);
            int second = Fibonacci(fib - 2);
            return first + second;
        }

        private static int Factorial(int n) // factorial 
        {
            if (n == 1)
            {
                return 1;
            }

            int sum = n * Factorial(n - 1);
            Console.WriteLine(sum);
            return sum;
        }

        static int Sum(int[] arr, int index)  // array sum 
        {
            if (index == arr.Length)
            {
                return 0;
            }

            Console.WriteLine("Before");
            int curSum = arr[index] + Sum(arr, index + 1);
            Console.WriteLine(curSum);
            Console.WriteLine("After");

            return curSum;
        }
    }
}
