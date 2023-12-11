using Cookbook.App.Abstract;
using Cookbook.App.Concrete;
using Cookbook.Domain.Entity;
using Cookbook.Domain.Helpers;
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

        private readonly UserActionManager _userManager;
        private readonly RecipeService _recipeService;

        public RecipeManager(UserActionManager userManager, RecipeService recipeService)
        {
            _recipeService = recipeService;
            _userManager = userManager;
        }

        public void AddNewRecipe()
        {
            ConsoleKeyInfo operation = _userManager.ShowMenu("RecipeMenu", "What type of meal you want to add?");
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

                int id = _recipeService.GetFreeId();

                Recipe recipe = new(id, name, mealTypeNumber, ingredients, instructions, preparationTime);
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

            Recipe recipe = _recipeService.GetItemById(idToRemove);

            if (recipe.Id == idToRemove)
            {
                if (UserActionManager.ConfirmSelection($"remove {recipe.Name} recipe?"))
                {
                    Console.WriteLine($"\n{recipe.Name} has been removed from Cookbook successfully");
                    _recipeService.RemoveItem(recipe);
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

        public void FilterRecipes()
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
                    Int32.TryParse(Console.ReadLine(), out int maxPreparationTime);

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

        public void DisplayRecipes(List<Recipe> recipes)
        {
            if (recipes.Count > 0)
            {
                Console.WriteLine("\nRecipes you are looking for: ");
                foreach (Recipe recipe in recipes)
                {

                    MealType mealType = (MealType)recipe.MealTypeNumber;

                    Console.WriteLine($"\nName: {recipe.Name}\nId: {recipe.Id}");
                    Console.WriteLine("Igredients: " + string.Join(", ", recipe.Ingredients));
                    Console.WriteLine($"Instructions: {recipe.Instructions}");
                    Console.WriteLine($"MealType: {mealType}\nPreparation time: {recipe.PreparationTime}");
                }
            }
            else
            {
                Console.WriteLine("\nNo recipes found.");
            }
        }

        private static void DisplaySingleRecipe(Recipe recipe)
        {
            Console.WriteLine($"\nName: {recipe.Name}");
            Console.WriteLine($"Meal type: {(MealType)recipe.MealTypeNumber}");
            Console.WriteLine("Igredients: " + string.Join(", ", recipe.Ingredients));
            Console.WriteLine($"Instructions: {recipe.Instructions}");
            Console.WriteLine($"Preparation time: {recipe.PreparationTime}");
        }

        public void UpdateRecipeView()
        {
            Console.WriteLine("\r\nEnter the name or ID of the recipe you want to update.");
            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int recipeId))
            {
                Recipe recipeById = _recipeService.Items.FirstOrDefault(r => r.Id == recipeId);

                if (recipeById != null)
                {
                    UpdatingConfirmationView(recipeById);
                }
                else
                {
                    Console.WriteLine("The recipe with the given ID does not exist.");
                }
            }
            else
            {
                Recipe recipeByName = _recipeService.Items.FirstOrDefault(r => r.Name.Equals(userInput, StringComparison.OrdinalIgnoreCase));

                if (recipeByName != null)
                {
                    UpdatingConfirmationView(recipeByName);
                }
                else
                {
                    Console.WriteLine("The recipe with the given name does not exits.");
                }
            }
        }

        public void UpdatingConfirmationView(Recipe recipe)
        {
            if (UserActionManager.ConfirmSelection($"update {recipe.Name} recipe?"))
            {
                DisplaySingleRecipe(recipe);

                ConsoleKeyInfo chosenPropertyKeyChar = _userManager.ShowMenu("UpdatingMenu", "\nWhat do you want to update?");
                int chosenProperty = (int)char.GetNumericValue(chosenPropertyKeyChar.KeyChar);

                if (chosenProperty >= 1 && chosenProperty <= 5)
                {
                    UpdateRecipe(chosenProperty, recipe);
                }
                else
                {
                    Console.WriteLine("Wrong choice");
                }
                
            }
            else
            {
                Console.WriteLine("\nRecipe updating has been cancelled.");
            }
        }

        public void UpdateRecipe(int chosenProperty, Recipe recipe)
        {
            switch (chosenProperty)
            {
                case 1:
                    Console.WriteLine("\nEnter a new name");
                    string newName = Console.ReadLine();
                    recipe.Name = newName;
                    break;
                case 2:
                    ConsoleKeyInfo chosenMealTypeKeyChar = _userManager.ShowMenu("RecipeMenu", "\nWhat is the correct type of meal?");
                    int newMealTypeNumber = (int)char.GetNumericValue(chosenMealTypeKeyChar.KeyChar);
                    recipe.MealTypeNumber = newMealTypeNumber;
                    break;
                case 3:
                    Console.WriteLine("\nPlease enter new ingredients (comma-separated)");
                    List<string> newIngredients = new List<string>(Console.ReadLine().ToLower().Split(", "));
                    recipe.Ingredients = newIngredients;
                    break;
                case 4:
                    Console.WriteLine("\nPlease enter new instructions: ");
                    string newInstructions = Console.ReadLine();
                    recipe.Instructions = newInstructions;
                    break;
                case 5:
                    Console.WriteLine("\nPlease enter enter approximate preparation time.");
                    Int32.TryParse(Console.ReadLine(), out int newPreparationTime);
                    recipe.PreparationTime = newPreparationTime;
                    break;
            }

            Console.WriteLine("The update was successful");
        }
    }
}


