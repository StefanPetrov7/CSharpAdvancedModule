using System;
using System.Linq;

namespace Exercise_03_MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToArray();

            int[,] matrix = new int[sizes[0], sizes[1]];
            int bestSum = 0;
            int firstRow = 0;
            int firstColumn = 0;

            ReadMatrix(matrix);

            for (int r = 0; r < matrix.GetLength(0) - 2; r++)
            {
                for (int c = 0; c < matrix.GetLength(1) - 2; c++)
                {
                    int curSum = matrix[r, c] + matrix[r, c + 1] + matrix[r, c + 2]
                        + matrix[r + 1, c] + matrix[r + 1, c + 1] + matrix[r + 1, c + 2]
                        + matrix[r + 2, c] + matrix[r + 2, c + 1] + matrix[r + 2, c + 2];

                    if (curSum > bestSum)
                    {
                        bestSum = curSum;
                        firstRow = r;
                        firstColumn = c;
                    }
                }
            }

            Console.WriteLine("Sum = " + bestSum);

            for (int r = firstRow; r < firstRow + 3; r++)
            {
                for (int c = firstColumn; c < firstColumn + 3; c++)
                {
                    Console.Write(matrix[r, c] + " ");
                }
                Console.WriteLine();
            }

        }

        static int[,] ReadMatrix(int[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                int[] rowData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
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
