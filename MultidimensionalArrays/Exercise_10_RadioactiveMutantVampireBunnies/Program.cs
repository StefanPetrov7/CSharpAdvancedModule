using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise_10_RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            List<int> possition = new List<int> { 0, 0 };
            char[,] layer = new char[sizes[0], sizes[1]];

            for (int r = 0; r < layer.GetLength(0); r++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();

                for (int c = 0; c < layer.GetLength(1); c++)
                {
                    layer[r, c] = rowData[c];

                    if (layer[r, c] == 'P')
                    {
                        possition[0] = r;
                        possition[1] = c;
                    }
                }
            }

            Stack<char> cmd = new Stack<char>(Console.ReadLine().ToCharArray().Reverse());
            string result = string.Empty;
            bool IsGameOver = false;
            int prevRow = 0;
            int prevCol = 0;

            while (cmd.Count > 0 && IsGameOver == false)
            {
                char command = cmd.Pop();
                prevRow = possition[0];
                prevCol = possition[1];

                switch (command)
                {
                    case 'U':
                        possition[0] -= 1;
                        if (IsPlayerOrBunnyOutOfLayer(layer, possition))
                        {
                            result = "won";
                            layer[prevRow, prevCol] = '.';
                            IsGameOver = true;
                        }
                        else if (IsPlayerHitBunny(layer, possition))
                        {
                            result = "dead";
                            IsGameOver = true;
                        }
                        else
                        {
                            PlayerMoves(layer, possition, prevRow, prevCol);
                        }

                        if (IsPlayerWillGetHitByBunny(layer, possition))
                        {
                            result = "dead";
                            IsGameOver = true;
                        }
                        BunniesMoves(layer);
                        break;
                    case 'D':
                        possition[0] += 1;
                        if (IsPlayerOrBunnyOutOfLayer(layer, possition))
                        {
                            result = "won";
                            layer[prevRow, prevCol] = '.';
                            IsGameOver = true;
                        }
                        else if (IsPlayerHitBunny(layer, possition))
                        {
                            result = "dead";
                            IsGameOver = true;
                        }
                        else
                        {
                            PlayerMoves(layer, possition, prevRow, prevCol);
                        }

                        if (IsPlayerWillGetHitByBunny(layer, possition))
                        {
                            result = "dead";
                            IsGameOver = true;
                        }
                        BunniesMoves(layer);
                        break;
                    case 'R':
                        possition[1] += 1;
                        if (IsPlayerOrBunnyOutOfLayer(layer, possition))
                        {
                            result = "won";
                            layer[prevRow, prevCol] = '.';
                            IsGameOver = true;
                        }
                        else if (IsPlayerHitBunny(layer, possition))
                        {
                            result = "dead";
                            IsGameOver = true;
                        }
                        else
                        {
                            PlayerMoves(layer, possition, prevRow, prevCol);
                        }

                        if (IsPlayerWillGetHitByBunny(layer, possition))
                        {
                            result = "dead";
                            IsGameOver = true;
                        }
                        BunniesMoves(layer);
                        break;
                    case 'L':
                        possition[1] -= 1;
                        if (IsPlayerOrBunnyOutOfLayer(layer, possition))
                        {
                            result = "won";
                            layer[prevRow, prevCol] = '.';
                            IsGameOver = true;
                        }
                        else if (IsPlayerHitBunny(layer, possition))
                        {
                            result = "dead";
                            IsGameOver = true;
                        }
                        else
                        {
                            PlayerMoves(layer, possition, prevRow, prevCol);
                        }

                        if (IsPlayerWillGetHitByBunny(layer, possition))
                        {
                            result = "dead";
                            IsGameOver = true;
                        }
                        BunniesMoves(layer);
                        break;
                }
            }

            PrintMatrix(layer);

            if (result == "won")
            {
                Console.WriteLine($"won: {prevRow} {prevCol}");
            }
            else if (result == "dead")
            {
                Console.WriteLine($"dead: {possition[0]} {possition[1]}");
            }
        }

        public static bool IsPlayerWillGetHitByBunny(char[,] layer, List<int> possition)
        {
            bool isPlayerGetHit = false;
            int curPlayerR = possition[0];
            int curPlayerC = possition[1];
            List<int> checkUp = new List<int> { curPlayerR - 1, curPlayerC };
            List<int> checkDown = new List<int> { curPlayerR + 1, curPlayerC };
            List<int> checkRight = new List<int> { curPlayerR, curPlayerC - 1 };
            List<int> checkLeft = new List<int> { curPlayerR, curPlayerC + 1 };
            Queue<List<int>> bunnies = new Queue<List<int>>();
            bunnies.Enqueue(checkUp);
            bunnies.Enqueue(checkDown);
            bunnies.Enqueue(checkRight);
            bunnies.Enqueue(checkLeft);

            while (bunnies.Count > 0)
            {
                List<int> curBunny = bunnies.Dequeue();

                if (IsPlayerOrBunnyOutOfLayer(layer, curBunny) == false)
                {
                    if (layer[curBunny[0], curBunny[1]] == 'B')
                    {
                        isPlayerGetHit = true;
                        break;
                    }
                }
            }
            return isPlayerGetHit;
        }

        public static char[,] BunniesMoves(char[,] layer)
        {
            Queue<List<int>> bunnies = new Queue<List<int>>();

            for (int r = 0; r < layer.GetLength(0); r++)
            {
                for (int c = 0; c < layer.GetLength(1); c++)
                {
                    if (layer[r, c] == 'B')
                    {
                        List<int> curBunny = new List<int> { r, c };
                        bunnies.Enqueue(curBunny);
                    }
                }
            }

            while (bunnies.Count > 0)
            {
                List<int> curBunny = bunnies.Dequeue();
                int bunnyR = curBunny[0];
                int bunnyC = curBunny[1];
                List<int> bunnyUp = new List<int> { bunnyR - 1, bunnyC };
                List<int> bunnyDown = new List<int> { bunnyR + 1, bunnyC };
                List<int> bunnyRight = new List<int> { bunnyR, bunnyC + 1 };
                List<int> bunnyLeft = new List<int> { bunnyR, bunnyC - 1 };

                if (IsPlayerOrBunnyOutOfLayer(layer, bunnyUp) == false)
                {
                    layer[bunnyUp[0], bunnyUp[1]] = 'B';
                }
                if (IsPlayerOrBunnyOutOfLayer(layer, bunnyDown) == false)
                {
                    layer[bunnyDown[0], bunnyDown[1]] = 'B';
                }
                if (IsPlayerOrBunnyOutOfLayer(layer, bunnyRight) == false)
                {
                    layer[bunnyRight[0], bunnyRight[1]] = 'B';
                }
                if (IsPlayerOrBunnyOutOfLayer(layer, bunnyLeft) == false)
                {
                    layer[bunnyLeft[0], bunnyLeft[1]] = 'B';
                }
            }
            return layer;
        }

        public static bool IsPlayerHitBunny(char[,] layer, List<int> possition)
        {
            if (layer[possition[0], possition[1]] == 'B')
            {
                return true;
            }
            else return false;
        }

        public static bool IsPlayerOrBunnyOutOfLayer(char[,] layer, List<int> possition)
        {
            if ((possition[0] >= 0 && possition[0] < layer.GetLength(0))
                && (possition[1] >= 0 && possition[1] < layer.GetLength(1)))
            {
                return false;
            }
            else return true;
        }

        public static char[,] PlayerMoves(char[,] layer, List<int> possition, int prevR, int prevC)
        {
            layer[possition[0], possition[1]] = 'P';
            layer[prevR, prevC] = '.';
            return layer;
        }

        private static void PrintMatrix(char[,] layer)
        {
            for (int r = 0; r < layer.GetLength(0); r++)
            {
                for (int c = 0; c < layer.GetLength(1); c++)
                {
                    Console.Write(layer[r, c]);
                }
                Console.WriteLine();
            }
        }
    }
}