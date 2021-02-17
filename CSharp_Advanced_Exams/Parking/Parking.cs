using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Parking
{
    public class Parking
    {
        public ICollection<Car> cars;

        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.cars = new HashSet<Car>();
        }

        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count => cars.Count;

        public void Add(Car car)
        {
            if (cars.Count < Capacity)
            {
                cars.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Car carToRemove = cars.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);

            if (carToRemove != null)
            {
                cars.Remove(carToRemove);
                return true;
            }

            return false;
        }

        public Car GetLatestCar()
            => cars.OrderByDescending(c => c.Year).FirstOrDefault();

        public Car GetCar(string manufacturer, string model)
            => cars.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {this.Type}:");
            foreach (var car in cars)
            {
                sb.AppendLine(car.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
