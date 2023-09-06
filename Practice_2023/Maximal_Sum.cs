namespace Practice_2023;

class Maximal_Sum
{
    static void Main(string[] args)
    {

        int[] size = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
        int[,] matrix = new int[size[0], size[1]];
        ReadMatrix(matrix);
        int bestSum = int.MinValue;
        int bestR = 0;
        int bestC = 0;

        for (int r = 0; r < matrix.GetLength(0) - 2; r++)
        {
            for (int c = 0; c < matrix.GetLength(1) - 2; c++)
            {
                int curSum = 0;


                for (int row = r; row < r + 3; row++)
                {
                    for (int col = c; col < c + 3; col++)
                    {
                        curSum += matrix[row, col];
                    }
                }

                if (curSum > bestSum)
                {
                    bestSum = curSum;
                    bestR = r;
                    bestC = c;
                }
            }
        }

        Console.WriteLine("Sum =   " + bestSum);

        PrintMatrix(matrix, bestR, bestC);

    }

    public static int[,] ReadMatrix(int[,] matrix)
    {
        for (int r = 0; r < matrix.GetLength(0); r++)
        {
            int[] rowData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            for (int c = 0; c < matrix.GetLength(1); c++)
            {
                matrix[r, c] = rowData[c];
            }
        }

        return matrix;
    }

    public static void PrintMatrix(int[,] matrix, int row, int col)
    {
        for (int r = row; r < row + 3; r++)
        {
            for (int c = col; c < col + 3; c++)
            {
                Console.Write(matrix[r, c] + " ");
            }

            Console.WriteLine();
        }
    }
}