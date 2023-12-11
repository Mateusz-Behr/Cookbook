using Cookbook.App.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.App.Managers
{
    public class ProductManager
    {
        public UserActionManager userManager;
        public ProductService productService;

        public ProductManager()
        {
            userManager = new UserActionManager();
            productService = new ProductService();
        }

        public ConsoleKeyInfo ShowProducts()
        {
            ConsoleKeyInfo chosenProduct = userManager.ShowMenu("ShowProductsMenu", "\nChoose a product to recalculate units for:");

            return chosenProduct;

        }

        public ConsoleKeyInfo ChooseUnitToCalculate()
        {
            ConsoleKeyInfo chosenUnit = userManager.ShowMenu("ShowUnitsMenu", "\nChoose a unit you want to recalculate:");

            return chosenUnit;
        }

        public void ShowResultAfterCalculate(Dictionary<string, List<double>> product, char chosenUnitKeyChar)
        {
            int chosenUnitNumber = (int)char.GetNumericValue(chosenUnitKeyChar);

            if (chosenUnitNumber >= 1 && chosenUnitNumber < productService.Items[0].ListOfUnits.Count)
            {
                Console.WriteLine("\nEnter a value:");
                Double.TryParse(Console.ReadLine(), out double valueToRecalculate);

                List<double> results = productService.CalculateUnits(valueToRecalculate, product, chosenUnitNumber);
                string unitName = productService.GetUnitName(chosenUnitNumber);

                Console.WriteLine($"\n{valueToRecalculate} {unitName} = ");
                for (int i = 0; i < results.Count; i++)
                {
                    Console.WriteLine($"{results[i]} {productService.GetUnitName(i + 1)}");
                }
            }
            else
            {
                Console.WriteLine("\nYou have chosen a wrong unit.");
            }
            
        }
    }
}
