namespace Practice_2023;

class Radioactive_Mutant_Vampire_Bunnies
{
    static void Main(string[] args)
    {
        int[] sizes = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
        Player player = new Player();
        string[,] matrix = ReadMatrix(sizes[0], sizes[1], player);
        string input = Console.ReadLine();

        for (int i = 0; i < input.Length; i++)
        {
            string cmd = input[i].ToString();
            MovePlayer(cmd, matrix, player);
            MultiplyBunnies(matrix, player);

            if (player.IsWon == true)
            {
                PrintMatrix(matrix);
                break;
            }

            if (player.IsAlive == false)
            {
                PrintMatrix(matrix);
                break;
            }
        }

        Console.WriteLine(player.ToString());
    }

    private static void MovePlayer(string cmd, string[,] matrix, Player player)
    {
        matrix[player.Row, player.Col] = ".";

        switch (cmd)
        {
            case "U":
                player.PrevRow = player.Row;
                player.Row--;
                Move(matrix, player);
                break;
            case "D":
                player.PrevRow = player.Row;
                player.Row++;
                Move(matrix, player);
                break;
            case "L":
                player.PrevCol = player.Col;
                player.Col--;
                Move(matrix, player);
                break;
            case "R":
                player.PrevCol = player.Col;
                player.Col++;
                Move(matrix, player);
                break;
        }
    }

    private static void MultiplyBunnies(string[,] matrix, Player player)
    {
        for (int r = 0; r < matrix.GetLength(0); r++)
        {
            for (int c = 0; c < matrix.GetLength(1); c++)
            {
                if (matrix[r, c] == "B")
                {
                    if (IsIndexValid(matrix, r - 1, c)&& matrix[r - 1, c] != "B")
                    {
                        if (matrix[r - 1, c] == "P")
                        {
                            player.IsAlive = false;
                        }
                        matrix[r - 1, c] = "b";
                    }

                    if (IsIndexValid(matrix, r + 1, c)&& matrix[r + 1, c] != "B")
                    {
                        if (matrix[r + 1, c] == "P")
                        {
                            player.IsAlive = false;
                        }
                        matrix[r + 1, c] = "b";
                    }

                    if (IsIndexValid(matrix, r, c - 1)&& matrix[r, c - 1] != "B")
                    {
                        if (matrix[r, c - 1] == "P")
                        {
                            player.IsAlive = false;
                        }
                        matrix[r, c - 1] = "b";
                    }

                    if (IsIndexValid(matrix, r, c + 1) && matrix[r, c + 1] != "B")
                    {
                        if (matrix[r, c + 1] == "P")
                        {
                            player.IsAlive = false;
                        }
                        matrix[r, c + 1] = "b";
                    }
                }
            }
        }

        for (int r = 0; r < matrix.GetLength(0); r++)
        {
            for (int c = 0; c < matrix.GetLength(1); c++)
            {
                if (matrix[r,c]=="b")
                {
                    matrix[r, c] = "B";
                }
            }
        }
    }

    private static void Move(string[,] matrix, Player player)
    {
        if (IsIndexValid(matrix, player.Row, player.Col))
        {
            if (matrix[player.Row, player.Col] == "B")
            {
                player.IsAlive = false;
                player.PrevRow = player.Row;
                player.PrevCol = player.Col;
                return;
            }

            if (matrix[player.Row, player.Col] == ".")
            {
                player.PrevRow = player.Row;
                player.PrevCol = player.Col;
                matrix[player.Row, player.Col] = "P";
                return;
            }
        }
        else
        {
            player.IsWon = true;
        }
    }

    private static bool IsIndexValid(string[,] matrix, int row, int col)
    {
        return (row >= 0 && row <= matrix.GetLength(0) - 1 && col >= 0 && col <= matrix.GetLength(1) - 1);
    }

    public class Player
    {
        public int Row { get; set; }

        public int Col { get; set; }

        public int PrevRow { get; set; }

        public int PrevCol { get; set; }

        public bool IsAlive { get; set; }

        public bool IsWon { get; set; }

        public override string ToString()
        {
            if (IsAlive == false)
            {
                return $"dead: {this.PrevRow} {this.PrevCol}".ToString();
            }
            else
            {
                return $"won: {this.PrevRow} {this.PrevCol}".ToString();
            }
        }
    }

    public static string[,] ReadMatrix(int n, int m, Player player)
    {
        string[,] matrix = new string[n, m];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            string rowData = Console.ReadLine();

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = rowData[col].ToString();

                if (matrix[row, col] == "P")
                {
                    player.Row = row;
                    player.Col = col;
                    player.PrevRow = row;
                    player.PrevCol = col;
                    player.IsAlive = true;
                    player.IsWon = false;
                }
            }
        }

        return matrix;
    }

    public static void PrintMatrix(string[,] matrix)
    {
        Console.WriteLine();
        for (int r = 0; r < matrix.GetLength(0); r++)
        {
            for (int c = 0; c < matrix.GetLength(1); c++)
            {
                Console.Write(matrix[r, c]);
            }

            Console.WriteLine();
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
}
