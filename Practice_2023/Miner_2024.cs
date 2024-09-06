namespace Practice2024
{
    internal class Miner_2024
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[,] field = new string[size, size];
            Stack<string> commands = new Stack<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Reverse());
            Miner miner = new Miner();

            CreateField(field, miner);
            PlayGame(field, miner, commands);
           // PrintGame(field);  // => not needed in the solution 
        }

        public static void PlayGame(string[,] field, Miner miner, Stack<string> commands)
        {
            while (commands.Count > 0)
            {
                string cmd = commands.Pop();
                Move(cmd, field, miner);
            }

            miner.IsCommandsOver = true;    
            Console.WriteLine(miner.ToString());
        }

        public static void Move(string cmd, string[,] field, Miner miner)
        {
            int curRow = miner.Row;
            int curCol = miner.Col; 

            switch (cmd)
            {
                case "up":
                    curRow--;
                    if (CheckIfMoveIsValid(curRow, curCol, field))
                    {
                        field[miner.Row, miner.Col] = "*";
                        miner.Row--;
                        InspectFiled(field, miner);
                    }
                    else
                    {
                        return;
                    }
                    break;
                case "down":
                    curRow++;
                    if (CheckIfMoveIsValid(curRow, curCol, field))
                    {
                        field[miner.Row, miner.Col] = "*";
                        miner.Row++;
                        InspectFiled(field, miner);
                    }
                    else
                    {
                        return;
                    }
                    break;
                case "left":
                   curCol--;
                    if (CheckIfMoveIsValid(curRow,curCol, field))
                    {
                        field[miner.Row, miner.Col] = "*";
                        miner.Col--;
                        InspectFiled(field, miner);
                    }
                    else
                    {
                        return;
                    }
                    break;
                case "right":
                    curCol++;
                    if (CheckIfMoveIsValid(curRow,curCol, field))
                    {
                        field[miner.Row, miner.Col] = "*";
                        miner.Col++;
                        InspectFiled(field, miner);
                    }
                    else
                    {
                        return;
                    }
                    break;
            }
        }

        public static void InspectFiled(string[,] field, Miner miner)
        {
            if (field[miner.Row, miner.Col] == "c")
            {
                miner.Coals++;
                field[miner.Row, miner.Col] = "s";
            }

            if (field[miner.Row, miner.Col] == "e")
            {
                miner.IsDead = true;
                Console.WriteLine(miner.ToString());
                Environment.Exit(0);
            }

            field[miner.Row, miner.Col] = "s";

            if (miner.Coals == miner.TotalCoals)
            {
                miner.IsCollected = true;
                Console.WriteLine(miner.ToString());
                Environment.Exit(0);
            }
        }

        public static bool CheckIfMoveIsValid(int row, int col, string[,] field)
            => row >= 0 && row < field.GetLength(0) && col >= 0 && col < field.GetLength(1);

        public static void PrintGame(string[,] field)
        {
            for (int r = 0; r < field.GetLength(0); r++)
            {
                for (int c = 0; c < field.GetLength(1); c++)
                {
                    Console.Write(field[r, c] + " ");
                }

                Console.WriteLine();
            }
        }

        public static void CreateField(string[,] field, Miner miner)
        {
            for (int r = 0; r < field.GetLength(0); r++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int c = 0; c < field.GetLength(1); c++)
                {
                    field[r, c] = data[c];

                    if (data[c] == "c")
                    {
                        miner.TotalCoals++;
                    }

                    if (data[c] == "s")
                    {
                        miner.Row = r;
                        miner.Col = c;
                    }
                }
            }
        }
    }
    public class Miner
    {
        public Miner()
        {
            this.IsDead = false;
            this.IsCollected = false;
            this.IsCommandsOver = false;
        }
        public int Row { get; set; }

        public int Col { get; set; }

        public int Coals { get; set; }

        public int TotalCoals { get; set; }

        public int CoalsLeft => this.TotalCoals - Coals;

        public bool IsDead { get; set; }

        public bool IsCollected { get; set; }

        public bool IsCommandsOver { get; set;  }

        public override string ToString()
        {
            if (IsDead == true)
            {
                return $"Game over! ({this.Row}, {this.Col})";
            }
            else if (IsCollected == true)
            {
                return $"You collected all coals! ({this.Row}, {this.Col})";
            }
            else if (IsCommandsOver == true)
            {
                return $"{this.CoalsLeft} coals left. ({this.Row}, {this.Col})";
            }
            else
            {
                return "Something went wrong";
            }
        }
    }
}
