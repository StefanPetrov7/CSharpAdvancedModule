namespace Practice_2025
{
    public class RadioactiveMutantVampireBunnies
    {
        static void Main(string[] args)
        {
            var player = new Player();

            int[] matrixSize = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = matrixSize[0];
            int cols = matrixSize[1];

            string[,] matrix = ReadMatrix(rows, cols, player);

            char[] commands = Console.ReadLine().ToCharArray();

            for (int i = 0; i < commands.Length; i++)
            {
                string move = commands[i].ToString();

                matrix[player.Row, player.Col] = ".";

                switch (move)
                {
                    case "L":
                        player.Col--;
                        MovePlayer(matrix, player);
                        break;
                    case "R":
                        player.Col++;
                        MovePlayer(matrix, player);
                        break;
                    case "U":
                        player.Row--;
                        MovePlayer(matrix, player);
                        break;
                    case "D":
                        player.Row++;
                        MovePlayer(matrix, player);
                        break;
                }

                BunnyMultiplier(matrix, player);

                if (player.IsWon == true)
                {
                    break;
                }

                if (player.IsAlive == false)
                {
                    break;
                }

            }

            WriteMatrix(matrix);
            Console.WriteLine(player.ToString());

        }

        public static void MovePlayer(string[,] matrix, Player player)
        {

            if (IsIndexValid(matrix, player.Row, player.Col))
            {

                if (IsPlayerMoveOnBunny(matrix, player))
                {
                    return;
                }

                player.LastRow = player.Row;
                player.LastCol = player.Col;
                matrix[player.Row, player.Col] = "P";
            }
            else
            {
                player.IsWon = true;
            }
        }

        public static bool IsPlayerMoveOnBunny(string[,] matrix, Player player)
        {
            if (matrix[player.Row, player.Col] == "B")
            {
                player.IsAlive = false;
                player.LastRow = player.Row;
                player.LastCol = player.Col;
                return true;
            }

            return false;
        }

        public static void BunnyMultiplier(string[,] matrix, Player player)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r, c] == "B")
                    {
                        if (IsIndexValid(matrix, r - 1, c) && matrix[r - 1, c] != "B")
                        {
                            KillPlayer(matrix, r - 1, c, player);
                            matrix[r - 1, c] = "b";
                        }

                        if (IsIndexValid(matrix, r + 1, c) && matrix[r + 1, c] != "B")
                        {
                            KillPlayer(matrix, r + 1, c, player);
                            matrix[r + 1, c] = "b";
                        }

                        if (IsIndexValid(matrix, r, c - 1) && matrix[r, c - 1] != "B")
                        {
                            KillPlayer(matrix, r, c - 1, player);
                            matrix[r, c - 1] = "b";
                        }

                        if (IsIndexValid(matrix, r, c + 1) && matrix[r, c + 1] != "B")
                        {
                            KillPlayer(matrix, r, c + 1, player);
                            matrix[r, c + 1] = "b";
                        }
                    }
                }
            }

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = matrix[r, c].ToUpper();
                }
            }
        }

        public static bool IsIndexValid(string[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        public static void KillPlayer(string[,] matrix, int row, int col, Player player)
        {
            if (matrix[row, col] == "P")
            {
                player.IsAlive = false;
            }
        }

        public static string[,] ReadMatrix(int row, int col, Player player)
        {
            string[,] matrix = new string[row, col];

            for (int r = 0; r < row; r++)
            {
                char[] rowInput = Console.ReadLine().ToCharArray();

                for (int c = 0; c < col; c++)
                {
                    matrix[r, c] = rowInput[c].ToString();

                    if (rowInput[c] == 'P')
                    {
                        player.Row = r;
                        player.Col = c;
                        player.LastRow = r;
                        player.LastCol = c;
                    }
                }
            }

            return matrix;
        }

        public static void WriteMatrix(string[,] matrix)
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

    public class Player
    {
        public Player()
        { }

        public int Row { get; set; }

        public int Col { get; set; }

        public bool IsAlive { get; set; } = true;

        public bool IsWon { get; set; } = false;

        public int LastRow { get; set; }

        public int LastCol { get; set; }

        public override string ToString()
        {
            if (this.IsWon)
            {
                return $"won: {this.LastRow} {this.LastCol}";
            }
            else
            {
                return $"dead: {this.LastRow} {this.LastCol}";
            }
        }
    }
}
