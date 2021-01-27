using System;
using System.Linq;

namespace Crossfire
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = size[0];
            int cols = size[1];
            int[][] matrix = FillMatrix(rows, cols);

            string input;

            while ((input = Console.ReadLine()) != "Nuke it from orbit")
            {
                int[] info = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int bombRow = info[0];
                int bombCol = info[1];
                int radius = info[2];

                RemoveExplodedCells(bombRow, bombCol, radius, ref matrix);
            }

            PrintMatrix(matrix);
        }

        private static void RemoveExplodedCells(int bombRow, int bombCol, int raduius, ref int[][] matrix)
        {

            for (int row = bombRow - raduius; row <= bombRow + raduius; row++)
            {
                if (IsIndexVAlid(row, bombCol, matrix))
                {
                    matrix[row][bombCol] = -1;
                }
            }

            for (int col = bombCol - raduius; col <= bombCol + raduius; col++)
            {
                if (IsIndexVAlid(bombRow, col, matrix))
                {
                    matrix[bombRow][col] = -1;
                }
            }

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                if (matrix[rowIndex].Any(element => element == -1))
                {
                    matrix[rowIndex] = matrix[rowIndex].Where(element => element > 0).ToArray();
                }

                if (matrix[rowIndex].Length < 1)
                {
                    matrix = matrix.Take(rowIndex).Concat(matrix.Skip(rowIndex + 1)).ToArray();
                    rowIndex--;
                }
            }
        }

        private static bool IsIndexVAlid(int row, int col, int[][] matrix)
        {
            return row >= 0 && row <= matrix.Length - 1 && col >= 0 && col <= matrix[row].Length - 1;
        }

        public static int[][] FillMatrix(int rows, int cols)
        {
            int counter = 1;

            int[][] matrix = new int[rows][];  

            for (int r = 0; r < rows; r++)
            {
                matrix[r] = new int[cols];

                for (int c = 0; c < matrix[r].Length; c++)
                {
                    matrix[r][c] = counter;

                    counter++;
                }
            }

            return matrix;
        }

        private static void PrintMatrix(int[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row.Where(x => x > 0)));
            }
        }
    }
}
