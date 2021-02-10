using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private HashSet<Pet> pets;

        private int count;

        public Clinic(int capacity)
        {
            Capacity = capacity;
            pets = new HashSet<Pet>(Capacity);
            count = 0;
        }

        public int Capacity { get; set; }

        public int Count
        {
            get { return count; }
        }

        public void Add(Pet pet)
        {
            if (Count < Capacity)
            {
                pets.Add(pet);
                count++;
            }
        }

        public bool Remove(string name)
        {
            if (Count == 0)
            {
                return false;
            }

            if (pets.Any(pet => pet.Name == name))
            {
                Pet pet = pets.FirstOrDefault(pet => pet.Name == name);
                pets.Remove(pet);
                count--;
                return true;
            }

            return false;
        }

        public Pet GetPet(string name, string owner)
        {
            Pet pet = pets.FirstOrDefault(pet => pet.Name == name && pet.Owner == owner);
            return pet;
        }

        public Pet GetOldestPet()
        {
            if (Count == 0)
            {
                return null;
            }

            Pet pet = pets.OrderByDescending(pet => pet.Age).FirstOrDefault();
            return pet;

        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");

            foreach (var pet in pets)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
