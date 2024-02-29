﻿using Cookbook.Domain.Entity;
using Cookbook.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Cookbook.App.Managers
{
    public class FileManager
    {
        public static void SaveRecipeToTxtFile(string path, string name, Recipe recipe)
        {
            Helpers.MealType mealType = (Helpers.MealType)recipe.MealTypeNumber;
            string fileName = $"{name.Replace(" ", "_")}.txt";
            string filePath = Path.Combine(path, fileName);

            using StreamWriter writer = new (filePath);

            writer.WriteLine($"Recipe: {recipe.Name}");
            writer.WriteLine($"Type: {mealType}");
            writer.WriteLine("Ingredients:");
            foreach (var ingredient in recipe.Ingredients)
            {
                writer.WriteLine(ingredient);
            }
            writer.WriteLine($"Instructions: \n{recipe.Instructions}");
            writer.WriteLine($"Prepration time: {recipe.PreparationTime} minutes");

            Console.WriteLine($"\nRecipe saved to {filePath} successfully.");
        }

        public static Dictionary<string, Dictionary<string, List<double>>> LoadUnitsFromJson(string path)
        {
            string jsonFile = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, List<double>>>>(jsonFile);
        }
    }
}
