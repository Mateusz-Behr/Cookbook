using System;
using System.ComponentModel;
using System.Collections.Generic;
using Cookbook.Domain.Entity;
using Cookbook.App.Abstract;
using Cookbook.App.Concrete;
using Cookbook.App.Managers;
using Cookbook.Domain.Helpers;

namespace Cookbook
{
    class Program
    {
        //public const string FILE_NAME = "F:\\Cookbook App\\Recipes.xlsx";
        static void Main(string[] args)
        {

            RecipeService recipeService = new();
            MenuActionService menuActionService = new();
            Helpers helpers = new();
            UserActionManager userManager = new (menuActionService, helpers);
            RecipeManager recipeManager = new (userManager, recipeService, helpers);
            ProductService productService = new();
            ProductManager productManager = new (userManager, productService, helpers, menuActionService);
            

            Console.WriteLine("Welcome to Cookbook App.");
            while (true)
            {
                ConsoleKeyInfo operation = userManager.ShowMenu("Main", "What would you like to do?");

                switch (operation.KeyChar)
                {
                    case '1':
                        recipeManager.FilterRecipes();
                        break;
                    case '2':
                        recipeManager.AddNewRecipe();
                        break;
                    case '3':
                        var showProducts = productManager.ChooseProductToCalculate();
                        var unitsList = productService.GetUnitsListFromChosenProduct(showProducts);
                        if (unitsList.Count > 0)
                        {
                            var unitToCalculate = productManager.ChooseUnitToCalculate();
                            productManager.ShowResultAfterCalculate(showProducts, unitsList, unitToCalculate);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("There is no product with that index on list.");
                            break;
                        }
                    case '4':
                        recipeManager.SelectRecipeToRemove();
                        break;
                    case '5':
                        recipeManager.SelectRecipeToUpdate();
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

 
