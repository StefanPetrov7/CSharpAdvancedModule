using System;
using System.Xml.Linq;

namespace Practice_2023;

class Snake_Moves
{
    static void Main(string[] args)
    {

        int[] size = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
        char[,] matrix = new char[size[0], size[1]];
        string input = Console.ReadLine();
        Queue<char> snake = new Queue<char>();

        for (int i = 0; i < input.Length; i++)
        {
            snake.Enqueue(input[i]);
        }

        for (int r = 0; r < matrix.GetLength(0); r++)
        {

            for (int c = 0; c < matrix.GetLength(1); c++)
            {

                if (r % 2 == 0)
                {
                    for (int revC = matrix.GetLength(1) - 1; revC >= 0; revC--)
                    {
                        char curChar = snake.Dequeue();
                        matrix[r, revC] = curChar;
                        snake.Enqueue(curChar);
                    }
                }
                else
                {
                    char curChar = snake.Dequeue();
                    matrix[r, c] = curChar;
                    snake.Enqueue(curChar);
                }

                if (r % 2 != 0)
                {
                    break;
                }

            }
        }

        PrintMatrix(matrix);
    }

    public static void PrintMatrix(char[,] matrix)
    {
        for (int r = 0; r < matrix.GetLength(0); r++)
        {
            for (int c = 0; c < matrix.GetLength(1); c++)
            {
                Console.Write(matrix[r, c]);
            }

            Console.WriteLine();
        }
    }
}
