using Cookbook.App.Abstract;
using Cookbook.App.Common;
using Cookbook.App.Managers;
using Cookbook.Domain;
using Cookbook.Domain.Entity;
using Cookbook.Domain.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.App.Concrete
{
    public class RecipeService : BaseService<Recipe>
    {
        public const string COOKBOOK = "C:\\Users\\behrm\\source\\RecipesList\\Cookbook\\Cookbook.json";
        public RecipeService()
        {
            LoadRecipesFromJson(COOKBOOK);
        }
        public void RemoveRecipe(Recipe recipe)
        {
            Items.Remove(recipe);
        }

        private void LoadRecipesFromJson(string path)
        {
            if (File.Exists(path))
            {
                string jsonFile = File.ReadAllText(path);
                Items = JsonConvert.DeserializeObject<List<Recipe>>(jsonFile);

                int maxId = Items.Max(r => r.Id);
                Recipe.lastRecipeId = maxId;
            }
        }

        public void SaveRecipesToJson(string path)
        {
            string json = JsonConvert.SerializeObject(Items, Formatting.Indented);
            File.WriteAllText(path, json);
        }
    }
}

   