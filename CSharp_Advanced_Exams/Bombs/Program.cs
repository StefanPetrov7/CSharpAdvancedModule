using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            const int DATURA_BOMBS = 40;
            const int CHERRY_BOMBS = 60;
            const int SMOKE_DECOY_BOMBS = 120;
            bool isBombsComplete = false;

            Dictionary<string, int> bombs = new Dictionary<string, int>()
            {
                {"Cherry Bombs", 0 },
                {"Datura Bombs", 0 },
                {"Smoke Decoy Bombs", 0 }
            };

            Queue<int> effects = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Stack<int> casings = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            while (effects.Count > 0 && casings.Count > 0)
            {
                if (bombs["Cherry Bombs"] >= 3 && bombs["Datura Bombs"] >= 3 && bombs["Smoke Decoy Bombs"] >= 3)
                {
                    isBombsComplete = true;
                    break;
                }

                int effect = effects.Peek();
                int casing = casings.Pop();
                int tryMix = effect + casing;

                if (tryMix == DATURA_BOMBS)
                {
                    bombs["Datura Bombs"]++;
                    effects.Dequeue();
                }
                else if (tryMix == CHERRY_BOMBS)
                {
                    bombs["Cherry Bombs"]++;
                    effects.Dequeue();
                }
                else if (tryMix == SMOKE_DECOY_BOMBS)
                {
                    bombs["Smoke Decoy Bombs"]++;
                    effects.Dequeue();
                }
                else
                {
                    casing -= 5;
                    casings.Push(casing);
                }
            }

            string lineOne = isBombsComplete ?
                "Bene! You have successfully filled the bomb pouch!" : "You don't have enough materials to fill the bomb pouch.";
            string lineTwo = effects.Count > 0 ? $"Bomb Effects: {string.Join(", ", effects)}" : "Bomb Effects: empty";
            string lineThree = casings.Count > 0 ? $"Bomb Casings: {string.Join(", ", casings)}" : "Bomb Casings: empty";
            Console.WriteLine(lineOne);
            Console.WriteLine(lineTwo);
            Console.WriteLine(lineThree);

            foreach (var bomb in bombs.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }
        }
    }
}
