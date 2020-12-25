using System;
using System.Linq;

namespace Lab_02_SumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[sizes[0], sizes[1]];

            int[] result = new int[sizes[1]];

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

            for (int c = 0; c < matrix.GetLength(1); c++)
            {
                int sumCols = 0;

                for (int r = 0; r < matrix.GetLength(0); r++)
                {
                    sumCols += matrix[r, c];
                }

                result[c] = sumCols;
            }

            Console.WriteLine(string.Join(Environment.NewLine, result));

        }
    }
}
