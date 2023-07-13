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

            //Przywitanie użytkownika
            //Wybór akcji przez użytkownika - exit ==> wyjście
            ////a. wyświetl przepisy wg filtra
            ////b. dodaj przepis
            ////c. przelicz wartości
            ////d. usuń przepis podając Id przepisu
            /////a1. alfabetycznie
            /////a2. wg rodzaju daniu (śniadanie, obiad, deser, kolacja)
            /////a3. wg konkretnego składnika
            /////a4. czas przygotowania (< 30 min, 30 - 60 min, ponad 60 min)
            /////a5. wg konkretnej nazwy
            /////c1. podaj jaką jednostkę chcesz przeliczyć
            /////c2. podaj wartość
            /////c3. Jaką jednostkę chcesz otrzymać?
            /////c4. Wynik przeliczenia
   
            MenuActionService actionService = new MenuActionService();
            actionService = Initialize(actionService);
            RecipeService recipeService = new RecipeService();
            RecipesFilterService filterService = new RecipesFilterService();

            Console.WriteLine("Welcome to Cookbook App.");
            while (true)
            {

                Console.WriteLine("What would you like to do?");
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
                        var showRecipe = filterService.ShowRecipesByFilterView(actionService);
                        var filteredRecipes = filterService.FilterRecipes(showRecipe.KeyChar);
                        recipeService.DisplayRecipes(filteredRecipes);
                        break;
                    case '2':
                        var keyInfo = recipeService.AddNewRecipeView(actionService);
                        recipeService.AddNewRecipe(keyInfo.KeyChar);
                        break;
                    case '3':
                        break;
                    case '4':
                        var removeId = recipeService.RemoveRecipeView();
                        recipeService.RemoveRecipe(removeId);
                        break;
                    case '9':
                        Console.WriteLine(" Thank you for using the Cookbook App. See you soon!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine(" You chose the wrong action, try again.");
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

            return actionsService;
        }
    }
}

 
