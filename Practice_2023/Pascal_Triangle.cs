namespace Practice_2023;

class Pascal_Triangle
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        long[][] matrix = new long[n][];


        for (int r = 0; r < n; r++)
        {
            matrix[r] = new long[r + 1];

            for (int c = 0; c < matrix[r].Length; c++)
            {
                long element = 0;

                if (r - 1 >= 0 && c <= matrix[r - 1].Length - 1) 
                {
                    element += matrix[r - 1][c];
                }

                if (r - 1 >= 0 && c - 1 >= 0)
                {
                    element += matrix[r - 1][c - 1];
                }

                if (element == 0)
                {
                    element = 1;
                }

                matrix[r][c] = element;

            }
        }

        PrintMatrix(matrix);
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