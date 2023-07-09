using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook
{
    public class RecipesFilterService
    {
        public List<Recipe> Recipes { get; set; }

        public RecipesFilterService()
        {
            Recipes = new List<Recipe>();
        }

        public ConsoleKeyInfo ShowRecipesByFilterView(MenuActionService actionService)
        {
            var showRecipesByFilterMenu = actionService.GetMenuActionsByMenuName("ShowRecipesByFilterMenu");
            Console.WriteLine("How would you like to view the recipes?");
            for (int i = 0; i < showRecipesByFilterMenu.Count; i++)
            {
                Console.WriteLine($"{showRecipesByFilterMenu[i].Id}. {showRecipesByFilterMenu[i].Name}");
            }

            var operation = Console.ReadKey();
            Console.WriteLine();
            return operation;
        }
        public List<Recipe> FilterRecipes(int filter) 
        {
            switch (filter)
            {
                case '1':
                    return Recipes.OrderBy(r => r.Name).ToList();
                case '2':
                    Console.WriteLine("Enter type of meals you want to show: (pick one - breakfest/lunch/dessert/dinner) ");
                    string recipeType = Console.ReadLine();
                    return Recipes.Where(r => r.MealType.ToLower() == recipeType.ToLower()).ToList();
                case '3':
                    Console.WriteLine("Enter an ingredient to filter by: ");
                    string ingredient = Console.ReadLine().ToLower();
                    return Recipes.Where(r => r.Ingredients.Contains(ingredient)).ToList();
                case '4':
                    Console.WriteLine("Enter maximum preparation time (in minutes): ");
                    Int32.TryParse(Console.ReadLine(), out int maxPreparationTime);
                    return Recipes.Where(r => r.PreparationTime <= maxPreparationTime).ToList();
                case '5':
                    Console.WriteLine("Enter a name of recipe you are looking for: ");
                    string recipeName = Console.ReadLine();
                    return Recipes.Where(r => r.Name.ToLower().Contains(recipeName.ToLower())).ToList();
                default:
                    Console.WriteLine("Filter has not been chosen.");
                    return new List<Recipe>();
            }
        }
    }
}
