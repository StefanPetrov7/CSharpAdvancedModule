using System;

namespace Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[,] matrix = new string[size, size];
            int[] row = new int[1];
            int[] col = new int[1];
            int[] pilarOne = new int[2];
            int[] pilarTwo = new int[2];
            bool isPilarFound = false;
            bool isOut = false;

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = rowData[c].ToString();

                    if (matrix[r, c] == "S")
                    {
                        row[0] = r;
                        col[0] = c;
                    }

                    if (matrix[r, c] == "O" && !isPilarFound)
                    {
                        pilarOne[0] = r;
                        pilarOne[1] = c;
                        isPilarFound = true;
                    }

                    if (matrix[r, c] == "O" && isPilarFound)
                    {
                        pilarTwo[0] = r;
                        pilarTwo[1] = c;
                    }
                }
            }

            int[] sum = new int[1] { 0 };

            while (sum[0] < 50)
            {
                string cmd = Console.ReadLine();
                matrix[row[0], col[0]] = "-";

                if (cmd == "up")
                {
                    row[0]--;
                    if (IsInTheMatrix(matrix, row, col))
                    {
                        MoveNextSquare(pilarOne, pilarTwo, matrix, row, col, sum);
                    }
                    else
                    {
                        isOut = true;
                        break;
                    }
                }
                else if (cmd == "down")
                {
                    row[0]++;
                    if (IsInTheMatrix(matrix, row, col))
                    {
                        MoveNextSquare(pilarOne, pilarTwo, matrix, row, col, sum);
                    }
                    else
                    {
                        isOut = true;
                        break;
                    }
                }
                else if (cmd == "right")
                {
                    col[0]++;
                    if (IsInTheMatrix(matrix, row, col))
                    {
                        MoveNextSquare(pilarOne, pilarTwo, matrix, row, col, sum);
                    }
                    else
                    {
                        isOut = true;
                        break;
                    }
                }
                else if (cmd == "left")
                {
                    col[0]--;
                    if (IsInTheMatrix(matrix, row, col))
                    {
                        MoveNextSquare(pilarOne, pilarTwo, matrix, row, col, sum);
                    }
                    else
                    {
                        isOut = true;
                        break;
                    }
                }
            }

            if (isOut)
            {
                Console.WriteLine($"Bad news, you are out of the bakery.");
            }

            if (sum[0] >= 50)
            {
                matrix[row[0], col[0]] = "S";
                Console.WriteLine($"Good news! You succeeded in collecting enough money!");
            }

            Console.WriteLine($"Money: {sum[0]}");
            PrintMatrix(matrix);
        }

        private static void MoveNextSquare(int[] pilarOne, int[] pilarTwo, string[,] matrix, int[] row, int[] col, int[] sum)
        {
            if (int.TryParse(matrix[row[0], col[0]], out int result))
            {
                sum[0] += result;
            }
            else if (matrix[row[0], col[0]] == "O")
            {
                if (row[0] == pilarOne[0] && col[0] == pilarOne[1])
                {
                    matrix[row[0], col[0]] = "-";
                    row[0] = pilarTwo[0];
                    col[0] = pilarTwo[1];
                }
                else if (row[0] == pilarTwo[0] && col[0] == pilarTwo[1])
                {
                    matrix[row[0], col[0]] = "-";
                    row[0] = pilarOne[0];
                    col[0] = pilarOne[1];
                }
            }
        }

        private static bool IsInTheMatrix(string[,] matrix, int[] row, int[] col)
        {
            if (row[0] >= 0 && row[0] < matrix.GetLength(0) && col[0] >= 0 && col[0] < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }

        private static void PrintMatrix(string[,] matrix)
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
