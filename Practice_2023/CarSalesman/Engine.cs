using System;
using System.Text;

namespace CarSalesman
{
    public class Engine
    {
        public Engine(string model, double power)
        {
            this.Model = model;
            this.Power = power;
            this.Efficiency = "n/a";
        }

        public string Model { get; set; }

        public double Power { get; set; }

        public double Displacement { get; set; }

        public string Efficiency { get; set; }

        public override string ToString()
        {
            string displacementText = this.Displacement == 0 ? "n/a" : this.Displacement.ToString();

            StringBuilder engineSpecs = new StringBuilder();
            engineSpecs.AppendLine($"  {this.Model}:");
            engineSpecs.AppendLine($"    Power: {this.Power}");
            engineSpecs.AppendLine($"    Displacement: {displacementText}");
            engineSpecs.AppendLine($"    Efficiency: {this.Efficiency}");

            return engineSpecs.ToString().TrimEnd();
        }
    }
}