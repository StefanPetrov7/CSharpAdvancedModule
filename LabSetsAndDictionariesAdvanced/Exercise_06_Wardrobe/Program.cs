using System;
using System.Collections.Generic;

namespace Exercise_06_Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(new string[] { " -> ", ","}, StringSplitOptions.RemoveEmptyEntries);
                string color = input[0];

                if (wardrobe.ContainsKey(color) == false)
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                for (int k = 1; k < input.Length; k++)
                {
                    if (wardrobe[color].ContainsKey(input[k]) == false)
                    {
                        wardrobe[color][input[k]] = 0;
                    }
                    wardrobe[color][input[k]] += 1;
                }
            }

            string[] findItems = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (KeyValuePair<string, Dictionary<string, int>> color in wardrobe)
            {
                string curColor = color.Key;
                Console.WriteLine($"{curColor} clothes:");

                foreach (KeyValuePair<string, int> items in color.Value)
                {
                    string searchColor = findItems[0];
                    string searchItem = findItems[1];
                    string curItem = items.Key;

                    if (curColor == searchColor && curItem == searchItem)
                    {
                        Console.WriteLine($"* {items.Key} - {items.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {items.Key} - {items.Value}");
                    }
                }
            }
        }
    }
}
