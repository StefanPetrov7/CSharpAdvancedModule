using System;
using System.Linq;

namespace Exercise_02_2X2SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            char[,] matrix = new char[sizes[0], sizes[1]];
            ReadMatrix(matrix);

            int equalSquares = 0;

            for (int r = 0; r < matrix.GetLength(0) - 1; r++)
            {
                for (int c = 0; c < matrix.GetLength(1) - 1; c++)
                {
                    char one = matrix[r, c];
                    char two = matrix[r, c + 1];
                    char three = matrix[r + 1, c];
                    char four = matrix[r + 1, c + 1];

                    if ((one == two) && (two == three) && (three == four))
                    {
                        equalSquares++;
                    }
                }
            }

            Console.WriteLine(equalSquares);

        }

        static char[,] ReadMatrix(char[,] matrix)
        {

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                string[] rowData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = char.P(rowData[c]);
                }
            }

            return matrix;

        }
    }
}
