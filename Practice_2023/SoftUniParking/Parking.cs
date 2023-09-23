using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        private HashSet<Car> parking;
        private int capacity;

        public Parking(int capacity)
        {
            this.capacity = capacity;
            this.parking = new HashSet<Car>(this.capacity);
        }

        public int Count => this.parking.Count;

        public string AddCar(Car car)
        {
            if (this.parking.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }

            if (this.parking.Count == this.capacity)
            {
                return "Parking is full!";
            }

            this.parking.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string RegistrationNumber)
        {
            Car car = this.parking.FirstOrDefault(x => x.RegistrationNumber == RegistrationNumber);

            if (car == null)
            {
                return $"Car with that registration number, doesn't exist!";
            }

            this.parking.Remove(car);
            return $"Successfully removed {RegistrationNumber}";

        }

        public Car GetCar(string RegistrationNumber) => this.parking.FirstOrDefault(x => x.RegistrationNumber == RegistrationNumber);

        public void RemoveSetOfRegistrationNumber(List<string> regNumbers)
        {
            foreach (var number in regNumbers)
            {
                Car car = this.parking.FirstOrDefault(x => x.RegistrationNumber == number);
                this.parking.Remove(car);
            }
        }
    }
}

