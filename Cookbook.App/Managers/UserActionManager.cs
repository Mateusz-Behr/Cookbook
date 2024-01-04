using Cookbook.App.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.App.Managers
{
    public class UserActionManager

    {
        public MenuActionService menuActionService;
        public UserActionService userService;

        public UserActionManager(MenuActionService menuActionService, UserActionService userService)
        {
            this.menuActionService = menuActionService;
            this.userService = userService;
        }
        public static bool ConfirmSelection(string selectionName)
        {
            Console.WriteLine($"Are you sure you want to {selectionName} (y/n):");
            char key;
            do
            {
                key = Console.ReadKey().KeyChar;
            }
            while (key != 'y' && key != 'n');

            if (key == 'y') return true;
            else return false;
        }

        public ConsoleKeyInfo ShowMenu(string menuName, string message)
        {

            var showProductsMenu = menuActionService.GetMenuActionsByMenuName(menuName);
            Console.WriteLine($"\n{message}");

            foreach (var menuItem in showProductsMenu)
            {
                Console.WriteLine($"{menuItem.Id}. {menuItem.Name}");
            }

            var chosenMenuItem = Console.ReadKey();
            Console.WriteLine();
            return chosenMenuItem;
        }

        public int ShowLargeMenu(string menuName, string message)
        {

            var showProductsMenu = menuActionService.GetMenuActionsByMenuName(menuName);
            Console.WriteLine($"\n{message}");

            foreach (var menuItem in showProductsMenu)
            {
                Console.WriteLine($"{menuItem.Id}. {menuItem.Name}");
            }

            string chosenMenuItemString = Console.ReadLine();

            int chosenMenuItem = userService.ConvertToInt(chosenMenuItemString);
            return chosenMenuItem;

        }

    }

    
}
