using Cookbook.App.Abstract;
using Cookbook.App.Concrete;
using Cookbook.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.App.Managers
{
    public class RecipeManager
    {
        private readonly MenuActionService _actionService;
        private IService<Recipe> _recipeService;
        public RecipeManager(MenuActionService actionService, IService<Recipe> recipeService)
        {
            _recipeService = recipeService;
            _actionService = actionService;
        }
        public int AddNewRecipe()
        {
            var addNewRecipeMenu = _actionService.GetMenuActionsByMenuName("AddNewRecipeMenu");
            Console.WriteLine("\nWhat type of meal you want to add?");
            for (int i = 0; i < addNewRecipeMenu.Count; i++)
            {
                Console.WriteLine($"{addNewRecipeMenu[i].Id}. {addNewRecipeMenu[i].Name}");
            }

            var operation = Console.ReadKey();
            Int32.TryParse(operation.KeyChar.ToString(), out int mealTypeNumber);

            Console.WriteLine("\nPlease enter a recipe name: ");
            var name = Console.ReadLine();

            Console.WriteLine("\nPlease enter ingredients (comma-separated)");
            string ingredientsInput = Console.ReadLine();
            List<string> ingredients = new List<string>(ingredientsInput.ToLower().Split(", "));

            Console.WriteLine("\nPlease enter instructions: ");
            string instructions = Console.ReadLine();

            Console.WriteLine("\nPlease enter the cooking time in minutes: ");
            Int32.TryParse(Console.ReadLine(), out int preparationTime);

            var id = _recipeService.GetFreeId(); //?

            Recipe recipe = new Recipe(id, name, mealTypeNumber, ingredients, instructions, preparationTime);
            return recipe.Id;
        }
    }
}
