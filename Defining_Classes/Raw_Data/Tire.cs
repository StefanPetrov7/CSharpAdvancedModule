using System;
namespace Raw_Data
{
    public class Tire
    {
        public Tire(double preasure, int age)
        {
            this.Preasure = preasure;
            this.Age = age;
        }

        public double Preasure { get; set; }

        public int Age { get; set; }
    }
}
