using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> foods = new Dictionary<string, List<int>>()
            {
                {"Bread", new List<int>{25,0 } },
                {"Cake", new List<int>{50,0 }  },
                {"Pastry", new List<int>{75,0 }  },
                {"Fruit Pie", new List<int>{100,0 }  }
            };

            Queue<int> liquids = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            Stack<int> ingredients = new Stack<int>(Console.ReadLine()
              .Split(" ", StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToArray());

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int liquid = liquids.Dequeue();
                int ingredient = ingredients.Pop();
                int sum = liquid + ingredient;
                bool isCooked = false;

                foreach (var food in foods)
                {
                    if (sum == food.Value[0])
                    {
                        food.Value[1]++;
                        isCooked = true;
                        break;
                    }
                }

                if (!isCooked)
                {
                    ingredients.Push(ingredient + 3);
                }
            }

            string lineOneResult;

            if (foods["Bread"][1] > 0
                && foods["Cake"][1] > 0
                && foods["Pastry"][1] > 0
                && foods["Fruit Pie"][1] > 0)
            {
                lineOneResult = "Wohoo! You succeeded in cooking all the food!";
            }
            else
            {
                lineOneResult = "Ugh, what a pity! You didn't have enough materials to cook everything.";
            }

            string seconLineResult =
                liquids.Count > 0 ? $"Liquids left: {string.Join(", ", liquids)}" : "Liquids left: none";
            string thirdLineResult =
                ingredients.Count > 0 ? $"Ingredients left: {string.Join(", ", ingredients)}" : "Ingredients left: none";

            Console.WriteLine(lineOneResult);
            Console.WriteLine(seconLineResult);
            Console.WriteLine(thirdLineResult);

            foreach (var food in foods.OrderBy(f => f.Key))
            {
                Console.WriteLine($"{food.Key}: {food.Value[1]}");
            }
        }
    }
}
