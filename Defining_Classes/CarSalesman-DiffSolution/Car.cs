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
        }

        public Car(string model, Engine engine, double weight, string color) : this(model, engine)
        {
            this.Weight = weight;
            this.Color = color;
        }


        public string Model { get; set; }

        public Engine Engine { get; set; }

        public double Weight { get; set; }

        public string Color { get; set; }

        public override string ToString()
        {
            string weight = this.Weight == 0 ? "n/a" : this.Weight.ToString();
            string color = this.Color == null ? "n/a" : this.Color.ToString();

            StringBuilder info = new StringBuilder();
            info.AppendLine($"{this.Model}:");
            info.AppendLine($"{this.Engine.ToString()}");
            info.AppendLine($"  Weight: {weight}");
            info.AppendLine($"  Color: {color}");
            return info.ToString().TrimEnd();
        }
    }
}
