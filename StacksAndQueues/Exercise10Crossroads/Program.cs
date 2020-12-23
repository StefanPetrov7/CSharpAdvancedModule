using System;
using System.Collections.Generic;

namespace _10._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> cars = new Queue<string>();
            int greenLightTime = int.Parse(Console.ReadLine());
            int exitWindow = int.Parse(Console.ReadLine());
            int count = 0;
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                if (input == "green")
                {
                    int curTime = greenLightTime;
                    while (cars.Count > 0)
                    {
                        string car = cars.Peek();
                        int totalTime = exitWindow + curTime;

                        if (car.Length <= totalTime)
                        {
                            curTime -= car.Length;
                            cars.Dequeue();
                            count++;
                            if (curTime <= 0)
                            {
                                break;
                            }
                        }
                        else
                        {
                            string crash = car.Substring(totalTime, car.Length - totalTime);
                            Console.WriteLine($"A crash happened!");
                            Console.WriteLine($"{car} was hit at {crash[0]}.");
                            return;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }
            }
            Console.WriteLine($"Everyone is safe.");
            Console.WriteLine($"{count} total cars passed the crossroads.");

        }
    }
}