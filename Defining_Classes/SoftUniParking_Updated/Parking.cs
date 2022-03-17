using System;
using System.Linq;
using System.Collections.Generic;

namespace SoftUniParking
{
    public class Parking
    {
        private HashSet<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            this.capacity = capacity;
            this.cars = new HashSet<Car>();
        }

        public int Count => this.cars.Count;

        public string AddCar(Car car)
        {
            if (this.cars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }

            if (this.Count == this.capacity)
            {
                return "Parking is full!";
            }

            this.cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";

        }

        public string RemoveCar(string registrationNumber)
        {
            Car car = this.cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);

            if (car == null)
            {
                return "Car with that registration number, doesn't exist!";
            }

            this.cars.Remove(car);
            return $"Successfully removed {registrationNumber}";
        }

        public Car GetCar(string registrationNumber)
        {
            return this.cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {

            this.cars = this.cars.Where(x => !registrationNumbers.Contains(x.RegistrationNumber)).ToHashSet();

            //foreach (var numberToRemove in registrationNumbers) // => Judge gives 8 pts less, total 92 from 100
            //{
            //    foreach (var car in this.cars)
            //    {
            //        if (car.RegistrationNumber == numberToRemove)
            //        {
            //            this.cars.Remove(car);
            //        }
            //    }
            //}
        }
    }
}
