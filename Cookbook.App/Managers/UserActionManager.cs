using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.App.Managers
{
    public static class UserActionManager
    {
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
    }
}
