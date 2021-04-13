using System;
using System.Collections.Generic;
using System.Linq;

namespace Warships
{
    class Program
    {
        public class Player
        {
            public int ShipCount { get; set; }
            public int ShipDestroyed { get; set; }

        }

        public class Point
        {
            public int Row { get; set; }
            public int Col { get; set; }
        }

        static void Main(string[] args)
        {
            bool IsDraw = false;
            int playerTurn = -1;
            int size = int.Parse(Console.ReadLine());

            List<int> info = Console.ReadLine()
                 .Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToList();

            char[,] matrix = new char[size, size];

            Player playerOne = new Player();
            Player playerTwo = new Player();
            Point point = new Point();


            CompleteMatrix(matrix, playerOne, playerTwo);

            while (playerOne.ShipCount > 0 && playerTwo.ShipCount > 0)
            {
                if (info.Count == 0)
                {
                    IsDraw = true;
                    break;
                }

                point.Row = info[0];
                point.Col = info[1];

                info.RemoveAt(0);
                info.RemoveAt(0);

                playerTurn++;

                if (playerTurn % 2 == 0)
                {
                    if (IsCoordinatesValid(point.Row, point.Col, matrix))
                    {
                        PlayerAttack(playerOne, playerTwo, matrix, point);
                    }
                }
                else
                {
                    if (IsCoordinatesValid(point.Row, point.Col, matrix))
                    {
                        PlayerAttack(playerOne, playerTwo, matrix, point);
                    }
                }
            }

            if (IsDraw)
            {
                Console.WriteLine($"It's a draw! Player One has {playerOne.ShipCount} ships left. Player Two has {playerTwo.ShipCount} ships left.");
                Environment.Exit(0);
            }

            if (playerTwo.ShipCount == 0)
            {
                Console.WriteLine($"Player One has won the game! {playerOne.ShipDestroyed + playerTwo.ShipDestroyed} ships have been sunk in the battle.");
                Environment.Exit(0);
            }

            if (playerOne.ShipCount == 0)
            {
                Console.WriteLine($"Player Two has won the game! {playerOne.ShipDestroyed + playerTwo.ShipDestroyed} ships have been sunk in the battle.");
                Environment.Exit(0);
            }
        }

        private static void PlayerAttack(Player playerOne, Player playerTwo, char[,] matrix, Point point)
        {
            if (matrix[point.Row, point.Col] == '#')
            {
                matrix[point.Row, point.Col] = 'X';
                MineExplosion(playerOne, playerTwo, matrix, point);
                return;
            }

            Attack(point.Row, point.Col, matrix, playerOne, playerTwo);
        }

        private static void MineExplosion(Player playerOne, Player playerTwo, char[,] matrix, Point point)
        {

            for (int r = point.Row - 1; r <= point.Row + 1; r++)
            {
                for (int c = point.Col - 1; c <= point.Col + 1; c++)
                {
                    if (IsCoordinatesValid(r, c, matrix))
                    {
                        Attack(r, c, matrix, playerOne, playerTwo);
                    }
                }
            }
        }

        private static void Attack(int row, int col, char[,] matrix, Player playerOne, Player playerTwo)
        {
            if (matrix[row, col] == '<')
            {
                playerOne.ShipCount -= 1;
                playerTwo.ShipDestroyed += 1;
            }
            else if (matrix[row, col] == '>')
            {
                playerTwo.ShipCount -= 1;
                playerOne.ShipDestroyed += 1;
            }

            matrix[row, col] = 'X';
        }

        private static bool IsCoordinatesValid(int row, int col, char[,] matrix)
        {
            return   row >= 0
                     && row <= matrix.GetLength(0) - 1
                     && col >= 0
                     && col <= matrix.GetLength(1) - 1;
        }

        private static void CompleteMatrix(char[,] matrix, Player playerOne, Player playerTwo)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                string[] rowInfo = Console.ReadLine().Split();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = char.Parse(rowInfo[c]);

                    if (matrix[r, c] == '<')
                    {
                        playerOne.ShipCount++;
                    }

                    if (matrix[r, c] == '>')
                    {
                        playerTwo.ShipCount++;
                    }
                }
            }
        }
    }
}
