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
        private int nextId = 1;
        private readonly List<int> freeIds = new();

        public override void RemoveItem(Recipe recipe)
        {
            Items.Remove(recipe);
            freeIds.Add(recipe.Id);
        }

        public int GetFreeId()
        {
            int searchedId;

            if (freeIds.Count > 0)
            {
                searchedId = freeIds[0];
                freeIds.RemoveAt(0);
                return searchedId;
            }
            else
            {
                searchedId = nextId;
                nextId++;
                return searchedId;
            }
        }
    }
}

   