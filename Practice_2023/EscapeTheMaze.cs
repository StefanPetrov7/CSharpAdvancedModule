using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace EscapeTheMaze
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int size = int.Parse(Console.ReadLine());
            char[][] matrix = new char[size][];
            Player player = new Player();
            CreateGame(matrix, player);

            while (true)
            {
                string move = Console.ReadLine();
                MovePlayer(move, player, matrix);

                if (player.IsEscaped == true)
                {
                    break;
                }

                if (player.IsAlive == false)
                {
                    break;
                }
            }

            Console.WriteLine(player.ToString());
            PrintMatrix(matrix);    

        }

        public static void MovePlayer(string? move, Player player, char[][] matrix)
        {
            int tempRow = player.Row;
            int tempCol = player.Col;
            switch (move)
            {
                case "up":
                    tempRow--;
                    if (CheckIfMoveIsValid(tempRow, tempCol, matrix))
                    {
                        matrix[player.Row][player.Col] = '-';
                        player.Row = tempRow;
                        InspectMatrix(player, matrix);
                    }
                    break;
                case "down":
                    tempRow++;
                    if (CheckIfMoveIsValid(tempRow, tempCol, matrix))
                    {
                        matrix[player.Row][player.Col] = '-';
                        player.Row = tempRow;
                        InspectMatrix(player, matrix);
                    }
                    break;
                case "left":
                    tempCol--;
                    if (CheckIfMoveIsValid(tempRow, tempCol, matrix))
                    {
                        matrix[player.Row][player.Col] = '-';
                        player.Col = tempCol;
                        InspectMatrix(player, matrix);
                    }
                    break;
                case "right":
                    tempCol++;
                    if (CheckIfMoveIsValid(tempRow, tempCol, matrix))
                    {
                        matrix[player.Row][player.Col] = '-';
                        player.Col = tempCol;
                        InspectMatrix(player, matrix);
                    }
                    break;
            }
        }

        public static void InspectMatrix(Player player, char[][] matrix)
        {
            if (matrix[player.Row][player.Col] == 'M')
            {
                player.Health -= 40;
                player.CheckHeath();
                matrix[player.Row][player.Col] = 'P';  
                if (player.IsAlive == false)
                {
                    return;
                }
            }
            else if (matrix[player.Row][player.Col] == 'H')
            {
                player.Health += 15;
                player.CheckHeath();
                matrix[player.Row][player.Col] = 'P';
                return;
            }
            else if (matrix[player.Row][player.Col] == '-')
            {
                matrix[player.Row][player.Col] = 'P';
                return;
            }
            else
            {
                matrix[player.Row][player.Col] = 'P';
                player.IsEscaped = true;    
            }
        }

        public static bool CheckIfMoveIsValid(int tempRow, int tempCol, char[][] matrix) => tempRow >= 0 && tempRow < matrix.GetLength(0) && tempCol >= 0 && tempCol < matrix[tempRow].Length;

        public static void PrintMatrix(char[][] matrix)
        {
            foreach (char[] row in matrix)
            {
                Console.WriteLine(String.Join("", row));
            }
        }

        public static void CreateGame(char[][] matrix, Player player)
        {

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                matrix[r] = new char[matrix.GetLength(0)];
                char[] data = Console.ReadLine().ToCharArray();

                for (int c = 0; c < matrix[r].Length; c++)
                {
                    matrix[r][c] = data[c];

                    if (data[c] == 'P')
                    {
                        player.Row = r;
                        player.Col = c;
                    }
                }
            }
        }
    }

    public class Player
    {
        public Player()
        {
            this.Health = 100;
            this.IsEscaped = false; 
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public int Health { get; set; }

        public bool IsAlive => this.Health > 0;

        public bool IsEscaped { get; set; }

        public void CheckHeath()
        {
            if (this.Health > 100)
            {
                this.Health = 100;
            }
            else if (this.Health <= 0)
            {
                this.Health = 0;
            }
        }

        public override string ToString()
        {
            StringBuilder print = new StringBuilder();

            if (this.IsEscaped)
            {
                print.AppendLine("Player escaped the maze. Danger passed!");
                print.AppendLine($"Player's health: {this.Health} units ");
                return print.ToString().TrimEnd();
            }
            else
            {
                print.AppendLine("Player is dead. Maze over!");
                print.AppendLine($"Player's health: {this.Health} units ");
                return print.ToString().TrimEnd();
            }
        }
    }
}
