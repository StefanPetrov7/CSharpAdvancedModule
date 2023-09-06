namespace Practice_2023;

class Diagonal_Differenceatrix
{
    static void Main(string[] args)
    {

        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];
        ReadMatrix(matrix);
        int primaryDiagonal = 0;
        int secondaryGiagonal = 0;

        for (int r = 0; r < matrix.GetLength(0); r++)
        {
            for (int c = 0; c < matrix.GetLength(1); c++)
            {
                if (r <= matrix.GetLength(0) - 1 && c <= matrix.GetLength(1) - 1)
                {
                    primaryDiagonal += matrix[r, r];
                    break;
                }
            }
        }

        for (int r = 0; r < matrix.GetLength(0); r++)
        {
            for (int c = matrix.GetLength(1) - 1; c >= 0; c--)
            {
                if (r <= matrix.GetLength(0) - 1 && c >= 0)
                {
                    secondaryGiagonal += matrix[r, c - r];
                    break;
                }
            }
        }

        Console.WriteLine(Math.Abs(primaryDiagonal - secondaryGiagonal));


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

    public static void PrintMatrix(long[][] matrix)
    {
        for (int r = 0; r < matrix.GetLength(0); r++)
        {
            for (int c = 0; c < matrix[r].Length; c++)
            {
                Console.Write(matrix[r][c] + " ");
            }

            Console.WriteLine();
        }
    }

}