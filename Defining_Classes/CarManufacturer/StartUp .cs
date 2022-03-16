using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input;
            List<List<Tire>> tires = new List<List<Tire>>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();


            while ((input = Console.ReadLine()) != "No more tires")
            {
                string[] arg = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                List<Tire> tireSet = new List<Tire>();

                for (int i = 0; i < arg.Length; i += 2)
                {
                    Tire tire = new Tire(int.Parse(arg[i]), double.Parse(arg[i + 1]));
                    tireSet.Add(tire);
                }

                tires.Add(tireSet);
            }

            while ((input = Console.ReadLine()) != "Engines done")
            {
                string[] arg = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                Engine engine = new Engine(int.Parse(arg[0]), double.Parse(arg[1]));
                engines.Add(engine);
            }

            while ((input = Console.ReadLine()) != "Show special")
            {
                string[] arg = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                int engineIndex = int.Parse(arg[5]);
                int tireIndex = int.Parse(arg[6]);
                Engine getEngine = engines.ElementAt(engineIndex);
                List<Tire> getTires = tires.ElementAt(tireIndex);
                Car car = new Car(arg[0], arg[1], int.Parse(arg[2]), double.Parse(arg[3]), double.Parse(arg[4]), getEngine, getTires.ToArray());
                cars.Add(car);
            }

            for (int i = 0; i < cars.Count; i++)
            {
                Car currentCar = cars[i];

                double currentTirePressure = currentCar.Tires.Sum(x => x.Pressure);

                if (currentCar.Year >= 2017 && currentCar.Engine.HorsePower > 330 && currentTirePressure > 9 && currentTirePressure < 10)
                {
                    currentCar.Drive(20);
                    Console.WriteLine(currentCar.WhoAmI());
                }
            }
        }
    }
}
