using System;
using System.Linq;

namespace Lego_Blocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] matrixOne = new int[n][];
            int[][] matrixTwo = new int[n][];
            FillMatrix(matrixOne);
            FillMatrix(matrixTwo);
            ReverseMatrix(matrixTwo);
            bool isMatching = true;
            bool isRowsEven = n % 2 == 0 ? true : false;

            if (isRowsEven)
            {
                for (int i = 0; i < matrixOne.GetLength(0); i += 2)
                {
                    int matrixOneRowAbsSum = Math.Abs(matrixOne[i].Length - matrixOne[i + 1].Length);
                    int matrixTwoRowAbsSum = Math.Abs(matrixTwo[i].Length - matrixTwo[i + 1].Length);

                    if (matrixOneRowAbsSum != matrixTwoRowAbsSum)
                    {
                        isMatching = false;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < matrixOne.GetLength(0) - 1; i += 2)
                {
                    int matrixOneRowAbsSum = Math.Abs(matrixOne[i].Length - matrixOne[i + 1].Length);
                    int matrixTwoRowAbsSum = Math.Abs(matrixTwo[i].Length - matrixTwo[i + 1].Length);

                    if (matrixOneRowAbsSum != matrixTwoRowAbsSum)
                    {
                        isMatching = false;
                        break;
                    }

                    int matrixOneFirstRow = matrixOne[i].Length;
                    int matrixTwoFirsRow = matrixTwo[i].Length;
                    int sumFirstRowLenth = matrixOneFirstRow + matrixTwoFirsRow;
                    int matrixOneLastRow = matrixOne[matrixOne.GetLength(0) - 1].Length;
                    int matrixTwoLastRow = matrixTwo[matrixTwo.GetLength(0) - 1].Length;
                    int sumLastRowLenth = matrixOneLastRow + matrixTwoLastRow;
                    
                    if (sumFirstRowLenth!=sumLastRowLenth)
                    {
                        isMatching = false;
                        break;
                    }
                }
            }


            if (!isMatching)
            {
                int totalCellSum = 0;

                for (int i = 0; i < matrixOne.GetLength(0); i++)
                {
                    totalCellSum += (matrixOne[i].Length + matrixTwo[i].Length);
                }

                Console.WriteLine($"The total number of cells is: {totalCellSum}");
            }
            else
            {
                PrintMatrix(CombineMatrix(matrixOne, matrixTwo));
            }
        }

        private static int[][] CombineMatrix(int[][] matrixOne, int[][] matrixTwo)
        {
            int[][] vsMatrix = new int[matrixOne.GetLength(0)][];

            for (int row = 0; row < vsMatrix.GetLength(0); row++)
            {
                vsMatrix[row] = new int[matrixOne[row].Length + matrixTwo[row].Length];
                int vsCol = 0;

                for (int colOne = 0; colOne < matrixOne[row].Length; colOne++)
                {
                    vsMatrix[row][vsCol] = matrixOne[row][colOne];
                    vsCol++;
                }

                for (int colTwo = 0; colTwo < matrixTwo[row].Length; colTwo++)
                {
                    vsMatrix[row][vsCol] = matrixTwo[row][colTwo];
                    vsCol++;
                }
            }

            return vsMatrix;
        }

        private static void ReverseMatrix(int[][] matrixTWo)
        {
            for (int row = 0; row < matrixTWo.GetLength(0); row++)
            {
                matrixTWo[row] = matrixTWo[row].Reverse().ToArray();
            }
        }

        public static void FillMatrix(int[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                matrix[row] = new int[rowData.Length];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = rowData[col];
                }
            }
        }

        private static void PrintMatrix(int[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                Console.WriteLine($"[{string.Join(", ", matrix[row])}]");
            }
        }
    }
}
