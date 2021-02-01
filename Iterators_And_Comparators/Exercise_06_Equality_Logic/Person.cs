using System;

namespace Exercise_06_Equality_Logic
{
    public class Person : IComparable<Person>
    {
        public string name;

        public int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public int CompareTo(Person other)
        {
            int result = 1;

            if (other != null)
            {
                result = name.CompareTo(other.name);

                if (result == 0)
                {
                    result = age.CompareTo(other.age);
                }
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is Person other)
            {
                return this.name == other.name && this.age == other.age;
            }

            return false;
        }

        public override int GetHashCode()
        {
            //return this.name.GetHashCode() + this.age.GetHashCode(); // -> same result sa below code.
            return HashCode.Combine(this.name, this.age);

        }
    }
}
