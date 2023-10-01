using System;
using System.ComponentModel;
using System.Collections.Generic;
using Cookbook.Domain.Entity;
using Cookbook.App.Abstract;
using Cookbook.App.Concrete;
using Cookbook.App.Managers;

namespace Cookbook
{
    class Program
    {
        public const string FILE_NAME = "F:\\Cookbook App\\Recipes.xlsx";
        static void Main(string[] args)
        {
            MenuActionService actionService = new MenuActionService();
            RecipeService recipeService = new RecipeService();
            RecipeManager recipeManager = new RecipeManager(actionService, recipeService);
            
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
                        //var showRecipe = recipeService.ShowRecipesByFilterView(actionService);
                        //var filteredRecipes = recipeService.FilterRecipes(showRecipe.KeyChar);
                        //recipeService.DisplayRecipes(filteredRecipes);
                        break;
                    case '2':
                        var newId = recipeManager.AddNewRecipe();
                        break;
                    case '3':
                        //var showProducts = unitsConverter.ShowProducts(actionService);
                        //var chosenProduct = unitsConverter.ChosenProduct(showProducts.KeyChar);
                        //if (chosenProduct.Count > 0)
                        //{
                        //    var unitToCalculate = unitsConverter.UnitToCalculate(actionService);
                        //    unitsConverter.RecalculateUnits(unitToCalculate.KeyChar, chosenProduct);
                        //    break;
                        //}
                        //else
                        //{
                        //    Console.WriteLine("There is no product with that index on list.");
                        //    break;
                        //}
                    case '4':
                        //var removeId = recipeService.RemoveRecipeView();
                        //recipeService.RemoveRecipe(removeId);
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


    }
}

 
