using System;
using System.Text;

namespace SoftUniParking
{
    public class Car
    {
        public Car(string make, string model, int hp, string number)
        {
            this.Make = make;
            this.Model = model;
            this.HorsePower = hp;
            this.RegistrationNumber = number;
        }

        public string Make { get; set; }

        public string Model { get; set; }

        public int HorsePower { get; set; }

        public string RegistrationNumber { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Make: {this.Make}");
            result.AppendLine($"Model: {this.Model}");
            result.AppendLine($"HorsePower: {this.HorsePower}");
            result.AppendLine($"RegistrationNumber: {this.RegistrationNumber}");
            return result.ToString().Trim();
        }
    }
}
