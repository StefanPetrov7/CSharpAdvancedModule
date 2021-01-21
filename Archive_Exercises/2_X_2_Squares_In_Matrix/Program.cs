using System;
using System.Linq;

namespace _2_X_2_Squares_In_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string[,] matrix = new string[size[0], size[1]];

            ReadMatrix(matrix);

            int result = 0;

            for (int r = 0; r < matrix.GetLength(0) - 1; r++)
            {
                for (int c = 0; c < matrix.GetLength(1) - 1; c++)
                {
                    if ((matrix[r, c] == matrix[r, c + 1])
                        && (matrix[r, c] == matrix[r + 1, c])
                        && (matrix[r, c] == matrix[r + 1, c + 1]))
                    {
                        result++;
                    }
                }
            }

            Console.WriteLine(result);
        }

        public static string[,] ReadMatrix(string[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                string[] rowData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = rowData[c];
                }
            }

            return matrix;
        }
    }
}
