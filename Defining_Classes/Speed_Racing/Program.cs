using System;
using System.Collections.Generic;
using System.Linq;

namespace Speed_Racing
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = info[0];
                double fuelAmount = double.Parse(info[1]);
                double fuelConsumption = double.Parse(info[2]);
                Car car = new Car(model, fuelAmount, fuelConsumption);
                cars.Add(car);
            }

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] info = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = info[1];
                double distance = double.Parse(info[2]);

                cars.Where(x => x.Model == model).ToList().ForEach(x => x.Drive(distance));
            }

            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }
    }
}
