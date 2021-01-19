using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;

        public Family()
        {
            this.People = new List<Person>();
        }

        public List<Person> People
        {
            get { return this.people; }
            set { this.people = value; }
        }

        public void AddMember(Person person)
        {
            this.people.Add(person);
        }

        public Person GetOldestMember()
        {
            Person oldest = this.People.OrderByDescending(x => x.Age).FirstOrDefault();
            return oldest;
        }
    }
}
