using Cookbook.App.Abstract;
using Cookbook.App.Concrete;
using Cookbook.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.App.Managers
{
    public class RecipeManager
    {
        private readonly MenuActionService _actionService;
        private readonly RecipeService _recipeService;

        public RecipeManager(MenuActionService actionService, RecipeService recipeService)
        {
            _recipeService = recipeService;
            _actionService = actionService;
        }

        public void AddNewRecipe()
        {
            var addNewRecipeMenu = _actionService.GetMenuActionsByMenuName("RecipeMenu");
            Console.WriteLine("\nWhat type of meal you want to add?");
            for (int i = 0; i < addNewRecipeMenu.Count; i++)
            {
                Console.WriteLine($"{addNewRecipeMenu[i].Id}. {addNewRecipeMenu[i].Name}");
            }

            var operation = Console.ReadKey();
            Int32.TryParse(operation.KeyChar.ToString(), out int mealTypeNumber);

            if (mealTypeNumber >= 1 && mealTypeNumber <= 4)
            {
                Console.WriteLine("\nPlease enter a recipe name: ");
                var name = Console.ReadLine();

                Console.WriteLine("\nPlease enter ingredients (comma-separated)");
                string ingredientsInput = Console.ReadLine();
                List<string> ingredients = new List<string>(ingredientsInput.ToLower().Split(", "));

                Console.WriteLine("\nPlease enter instructions: ");
                string instructions = Console.ReadLine();

                Console.WriteLine("\nPlease enter the cooking time in minutes: ");
                Int32.TryParse(Console.ReadLine(), out int preparationTime);

                var id = _recipeService.GetFreeId();

                Recipe recipe = new Recipe(id, name, mealTypeNumber, ingredients, instructions, preparationTime);
                _recipeService.AddItem(recipe);
                Console.WriteLine("\nRecipe added successfully!");

            }
            else
            {
                Console.WriteLine("\nWrong meal type.");

            }
        }
        public void RemoveRecipeView()
        {
            Console.WriteLine("\nPlease enter Id for recipe you want to remove: ");
            Int32.TryParse(Console.ReadLine().ToString(), out int idToRemove);

            _recipeService.RemoveItem(idToRemove);
            
        }

        public int ShowRecipesView()
        {
            var showRecipesByFilterMenu = _actionService.GetMenuActionsByMenuName("ShowRecipesByFilterMenu");

            Console.WriteLine("\nHow would you like to view the recipes?");
            for (int i = 0; i < showRecipesByFilterMenu.Count; i++)
            {
                Console.WriteLine($"{showRecipesByFilterMenu[i].Id}. {showRecipesByFilterMenu[i].Name}");
            }

            var operation = Console.ReadKey();
            Int32.TryParse(operation.KeyChar.ToString(), out int filter);
            Console.WriteLine();

            return filter;


        }
    }
}


