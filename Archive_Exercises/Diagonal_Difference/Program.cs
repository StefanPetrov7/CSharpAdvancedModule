using System;
using System.Linq;

namespace Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            int primeSum = 0;
            int secondSum = 0;

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                int[] rowData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = rowData[c];

                    if (r == c)
                    {
                        primeSum += matrix[r, c];
                    }
                }
            }

            int row = 0;
            int col = matrix.GetLength(1)-1;

            for (int i = 0; i < n; i++)
            {
                secondSum += matrix[row, col];
                col--;
                row++;
            }

            Console.WriteLine(Math.Abs(primeSum-secondSum));
        }
    }
}
