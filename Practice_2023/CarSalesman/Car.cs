using System;
using System.Text;

namespace CarSalesman
{
    public class Car
    {
        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Color = "n/a";
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public double Weight { get; set; }

        public string Color { get; set; }

        public override string ToString()
        {
            string weightText = this.Weight == 0 ? "n/a" : this.Weight.ToString();

            StringBuilder carSpecs = new StringBuilder();
            carSpecs.AppendLine($"{this.Model}:");
            carSpecs.AppendLine($"{this.Engine.ToString()}");
            carSpecs.AppendLine($"  Weight: {weightText}");
            carSpecs.AppendLine($"  Color: {this.Color}");

            return carSpecs.ToString().TrimEnd();
        }
    }
}