using System;
using System.Linq;
using System.Collections.Generic;

namespace Car_Salesman
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<Engine> engines = new HashSet<Engine>(n);

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Engine engine = new Engine(info[0], int.Parse(info[1]));

                if (info.Length == 3)
                {
                    if (int.TryParse(info[2], out int result))
                    {
                        engine.Displacement = result;
                    }
                    else
                    {
                        engine.Efficiency = info[2];
                    }
                }
                else if (info.Length == 4)
                {
                    engine = new Engine(info[0], int.Parse(info[1]), int.Parse(info[2]), info[3]);
                }

                engines.Add(engine);

            }

            n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>(n);

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = info[0];
                string engineModel = info[1];

                Engine engine = engines.Where(x => x.Model == engineModel).FirstOrDefault();
                Car car = new Car(model, engine);

                if (info.Length == 3)
                {
                    if (int.TryParse(info[2], out int weight))
                    {
                        car.Weight = weight;
                    }
                    else
                    {
                        car.Color = info[2];
                    }
                }
                else if (info.Length == 4)
                {
                    car = new Car(model, engine, int.Parse(info[2]), info[3]);
                }

                cars.Add(car);

            }

            cars.ForEach(x => Console.WriteLine(x));
        }
    }
}
