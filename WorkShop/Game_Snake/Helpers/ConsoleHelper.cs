using System;
namespace Game_Snake.Interface.LinkedList.Helpers
{
    public class ConsoleHelper
    {
        public static void Clear(Possition possition)
        {
            Console.SetCursorPosition(possition.X, possition.Y);
            Console.Write(" ");
        }

        public static void Write(Possition possition, string text)
        {
            Console.SetCursorPosition(possition.X, possition.Y);
            Console.Write(text);
        }

    }
}
