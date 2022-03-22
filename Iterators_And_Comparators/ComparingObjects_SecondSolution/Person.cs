using System;
namespace ComparingObjects_SecondSolution
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Town { get; private set; }

        public int CompareTo(Person p)
        {
            if (this.Name.CompareTo(p.Name) != 0)
            {
                return this.Name.CompareTo(p.Name);
            }
            else if (this.Age.CompareTo(p.Age) != 0)
            {
                return this.Age.CompareTo(p.Age);
            }
            else
            {
                return this.Town.CompareTo(p.Town);
            }
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Age} {this.Town}";
        }
    }
}
