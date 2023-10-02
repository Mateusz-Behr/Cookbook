using Cookbook.App.Common;
using Cookbook.Domain;
using Cookbook.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.App.Concrete;

public class RecipeService : BaseService<Recipe>
{

    private static int nextId = 1;
    private static List<int> freeIds = new List<int>();
    public static new void GetFreeId()
    {
        if (freeIds.Count > 0)
        {
            recipe.Id = freeIds[0];
            freeIds.RemoveAt(0);
        }
        else
        {
            recipe.Id = nextId;
            nextId++;
        }
    }
}


//    public void AddNewRecipe(char recipeType)         //BĘDĄ ZAIMPLEMENTOWANE INACZEJ
//{
//    Int32.TryParse(recipeType.ToString(), out int mealType);

//    if (mealType >= 1 && mealType <= 4)
//    {
//        Recipe recipe = new Recipe();

//    Console.WriteLine("\nPlease enter a recipe name: ");
//        var name = Console.ReadLine();

//    Console.WriteLine("\nPlease enter ingredients (comma-separated)");
//        string ingredientsInput = Console.ReadLine();
//    List<string> ingredients = new List<string>(ingredientsInput.ToLower().Split(", "));

//    Console.WriteLine("\nPlease enter instructions: ");
//        string instructions = Console.ReadLine();

//    Console.WriteLine("\nPlease enter the cooking time in minutes: ");
//        Int32.TryParse(Console.ReadLine(), out int preparationTime);


//        if (Recipe.freeIds.Count > 0)
//        {
//            recipe.Id = Recipe.freeIds[0];
//            Recipe.freeIds.RemoveAt(0);
//        }
//        else
//        {
//            recipe.Id = Recipe.nextId;
//            Recipe.nextId++;
//        }
//        recipe.Name = name;
//recipe.Ingredients = ingredients;
//recipe.Instructions = instructions;
//switch (recipeType)
//{
//    case '1':
//        recipe.MealType = "Breakfest";
//        break;
//    case '2':
//        recipe.MealType = "Lunch";
//        break;
//    case '3':
//        recipe.MealType = "Dessert";
//        break;
//    case '4':
//        recipe.MealType = "Dinner";
//        break;
//}
//recipe.PreparationTime = preparationTime;

//Recipes.Add(recipe);
//Console.WriteLine("\nRecipe added successfully!");
//    }
//    else
//{
//    Console.WriteLine();
//    Console.WriteLine("Wrong meal type.");
//}
//}

//public int RemoveRecipeView()             <><><><>TO TEŻ INACZEJ<><><><>
//{
//    Console.WriteLine("\nPlease enter Id for recipe you want to remove: ");
//    int removeId;
//    Int32.TryParse(Console.ReadKey().KeyChar.ToString(), out removeId);

//    return removeId;
//}

//public void RemoveRecipe(int removeId)
//{
//    Recipe recipeToRemove = new Recipe();
//    foreach(var recipe in Recipes)
//    {
//        if(recipe.Id == removeId)
//        {
//            recipeToRemove = recipe;
//            break;
//        }
//    }

//    if (recipeToRemove.Name != null && recipeToRemove.Instructions != null)
//    {
//        Console.WriteLine($"\nDo you really want to remove {recipeToRemove.Name} Recipe? Y/N");
//        string confirmation = Console.ReadLine().ToUpper();

//        if (confirmation == "Y")
//        {
//            Console.WriteLine($"\n{recipeToRemove.Name} has been removed from Cookbook successfully");
//            Recipe.freeIds.Add(recipeToRemove.Id);
//            Recipes.Remove(recipeToRemove); 
//        }
//        else
//        {
//            Console.WriteLine("\nRecipe removal cancelled.");
//        }
//    }
//    else
//    {
//        Console.WriteLine("\nRecipe not found.");
//    }
//}

//        public ConsoleKeyInfo ShowRecipesByFilterView(MenuActionService actionService)            NIEPRZENIESIONE - NA RAZIE COMMENT
//        {
//            var showRecipesByFilterMenu = actionService.GetMenuActionsByMenuName("ShowRecipesByFilterMenu");
//            Console.WriteLine("\nHow would you like to view the recipes?");
//            for (int i = 0; i < showRecipesByFilterMenu.Count; i++)
//            {
//                Console.WriteLine($"{showRecipesByFilterMenu[i].Id}. {showRecipesByFilterMenu[i].Name}");
//            }

//            var operation = Console.ReadKey();
//            Console.WriteLine();
//            return operation;
//        }
//        public List<Recipe> FilterRecipes(int filter)
//        {

//            switch (filter)
//            {
//                case '1':
//                    return Recipes.OrderBy(r => r.Name).ToList();
//                case '2':
//                    Console.WriteLine("\nEnter type of meals you want to show: (pick one - breakfest/lunch/dessert/dinner) ");
//                    string recipeType = Console.ReadLine();
//                    return Recipes.Where(r => r.MealType.ToLower() == recipeType.ToLower()).ToList();
//                case '3':
//                    Console.WriteLine("\nEnter an ingredient to filter by: ");
//                    string ingredient = Console.ReadLine().ToLower();
//                    return Recipes.Where(r => r.Ingredients.Contains(ingredient)).ToList();
//                case '4':
//                    Console.WriteLine("\nEnter maximum preparation time (in minutes): ");
//                    Int32.TryParse(Console.ReadLine(), out int maxPreparationTime);
//                    return Recipes.Where(r => r.PreparationTime <= maxPreparationTime).ToList();
//                case '5':
//                    Console.WriteLine("\nEnter a name of recipe you are looking for: ");
//                    string recipeName = Console.ReadLine();
//                    return Recipes.Where(r => r.Name.ToLower().Contains(recipeName.ToLower())).ToList();
//                default:
//                    Console.WriteLine("\nFilter has not been chosen.");
//                    return new List<Recipe>();
//            }
//        }

//        public void DisplayRecipes(List<Recipe> recipes)
//        {

//            if (recipes.Count > 0)
//            {
//                Console.WriteLine("\nRecipes you are looking for: ");
//                foreach (Recipe recipe in recipes)
//                {
//                    Console.WriteLine($"\nName: {recipe.Name}\nId: {recipe.Id}");
//                    Console.WriteLine("Instructions: " + string.Join(", ", recipe.Ingredients));
//                    Console.WriteLine($"Instructions: {recipe.Instructions}");
//                    Console.WriteLine($"MealType: {recipe.MealType}\nPreparation time: {recipe.PreparationTime}");
//                }
//            }
//            else
//            {
//                Console.WriteLine("\nNo recipes found.");
//            }
//        }

//    }
//}
