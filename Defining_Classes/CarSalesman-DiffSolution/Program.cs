using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                var info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string engineModel = info[0];
                int enginePower = int.Parse(info[1]);
                Engine engine = new Engine(engineModel, enginePower);

                if (info.Length > 2)
                {
                    string efficency;
                    double engineDisplacement;

                    bool doubleString = double.TryParse(info[2], out engineDisplacement);

                    if (doubleString == false)
                    {
                        efficency = info[2];
                        engine.Efficency = efficency;
                    }
                    else
                    {
                        engine.Displacement = engineDisplacement;
                    }

                    if (info.Length > 3)
                    {
                        efficency = info[3];
                        engine.Efficency = efficency;
                    }
                }

                engines.Add(engine);
            }

            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                var info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string carModel = info[0];
                string engineModel = info[1];
                Engine engine = engines.FirstOrDefault(x => x.Model == engineModel);
                Car car = new Car(carModel, engine);

                if (info.Length > 2)
                {
                    string carColor;
                    int carWeight;

                    bool intStr = int.TryParse(info[2], out carWeight);

                    if (intStr == false)
                    {
                        carColor = info[2];
                        car.Color = carColor;
                    }
                    else
                    {
                        car.Weight = carWeight;
                    }


                    if (info.Length > 3)
                    {
                        carColor = info[3];
                        car.Color = carColor;
                    }
                }

                cars.Add(car);
            }

            cars.ForEach(x => Console.WriteLine(x));


        }
    }
}
