using Cookbook.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.App.Abstract
{
    public interface IRecipeService : IService<Recipe>
    {
        void DisplayRecipes(List<Recipe> recipes);
    }
}
