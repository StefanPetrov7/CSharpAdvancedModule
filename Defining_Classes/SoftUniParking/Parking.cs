using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        private int capacity;

        public Dictionary<string, Car> cars;

        public Parking(int capacity)
        {
            this.capacity = capacity;
            this.cars = new Dictionary<string, Car>();
        }

        public int Count => cars.Count;

        public string AddCar(Car car)
        {
            string number = car.RegistrationNumber;

            if (this.cars.ContainsKey(number))
            {
                return $"Car with that registration number, already exists!";
            }
            else
            {
                if (this.cars.Count == this.capacity)
                {
                    return "Parking is full!";
                }
                else
                {
                    this.cars.Add(number, car);
                    return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
                }
            }
        }

        public string RemoveCar(string number)
        {
            if (this.cars.ContainsKey(number))
            {
                cars.Remove(number);
                return $"Successfully removed {number}";
            }
            else
            {
                return $"Car with that registration number, doesn't exist!";
            }
        }

        public Car GetCar(string number)
        {
            var car = this.cars.Single(x => x.Key == number);
            return car.Value;
        }

        public void RemoveSetOfRegistrationNumber(List<string> numbers)
        {
            foreach (var num in numbers)
            {
                if (this.cars.ContainsKey(num))
                {
                    this.cars.Remove(num);
                }
            }
        }
    }
}
