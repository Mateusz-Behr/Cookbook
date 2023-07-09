using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook
{
    public class RecipeService
    {
        public List<Recipe> Recipes { get; set; }
        public RecipeService()
        {
            Recipes = new List<Recipe>();
        }
              
        public ConsoleKeyInfo AddNewRecipeView(MenuActionService actionService)
        {
            var addNewRecipeMenu = actionService.GetMenuActionsByMenuName("AddNewRecipeMenu");
            Console.WriteLine("What type of meal you want to add?");
            for (int i = 0; i < addNewRecipeMenu.Count; i++)
            {
                Console.WriteLine($"{addNewRecipeMenu[i].Id}. {addNewRecipeMenu[i].Name}");
            }

            var operation = Console.ReadKey();
            Console.WriteLine();
            return operation;
        }

        public void AddNewRecipe(char recipeType)
        {
            Int32.TryParse(recipeType.ToString(), out int mealType);

            if (mealType >= 1 && mealType <= 4)
            {
                Recipe recipe = new Recipe();

                Console.WriteLine("Please enter a recipe name: ");
                var name = Console.ReadLine();

                Console.WriteLine("Please enter ingredients (comma-separated)");
                string ingredientsInput = Console.ReadLine();
                List<string> ingredients = new List<string> (ingredientsInput.ToLower().Split(','));

                Console.WriteLine("Please enter instructions: ");
                string instructions = Console.ReadLine();

                Console.WriteLine("Please enter the cooking time in minutes: ");
                Int32.TryParse(Console.ReadLine(), out int preparationTime);
            

                recipe.Id = recipe.GetFirstUnused();
                recipe.Name = name;
                recipe.Ingredients = ingredients;
                recipe.Instructions = instructions;
                switch (recipeType)
                {
                    case '1':
                        recipe.MealType = "Breakfest";
                        break;
                    case '2':
                        recipe.MealType = "Lunch";
                        break;
                    case '3':
                        recipe.MealType = "Dessert";
                        break;
                    case '4':
                        recipe.MealType = "Dinner";
                        break;
                }
                recipe.PreparationTime = preparationTime;

                Recipes.Add(recipe);
                Console.WriteLine("Recipe added successfully!");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Wrong meal type.");
            }
        }

        public int RemoveRecipeView()
        {
            Console.WriteLine("Please enter Id for recipe you want to remove: ");
            int removeId;
            Int32.TryParse(Console.ReadKey().KeyChar.ToString(), out removeId);

            return removeId;
        }

        public void RemoveRecipe(int removeId)
        {
            Recipe recipeToRemove = new Recipe();
            foreach(var recipe in Recipes)
            {
                if(recipe.Id == removeId)
                {
                    recipeToRemove = recipe;
                    break;
                }
            }

            if (recipeToRemove != null)
            {
                Console.WriteLine($"Do you really want to remove this {recipeToRemove.Name} Recipe? Y/N");
                string confirmation = Console.ReadLine().ToUpper();

                if (confirmation == "Y")
                {
                    Console.WriteLine($"{recipeToRemove.Name} has been removed from Cookbook successfully");
                    Recipes.Remove(recipeToRemove); 
                }
                else
                {
                    Console.WriteLine("Recipe removal cancelled.");
                }
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }

        public void DisplayRecipes(List<Recipe> Recipes)
        {
            
            if (Recipes.Count > 0)
            {
                Console.WriteLine("\nRecipes you are looking for: ");
                foreach (Recipe recipe in Recipes)
                {
                    Console.WriteLine($"ID: {recipe.Id}\nName: {recipe.Name}\nIngredients: {recipe.Ingredients}\nInstructions: {recipe.Instructions}");
                    Console.WriteLine($"MealType: {recipe.MealType}\nPreparation time: {recipe.PreparationTime}");
                }
            }
            else
            {
                Console.WriteLine("No recipes found.");
            }
        }

    }
}
