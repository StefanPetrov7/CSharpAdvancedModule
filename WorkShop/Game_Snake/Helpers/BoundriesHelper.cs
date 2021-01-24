using System;
using Game_Snake.Interface.LinkedList.Helpers;

namespace Game_Snake.Helpers
{
    public class BoundriesHelper
    {
        public static void CheckBoundaries(Possition headPossition, Possition movement)
        {
            var newHeadPossition = headPossition.GetNewPossition(movement);

            if (newHeadPossition.Y == -1)
            {
                ConsoleHelper.Clear(headPossition);
                headPossition.Y = Console.WindowHeight - 1;
            }

            if (newHeadPossition.X== -1)
            {
                ConsoleHelper.Clear(headPossition);
                headPossition.X = Console.WindowWidth - 1;
            }

            if (newHeadPossition.X == Console.WindowWidth)
            {
                ConsoleHelper.Clear(headPossition);
                headPossition.X = 0;
            }

            if (newHeadPossition.Y == Console.WindowHeight)
            {
                ConsoleHelper.Clear(headPossition);
                headPossition.Y = 0;
            }
        }
    }
}

 