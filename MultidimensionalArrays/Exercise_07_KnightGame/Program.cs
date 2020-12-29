using System;
using System.Linq;

namespace Exercise_07_KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[,] matrix = new string[n, n];

            int removedHorses = 0;
            int bestHorseR = 0;
            int bestHorseC = 0;

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                string data = Console.ReadLine();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = data[c].ToString();
                }
            }

            while (true)
            {
                int maxAttack = 0;

                for (int r = 0; r < matrix.GetLength(0); r++)
                {
                    for (int c = 0; c < matrix.GetLength(1); c++)
                    {
                        if (matrix[r, c] == "K")
                        {
                           int attacks = AttacksCount(matrix, r, c);

                            if (attacks > maxAttack)
                            {
                                maxAttack = attacks;
                                bestHorseR = r;
                                bestHorseC = c;
                            }
                        }
                    }
                }

                if (maxAttack > 0)
                {
                    matrix[bestHorseR, bestHorseC] = "0";
                    removedHorses++;
                }

                if (maxAttack == 0)
                {
                    Console.WriteLine(removedHorses);
                    break;
                }
            }
        }

        static int AttacksCount(string[,] matrix, int row, int col)
        {
            int attacks = 0;

            if (IsElementValid(row - 2, col - 1, matrix) && (matrix[row - 2, col - 1] == "K"))
            {
                attacks++;
            }
            if (IsElementValid(row - 2, col + 1, matrix) && (matrix[row - 2, col + 1] == "K"))
            {
                attacks++;
            }
            if (IsElementValid(row - 1, col + 2, matrix) && (matrix[row - 1, col + 2] == "K"))
            {
                attacks++;
            }
            if (IsElementValid(row + 1, col + 2, matrix) && (matrix[row + 1, col + 2] == "K"))
            {
                attacks++;
            }
            if (IsElementValid(row + 2, col + 1, matrix) && (matrix[row + 2, col + 1] == "K"))
            {
                attacks++;
            }
            if (IsElementValid(row + 2, col - 1, matrix) && (matrix[row + 2, col - 1] == "K"))
            {
                attacks++;
            }
            if (IsElementValid(row + 1, col - 2, matrix) && (matrix[row + 1, col - 2] == "K"))
            {
                attacks++;
            }
            if (IsElementValid(row - 1, col - 2, matrix) && (matrix[row - 1, col - 2] == "K"))
            {
                attacks++;
            }

            return attacks;
        }

        static bool IsElementValid(int row, int col, string[,] matrix)
        {
            if ((row >= 0 && row < matrix.GetLength(0)) &&
               (col >= 0 && col < matrix.GetLength(1)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
