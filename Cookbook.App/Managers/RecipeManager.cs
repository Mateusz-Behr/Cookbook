using Cookbook.App.Abstract;
using Cookbook.App.Concrete;
using Cookbook.Domain.Entity;
using Cookbook.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.App.Managers
{
    public class RecipeManager
    {
        private readonly UserActionManager _userManager;
        private readonly RecipeService _recipeService;

        public RecipeManager(UserActionManager userManager, RecipeService recipeService)
        {
            _recipeService = recipeService;
            _userManager = userManager;
        }

        bool isValidInput = false;
        int preparationTime;
        private const string RECIPES_LIST_PATH = "C:\\Users\\behrm\\source\\RecipesList";


        public void AddNewRecipe()
        {
            ConsoleKeyInfo operation = _userManager.ShowMenu("RecipeMenu", "What type of meal you want to add?");
            int.TryParse(operation.KeyChar.ToString(), out int mealTypeNumber);

            if (mealTypeNumber >= 1 && mealTypeNumber <= 4)
            {
                Console.WriteLine("\nPlease enter a recipe name: ");
                var name = Console.ReadLine();

                Console.WriteLine("\nPlease enter ingredients (comma-separated)");
                var ingredientsInput = Console.ReadLine();
                List<string> ingredients = new(ingredientsInput.ToLower().Split(", "));

                Console.WriteLine("\nPlease enter instructions (press Enter twice to finish): ");
                StringBuilder instructionsBuilder = new();

                string line;

                while (!string.IsNullOrWhiteSpace(line = Console.ReadLine()))
                {
                    instructionsBuilder.Append(line + "\n");
                }

                var instructions = instructionsBuilder.ToString();

                do
                {
                    Console.WriteLine("\nPlease enter the cooking time in minutes: ");
                    var inputtedPreparationTime = Console.ReadLine();

                    isValidInput = int.TryParse(inputtedPreparationTime, out preparationTime);

                    if (!isValidInput || preparationTime <= 0)
                    {
                        Console.WriteLine("Incorrect data. Enter a positive integer.");
                    }
                }
                while (!isValidInput || preparationTime <= 0);

                Recipe recipe = new(name, mealTypeNumber, ingredients, instructions, preparationTime);
                _recipeService.AddItem(recipe);

                Console.WriteLine("\nRecipe added successfully!");

                if (UserActionManager.ConfirmSelection("Do you want to save this recipe to a text file?"))
                {
                    SaveRecipeToTxtFile(RECIPES_LIST_PATH, recipe.Name, recipe);
                }
            }
            else
            {
                Console.WriteLine("\nWrong meal type.");
            }
        }

        public void DeleteRecipe()
        {
            int idToRemove = GetRecipeIdFromUserInput();
            Recipe recipe = _recipeService.GetItemById(idToRemove);

            if (recipe != null && recipe.Id == idToRemove)
            {
                if (UserActionManager.ConfirmSelection($"Are you sure you want to remove {recipe.Name} recipe?"))
                {
                    Console.WriteLine($"\n{recipe.Name} has been removed from Cookbook successfully");
                    _recipeService.RemoveRecipe(recipe);
                }
                else
                {
                    Console.WriteLine("\nRecipe removal cancelled.");
                }
            }
            else
            {
                Console.WriteLine("\nRecipe not found.");
            }
        }

        private static int GetRecipeIdFromUserInput()
        {
            int idToRemove;
            bool isValidInput = false;

            do
            {
                Console.WriteLine("\nPlease enter proper Id for recipe you want to remove: ");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out idToRemove))
                {
                    isValidInput = true;
                }
            }
            while (!isValidInput);

            return idToRemove;
        }

        public void ShowRecipes()
        {
            ConsoleKeyInfo operation = _userManager.ShowMenu("ShowRecipesByFilterMenu", "How would you like to view the recipes?");
            int filter = (int)char.GetNumericValue(operation.KeyChar);

            List<Recipe> filteredRecipes;

            switch (filter)
            {
                case 1:
                    filteredRecipes = _recipeService.GetAllItems();
                    DisplayRecipes(filteredRecipes.OrderBy(r => r.Name).ToList());
                    break;
                case 2:
                    ConsoleKeyInfo mealType = _userManager.ShowMenu("RecipeMenu", "What type of meals you want to display:");
                    int mealTypeNumber = (int)char.GetNumericValue(mealType.KeyChar);

                    filteredRecipes = _recipeService.GetAllItems().Where(r => r.MealTypeNumber == mealTypeNumber).ToList();
                    DisplayRecipes(filteredRecipes.OrderBy(r => r.Name).ToList());
                    break;
                case 3:
                    Console.WriteLine("\nEnter an ingredient to filter by: ");
                    string ingredient = Console.ReadLine().ToLower();

                    filteredRecipes = _recipeService.GetAllItems().Where(r => r.Ingredients.Contains(ingredient)).ToList();
                    DisplayRecipes(filteredRecipes.OrderBy(r => r.Name).ToList());
                    break;
                case 4:
                    Console.WriteLine("\nEnter maximum preparation time (in minutes): ");
                    int.TryParse(Console.ReadLine(), out int maxPreparationTime);

                    filteredRecipes = _recipeService.GetAllItems().Where(r => r.PreparationTime <= maxPreparationTime).ToList();
                    DisplayRecipes(filteredRecipes.OrderBy(r => r.Name).ToList());
                    break;
                case 5:
                    filteredRecipes = _recipeService.GetAllItems();
                    DisplayRecipes(filteredRecipes.OrderBy(r => r.CreatedDateTime).ToList());
                    break;
                case 6:
                    Console.WriteLine("\nEnter a name of recipe you are looking for: ");
                    string recipeName = Console.ReadLine();

                    filteredRecipes = _recipeService.GetAllItems().Where(r => r.Name.ToLower().Contains(recipeName.ToLower())).ToList();
                    DisplayRecipes(filteredRecipes.OrderBy(r => r.Name).ToList());
                    break;
                default:
                    Console.WriteLine("\nFilter has not been chosen.");
                    break;
            }
        }

        private static void DisplayRecipes(List<Recipe> recipes)
        {
            if (recipes.Count > 0)
            {
                Console.WriteLine("\nRecipes you are looking for: ");
                foreach (Recipe recipe in recipes)
                {
                    Helpers.MealType mealType = (Helpers.MealType)recipe.MealTypeNumber;

                    Console.WriteLine($"\nId: {recipe.Id}");
                    Console.WriteLine($"Name: {recipe.Name}");
                    Console.WriteLine("Igredients: " + string.Join(", ", recipe.Ingredients));
                    Console.WriteLine($"Instructions: {recipe.Instructions}");
                    Console.WriteLine($"MealType: {mealType}");
                    Console.WriteLine($"Preparation time: {recipe.PreparationTime}");
                }
            }
            else
            {
                Console.WriteLine("\nNo recipes found.");
            }
        }

        private static void DisplaySingleRecipe(Recipe recipe)
        {
            Console.WriteLine($"\nId: {recipe.Id}");
            Console.WriteLine($"Name: {recipe.Name}");
            Console.WriteLine($"Meal type: {(Helpers.MealType)recipe.MealTypeNumber}");
            Console.WriteLine("Igredients: " + string.Join(", ", recipe.Ingredients));
            Console.WriteLine($"Instructions: {recipe.Instructions}");
            Console.WriteLine($"Preparation time: {recipe.PreparationTime}");
        }

        public void UpdateRecipe()
        {
            Recipe recipe = SelectRecipeToUpdate();

            if (recipe == null)
            {
                Console.WriteLine("The recipe with the given ID/name does not exist.");
                return;
            }

            if (ConfirmUpdate(recipe))
            {
                var chosenProperty = SelectPropertyToUpdate();
                if (chosenProperty >= 1 && chosenProperty <= 5)
                {
                    ModifyRecipe(chosenProperty, recipe);
                }
                else
                {
                    Console.WriteLine("Wrong property choice");
                }
            }
            else
            {
                Console.WriteLine("\nRecipe updating has been cancelled.");
            }
        }

        private Recipe SelectRecipeToUpdate()
        {
            Console.WriteLine("\r\nEnter the name or ID of the recipe you want to update.");
            var userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int recipeId))
            {
                return _recipeService.Items.FirstOrDefault(r => r.Id == recipeId);
            }
            else
            {
                return _recipeService.Items.FirstOrDefault(r => r.Name.Equals(userInput, StringComparison.OrdinalIgnoreCase));
            }
        }


        private int SelectPropertyToUpdate()
        {
            ConsoleKeyInfo chosenPropertyKeyChar = _userManager.ShowMenu("UpdatingMenu", "\nWhat do you want to update?");
            int chosenProperty = (int)char.GetNumericValue(chosenPropertyKeyChar.KeyChar);
            return chosenProperty;
        }

        private static bool ConfirmUpdate(Recipe recipe)
        {
            if (UserActionManager.ConfirmSelection($"Are you sure you want to update {recipe.Name} recipe?"))
            {
                DisplaySingleRecipe(recipe);
                return true;
            }
            else
            {
                return false;
            }
        }


        private void ModifyRecipe(int chosenProperty, Recipe recipe)
        {
            switch (chosenProperty)
            {
                case 1:
                    Console.WriteLine("\nEnter a new name");
                    var newName = Console.ReadLine();
                    recipe.Name = newName;
                    break;
                case 2:
                    ConsoleKeyInfo chosenMealTypeKeyChar = _userManager.ShowMenu("RecipeMenu", "\nWhat is the correct type of meal?");
                    int newMealTypeNumber = (int)char.GetNumericValue(chosenMealTypeKeyChar.KeyChar);
                    recipe.MealTypeNumber = newMealTypeNumber;
                    break;
                case 3:
                    Console.WriteLine("\nEnter new ingredients (comma-separated)");
                    List<string> newIngredients = new(Console.ReadLine().ToLower().Split(", "));
                    recipe.Ingredients = newIngredients;
                    break;
                case 4:
                    Console.WriteLine("\nEnter new instructions: ");

                    StringBuilder instructionsBuilder = new StringBuilder();

                    string line;
                    while (!string.IsNullOrWhiteSpace(line = Console.ReadLine()))
                    {
                        instructionsBuilder.Append(line + "\n");
                    }

                    var newInstructions = instructionsBuilder.ToString();
                    recipe.Instructions = newInstructions;
                    break;
                case 5:
                    Console.WriteLine("\nEnter approximate preparation time.");
                    int.TryParse(Console.ReadLine(), out int newPreparationTime);
                    recipe.PreparationTime = newPreparationTime;
                    break;
            }

            Console.WriteLine("The update was successful");
        }
        public void ExportSingleRecipeToTxt()
        {
            if (_recipeService.Items.Count == 0)
            {
                Console.WriteLine("There are no recipes to export");
                return;
            }

            Console.WriteLine($"{_recipeService.Items.Count} recipe(s) in memory. Enter Id of recipe you want to export.");
            string userInput = Console.ReadLine();
            int.TryParse(userInput, out int idToExport);

            if (_recipeService.Items.Any(p => p.Id == idToExport))
            {
                Recipe recipeToExport = _recipeService.Items.FirstOrDefault(r => r.Id == idToExport);

                if (UserActionManager.ConfirmSelection($"Are you sure you want to export to .txt {recipeToExport.Name} recipe?"))
                {
                    SaveRecipeToTxtFile(RECIPES_LIST_PATH, recipeToExport.Name, recipeToExport);
                }
                else
                {
                    Console.WriteLine("\nThe process has been stopped.");
                }
            }
            else
            {
                Console.WriteLine("There is no recipe with that Id.");
            }
        }

        public void SaveCookbook()
        {
            string cookbookPath = RecipeService.COOKBOOK;

            if (_recipeService.Items.Count == 0)
            {
                Console.WriteLine("There are no recipes to save.");
                return;
            }

            if (UserActionManager.ConfirmSelection($"Are you sure you want to save your recipes to Cookbook?"))
            {
                _recipeService.SaveRecipesToJson(cookbookPath);
                Console.WriteLine("Recipes have been saved.");
            }
            else
            {
                Console.WriteLine("\nRecipes have not been saved.");
            }
        }

        public static void SaveRecipeToTxtFile(string path, string name, Recipe recipe)
        {
            Helpers.MealType mealType = (Helpers.MealType)recipe.MealTypeNumber;
            string fileName = $"{name.Replace(" ", "_")}.txt";
            string filePath = Path.Combine(path, fileName);

            using StreamWriter writer = new(filePath);

            writer.WriteLine($"Recipe: {recipe.Name}");
            writer.WriteLine($"Type: {mealType}");
            writer.WriteLine("Ingredients:");
            foreach (var ingredient in recipe.Ingredients)
            {
                writer.WriteLine(ingredient);
            }
            writer.WriteLine($"Instructions: \n{recipe.Instructions}");
            writer.WriteLine($"Prepration time: {recipe.PreparationTime} minutes");

            Console.WriteLine($"\nRecipe saved to {filePath} successfully.");
        }
    }
}


