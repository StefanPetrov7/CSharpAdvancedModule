namespace Practice_2023;

class Jagged_Array_Manipulator
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        string input;
        int[][] matrix = new int[n][];
        ReadJaggedMatrix(matrix);
        RowOperations(matrix);

        while ((input = Console.ReadLine()) != "End")
        {
            string[] cmd = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string command = cmd[0];
            int row = int.Parse(cmd[1]);
            int col = int.Parse(cmd[2]);
            int value = int.Parse(cmd[3]);

            if (IsIndexValid(matrix, row, col))
            {
                switch (command)
                {
                    case "Add":
                        matrix[row][col] += value;
                        break;
                    case "Subtract":
                        matrix[row][col] -= value;
                        break;
                }
            }
        }

        PrintMatrix(matrix);

    }

    public static bool IsIndexValid(int[][] matrix, int row, int col)
    {
        return row >= 0 && row <= matrix.GetLength(0) - 1 && col >= 0 && col <= matrix[row].Length - 1;
    }

    public static void RowOperations(int[][] matrix)
    {
        int prevrRowElements = 0;
        int curRowElements = 0;

        for (int row = 1; row < matrix.GetLength(0); row++)
        {
            prevrRowElements = matrix[row - 1].Length;
            curRowElements = matrix[row].Length;

            if (prevrRowElements == curRowElements)
            {
                matrix[row - 1] = matrix[row - 1].Select(x => x * 2).ToArray();
                matrix[row] = matrix[row].Select(x => x * 2).ToArray();
            }
            else
            {
                matrix[row - 1] = matrix[row - 1].Select(x => x / 2).ToArray();
                matrix[row] = matrix[row].Select(x => x / 2).ToArray();
            }
        }
    }

    public static void ReadJaggedMatrix(int[][] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            int[] rowData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            matrix[row] = new int[rowData.Length];

            for (int col = 0; col < matrix[row].Length; col++)
            {
                matrix[row][col] = rowData[col];
            }
        }
    }

    public static void PrintMatrix(int[][] matrix)
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
