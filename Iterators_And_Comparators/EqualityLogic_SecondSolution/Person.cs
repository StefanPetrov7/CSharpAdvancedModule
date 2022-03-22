using System;
using System.Diagnostics.CodeAnalysis;

namespace EqualityLogic_SecondSolution
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public override bool Equals(object p) // => used by the Sets when comparing 
        {
            return this.GetHashCode() == p.GetHashCode();
        }

        public override int GetHashCode() // => Used from the Sets when comparing 
        {
            int nameHash = this.Name.GetHashCode();
            int ageHash = this.Age.GetHashCode();
            return nameHash + ageHash;
        }

        public int CompareTo(Person other)
        {
            if (this.Name.CompareTo(other.Name) != 0)
            {
                return this.Name.CompareTo(other.Name);
            }
            else if (this.Age.CompareTo(other.Age) != 0)
            {
                return this.Age.CompareTo(other.Age);
            }
            else
            {
                return 0;
            }
        }
    }
}
