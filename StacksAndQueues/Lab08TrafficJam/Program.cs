using System;
using System.Collections.Generic;

namespace Lab08TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int countToPass = int.Parse(Console.ReadLine());
            int carsPassed = 0;
            Queue<string> cars = new Queue<string>();
            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                switch (input)
                {
                    case "green":
                        for (int i = 0; i < countToPass; i++)
                        {
                            if (cars.Count==0) break;
                            carsPassed++;
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                        }
                        break;
                    default:
                        cars.Enqueue(input);
                        break;
                }
            }
            Console.WriteLine($"{carsPassed} cars passed the crossroads.");
        }
    }
}
