using System;
using System.Linq;

namespace Exercise_04_MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string[,] matrix = new string[sizes[0], sizes[1]];

            ReadMatrix(matrix);

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] cmd = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (cmd.Length == 5 && cmd[0] == "swap")
                {
                    string command = cmd[0];
                    int firstR = int.Parse(cmd[1]);
                    int firstC = int.Parse(cmd[2]);
                    int secondR = int.Parse(cmd[3]);
                    int secondC = int.Parse(cmd[4]);

                    if ((firstR >= 0 && secondR >= 0) &&
                        (firstR < matrix.GetLength(0) && secondR < matrix.GetLength(0)))
                    {
                        if ((firstC >= 0 && secondC >= 0) &&
                            (firstC < matrix.GetLength(1) && secondC < matrix.GetLength(1)))
                        {
                            string firstEllement = matrix[firstR, firstC];
                            string secondEllement = matrix[secondR, secondC];

                            matrix[firstR, firstC] = secondEllement;
                            matrix[secondR, secondC] = firstEllement;

                            PrintMatrix(matrix);

                        }
                        else
                        {
                            Console.WriteLine("Invalid input!");
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

            }

        }

        static void PrintMatrix(string[,] matrix)
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

        static string[,] ReadMatrix(string[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                string[] rowData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = rowData[c];
                }
            }
            return matrix;
        }
    }
}
