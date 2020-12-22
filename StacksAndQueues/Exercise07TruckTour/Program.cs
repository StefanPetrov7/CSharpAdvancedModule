using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise07TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int pumpCount = int.Parse(Console.ReadLine());
            Queue<string> pumps = new Queue<string>();

            for (int i = 0; i < pumpCount; i++)
            {
                string pumpToAdd = i + " " + Console.ReadLine();
                pumps.Enqueue(pumpToAdd);
            }

            int bestPump = -1;
            int availableFuel = 0;
            int leftPumpCount = pumpCount;

            while (leftPumpCount>0)
            {
                string[] info = pumps.Peek()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                   .ToArray();

                int pumpNum = int.Parse(info[0]);
                int pumpedFuel = int.Parse(info[1]);
                int distance = int.Parse(info[2]);
                availableFuel += pumpedFuel;

                if (availableFuel>=distance)
                {
                    if (leftPumpCount==pumpCount)
                    {
                        bestPump = pumpNum;
                    }
                    pumps.Enqueue(pumps.Dequeue());
                    availableFuel -= distance;
                    leftPumpCount--;
                }
                else
                {
                    pumps.Enqueue(pumps.Dequeue());
                    availableFuel = 0;
                    leftPumpCount = pumpCount;
                    bestPump = -1;
                }
            }

            Console.WriteLine(bestPump);

        }
    }
}