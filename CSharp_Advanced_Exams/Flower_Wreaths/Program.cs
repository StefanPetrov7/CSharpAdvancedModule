using System;
using System.Collections.Generic;
using System.Linq;

namespace Flower_Wreaths
{
    class Program
    {
        static void Main(string[] args)
        {

            Stack<int> lilies = new Stack<int>(Console.ReadLine()
               .Split(", ", StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToArray());
            Queue<int> roses = new Queue<int>(Console.ReadLine()
               .Split(", ", StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToArray());

            int wreaths = 0;
            int storedFlowers = 0;

            while (lilies.Count > 0 && roses.Count > 0)
            {
                int currentSum = roses.Peek() + lilies.Peek();

                if (currentSum == 15)
                {
                    roses.Dequeue();
                    lilies.Pop();
                    wreaths++;
                }

                if (currentSum < 15)
                {
                    roses.Dequeue();
                    lilies.Pop();
                    storedFlowers += currentSum;
                }

                if (currentSum > 15)
                {
                    int currentRoses = roses.Peek();
                    int currentLilies = lilies.Peek();


                    while (true)
                    {
                        currentLilies -= 2;
                        currentSum = currentRoses + currentLilies;

                        if (currentSum == 15)
                        {
                            roses.Dequeue();
                            lilies.Pop();
                            wreaths++;
                            break;
                        }

                        if (currentSum < 15)
                        {
                            roses.Dequeue();
                            lilies.Pop();
                            storedFlowers += currentSum;
                            break;
                        }
                    }
                }
            }

            if (storedFlowers >= 15)
            {
                storedFlowers /= 15;
                wreaths += storedFlowers;
            }

            if (wreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreaths} wreaths more!");
            }
        }
    }
}
