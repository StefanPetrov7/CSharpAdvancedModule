using System;
using System.Text;

namespace SoftUniParking
{
    public class Car
    {
        public Car(string make, string model, int hp, string regNumber)
        {
            this.Make = make;
            this.Model = model;
            this.HorsePower = hp;
            this.RegistrationNumber = regNumber;
        }

        public string Make { get; set; }

        public string Model { get; set; }

        public int HorsePower { get; set; }

        public string RegistrationNumber { get; set; }

        public override string ToString()
        {
            StringBuilder carInfoPrint = new StringBuilder();
            carInfoPrint.AppendLine($"Make: {this.Make}");
            carInfoPrint.AppendLine($"Model: {this.Model}");
            carInfoPrint.AppendLine($"HorsePower: {this.HorsePower}");
            carInfoPrint.AppendLine($"RegistrationNumber: {this.RegistrationNumber}");
            return carInfoPrint.ToString().Trim();
        }
    }
}
