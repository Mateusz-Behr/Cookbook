using Cookbook.App.Common;
using Cookbook.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.App.Concrete
{
    public class MenuActionService : BaseService<MenuAction>
    {
        public MenuActionService()
        {
            Initialize();
        }

        public List<MenuAction> GetMenuActionsByMenuName(string menuName)
        {
            List<MenuAction> result = new();
            foreach(var menuAction in Items)
            {
                if(menuAction.MenuName == menuName)
                {
                    result.Add(menuAction);
                }
            }
            return result;
        }

        private void Initialize()
        {
            AddItem(new MenuAction(1, "View recipes", "Main"));
            AddItem(new MenuAction(2, "Add a new recipe", "Main"));
            AddItem(new MenuAction(3, "Convert kitchen units", "Main"));
            AddItem(new MenuAction(4, "Remove recipe", "Main"));
            AddItem(new MenuAction(5, "Update recipe", "Main"));
            AddItem(new MenuAction(8, "Export recipes to txt file", "Main"));
            AddItem(new MenuAction(9, "Exit program", "Main"));

            AddItem(new MenuAction(1, "Breakfest", "RecipeMenu"));
            AddItem(new MenuAction(2, "Lunch", "RecipeMenu"));
            AddItem(new MenuAction(3, "Dessert", "RecipeMenu"));
            AddItem(new MenuAction(4, "Dinner", "RecipeMenu"));

            AddItem(new MenuAction(1, "Alphabetically", "ShowRecipesByFilterMenu"));
            AddItem(new MenuAction(2, "According to a meal type", "ShowRecipesByFilterMenu"));
            AddItem(new MenuAction(3, "According to a specific ingredient", "ShowRecipesByFilterMenu"));
            AddItem(new MenuAction(4, "According to preparation time", "ShowRecipesByFilterMenu"));
            AddItem(new MenuAction(5, "In the order of addition", "ShowRecipesByFilterMenu"));
            AddItem(new MenuAction(6, "Specific meal by a name", "ShowRecipesByFilterMenu"));

            AddItem(new MenuAction(1, "Water", "ShowProductsMenu"));
            AddItem(new MenuAction(2, "Sugar", "ShowProductsMenu"));
            AddItem(new MenuAction(3, "Butter", "ShowProductsMenu"));
            AddItem(new MenuAction(4, "Wheat Flour", "ShowProductsMenu"));
            AddItem(new MenuAction(5, "Oil", "ShowProductsMenu"));
            AddItem(new MenuAction(6, "Cream 18%", "ShowProductsMenu"));

            AddItem(new MenuAction(1, "Grams", "ShowUnitsMenu"));
            AddItem(new MenuAction(2, "Mililiters", "ShowUnitsMenu"));
            AddItem(new MenuAction(3, "Glasses", "ShowUnitsMenu"));
            AddItem(new MenuAction(4, "Spoons", "ShowUnitsMenu"));
            AddItem(new MenuAction(5, "Teaspoons", "ShowUnitsMenu"));

            AddItem(new MenuAction(1, "Name", "UpdatingMenu"));
            AddItem(new MenuAction(2, "Meal Type", "UpdatingMenu"));
            AddItem(new MenuAction(3, "Ingredients", "UpdatingMenu"));
            AddItem(new MenuAction(4, "Instructions", "UpdatingMenu"));
            AddItem(new MenuAction(5, "Preparation time", "UpdatingMenu"));
        }
    }
}

