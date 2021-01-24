using System;
using System.Collections.Generic;
using System.Threading;
using Game_Snake.Helpers;
using Game_Snake.Interface;
using Game_Snake.Interface.LinkedList.Helpers;

namespace Game_Snake
{
    public class GameEngine
    {
        private bool isStarded = false;
        private List<IDrawable> gameItems = new List<IDrawable>();
        private Random rand = new Random();

        public Snake Snake { get; set; }


        public GameEngine()
        {
            Snake = new Snake(new Possition(30, 20),SpawnFood);
            gameItems.Add(Snake);

            for (int i = 0; i < 20; i++)
            {
                SpawnFood();
            }
        }

        public void Start()
        {
            isStarded = true;
            Possition movement = new Possition(0, 0);

            while (isStarded == true)
            {
                BoundriesHelper.CheckBoundaries(Snake.SnakeBody.Head.Value, movement);
                Snake.Move(movement);
                if (Snake.CheckSelfCanibalism())
                {
                    Console.Clear();
                    ConsoleHelper.Write(new Possition(0, 0), "Game Over");
                    isStarded = false;
                    break;
                }
               
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(false).Key;
                    movement = ReadUserInput.GetMovement(key);
                }
                Thread.Sleep(200);
                gameItems.ForEach(i => i.Draw());
                
            }
        }

        public void Stop()
        {
            isStarded = false;
        }

        private void SpawnFood()
        {
            var food = new Food(new Possition(
                  rand.Next(0, Console.WindowHeight-1),
                  rand.Next(0, Console.WindowHeight-1)));

            gameItems.Add(food);
            Snake.Foods.Add(food);
        }
    }
}
