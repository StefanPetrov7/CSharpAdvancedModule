using System;
using System.Text;

namespace Speed_Racing

{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumption;
            this.TravelledDistance = 0;
        }

        private string model;

        private double fuelAmount;

        private double fuelConsumptionPerKilometer;

        private double travelledDistance;

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public double FuelAmount
        {
            get { return this.fuelAmount; }
            set { this.fuelAmount = value; }
        }

        public double FuelConsumptionPerKilometer
        {
            get { return this.fuelConsumptionPerKilometer; }
            set { this.fuelConsumptionPerKilometer = value; }
        }

        public double TravelledDistance
        {
            get { return this.travelledDistance; }
            set { this.travelledDistance = value; }
        }


        public void Drive(double distance)
        {
            double fuelNeeded = distance * FuelConsumptionPerKilometer;

            if (FuelAmount >= fuelNeeded)
            {
                FuelAmount -= fuelNeeded;
                TravelledDistance += distance;
            }
            else
            {
                Console.WriteLine($"Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append($"{Model} {FuelAmount:f2} {TravelledDistance}");
            return result.ToString();
        }
    }
}

