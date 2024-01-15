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
        private readonly Helpers _helpers;
        private readonly MenuActionService _menuActionService;

        public ProductManager(UserActionManager userManager, ProductService productService, Helpers helpers, MenuActionService menuActionService)
        {
            _userManager = userManager;
            _productService = productService;
            _helpers = helpers;
            _menuActionService = menuActionService;
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

        public void ShowResultAfterCalculate(int chosenProduct, Dictionary<string, List<double>> productUnits, int chosenUnit)
        {

            if (chosenUnit >= 1 && chosenUnit <= _productService.Items[0].ListOfUnits.Count)
            {
                Console.WriteLine("\nEnter a value:");
                var inputtedValueToRecalculate = Console.ReadLine();

                double valueToRecalculate = _helpers.ConvertToDouble(inputtedValueToRecalculate);

                if (valueToRecalculate >= 0)
                {
                    List<double> results = _productService.CalculateUnits(valueToRecalculate, productUnits, chosenUnit);
                    string unitName = _productService.GetUnitName(chosenUnit);

                    List<MenuAction> productsMenuActions = _menuActionService.GetMenuActionsByMenuName("ShowProductsMenu");
                    MenuAction targetProductMenuAction = productsMenuActions.FirstOrDefault(action => action.Id == chosenProduct);

                    Console.WriteLine($"\n{valueToRecalculate} {unitName} of {targetProductMenuAction.Name} = \n");
                    for (int i = 0; i < results.Count; i++)
                    {
                        if (unitName != _productService.GetUnitName(i + 1))
                        {
                            Console.WriteLine($"{results[i]} {_productService.GetUnitName(i + 1)}");
                        }
                    
                    }
                }
                else
                {
                    Console.WriteLine("\r\nThe specified value cannot be negative.");
                }               
            }
            else
            {
                Console.WriteLine("\nYou have chosen a wrong unit.");
            }
            
        }
    }
}
