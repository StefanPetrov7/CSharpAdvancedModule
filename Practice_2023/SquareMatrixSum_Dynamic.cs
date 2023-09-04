namespace Practice_2023;

class Square_With_Maximum_Sum
{
    static void Main(string[] args)
    {

        // best matrix sym with dynamic size
        // adjusted print method for printing best n x matrix from the starting matrix 

        int[] data = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[data[0], data[1]];
        int best = int.MinValue;
        int bestR = 0;
        int bestC = 0;

        ReadMatrix(matrix);

        for (int r = 0; r < matrix.GetLength(0) - n + 1; r++)
        {

            for (int c = 0; c < matrix.GetLength(1) - n + 1; c++)
            {
                int dynamicRow = r;
                int dynamicCol = c;
                int curBest = FindBestMatrix(dynamicRow, dynamicCol, n, matrix);

                if (curBest > best)
                {
                    best = curBest;
                    bestR = r;
                    bestC = c;
                }
            }
        }

        PrintMatrix(matrix, bestR, bestC, n);
        Console.WriteLine(best);
    }

    private static int FindBestMatrix(int dynamicRow, int dynamicCol, int n, int[,] matrix)
    {
        int result = 0;

        for (int r = dynamicRow; r < n + dynamicRow; r++)
        {
            for (int c = dynamicCol; c < n + dynamicCol; c++)
            {
                result += matrix[r, c];
            }
        }

        return result;
    }

    public static void ReadMatrix(int[,] matrix)
    {
        for (int rows = 0; rows < matrix.GetLength(0); rows++)
        {
            int[] readRow = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            for (int cols = 0; cols < matrix.GetLength(1); cols++)
            {
                matrix[rows, cols] = readRow[cols];
            }
        }
    }

    public static void PrintMatrix(int[,] matrix, int bestR, int bestC, int n)
    {
        for (int r = bestR; r < n + bestR; r++)
        {
            for (int c = bestC; c < n + bestC; c++)
            {
                Console.Write(matrix[r,c]+ " ");
            }

            Console.WriteLine();
        }
    }
}
