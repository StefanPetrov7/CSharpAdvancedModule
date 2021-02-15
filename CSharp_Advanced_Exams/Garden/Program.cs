using System;
using System.Collections.Generic;
using System.Linq;

namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            const string END_INPUT = "Bloom Bloom Plow";

            int[] size = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[size[0], size[1]];
            FillMatrix(matrix);
            string input;
            Queue<int[]> flowers = new Queue<int[]>();

            while ((input = Console.ReadLine()) != END_INPUT)
            {
                int[] coordinates = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                if (IsCoordinatesValid(coordinates, matrix))
                {
                    matrix[coordinates[0], coordinates[1]] = 1;
                    flowers.Enqueue(coordinates);
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }
            }

            while (flowers.Count > 0)
            {
                int[] flower = flowers.Dequeue();
                int row = flower[0];
                int col = flower[1];

                for (int r = 0; r < row; r++)
                {
                    matrix[r, col] += 1;
                }

                for (int r = row + 1; r < matrix.GetLength(0); r++)
                {
                    matrix[r, col] += 1;
                }

                for (int c = 0; c < col; c++)
                {
                    matrix[row, c] += 1;
                }

                for (int c = col + 1; c < matrix.GetLength(1); c++)
                {
                    matrix[row, c] += 1;
                }
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write(matrix[r, c] + " ");
                }
                Console.WriteLine();
            }
        }

        public static bool IsCoordinatesValid(int[] coordinates, int[,] matrix)
        {
            return (coordinates[0] >= 0 && coordinates[0] < matrix.GetLength(0)
                && coordinates[1] >= 0 && coordinates[1] < matrix.GetLength(1));

        }

        public static void FillMatrix(int[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = 0;
                }
            }
        }
    }
}
