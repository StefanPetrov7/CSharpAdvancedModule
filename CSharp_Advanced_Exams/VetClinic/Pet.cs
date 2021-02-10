using System;
namespace VetClinic
{
    public class Pet
    {
        private int age;

        public Pet(string name, int age, string owner)
        {
            Name = name;
            Age = age;
            Owner = owner;
        }

        public string Name { get; set; }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("invalide age");
                }

                this.age = value;
            }
        }

        public string Owner { get; set; }

        public override string ToString()
        {
            return $"Name: {Name} Age: {Age} Owner: {Owner}";
        }
    }
}
