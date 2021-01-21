using System;
using System.Linq;

namespace Matrix_of_Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string[,] matrix = new string[size[0], size[1]];

            char[] alpha = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    string one = alpha[r].ToString();
                    string two = alpha[r + c].ToString();
                    string three = alpha[r].ToString();
                    string element = one + two + three;
                    matrix[r, c] = element;
                }
            }

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write(matrix[r, c] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}