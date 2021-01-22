using System;
using System.Linq;

namespace Rubiks_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size[0], size[1]];
            ReadMatrix(matrix);

            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string direction = cmd[1];
                int moves = int.Parse(cmd[2]);

                switch (direction)
                {
                    case "up":
                        int col = int.Parse(cmd[0]);
                        MovingUp(matrix, moves, col);
                        break;
                    case "down":
                        col = int.Parse(cmd[0]);
                        MovingDown(matrix, moves, col);
                        break;
                    case "left":
                        int row = int.Parse(cmd[0]);
                        MovingLeft(matrix, moves, row);
                        break;
                    case "right":
                        row = int.Parse(cmd[0]);
                        MovingRight(matrix, moves, row);
                        break;
                }

                // PrintMatrix(matrix);
            }

            int counter = 1;
            bool flag = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == counter)
                    {
                        counter++;
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        flag = false;

                        for (int r = matrix.GetLength(0) - 1; r >= 0; r--)
                        {
                            for (int c = matrix.GetLength(1) - 1; c >= 0; c--)
                            {
                                if (matrix[r, c] == counter)
                                {
                                    Console.WriteLine($"Swap ({row}, {col}) with ({r}, {c})");
                                    matrix[r, c] = matrix[row, col];
                                    matrix[row, col] = counter;
                                    counter++;
                                    flag = true;
                                    break;
                                }
                            }
                            if (flag)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        public static void PrintMatrix(int[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write(matrix[r, c] + "   ");
                }
                Console.WriteLine();
            }
        }

        public static void MovingRight(int[,] matrix, int moves, int row)
        {
            for (int i = 0; i < moves; i++)
            {
                int last = matrix[row, matrix.GetLength(1) - 1];

                for (int c = matrix.GetLength(1) - 1; c > 0; c--)
                {
                    matrix[row, c] = matrix[row, c - 1];
                }

                matrix[row, 0] = last;
            }
        }

        public static void MovingLeft(int[,] matrix, int moves, int row)
        {
            for (int i = 0; i < moves; i++)
            {
                int first = matrix[row, 0];

                for (int c = 0; c < matrix.GetLength(1) - 1; c++)
                {
                    matrix[row, c] = matrix[row, c + 1];
                }

                matrix[row, matrix.GetLength(1) - 1] = first;
            }
        }

        public static void MovingDown(int[,] matrix, int moves, int col)
        {
            for (int i = 0; i < moves; i++)
            {
                int last = matrix[matrix.GetLength(0) - 1, col];

                for (int r = matrix.GetLength(0) - 1; r > 0; r--)
                {
                    matrix[r, col] = matrix[r - 1, col];
                }

                matrix[0, col] = last;
            }
        }

        public static void MovingUp(int[,] matrix, int moves, int col)
        {
            for (int i = 0; i < moves; i++)
            {
                int first = matrix[0, col];

                for (int r = 0; r < matrix.GetLength(0) - 1; r++)
                {
                    matrix[r, col] = matrix[r + 1, col];
                }

                matrix[matrix.GetLength(0) - 1, col] = first;
            }
        }

        public static void ReadMatrix(int[,] matrix)
        {
            int counter = 1;

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = counter;
                    counter++;
                }
            }
        }
    }
}
