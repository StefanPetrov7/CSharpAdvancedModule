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
            this.Name = name;
            this.Capacity = capacity;
            this.MaxAlcoholLevel = maxAlcoholLevel;
            this.Ingredients = new List<Ingredient>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int MaxAlcoholLevel { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public int CurrentAlcoholLevel => this.Ingredients.Sum(x => x.Alcohol);


        public void Add(Ingredient ingredient)
        {
            if (this.Ingredients.Any(x => x.Name == ingredient.Name))
            {
                return;
            }

            if (this.Capacity == Ingredients.Count)
            {
                return;
            }

            int currentAlcohol = this.Ingredients.Sum(x => x.Alcohol);

            if ((currentAlcohol + ingredient.Alcohol) >= this.MaxAlcoholLevel)
            {
                return;
            }

            this.Ingredients.Add(ingredient);

        }

        public bool Remove(string name)
        {
            Ingredient ingredient = this.Ingredients.FirstOrDefault(x => x.Name == name);

            if (ingredient == null)
            {
                return false;
            }
            else
            {
                this.Ingredients.Remove(ingredient);
                return true;
            }
        }

        public Ingredient FindIngredient(string name)
        {
            Ingredient ingredient = this.Ingredients.FirstOrDefault(x => x.Name == name);

            return ingredient;
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            this.Ingredients = this.Ingredients.OrderByDescending(x => x.Alcohol).ToList();
            Ingredient maxAlcoholIngredient = this.Ingredients[0];
            return maxAlcoholIngredient;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {this.Name} - Current Alcohol Level: {this.CurrentAlcoholLevel}");
            foreach (var ingredient in this.Ingredients)
            {
                sb.AppendLine(ingredient.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
