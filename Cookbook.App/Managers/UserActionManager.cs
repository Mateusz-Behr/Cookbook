﻿using Cookbook.App.Concrete;
using Cookbook.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.App.Managers
{
    public class UserActionManager

    {
        private readonly MenuActionService _menuActionService;

        public UserActionManager(MenuActionService menuActionService)
        {
            _menuActionService = menuActionService;
        }
        public static bool ConfirmSelection(string question)
        {
            Console.WriteLine($"{question} (y/n):");
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

            var showProductsMenu = _menuActionService.GetMenuActionsByMenuName(menuName);
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

            var showProductsMenu = _menuActionService.GetMenuActionsByMenuName(menuName);
            Console.WriteLine($"\n{message}");

            foreach (var menuItem in showProductsMenu)
            {
                Console.WriteLine($"{menuItem.Id}. {menuItem.Name}");
            }

            string chosenMenuItemString = Console.ReadLine();

            int.TryParse(chosenMenuItemString, out int chosenMenuItem);
            return chosenMenuItem;

        }
    } 
}
