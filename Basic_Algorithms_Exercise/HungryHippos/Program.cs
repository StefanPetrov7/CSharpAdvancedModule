using System;
using System.Linq;

namespace HungryHippos
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeR = int.Parse(Console.ReadLine());
            int sizeC = int.Parse(Console.ReadLine());
            int[,] matrix = CreateMatrix(sizeR, sizeC);
            bool[,] visited = new bool[matrix.GetLength(0), matrix.GetLength(1)];
            int foodBlocks = 0;

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r, c] == 1 && visited[r, c] == false)
                    {
                        FindBlocks(matrix, r, c, visited);
                        foodBlocks++;
                    }
                }
            }

            Console.WriteLine(foodBlocks);
        }

        private static void FindBlocks(int[,] matrix, int row, int col, bool[,] visited)
        {
            visited[row, col] = true;

            if (CanMove(matrix, visited, row + 1, col))
            {
                FindBlocks(matrix, row + 1, col, visited);
            }

            if (CanMove(matrix, visited, row - 1, col))
            {
                FindBlocks(matrix, row - 1, col, visited);
            }

            if (CanMove(matrix, visited, row, col + 1))
            {
                FindBlocks(matrix, row, col + 1, visited);
            }

            if (CanMove(matrix, visited, row, col - 1))
            {
                FindBlocks(matrix, row, col - 1, visited);
            }
        }

        private static bool CanMove(int[,] matrix, bool[,] visited, int row, int col)
        {
            if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
            {
                return false;
            }

            if (matrix[row, col] == 0 || visited[row, col] == true)
            {
                return false;
            }

            return true;
        }

        private static int[,] CreateMatrix(int sizeR, int sizeC)
        {
            int[,] matrix = new int[sizeR, sizeC];

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
