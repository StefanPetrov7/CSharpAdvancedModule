using System;
using System.Linq;

namespace Exercise_01_DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            int diagonalPrimarySum = 0;
            int diagonalSecondarySum = 0;

            ReadMatrix(matrix);

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (r==c)
                    {
                        diagonalPrimarySum += matrix[r, c];
                    }

                    if (c == n-1-r)  
                    {
                        diagonalSecondarySum += matrix[r, c];
                    }
                }
            }
            Console.WriteLine(Math.Abs(diagonalPrimarySum - diagonalSecondarySum));
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
