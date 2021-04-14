using System;

namespace Super_Mario
{
    class Program
    {

        static void Main(string[] args)
        {
            int health = int.Parse(Console.ReadLine());
            byte size = byte.Parse(Console.ReadLine());

            int[] marioHealth = new int[] { health };
            int[] marioRow = new int[1];
            int[] marioCol = new int[1];

            char[][] matrix = new char[size][];

            ComleteMatrix(matrix, size, marioRow, marioCol);

            while (true)
            {
                string[] arg = Console.ReadLine().Split();

                string move = arg[0];
                int enemyRow = int.Parse(arg[1]);
                int enemyCol = int.Parse(arg[2]);

                matrix[marioRow[0]][marioCol[0]] = '-';

                SpawnEnemy(enemyRow, enemyCol, matrix);

                switch (move)
                {
                    case "W":
                        marioRow[0]--;
                        marioHealth[0] -= 1;
                        CheckIfMarioIsOut(marioRow, marioCol, marioHealth, matrix);
                        InspectCrll(marioRow, marioCol, marioHealth, matrix);
                        break;
                    case "S":
                        marioRow[0]++;
                        marioHealth[0] -= 1;
                        CheckIfMarioIsOut(marioRow, marioCol, marioHealth, matrix);
                        InspectCrll(marioRow, marioCol, marioHealth, matrix);
                        break;
                    case "A":
                        marioCol[0]--;
                        marioHealth[0] -= 1;
                        CheckIfMarioIsOut(marioRow, marioCol, marioHealth, matrix);
                        InspectCrll(marioRow, marioCol, marioHealth, matrix);
                        break;
                    case "D":
                        marioCol[0]++;
                        marioHealth[0] -= 1;
                        CheckIfMarioIsOut(marioRow, marioCol, marioHealth, matrix);
                        InspectCrll(marioRow, marioCol, marioHealth, matrix);
                        break;
                }

                if (matrix[marioRow[0]][marioCol[0]] == 'P')
                {
                    matrix[marioRow[0]][marioCol[0]] = '-';
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {marioHealth[0]}");
                    break;
                }

                if (marioHealth[0] <= 0)
                {
                    matrix[marioRow[0]][marioCol[0]] = 'X';
                    Console.WriteLine($"Mario died at {marioRow[0]};{marioCol[0]}.");
                    break;
                }
            }

            PrintMatrix(matrix);
        }

        private static void InspectCrll(int[] marioRow, int[] marioCol, int[] marioHealth, char[][] matrix)
        {

            if (matrix[marioRow[0]][marioCol[0]] == 'B')
            {
                marioHealth[0] -= 2;
            }
        }

        private static void CheckIfMarioIsOut(int[] marioRow, int[] marioCol, int[] marioHealth, char[][] matrix)
        {
            if (marioRow[0] < 0)
            {
                marioRow[0] = 0;
            }

            if (marioRow[0] > matrix.Length - 1)
            {
                marioRow[0] = matrix.Length - 1;
            }

            if (marioCol[0] < 0)
            {
                marioCol[0] = 0;
            }

            if (marioCol[0] > matrix[marioRow[0]].Length - 1)
            {
                marioCol[0] = matrix[marioRow[0]].Length - 1;
            }

        }

        private static void SpawnEnemy(int enemyRow, int enemyCol, char[][] matrix)
        {
            matrix[enemyRow][enemyCol] = 'B';
        }

        private static void PrintMatrix(char[][] matrix)
        {
            for (int r = 0; r < matrix.Length; r++)
            {
                for (int c = 0; c < matrix[r].Length; c++)
                {
                    Console.Write(matrix[r][c]);
                }

                Console.WriteLine();
            }
        }

        private static void CompleteMatrix(char[][] matrix, int size, int[] marioRow, int[] marioCol)
        {
            for (int r = 0; r < size; r++)
            {
                char[] rowInfo = Console.ReadLine().ToCharArray();

                matrix[r] = new char[rowInfo.Length];

                for (int c = 0; c < rowInfo.Length; c++)
                {
                    matrix[r][c] = rowInfo[c];

                    if (matrix[r][c] == 'M')
                    {
                        marioRow[0] = r;
                        marioCol[0] = c;
                    }
                }
            }
        }
    }
}
