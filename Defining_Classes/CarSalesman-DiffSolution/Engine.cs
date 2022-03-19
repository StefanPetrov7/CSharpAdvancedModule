using System;
using System.Text;

namespace CarSalesman
{
    public class Engine
    {
        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
        }

        public Engine(string model, int power, double displacement, string efficency) : this(model,  power)
        {
            this.Displacement = displacement;
            this.Efficency = efficency;
        }

        public string Model { get; set; }

        public int Power { get; set; }

        public double Displacement { get; set; }

        public string Efficency { get; set; }

        public override string ToString()
        {
            string displacementResult = this.Displacement == 0 ? "n/a" : this.Displacement.ToString();
            string efficencyResult = this.Efficency == null ? "n/a" : this.Efficency;

            StringBuilder info = new StringBuilder();
            info.AppendLine($"  {this.Model}:");
            info.AppendLine($"    Power: {this.Power}");
            info.AppendLine($"    Displacement: {displacementResult}");
            info.AppendLine($"    Efficiency: {efficencyResult}");
            return info.ToString().TrimEnd();
        }
    }
}
