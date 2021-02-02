using System;

namespace Maze
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] maze = new string[]
            {
                "010001",
                "01010E",
                "010100",
                "000000",
            };

            Print(maze);
            Console.WriteLine();

            //  string[] maze = new string[]
            //  {
            //      "000",
            //      "010",
            //      "00E",
            //  };

            FindPaths(maze, 0, 0, new bool[maze.Length, maze[0].Length], "");

        }

        private static void FindPaths(string[] maze, int row, int col, bool[,] visited, string path)
        {
            if (maze[row][col] == 'E')
            {
                Console.WriteLine(path);
                return;
            }

            visited[row, col] = true;

            if (IsSafe(maze, row + 1, col, visited))
            {
                FindPaths(maze, row + 1, col, visited, path + "D");   // D stays for "down".
            }

            if (IsSafe(maze, row - 1, col, visited))
            {
                FindPaths(maze, row - 1, col, visited, path + "U");   // U stays for "up".
            }

            if (IsSafe(maze, row, col + 1, visited))
            {
                FindPaths(maze, row, col + 1, visited, path + "R");   // R stays for "right".
            }

            if (IsSafe(maze, row, col - 1, visited))
            {
                FindPaths(maze, row, col - 1, visited, path + "L");   // L stays for "left".
            }

            visited[row, col] = false;

        }

        private static bool IsSafe(string[] maze, int row, int col, bool[,] visited)
        {
            if (row < 0 || col < 0 || row >= maze.Length || col >= maze[0].Length)
            {
                return false;
            }

            if (maze[row][col] == '1' || visited[row, col])
            {
                return false;
            }

            return true;
        }

        private static void Print(string[] matrix)
        {
            for (int r = 0; r < matrix.Length; r++)
            {
                for (int c = 0; c < matrix[r].Length; c++)
                {
                    Console.Write(matrix[r][c]+" ");
                }

                Console.WriteLine();
            }
        }
    }
}
