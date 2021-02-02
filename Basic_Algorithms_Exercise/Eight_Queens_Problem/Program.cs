using System;

namespace Eight_Queens_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            int queens = int.Parse(Console.ReadLine());

            int[,] matrix = new int[queens, queens];

            Console.WriteLine(GetQueens(matrix, 0));
        }

        private static int GetQueens(int[,] queens, int row)
        {
            if (row == queens.GetLength(0))  // bottom
            {
                Print(queens);
                return 1;
            }

            int foundQueens = 0;

            for (int col = 0; col < queens.GetLength(1); col++)  // recursion engine
            {
                if (IsSafe(queens, row, col))
                {
                    queens[row, col] = 1;
                    foundQueens += GetQueens(queens, row + 1);
                    queens[row, col] = 0;
                }
            }

            return foundQueens;
        }

        static void Print(int[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r, c] == 1)
                    {
                        Console.Write("Q" + " ");
                    }

                    if (matrix[r, c] == 0)
                    {
                        Console.Write("*" + " ");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        private static bool IsSafe(int[,] queens, int row, int col)
        {
            for (int i = 1; i < queens.GetLength(0); i++)  // 8th if for the surondings squares of the queen.
            {
                if (row - i >= 0 && queens[row - i, col] == 1)
                {
                    return false;
                }

                if (col - i >= 0 && queens[row, col - i] == 1)
                {
                    return false;
                }

                if (row + i < queens.GetLength(0) && queens[row + i, col] == 1)
                {
                    return false;
                }

                if (col + i < queens.GetLength(0) && queens[row, col + i] == 1)
                {
                    return false;
                }

                if (col + i < queens.GetLength(0) &&
                    row + i < queens.GetLength(0) &&
                    queens[row + i, col + i] == 1)
                {
                    return false;
                }

                if (col - i >= 0 &&
                    row + i < queens.GetLength(0) &&
                    queens[row + i, col - i] == 1)
                {
                    return false;
                }

                if (col - i >= 0 &&
                    row - i >= 0 &&
                    queens[row - i, col - i] == 1)
                {
                    return false;
                }

                if (col + i < queens.GetLength(0) &&
                    row - i >= 0 &&
                    queens[row - i, col + i] == 1)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
