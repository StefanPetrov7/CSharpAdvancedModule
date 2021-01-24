using System;
namespace Game_Snake
{
    public static class ReadUserInput
    {
        public static Possition GetMovement(ConsoleKey key)
        {
            Possition possition = new Possition(0, 0);

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    possition = new Possition(0, -1);
                    break;
                case ConsoleKey.DownArrow:
                    possition = new Possition(0, 1);
                    break;
                case ConsoleKey.LeftArrow:
                    possition = new Possition(-1, 0);
                    break;
                case ConsoleKey.RightArrow:
                    possition = new Possition(1, 0);
                    break;
            }

            return possition;

        }
    }
}
