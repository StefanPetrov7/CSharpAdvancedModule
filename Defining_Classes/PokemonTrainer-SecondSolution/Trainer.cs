using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name)
        {
            this.Name = name;
            this.NumberOfBadges = 0;
            this.Pokemons = new HashSet<Pokemon>();
        }

        public string Name { get; set; }

        public int NumberOfBadges { get; set; }

        public HashSet<Pokemon> Pokemons { get; set; }

        public void RemoveDeadPokemons()
        {
            this.Pokemons = this.Pokemons.Where(x => x.Health > 0).ToHashSet();
        }

        public override string ToString()
        {
            return $"{this.Name} {this.NumberOfBadges} {this.Pokemons.Count}";
        }
    }
}
