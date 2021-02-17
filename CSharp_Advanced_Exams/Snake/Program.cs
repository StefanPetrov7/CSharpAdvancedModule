using System;
using System.Collections.Generic;

namespace Snake
{
    class Program
    {
        internal class Snake
        {
            public Snake(int row, int col)
            {
                this.Row = row;
                this.Col = col;
            }

            public int Row { get; set; }
            public int Col { get; set; }
            public int Food { get; set; }
        }

        internal class Burrow
        {
            public Burrow(int row, int col)
            {
                this.Row = row;
                this.Col = col;
            }

            public int Row { get; set; }
            public int Col { get; set; }
        }

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            Snake snake = new Snake(0, 0);
            List<Burrow> burrows = new List<Burrow>(2);
            FillMtrix(matrix, snake, burrows);

            while (snake.Food < 10)
            {
                string cmd = Console.ReadLine();
                matrix[snake.Row, snake.Col] = '.';

                switch (cmd)
                {
                    case "up":
                        snake.Row--;
                        if (IsSnakeInTheMatrix(snake, matrix, burrows)) continue;
                        else return;
                    case "down":
                        snake.Row++;
                        if (IsSnakeInTheMatrix(snake, matrix, burrows)) continue;
                        else return;
                    case "right":
                        snake.Col++;
                        if (IsSnakeInTheMatrix(snake, matrix, burrows)) continue;
                        else return;
                    case "left":
                        snake.Col--;
                        if (IsSnakeInTheMatrix(snake, matrix, burrows)) continue;
                        else return;
                }
            }

            if (snake.Food >= 10)
            {
                Console.WriteLine("You won! You fed the snake.");
                matrix[snake.Row, snake.Col] = 'S';
                Console.WriteLine($"Food eaten: {snake.Food}");
            }

            PrintMatrix(matrix);
        }

        private static bool IsSnakeInTheMatrix(Snake snake, char[,] matrix, List<Burrow> burrows)
        {
            if (snake.Row < 0 || snake.Row > matrix.GetLength(0) - 1 || snake.Col < 0 || snake.Col > matrix.GetLength(1) - 1)
            {
                Console.WriteLine("Game over!");
                Console.WriteLine($"Food eaten: {snake.Food}");
                PrintMatrix(matrix);
                return false;
            }

            if (matrix[snake.Row, snake.Col] == 'B')
            {
                if (snake.Row == burrows[0].Row && snake.Col == burrows[0].Col)
                {
                    matrix[snake.Row, snake.Col] = '.';
                    snake.Row = burrows[1].Row;
                    snake.Col = burrows[1].Col;
                }
                else
                {
                    matrix[snake.Row, snake.Col] = '.';
                    snake.Row = burrows[0].Row;
                    snake.Col = burrows[0].Col;
                }
                return true;
            }
            else if (matrix[snake.Row, snake.Col] == '*')
            {
                snake.Food++;
                return true;
            }

            return true;
        }

        private static void FillMtrix(char[,] matrix, Snake snake, List<Burrow> burrows)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = rowData[c];

                    if (matrix[r, c] == 'S')
                    {
                        snake.Row = r;
                        snake.Col = c;
                    }

                    if (matrix[r, c] == 'B')
                    {
                        Burrow burrow = new Burrow(r, c);
                        burrows.Add(burrow);
                    }
                }
            }
        }

        private static void PrintMatrix(char[,] matrix)
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
}
