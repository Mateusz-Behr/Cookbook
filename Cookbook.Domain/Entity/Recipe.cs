using Cookbook.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Domain.Entity
{
    
    public class Recipe : BaseEntity
    {
        public static int lastRecipeId = 0;
        public string Name { get; set; }
        public List<string> Ingredients { get; set; }
        public string Instructions { get; set; }
        public int MealTypeNumber { get; set; }
        public int PreparationTime { get; set; }

        public Recipe(string name, int mealTypeNumber, List<string> ingredients, string instructions, int preparationTime)
        {
            Id = ++lastRecipeId;
            Name = name;
            MealTypeNumber = mealTypeNumber;
            Ingredients = ingredients;
            Instructions = instructions;
            PreparationTime = preparationTime;
        }
    }
}
