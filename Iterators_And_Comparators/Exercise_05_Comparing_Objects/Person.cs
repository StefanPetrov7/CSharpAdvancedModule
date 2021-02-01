using System;

namespace Exercise_05_Comparing_Objects
{
    public class Person : IComparable<Person>
    {
        public string name;

        public int age;

        public string town;

        public Person(string name, int age, string town)
        {
            this.name = name;
            this.age = age;
            this.town = town;
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

                    if (result == 0)
                    {
                        result = town.CompareTo(other.town);
                    }
                }
            }

            return result;
        }
    }
}
