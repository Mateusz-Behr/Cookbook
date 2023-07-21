using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace Cookbook
{
    class Program
    {
        public const string FILE_NAME = "F:\\Cookbook App\\Recipes.xlsx";
        static void Main(string[] args)
        {   
            MenuActionService actionService = new MenuActionService();
            actionService = Initialize(actionService);
            RecipeService recipeService = new RecipeService();
            UnitsConverter unitsConverter = new UnitsConverter();

            Console.WriteLine("Welcome to Cookbook App.");
            while (true)
            {

                Console.WriteLine("\nWhat would you like to do?");
                var mainMenu = actionService.GetMenuActionsByMenuName("Main");
                for (int i = 0; i < mainMenu.Count; i++)
                {
                    Console.WriteLine($"{mainMenu[i].Id}. {mainMenu[i].Name}");
                }

                var operation = Console.ReadKey();
                Console.WriteLine();
                switch (operation.KeyChar)
                {
                    case '1':
                        var showRecipe = recipeService.ShowRecipesByFilterView(actionService);
                        var filteredRecipes = recipeService.FilterRecipes(showRecipe.KeyChar);
                        recipeService.DisplayRecipes(filteredRecipes);
                        break;
                    case '2':
                        var keyInfo = recipeService.AddNewRecipeView(actionService);
                        recipeService.AddNewRecipe(keyInfo.KeyChar);
                        break;
                    case '3':
                        var showProducts = unitsConverter.ShowProducts(actionService);
                        var chosenProduct = unitsConverter.ChosenProduct(showProducts.KeyChar);
                        var unitToCalculate = unitsConverter.UnitToCalculate(actionService);
                        unitsConverter.RecalculateUnits(unitToCalculate.KeyChar, chosenProduct);
                        break;
                    case '4':
                        var removeId = recipeService.RemoveRecipeView();
                        recipeService.RemoveRecipe(removeId);
                        break;
                    case '9':
                        Console.WriteLine("\nThank you for using the Cookbook App. See you soon!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\nYou chose the wrong action, try again.");
                        break;
                }
            }
        }

        private static MenuActionService Initialize(MenuActionService actionsService)
        {
            actionsService.AddNewAction(1, "View recipes", "Main");
            actionsService.AddNewAction(2, "Add a new recipe", "Main");
            actionsService.AddNewAction(3, "Convert kitchen units", "Main");
            actionsService.AddNewAction(4, "Remove recipe", "Main");
            actionsService.AddNewAction(9, "Exit program", "Main");

            actionsService.AddNewAction(1, "Breakfest", "AddNewRecipeMenu");
            actionsService.AddNewAction(2, "Lunch", "AddNewRecipeMenu");
            actionsService.AddNewAction(3, "Dessert", "AddNewRecipeMenu");
            actionsService.AddNewAction(4, "Dinner", "AddNewRecipeMenu");

            actionsService.AddNewAction(1, "Alphabetically", "ShowRecipesByFilterMenu");
            actionsService.AddNewAction(2, "According to a meal type", "ShowRecipesByFilterMenu");
            actionsService.AddNewAction(3, "According to a specific ingredient", "ShowRecipesByFilterMenu");
            actionsService.AddNewAction(4, "According to preparation time", "ShowRecipesByFilterMenu");
            actionsService.AddNewAction(5, "Specific meal by a name", "ShowRecipesByFilterMenu");

            actionsService.AddNewAction(1, "Water", "ShowProductsMenu");
            actionsService.AddNewAction(2, "Sugar", "ShowProductsMenu");
            actionsService.AddNewAction(3, "Butter", "ShowProductsMenu");
            actionsService.AddNewAction(4, "Wheat Flour", "ShowProductsMenu");
            actionsService.AddNewAction(5, "Oil", "ShowProductsMenu");
            actionsService.AddNewAction(6, "Cream 18%", "ShowProductsMenu");

            actionsService.AddNewAction(1, "Grams", "ShowUnitsMenu");
            actionsService.AddNewAction(2, "Mililiters", "ShowUnitsMenu");
            actionsService.AddNewAction(3, "Glasses", "ShowUnitsMenu");
            actionsService.AddNewAction(4, "Spoons", "ShowUnitsMenu");
            actionsService.AddNewAction(5, "Teaspoons", "ShowUnitsMenu");

            return actionsService;
        }
    }
}

 
