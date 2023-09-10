namespace Practice_2023;

class Knight_Game
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        string[,] matrix = ReadMatrix(n);
        int removeHorse = 0;
        List<Horse> horses = new List<Horse>();
        GetHorses(horses, matrix);

        while (true)
        {

            horses.ForEach(x => GetDamage(x, matrix));
            Horse bestHorse = new Horse();

            for (int h = 0; h < horses.Count; h++)
            {
                if (horses[h].Damage > bestHorse.Damage)
                {
                    bestHorse = horses[h];
                }
            }

            if (bestHorse.Damage > 0)
            {
                removeHorse++;
                horses.Remove(bestHorse);
                matrix[bestHorse.Row, bestHorse.Col] = "0";
                horses.ForEach(x => x.Damage = 0);
            }
            else
            {
                break;
            }

        }

        Console.WriteLine(removeHorse);

    }

    private static void GetHorses(List<Horse> horses, string[,] matrix)
    {
        for (int r = 0; r < matrix.GetLength(0); r++)
        {
            for (int c = 0; c < matrix.GetLength(1); c++)
            {
                if (matrix[r, c] == "K")
                {
                    Horse horse = new Horse();
                    horse.Row = r;
                    horse.Col = c;
                    horses.Add(horse);
                }
            }
        }
    }

    private static void GetDamage(Horse horse, string[,] matrix)
    {
        if (horse.Row - 2 >= 0 && horse.Col + 1 <= matrix.GetLength(1) - 1)
        {
            horse.Damage = matrix[horse.Row - 2, horse.Col + 1] == "K" ? horse.Damage += 1 : horse.Damage = horse.Damage;
        }

        if (horse.Row - 2 >= 0 && horse.Col - 1 >= 0)
        {
            horse.Damage = matrix[horse.Row - 2, horse.Col - 1] == "K" ? horse.Damage += 1 : horse.Damage = horse.Damage;
        }

        if (horse.Row - 1 >= 0 && horse.Col + 2 <= matrix.GetLength(1) - 1)
        {
            horse.Damage = matrix[horse.Row - 1, horse.Col + 2] == "K" ? horse.Damage += 1 : horse.Damage = horse.Damage;
        }

        if (horse.Row + 1 <= matrix.GetLength(0) - 1 && horse.Col + 2 <= matrix.GetLength(1) - 1)
        {
            horse.Damage = matrix[horse.Row + 1, horse.Col + 2] == "K" ? horse.Damage += 1 : horse.Damage = horse.Damage;
        }

        if (horse.Row + 2 <= matrix.GetLength(0) - 1 && horse.Col + 1 <= matrix.GetLength(1) - 1)
        {
            horse.Damage = matrix[horse.Row + 2, horse.Col + 1] == "K" ? horse.Damage += 1 : horse.Damage = horse.Damage;
        }

        if (horse.Row + 2 <= matrix.GetLength(0) - 1 && horse.Col - 1 >= 0)
        {
            horse.Damage = matrix[horse.Row + 2, horse.Col - 1] == "K" ? horse.Damage += 1 : horse.Damage = horse.Damage;
        }

        if (horse.Row + 1 <= matrix.GetLength(0) - 1 && horse.Col - 2 >= 0)
        {
            horse.Damage = matrix[horse.Row + 1, horse.Col - 2] == "K" ? horse.Damage += 1 : horse.Damage = horse.Damage;
        }

        if (horse.Row - 1 >= 0 && horse.Col - 2 >= 0)
        {
            horse.Damage = matrix[horse.Row - 1, horse.Col - 2] == "K" ? horse.Damage += 1 : horse.Damage = horse.Damage;
        }
    }

    public static string[,] ReadMatrix(int size)
    {
        string[,] matrix = new string[size, size];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            string rowData = Console.ReadLine();

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = rowData[col].ToString();
            }
        }

        return matrix;
    }

    public static void PrintMatrix(string[,] matrix)
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

    public class Horse
    {
        public int Row { get; set; }

        public int Col { get; set; }

        public int Damage { get; set; }

    }

    //public static void ReadJaggedMatrix(int[][] matrix)  // => Not needed for this task
    //{
    //    for (int row = 0; row < matrix.GetLength(0); row++)
    //    {
    //        int[] rowData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    //        matrix[row] = new int[rowData.Length];

    //        for (int col = 0; col < matrix[row].Length; col++)
    //        {
    //            matrix[row][col] = rowData[col];
    //        }
    //    }
    //}
}
