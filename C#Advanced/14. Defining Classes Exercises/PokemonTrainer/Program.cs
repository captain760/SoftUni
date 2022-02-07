using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Trainer> trainers = new List<Trainer>();            
            while (input!="Tournament")
            {
                string[] cmd = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainerName = cmd[0];
                string pokemonName = cmd[1];
                string pokemonElement = cmd[2];
                int pokemonHealth = int.Parse(cmd[3]);
                Pokemon pokemon = new Pokemon(pokemonName,pokemonElement,pokemonHealth);  
                bool coachExists = false;
                foreach (var coach in trainers)
                {                    
                    if (coach.Name == trainerName)
                    {
                        coachExists = true;
                        break;
                    }
                }
                if (!coachExists)
                {
                    List<Pokemon> pokemons = new List<Pokemon>();                    
                    Trainer trainer = new Trainer(trainerName, 0, pokemons);
                    trainers.Add(trainer);
                }
                foreach (var coach in trainers)
                {
                    if (coach.Name == trainerName)
                    {
                        coach.ListOfPokemons.Add(pokemon);
                    }
                }             
                input = Console.ReadLine();                
            }
            string command = Console.ReadLine();
            while (command!="End")
            {
                foreach (var trainer in trainers)
                {
                    bool appropriatePokemonExist = false;
                    foreach (var pokemon in trainer.ListOfPokemons)
                    {
                        if (pokemon.Element == command)
                        {
                            appropriatePokemonExist = true;
                            break;
                        }
                    }
                    if (appropriatePokemonExist)
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        foreach (var pokemon in trainer.ListOfPokemons)
                        {
                            pokemon.Health -= 10;
                        }
                        for (int j = 0; j <trainer.ListOfPokemons.Count; j++)
                        {
                            if (trainer.ListOfPokemons[j].Health<=0)
                            {
                                trainer.ListOfPokemons.RemoveAt(j);
                                j--;
                            }
                        }                        
                    }
                }
                command = Console.ReadLine();
            }
            trainers = trainers.OrderByDescending(x => x.NumberOfBadges).ToList();
            foreach (var item in trainers)
            {
                Console.WriteLine($"{item.Name} {item.NumberOfBadges} {item.ListOfPokemons.Count}");
            }
        }            
    }
}
