using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string make = Console.ReadLine();
            string model = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            double fuelConsumption = double.Parse(Console.ReadLine());
            double fuelQuantity = double.Parse(Console.ReadLine());

            Engine engine = new Engine(650, 2000);

            Tire[] tires = new Tire[]
            {
                new Tire(2008, 1200),
                new Tire(2008, 1200),
                new Tire(2008, 1200),
                new Tire(2008, 1200),
            };

            Car firstCar = new Car();
            Car secondCar = new Car(make, model, year);
            Car thirdCar = new Car(make, model, year, fuelQuantity, fuelConsumption);

            thirdCar.Engine = engine;
            thirdCar.Tires = tires;

        }
    }
}
