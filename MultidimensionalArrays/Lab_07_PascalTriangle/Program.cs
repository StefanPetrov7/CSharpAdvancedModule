using System;
using System.Linq;

namespace Lab_07_PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            long[][] matrixJ = new long[n][];

            int cols = 1;

            for (int r = 0; r < matrixJ.Length; r++)
            {
                matrixJ[r] = new long[cols];
                matrixJ[r][0] = 1;
                matrixJ[r][matrixJ[r].Length - 1] = 1;

                if (r > 1)
                {
                    for (int c = 1; c < matrixJ[r].Length - 1; c++)
                    {
                        long[] prevRow = matrixJ[r - 1];
                        long firstNum = prevRow[c];
                        long secondNum = prevRow[c - 1];
                        matrixJ[r][c] = firstNum + secondNum;
                    }
                }
                cols++;
            }

            for (int r = 0; r < matrixJ.Length; r++)
            {
                for (int c = 0; c < matrixJ[r].Length; c++)
                {
                    Console.Write(matrixJ[r][c] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
