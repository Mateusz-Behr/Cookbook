using Cookbook.App.Abstract;
using Cookbook.App.Common;
using Cookbook.App.Managers;
using Cookbook.Domain;
using Cookbook.Domain.Entity;
using Cookbook.Domain.Helpers;
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

        private int recipeNextId = 1;
        private List<int> recipeFreeIds = new List<int>();

        public override int GetFreeId()
        {
            int searchedId;

            if (recipeFreeIds.Count > 0)
            {
                searchedId = recipeFreeIds[0];
                recipeFreeIds.RemoveAt(0);
                return searchedId;
            }
            else
            {
                searchedId = recipeNextId;
                recipeNextId++;
                return searchedId;
            }
        }
        public override void RemoveItem(Recipe recipe)
        {
            Items.Remove(recipe);
            recipeFreeIds.Add(recipe.Id);
        }
    }
}