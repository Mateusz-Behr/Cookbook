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
    public class RecipeService : BaseService<Recipe>, IRecipeService
    {
        public const string COOKBOOK = "..\\Cookbook.json";
        readonly FileService fileService = new();
        public RecipeService()
        {
            GetMaxIdFromRecipesList();
        }
        public void RemoveRecipe(Recipe recipe)
        {
            Items.Remove(recipe);
        }

        public void GetMaxIdFromRecipesList()
        {
            if (File.Exists(COOKBOOK)) 
            {
                Items = fileService.LoadItemsFromJson<Recipe>(COOKBOOK);

                int maxId = Items.Max(r => r.Id);
                Recipe.lastRecipeId = maxId;
            }    
        }
    }
}

   