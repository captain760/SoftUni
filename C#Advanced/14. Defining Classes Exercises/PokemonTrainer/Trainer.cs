using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {
        private string name;
        private int numberOfBadges = 0;
        private List<Pokemon> pokemons;
        public Trainer(string name, int numberOfBadges,List<Pokemon> pokemons)
        {
            Name = name;
            NumberOfBadges = numberOfBadges;
            ListOfPokemons = pokemons;
        }
        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> ListOfPokemons { get; set; }
    }
}
