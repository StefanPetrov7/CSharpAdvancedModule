using System;
using System.Linq;

namespace Exercise_05_01_SnakeMoves_ReverseArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var snake = Console.ReadLine();
            char[][] matrix = new char[input[0]][];
            int startIndex = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                matrix[row] = new char[input[1]];
                for (int col = 0; col < input[1]; col++)
                {
                    matrix[row][col] = snake[startIndex];
                    startIndex++;

                    if (startIndex == snake.Length)
                    {
                        startIndex = 0;
                    }
                }
                if (row % 2 != 0)
                {
                    Array.Reverse(matrix[row]);
                }
            }
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}
