using System;
using System.Linq;

namespace Lab_05_SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[sizes[0], sizes[1]];

            int bestSquareSum = int.MinValue;
            int bestRow = 0;
            int bestCol = 0;

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                int[] rowData = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = rowData[c];
                }
            }

            for (int r = 0; r < matrix.GetLength(0) - 1; r++)
            {
                for (int c = 0; c < matrix.GetLength(1) - 1; c++)
                {
                    int squareSum = matrix[r, c] + matrix[r, c + 1] + matrix[r + 1, c] + matrix[r + 1, c + 1];

                    if (squareSum > bestSquareSum)
                    {
                        bestSquareSum = squareSum;
                        bestRow = r;
                        bestCol = c;
                    }
                }
            }

            Console.WriteLine($"{matrix[bestRow,bestCol]} {matrix[bestRow, bestCol+1]}");
            Console.WriteLine($"{matrix[bestRow+1, bestCol]} {matrix[bestRow+1, bestCol+1]}");
            Console.WriteLine(bestSquareSum);
        }
    }
}
