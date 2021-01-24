using System;
using System.Collections.Generic;
using Game_Snake.Helpers;
using Game_Snake.Interface;
using Game_Snake.Interface.LinkedList.Helpers;

namespace Game_Snake
{
    public class Snake : IDrawable
    {
        public Snake(Possition headPossition, Action spawnFood)
        {
            this.SpawnFood = spawnFood;
            SnakeBody = new LinkedList();
            SnakeBody.AddHead(new Node(headPossition));
            Foods = new List<Food>();

            for (int i = 1; i <= 10; i++)
            {
                SnakeBody.AddLast(new Node(new Possition(headPossition.X + i, headPossition.Y)));
            }
        }

        public Action SpawnFood { get; set; }

        public LinkedList SnakeBody { get; set; }

        public List<Food> Foods { get; set; }

        public void Draw()
        {
            SnakeBody.ForEach(node =>
            {
                var text = "*";
                Console.SetCursorPosition(node.Value.X, node.Value.Y);
                if (node == SnakeBody.Head)
                {
                    text = "@";
                }
                ConsoleHelper.Write(node.Value, text);
            });
        }

        public bool CheckSelfCanibalism()
        {
            HashSet<Possition> set = new HashSet<Possition>();
            bool isCanibal = false;

            SnakeBody.ForEach(node =>
            {
                if (set.Contains(node.Value)) isCanibal = true;
                set.Add(node.Value);
            });

            return isCanibal;
        }

        public void Move(Possition possition)
        {

            if (possition.X == 0 && possition.Y == 0)
            {
                return;
            }

            ConsoleHelper.Clear(SnakeBody.Tail.Value);

            SnakeBody.ReverseForEach(node =>
            {

                if (node.Previous != null)
                {
                    node.Value.X = node.Previous.Value.X;
                    node.Value.Y = node.Previous.Value.Y;
                }
            });

            SnakeBody.Head.Value.ChangePossition(possition);

            for (int i = 0; i < Foods.Count; i++)
            {
                if (Foods[i].Possition == SnakeBody.Head.Value)
                {
                    Foods[i].EatFood();
                    Grow(possition);
                    SpawnFood();
                }
            }
        }

        public void Grow(Possition possition)
        {
            var oldPOssition = SnakeBody.Head.Value;

            var newHead = new Node(new Possition(oldPOssition.X, oldPOssition.Y));
            //newHead.Value.ChangePossition(possition);
            BoundriesHelper.CheckBoundaries(newHead.Value, possition);
            SnakeBody.AddHead(newHead);
        }
    }
}
