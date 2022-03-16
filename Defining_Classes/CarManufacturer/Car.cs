using System;


namespace CarManufacturer
{
    public class Car
    {
        private string make = "VW";

        private string model = "Golf";

        private int year = 2025;

        private double fuelQuantity = 200;

        private double fuelConsumption = 10;

        private Engine engine;

        private Tire[] tires;

        public Car()
        {
            this.Make = this.make;
            this.Model = this.model;
            this.Year = this.year;
            this.FuelQuantity = this.fuelQuantity;
            this.FuelConsumption = this.fuelConsumption;
        }

        public Car(string make, string model, int year)
            : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
            : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires)
           : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }



        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public Engine Engine { get; set; }

        public Tire[] Tires { get; set; }

        public void Drive(double distance)
        {
            double fuelConsumptionPerKM = this.FuelConsumption / 100;
            double fuelLeft = this.FuelQuantity -= fuelConsumptionPerKM * distance;

            if (fuelLeft < 0)
            {
                Console.WriteLine($"Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            return $"Make: {this.Make}" +
                $"\nModel: {this.Model}" +
                $"\nYear: {this.Year}" +
                $"\nHorsePowers: {this.Engine.HorsePower}" +
                $"\nFuelQuantity: {this.FuelQuantity}";
        }
    }
}
