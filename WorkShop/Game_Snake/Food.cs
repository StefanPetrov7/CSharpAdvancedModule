using System;
using Game_Snake.Interface;
using Game_Snake.Interface.LinkedList.Helpers;

namespace Game_Snake
{
    public class Food : IDrawable
    {
        private bool isEaten = false;

        public Food(Possition possition, char symbol = '#')
        {
            this.Symbol = symbol;
            this.Possition = possition;
        }

        public Possition Possition { get; set; }

        public char Symbol { get; set; }

        public void EatFood()
        {
            ConsoleHelper.Clear(Possition);
            isEaten = true;
        }

        public void Draw()
        {
            if (isEaten==false)
            {
                ConsoleHelper.Write(Possition, Symbol.ToString());
            }
        }
    }
}
