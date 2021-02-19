using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace BakeryOpenning
{
    public class Bakery
    {
        private readonly int capacity;
        private HashSet<Employee> emplyees;

        public Bakery(string name, int capacity)
        {
            this.Name = name;
            this.capacity = capacity;
            this.emplyees = new HashSet<Employee>();
        }

        public string Name { get; set; }
        public int Capacity => this.capacity;
        public int Count => this.emplyees.Count;

        public void Add(Employee employee)
        {
            if (this.Count < this.capacity)
            {
                emplyees.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            Employee employee = emplyees.FirstOrDefault(e => e.Name == name);

            if (employee != null)
            {
                emplyees.Remove(employee);
                return true;
            }

            return false;
        }

        public Employee GetOldestEmployee() => emplyees.OrderByDescending(e => e.Age).FirstOrDefault();

        public Employee GetEmployee(string name) => emplyees.FirstOrDefault(e => e.Name == name);

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {this.Name}");
            foreach (var employee in this.emplyees)
            {
                sb.AppendLine(employee.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
