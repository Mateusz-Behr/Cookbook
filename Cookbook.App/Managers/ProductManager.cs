using Cookbook.App.Concrete;
using Cookbook.Domain.Entity;
using Cookbook.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.App.Managers
{
    public class ProductManager
    {
        private readonly UserActionManager _userManager;
        private readonly ProductService _productService;
        private readonly MenuActionService _menuActionService;

        public ProductManager(UserActionManager userManager, ProductService productService, MenuActionService menuActionService)
        {
            _userManager = userManager;
            _productService = productService;
            _menuActionService = menuActionService;
        }

        public void RecalculateUnits()
        {
            var chosenProduct = ChooseProductToCalculate();
            var unitsList = _productService.GetUnitsListFromChosenProduct(chosenProduct);
            if (unitsList.Count > 0)
            {
                var unitToCalculate = ChooseUnitToCalculate();
                if (unitToCalculate >= 1 && unitToCalculate <= _productService.Items[0].ListOfUnits.Count)
                {
                    var valueToRecalculate = GetValueToRecalculate();
                    var unitNameFromNumber = _productService.GetUnitNameByNumber(unitToCalculate);
                    var unitFullName = _productService.GetUnitFullName(unitToCalculate);

                    var results = _productService.CalculateUnits(valueToRecalculate, unitsList, unitNameFromNumber);

                    ShowResultsOfCalculating(chosenProduct, valueToRecalculate, unitFullName, results);
                }
                else
                {
                    Console.WriteLine("\nYou have chosen a wrong unit.");
                }
            }
            else
            {
                Console.WriteLine("There is no product with that index on list.");
            }
        }
        public int ChooseProductToCalculate()
        {
            int chosenProduct = _userManager.ShowLargeMenu("ShowProductsMenu", "\nChoose a product to recalculate units for:");

            return chosenProduct;

        }

        public int ChooseUnitToCalculate()
        {
            int chosenUnit = _userManager.ShowLargeMenu("ShowUnitsMenu", "\nChoose a unit you want to recalculate:");

            return chosenUnit;
        }

        public double GetValueToRecalculate()
        {
            while (true)
            {
                Console.WriteLine("\nEnter a value:");
                var inputtedValueToRecalculate = Console.ReadLine();

                if (Double.TryParse(inputtedValueToRecalculate, out double valueToRecalculate) && valueToRecalculate >= 0)
                {
                    return valueToRecalculate;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid positive number:");
                }
            }
        }

        public void ShowResultsOfCalculating(int chosenProduct, double valueToRecalculate, string unitName, List<double> results)
        {
            List<MenuAction> productsMenuActions = _menuActionService.GetMenuActionsByMenuName("ShowProductsMenu");
            MenuAction targetProductMenuAction = productsMenuActions.FirstOrDefault(action => action.Id == chosenProduct);

            Console.WriteLine($"\n{valueToRecalculate} {unitName} of {targetProductMenuAction.Name} = \n");
            for (int i = 0; i < results.Count; i++)
            {
                if (unitName != _productService.GetUnitFullName(i + 1))
                {
                    Console.WriteLine($"{results[i]} {_productService.GetUnitFullName(i + 1)}");
                }
            }
        }
    }
}
