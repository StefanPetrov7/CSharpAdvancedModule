using System;
using System.Linq;

namespace Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[,] matrix = new int[size[0], size[1]];
            ReadMatrix(matrix);

            int maxSum = 0;
            int row = 0;
            int col = 0;

            for (int r = 0; r < matrix.GetLength(0) - 2; r++)
            {
                for (int c = 0; c < matrix.GetLength(1) - 2; c++)
                {
                    int sum = matrix[r, c] + matrix[r, c + 1] + matrix[r, c + 2]
                        + matrix[r + 1, c] + matrix[r + 1, c + 1] + matrix[r + 1, c + 2]
                        + matrix[r + 2, c] + matrix[r + 2, c + 1] + matrix[r + 2, c + 2];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        row = r;
                        col = c;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int r = row; r < row + 3; r++)
            {
                for (int c = col; c < col + 3; c++)
                {
                    Console.Write(matrix[r, c] + " ");
                }
                Console.WriteLine();
            }
        }

        public static int[,] ReadMatrix(int[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                int[] rowData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = rowData[c];
                }
            }

            return matrix;
        }
    }
}

