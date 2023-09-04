namespace Practice_2023;

class Key_Revolver
{
    static void Main(string[] args)
    {
        int[] data = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int[,] matrix = new int[data[0], data[1]];
        int[,] bestSquare = new int[2, 2];
        int best = 0;

        ReadMatrix(matrix);

        for (int r = 0; r < matrix.GetLength(0) - 1; r++)
        {
            for (int c = 0; c < matrix.GetLength(1) - 1; c++)
            {
                int curBest = matrix[r, c] + matrix[r, c + 1] + matrix[r + 1, c] + matrix[r + 1, c + 1];

                if (curBest > best)
                {
                    best = curBest;
                    bestSquare[0, 0] = matrix[r, c];
                    bestSquare[0, 1] = matrix[r, c + 1];
                    bestSquare[1, 0] = matrix[r + 1, c];
                    bestSquare[1, 1] = matrix[r + 1, c + 1];
                }
            }
        }

        PrintMatrix(bestSquare);
        Console.WriteLine(best);
    }

    public static void ReadMatrix(int[,] matrix)
    {
        for (int rows = 0; rows < matrix.GetLength(0); rows++)
        {
            int[] input = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            for (int cols = 0; cols < matrix.GetLength(1); cols++)
            {
                matrix[rows, cols] = input[cols];
            }
        }
    }

    public static void PrintMatrix(int[,] matrix)
    {
        for (int rows = 0; rows < matrix.GetLength(0); rows++)
        {
            for (int cols = 0; cols < matrix.GetLength(1); cols++)
            {
                Console.Write(matrix[rows, cols] + " ");
            }

            Console.WriteLine();
        }
    }
}
