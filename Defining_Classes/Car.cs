using System;
using System.Text;
namespace Car_Salesman
{
    public class Car
    {
        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = 0;
            this.Color = "n/a";
        }

        public Car(string model, Engine engine, int weight, string color) : this(model, engine)
        {
            this.Weight = weight;
            this.Color = color;
        }


        public string Model { get; set; }

        public int Weight { get; set; }

        public Engine Engine { get; set; }

        public string Color { get; set; }

        public override string ToString()
        {
            bool weightFlag = this.Weight > 0 ? true : false;
            bool dispacementFlag = this.Engine.Displacement > 0 ? true : false;
            StringBuilder print = new StringBuilder();
            print.AppendLine($"{Model}:");
            print.AppendLine($" {Engine.Model}:");
            print.AppendLine($"  Power: {Engine.Power}");
            print.AppendLine(dispacementFlag ? $"  Displacement: {Engine.Displacement}" : "  Displacement: n/a");
            print.AppendLine($"  Efficiency: {Engine.Efficiency}");
            print.AppendLine(weightFlag ? $" Weight: {Weight}" : " Weight: n/a");
            print.Append($" Color: {Color}");

            return print.ToString();
        }
    }
}
