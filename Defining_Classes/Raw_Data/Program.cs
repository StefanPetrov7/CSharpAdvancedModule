using System;
using System.Collections.Generic;
using System.Linq;

namespace Raw_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<Car> carManifest = new HashSet<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                int eSpeed = int.Parse(input[1]);
                int ePower = int.Parse(input[2]);
                int cWeight = int.Parse(input[3]);
                string cType = input[4];
                double tOnePreasure = double.Parse(input[5]);
                int tOneAge = int.Parse(input[6]);
                double tTwoPreasure = double.Parse(input[7]);
                int tTwoAge = int.Parse(input[8]);
                double tThreePreasure = double.Parse(input[9]);
                int tThreeAge = int.Parse(input[10]);
                double tFourPreasure = double.Parse(input[11]);
                int tFourAge = int.Parse(input[12]);

                Engine engine = new Engine(eSpeed, ePower);
                Cargo cargo = new Cargo(cWeight, cType);
                Tire[] tires = new Tire[]
                {
                    new Tire(tOnePreasure, tOneAge),
                    new Tire(tTwoPreasure, tTwoAge),
                    new Tire(tThreePreasure, tThreeAge),
                    new Tire(tFourPreasure, tFourAge)
                };

                Car car = new Car(model, engine, cargo, tires);
                carManifest.Add(car);
            }

            string cmd = Console.ReadLine();

            switch (cmd)
            {
                case "fragile":
                    foreach (var car in carManifest.Where(x => x.Cargo.Type == "fragile").Where(x => x.Tires.Any(x => x.Preasure < 1)))
                    {
                        Console.WriteLine(car);
                    }
                    break;
                case "flamable":
                    foreach (var car in carManifest.Where(x => x.Cargo.Type == "flamable").Where(x => x.Engine.Power > 250))
                    {
                        Console.WriteLine(car);
                    }
                    break;
            }
        }
    }
}
