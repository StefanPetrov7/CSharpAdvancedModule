using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();

            string input;
            int tireSets = 0;

            while ((input = Console.ReadLine()) != "No more tires")
            {
                double[] tireInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                tires.Add(new Tire[4]);
                tires[tireSets][0] = new Tire((int)tireInfo[0], tireInfo[1]);
                tires[tireSets][1] = new Tire((int)tireInfo[2], tireInfo[3]);
                tires[tireSets][2] = new Tire((int)tireInfo[4], tireInfo[5]);
                tires[tireSets][3] = new Tire((int)tireInfo[6], tireInfo[7]);

                tireSets++;
            }

            while ((input = Console.ReadLine()) != "Engines done")
            {
                double[] enginesInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                engines.Add(new Engine((int)enginesInfo[0], enginesInfo[1]));
            }

            List<Car> cars = new List<Car>();

            while ((input = Console.ReadLine()) != "Show special")
            {
                string[] carInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string carMake = carInfo[0];
                string carModel = carInfo[1];
                int carYear = int.Parse(carInfo[2]);
                double carFuelQuantity = double.Parse(carInfo[3]);
                double carFuelConsumption = double.Parse(carInfo[4]);
                Engine carEngine = engines[int.Parse(carInfo[5])];
                Tire[] carTires = tires[int.Parse(carInfo[6])];

                Car curentCar =
                    new Car(carMake, carModel, carYear, carFuelQuantity, carFuelConsumption, carEngine, carTires);

                cars.Add(curentCar);

            }

            for (int i = 0; i < cars.Count; i++)
            {
                if ((cars[i].Year >= 2017) && (cars[i].Engine.HorsePower > 300)
                    && (cars[i].Tires.Sum(x => x.Pressure) > 9.0 && cars[i].Tires.Sum(x => x.Pressure) < 10.0))
                {
                    cars[i].Drive(20);
                    Console.WriteLine($"Make: {cars[i].Make}");
                    Console.WriteLine($"Model: {cars[i].Model}");
                    Console.WriteLine($"Year: {cars[i].Year}");
                    Console.WriteLine($"HorsePowers: {cars[i].Engine.HorsePower}");
                    Console.WriteLine($"FuelQuantity: {cars[i].FuelQuantity}");
                }
            }



         

        }
    }
}
