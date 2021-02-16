using System;

namespace Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            int[] possition = new int[2];
            bool isFinish = false;
            FillMatrix(matrix, possition);

            for (int i = 0; i < n; i++)
            {
                string cmd = Console.ReadLine();

                switch (cmd)
                {
                    case "up":
                        isFinish = MoveUp(matrix, possition, isFinish);
                        break;
                    case "down":
                        isFinish = MoveDown(matrix, possition, isFinish);
                        break;
                    case "right":
                        isFinish = MoveRight(matrix, possition, isFinish);
                        break;
                    case "left":
                        isFinish = MoveLeft(matrix, possition, isFinish);
                        break;
                }

                if (isFinish)
                {
                    break;
                }
            }

            if (isFinish)
            {
                matrix[possition[0], possition[1]] = 'f';
                Console.WriteLine("Player won!");
            }
            else
            {
                matrix[possition[0], possition[1]] = 'f';
                Console.WriteLine("Player lost!");
            }

            PrintMatrix(matrix);
        }

        private static bool MoveUp(char[,] matrix, int[] possition, bool isFinish)
        {
            possition[0]--;
            CheckIfPossitionIsOut(matrix, possition);

            if (matrix[possition[0], possition[1]] == 'B')
            {
                possition[0]--;
                CheckIfPossitionIsOut(matrix, possition);

                if (matrix[possition[0], possition[1]] == 'F')
                {
                    isFinish = true;
                }
            }
            else if (matrix[possition[0], possition[1]] == 'T')
            {
                possition[0]++;
                CheckIfPossitionIsOut(matrix, possition);
            }
            else if (matrix[possition[0], possition[1]] == 'F')
            {
                isFinish = true;
            }

            return isFinish;
        }

        private static bool MoveDown(char[,] matrix, int[] possition, bool isFinish)
        {
            possition[0]++;
            CheckIfPossitionIsOut(matrix, possition);

            if (matrix[possition[0], possition[1]] == 'B')
            {
                possition[0]++;
                CheckIfPossitionIsOut(matrix, possition);

                if (matrix[possition[0], possition[1]] == 'F')
                {
                    isFinish = true;
                }
            }
            else if (matrix[possition[0], possition[1]] == 'T')
            {
                possition[0]--;
                CheckIfPossitionIsOut(matrix, possition);
            }
            else if (matrix[possition[0], possition[1]] == 'F')
            {
                isFinish = true;
            }

            return isFinish;
        }

        private static bool MoveRight(char[,] matrix, int[] possition, bool isFinish)
        {
            possition[1]++;
            CheckIfPossitionIsOut(matrix, possition);

            if (matrix[possition[0], possition[1]] == 'B')
            {
                possition[1]++;
                CheckIfPossitionIsOut(matrix, possition);

                if (matrix[possition[0], possition[1]] == 'F')
                {
                    isFinish = true;
                }
            }
            else if (matrix[possition[0], possition[1]] == 'T')
            {
                possition[1]--;
                CheckIfPossitionIsOut(matrix, possition);
            }
            else if (matrix[possition[0], possition[1]] == 'F')
            {
                isFinish = true;
            }

            return isFinish;
        }

        private static bool MoveLeft(char[,] matrix, int[] possition, bool isFinish)
        {
            possition[1]--;
            CheckIfPossitionIsOut(matrix, possition);

            if (matrix[possition[0], possition[1]] == 'B')
            {
                possition[1]--;
                CheckIfPossitionIsOut(matrix, possition);

                if (matrix[possition[0], possition[1]] == 'F')
                {
                    isFinish = true;
                }
            }
            else if (matrix[possition[0], possition[1]] == 'T')
            {
                possition[1]++;
                CheckIfPossitionIsOut(matrix, possition);
            }
            else if (matrix[possition[0], possition[1]] == 'F')
            {
                isFinish = true;
            }

            return isFinish;
        }

        private static void CheckIfPossitionIsOut(char[,] matrix, int[] possition)
        {
            if (possition[0] > matrix.GetLength(0) - 1)
            {
                possition[0] = 0;
            }
            else if (possition[0] < 0)
            {
                possition[0] = matrix.GetLength(0) - 1;
            }
            else if (possition[1] > matrix.GetLength(1) - 1)
            {
                possition[1] = 0;
            }
            else if (possition[1] < 0)
            {
                possition[1] = matrix.GetLength(1) - 1;
            }
        }

        private static void FillMatrix(char[,] matrix, int[] possition)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = rowData[c];

                    if (matrix[r, c] == 'f')
                    {
                        matrix[r, c] = '-';
                        possition[0] = r;
                        possition[1] = c;
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
