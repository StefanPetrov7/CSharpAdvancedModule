using System;
using System.Collections.Generic;
using System.Linq;

namespace Pokemon_Trainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            HashSet<Trainer> trainers = new HashSet<Trainer>();
            string input;

            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] info = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Pokemon pokemon = new Pokemon(info[1], info[2], int.Parse(info[3]));
                Trainer trainer = new Trainer(info[0]);

                if (trainers.Any(x => x.Name == info[0]))
                {
                    trainers.Where(x => x.Name == info[0]).FirstOrDefault().Pokemons.Add(pokemon);
                }
                else
                {
                    trainer.Pokemons.Add(pokemon);
                    trainers.Add(trainer);
                }

            }

            while ((input = Console.ReadLine()) != "End")
            {
                switch (input)
                {
                    case "Fire":
                        trainers.Select(x => x.CheckPokemons("Fire")).ToHashSet();
                        break;
                    case "Water":
                        trainers.Select(x => x.CheckPokemons("Water")).ToHashSet();
                        break;
                    case "Electricity":
                        trainers.Select(x => x.CheckPokemons("Electricity")).ToHashSet();
                        break;

                }
            }

            trainers.OrderByDescending(x => x.Badges).ToList().ForEach(x => Console.WriteLine(x));

        }
    }
}
