namespace Practice_2023;

class Jagged_Array_Modification
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[][] matrix = ReadJaggedMAtrix(n);
        string input;

        while ((input = Console.ReadLine()) != "END")
        {
            string[] commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string cmd = commands[0];
            int row = int.Parse(commands[1]);
            int col = int.Parse(commands[2]);
            int number = int.Parse(commands[3]);

            switch (cmd)
            {
                case "Add":
                    if (CoordinatesValid(row, col, matrix))
                    {
                        matrix[row][col] += number;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                    break;
                case "Subtract":
                    if (CoordinatesValid(row, col, matrix))
                    {
                        matrix[row][col] -= number;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                    break;
            }
        }


        PrintMatrix(matrix);

    }

    private static bool CoordinatesValid(int row, int col, int[][] matrix)
    {
        if ((row >= 0 && row <= matrix.GetLength(0) - 1) && (col >= 0 && col <= matrix[row].Length - 1))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private static int[][] ReadJaggedMAtrix(int n)
    {
        int[][] matrix = new int[n][];

        for (int r = 0; r < matrix.Length; r++)
        {
            int[] rowData = Console.ReadLine().Split(" ", StringSplitOptions.TrimEntries).Select(int.Parse).ToArray();
            matrix[r] = new int[rowData.Length];

            for (int c = 0; c < rowData.Length; c++)
            {
                matrix[r][c] = rowData[c];
            }
        }

        return matrix;
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
