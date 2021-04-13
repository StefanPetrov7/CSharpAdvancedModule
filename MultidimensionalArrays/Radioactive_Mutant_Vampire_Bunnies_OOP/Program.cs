using System;
using System.Collections.Generic;
using System.Linq;

namespace Matrix_Practice
{
    class Program
    {
        public class Bunny
        {
            public Bunny(int row, int col)
            {
                this.Row = row;
                this.Col = col;
            }

            public int Row { get; set; }
            public int Col { get; set; }
        }

        public class Player
        {

            public int Row { get; set; }
            public int Col { get; set; }

            public bool Win { get; set; } = false;
            public bool IsAlive { get; set; } = true;

        }

        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[,] matrix = new char[size[0], size[1]];
            List<Bunny> bunnies = new List<Bunny>();
            Player player = new Player();
            Stack<int> positions = new Stack<int>();

            FillMatrix(matrix, bunnies, player);

            char[] cmd = Console.ReadLine().ToCharArray();

            for (int i = 0; i < cmd.Length; i++)
            {
                matrix[player.Row, player.Col] = '.';
                positions.Push(player.Col);  // => if win prev position
                positions.Push(player.Row);

                char direction = cmd[i];

                switch (direction)
                {
                    case 'U':
                        player.Row--;
                        PlayerMove(player, matrix);
                        break;
                    case 'D':
                        player.Row++;
                        PlayerMove(player, matrix);
                        break;
                    case 'R':
                        player.Col++;
                        PlayerMove(player, matrix);
                        break;
                    case 'L':
                        player.Col--;
                        PlayerMove(player, matrix);
                        break;
                }

                if (player.IsAlive == true && player.Win == false)  // => if player is alive and still in the game
                {
                    matrix[player.Row, player.Col] = 'P';
                }

                bunnies = BunnyMultiplication(matrix, bunnies, player);

                if (player.IsAlive == false || player.Win)
                {
                    break;
                }

            }

            int row = player.Win ? positions.Pop() : player.Row;
            int col = player.Win ? positions.Pop() : player.Col;

            string isAlive = player.IsAlive ? "won" : "dead";
            PrintMatrix(matrix);
            Console.WriteLine($"{isAlive}: {row} {col}");
        }


        private static List<Bunny> BunnyMultiplication(char[,] matrix, List<Bunny> bunnies, Player player)
        {
            List<Bunny> moreBunnies = new List<Bunny>();

            for (int b = 0; b < bunnies.Count; b++)
            {
                Bunny bunny = bunnies[b];

                List<Bunny> babyBunnies = BunnySpreading(matrix, bunny, player);

                for (int i = 0; i < babyBunnies.Count; i++)
                {
                    moreBunnies.Add(babyBunnies[i]);
                }
            }

            for (int i = 0; i < moreBunnies.Count; i++)
            {
                bunnies.Add(moreBunnies[i]);
            }

            return bunnies;
        }

        private static List<Bunny> BunnySpreading(char[,] matrix, Bunny bunny, Player player)
        {
            List<Bunny> moreBunnies = new List<Bunny>();

            if (IsInTheMatrix(bunny.Row + 1, bunny.Col, matrix))
            {
                IsBuunyKillPlayer(bunny.Row + 1, bunny.Col, player, matrix);

                if (matrix[bunny.Row + 1, bunny.Col] != 'B')
                {
                    matrix[bunny.Row + 1, bunny.Col] = 'B';
                    Bunny bornBunny = new Bunny(bunny.Row + 1, bunny.Col);
                    moreBunnies.Add(bornBunny);
                }
            }

            if (IsInTheMatrix(bunny.Row - 1, bunny.Col, matrix))
            {
                IsBuunyKillPlayer(bunny.Row - 1, bunny.Col, player, matrix);

                if (matrix[bunny.Row - 1, bunny.Col] != 'B')
                {
                    matrix[bunny.Row - 1, bunny.Col] = 'B';
                    Bunny bornBunny = new Bunny(bunny.Row - 1, bunny.Col);
                    moreBunnies.Add(bornBunny);
                }
            }

            if (IsInTheMatrix(bunny.Row, bunny.Col + 1, matrix))
            {
                IsBuunyKillPlayer(bunny.Row, bunny.Col + 1, player, matrix);

                if (matrix[bunny.Row, bunny.Col + 1] != 'B')
                {
                    matrix[bunny.Row, bunny.Col + 1] = 'B';
                    Bunny bornBunny = new Bunny(bunny.Row, bunny.Col + 1);
                    moreBunnies.Add(bornBunny);
                }
            }

            if (IsInTheMatrix(bunny.Row, bunny.Col - 1, matrix))
            {
                IsBuunyKillPlayer(bunny.Row, bunny.Col - 1, player, matrix);

                if (matrix[bunny.Row, bunny.Col - 1] != 'B')
                {
                    matrix[bunny.Row, bunny.Col - 1] = 'B';
                    Bunny bornBunny = new Bunny(bunny.Row, bunny.Col - 1);
                    moreBunnies.Add(bornBunny);
                }
            }

            return moreBunnies;
        }

        private static void IsBuunyKillPlayer(int row, int col, Player player, char[,] matrix)
        {
            if (matrix[row, col] == 'P')
            {
                player.IsAlive = false;
            }
        }

        private static bool IsInTheMatrix(int row, int col, char[,] matrix)
        {
            if (row < 0)
            {
                return false;
            }
            else if (row > matrix.GetLength(0) - 1)
            {
                return false;
            }
            else if (col < 0)
            {
                return false;
            }
            else if (col > matrix.GetLength(1) - 1)
            {
                return false;
            }

            return true;
        }

        private static void PlayerMove(Player player, char[,] matrix)
        {

            if (!IsInTheMatrix(player.Row, player.Col, matrix))
            {
                player.Win = true;
                return;
            }

            IsPlayerAlive(player, matrix);
        }

        private static void IsPlayerAlive(Player player, char[,] matrix)
        {
            if (matrix[player.Row, player.Col] == 'B')
            {
                player.IsAlive = false;
            }
        }

        private static void FillMatrix(char[,] matrix, List<Bunny> bunnies, Player player)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                char[] rowInfo = Console.ReadLine().ToArray();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = rowInfo[c];

                    if (matrix[r, c] == 'B')
                    {
                        Bunny bunny = new Bunny(r, c);
                        bunnies.Add(bunny);
                    }

                    if (matrix[r, c] == 'P')
                    {
                        player.Row = r;
                        player.Col = c;
                    }
                }
            }
        }

        private static void PrintMatrix(char[,] matrix)
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
}
