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
        static void Main(string[] args)
        {

            RecipeService recipeService = new();
            MenuActionService menuActionService = new();
            UserActionManager userManager = new (menuActionService);
            RecipeManager recipeManager = new (userManager, recipeService);
            ProductService productService = new();
            ProductManager productManager = new (userManager, productService, menuActionService);
            

            Console.WriteLine("Welcome to Cookbook App.");
            while (true)
            {
                ConsoleKeyInfo operation = userManager.ShowMenu("Main", "What would you like to do?");

                switch (operation.KeyChar)
                {
                    case '1':
                        recipeManager.ShowRecipes();
                        break;
                    case '2':
                        recipeManager.AddNewRecipe();
                        break;
                    case '3':
                        productManager.RecalculateUnits();
                        break;
                    case '4':
                        recipeManager.DeleteRecipe();
                        break;
                    case '5':
                        recipeManager.UpdateRecipe();
                        break;
                    case '8':
                        recipeManager.ExportRecipesToTxt();
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

 
