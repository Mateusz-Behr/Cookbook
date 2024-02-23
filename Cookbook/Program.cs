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
            UserActionManager userManager = new (menuActionService);
            RecipeManager recipeManager = new (userManager, recipeService, helpers);
            ProductService productService = new();
            ProductManager productManager = new (userManager, productService, menuActionService);
            

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
                        var chosenProduct = productManager.ChooseProductToCalculate();
                        var unitsList = productService.GetUnitsListFromChosenProduct(chosenProduct);
                        if (unitsList.Count > 0)
                        {
                            var unitToCalculate = productManager.ChooseUnitToCalculate();
                            if (unitToCalculate >= 1 && unitToCalculate <= productService.Items[0].ListOfUnits.Count)
                            {
                                var valueToRecalculate = productManager.GetValueToRecalculate();
                                var unitNameFromNumber = productService.GetUnitNameByNumber(unitToCalculate);
                                var unitFullName = productService.GetUnitFullName(unitToCalculate);

                                var results = productService.CalculateUnits(valueToRecalculate, unitsList, unitNameFromNumber);

                                productManager.ShowResultsOfCalculating(chosenProduct, valueToRecalculate, unitFullName, results);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("\nYou have chosen a wrong unit.");
                                break;
                            }
                            
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

 
