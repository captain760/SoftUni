using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            Ingredients = new List<Ingredient>();
        }
        public List<Ingredient> Ingredients { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public int CurrentAlcoholLevel { get {return Ingredients.Sum(x=>x.Alcohol); }  }
        public void Add(Ingredient ingredient)
        {
            if (!Ingredients.Any(x=>x.Name==ingredient.Name))
            {
                if (ingredient.Alcohol<=MaxAlcoholLevel)
                {
                    if (Ingredients.Count<Capacity)
                    {
                        Ingredients.Add(ingredient);
                    }
                }
            }
        }
        public bool Remove(string name)
        {
            if (Ingredients.Any(x => x.Name == name))
            {
                Ingredients.Remove(Ingredients.Where(x => x.Name == name).First());
                return true;
            }
            return false;
        }
        public Ingredient FindIngredient(string name)
        {
            return Ingredients.Where(x => x.Name == name).FirstOrDefault();
        }
        public Ingredient GetMostAlcoholicIngredient()
        {
            return Ingredients.OrderByDescending(x => x.Alcohol).First();
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");
            foreach (var item in Ingredients)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
