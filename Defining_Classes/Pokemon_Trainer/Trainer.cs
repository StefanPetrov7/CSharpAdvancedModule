using System;
using System.Collections.Generic;

namespace Pokemon_Trainer
{
    public class Trainer
    {
        public Trainer(string name)
        {
            this.Name = name;
            this.Badges = 0;
            this.Pokemons = new List<Pokemon>();
        }

        public string Name { get; set; }

        public int Badges { get; set; }

        public List<Pokemon> Pokemons { get; set; }

        public List<Pokemon> CheckPokemons(string input)
        {

            if (Pokemons.Exists(x => x.Element == input))
            {
                this.Badges += 1;
            }
            else
            {
                for (int i = 0; i < Pokemons.Count; i++)
                {
                    Pokemons[i].Health -= 10;

                    if (Pokemons[i].Health < 1)
                    {
                        Pokemons.Remove(Pokemons[i]);
                    }
                }
            }

            return Pokemons;
        }

        public override string ToString()
        {
            return $"{Name} {Badges} {Pokemons.Count}";
        }
    }
}

