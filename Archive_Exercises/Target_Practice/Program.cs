﻿using System;
using System.Linq;

namespace Target_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rowSize = size[0];
            int colSize = size[1];
            string snake = Console.ReadLine();

            int[] explosionParameters = Console.ReadLine()
              .Split(" ", StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToArray();
            string[][] matrix = new string[rowSize][];

            ReadMatrix(matrix, colSize, snake);
            RemoveExplodedCells(matrix, explosionParameters);
            CharDown(matrix, colSize);
            PrintMatrix(matrix);
        }

        private static void CharDown(string[][] matrix, int colSize)
        {
            for (int c = 0; c < colSize; c++)
            {
                for (int r = 0; r < matrix.GetLength(0); r++)
                {
                    for (int row = matrix.GetLength(0) - 1; row > 0; row--)
                    {
                        if (matrix[row][c] == " ")
                        {
                            matrix[row][c] = matrix[row - 1][c];
                            matrix[row - 1][c] = " ";
                        }
                    }
                }
            }
        }

        private static void RemoveExplodedCells(string[][] matrix, int[] explosionParameters)
        {
            int rowExp = explosionParameters[0];
            int colExp = explosionParameters[1];
            int radiusExp = explosionParameters[2];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix[r].Length; c++)
                {
                    if (Math.Sqrt(Math.Pow((r - rowExp), 2) + Math.Pow((c - colExp), 2)) <= radiusExp)
                    {
                        matrix[r][c] = " ";
                    }
                }
            }
        }

        public static void ReadMatrix(string[][] matrix, int colSzie, string snake)
        {
            int counter = 0;
            bool flagEveOrOdd = matrix.GetLength(0) % 2 == 0 ? true : false;

            for (int r = matrix.GetLength(0) - 1; r >= 0; r--)
            {
                matrix[r] = new string[colSzie];

                for (int c = matrix[r].Length - 1; c >= 0; c--)
                {
                    matrix[r][c] = snake[counter].ToString();
                    counter++;

                    if (counter == snake.Length)
                    {
                        counter = 0;
                    }
                }

                if (flagEveOrOdd)
                {
                    if (r % 2 == 0)
                    {
                        matrix[r] = matrix[r].Reverse().ToArray();
                    }
                }
                else
                {
                    if (r % 2 != 0)
                    {
                        matrix[r] = matrix[r].Reverse().ToArray();
                    }
                }
            }
        }

        public static void PrintMatrix(string[][] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix[r].Length; c++)
                {
                    Console.Write(matrix[r][c]);
                }

                Console.WriteLine();
            }
        }
    }
}
