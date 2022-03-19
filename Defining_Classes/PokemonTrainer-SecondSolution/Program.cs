using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainerLog = new Dictionary<string, Trainer>();
            string input;

            while ((input = Console.ReadLine()) != "Tournament")
            {
                var arg = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainerName = arg[0];
                string pokemonName = arg[1];
                string pokemonElement = arg[2];
                int pokemonHealth = int.Parse(arg[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                Trainer trainer = trainerLog.FirstOrDefault(x => x.Key == trainerName).Value;

                if (trainer == null)
                {
                    trainer = new Trainer(trainerName);
                    trainerLog.Add(trainerName, trainer);
                }

                trainer.Pokemons.Add(pokemon);

            }

            while ((input = Console.ReadLine()) != "End")
            {
                string cmd = input;

                switch (cmd)
                {
                    case "Fire":
                        Action(trainerLog, cmd);
                        break;
                    case "Water":
                        Action(trainerLog, cmd);
                        break;
                    case "Electricity":
                        Action(trainerLog, cmd);
                        break;
                }
            }

            foreach (var trainer in trainerLog.OrderByDescending(x => x.Value.NumberOfBadges))
            {
                Console.WriteLine(trainer.Value);
            }

        }

        public static void Action(Dictionary<string, Trainer> log, string cmd)
        {
            foreach (var kvp in log)
            {
                Trainer trainer = kvp.Value;

                if (trainer.Pokemons.Any(x => x.Element == cmd))
                {
                    trainer.NumberOfBadges += 1;
                }
                else
                {
                    trainer.Pokemons.ToList().ForEach(x => x.Health -= 10);
                }

                trainer.RemoveDeadPokemons();
            }
        }
    }
}
