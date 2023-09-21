using System;
namespace ComparingObjects
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

        public int CompareTo(Person person)
        {
            if (this.Name.CompareTo(person.Name) == 0)
            {
                return this.Age.CompareTo(person.Age);
            }
            else
            {
                return this.Name.CompareTo(person.Name);
            }
        }

        // below two methods need to be overrided in order the sets to implement different obj comparing 

        public override int GetHashCode()  // override the method so the objects can be compared as per our parameters 
        {
            return this.Name.GetHashCode() + this.Age.GetHashCode();
        }

        public override bool Equals(Object obj) // override the method so the objects can be compared as per our parameters 
        {
            if (obj != null && obj is Person person)
            {
                return this.Name == person.Name && this.Age == person.Age;
            }

            return false;
        }
    }
}

