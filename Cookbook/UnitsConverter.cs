using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook
{
    public class UnitsConverter
    {
        ProductsForConverting productsForConverting = new ProductsForConverting();

        public ConsoleKeyInfo ShowProducts(MenuActionService actionService)
        {
            var showProductsMenu = actionService.GetMenuActionsByMenuName("ShowProductsMenu");
            Console.WriteLine("\nChoose a product to recalculate units for:");
            for (int i = 0; i < showProductsMenu.Count; i++)
            {
                Console.WriteLine($"{showProductsMenu[i].Id}. {showProductsMenu[i].Name}");
            }

            var chosenProduct = Console.ReadKey();
            Console.WriteLine();
            return chosenProduct;

        }

        public ConsoleKeyInfo UnitToCalculate(MenuActionService actionService)
        {
            var showUnitsMenu = actionService.GetMenuActionsByMenuName("ShowUnitsMenu");
            Console.WriteLine("\nChoose a unit you want to recalculate:");
            for (int i = 0; i < showUnitsMenu.Count; i++)
            {
                Console.WriteLine($"{showUnitsMenu[i].Id}. {showUnitsMenu[i].Name}");
            }

            var chosenUnit = Console.ReadKey();
            Console.WriteLine();
            return chosenUnit;
        }

        public Dictionary<string, List<double>> ChosenProduct(int chosenProduct)
        {
            switch (chosenProduct)
            {
                case '1':
                    return productsForConverting.GetDictionary(0);
                case '2':
                    return productsForConverting.GetDictionary(1);
                case '3':
                    return productsForConverting.GetDictionary(2);
                case '4':
                    return productsForConverting.GetDictionary(3);
                case '5':
                    return productsForConverting.GetDictionary(4);
                case '6':
                    return productsForConverting.GetDictionary(5);
                default:
                    return new Dictionary<string, List<double>>();
            }
        }

        public void RecalculateUnits(int chosenUnit, Dictionary<string, List<double>> product)
        {
            Console.WriteLine("\nEnter a value:");
            Double.TryParse(Console.ReadLine(), out double valueToRecalculate);
            switch (chosenUnit)
            {
                case '1':
                    List<double> unitsFromG = product["g"];
                    Console.WriteLine($"{valueToRecalculate} gram(s) = {Math.Round(valueToRecalculate * unitsFromG[0], 2)} mililiter(s);" +
                        $" {Math.Round(valueToRecalculate * unitsFromG[1]), 2} glass(es); " +
                        $" {Math.Round(valueToRecalculate * unitsFromG[2], 2)} spoon(s); " +
                        $" {Math.Round(valueToRecalculate * unitsFromG[3], 2)} teaspoon(s)");
                    break;
                case '2':
                    List<double> unitsFromMl = product["ml"];
                    Console.WriteLine($"{valueToRecalculate} mililiter(s) = {Math.Round(valueToRecalculate * unitsFromMl[0], 2)} gram(s);" +
                        $" {Math.Round(valueToRecalculate * unitsFromMl[1], 2)} glass(es);" +
                        $" {Math.Round(valueToRecalculate * unitsFromMl[2], 2)} spoon(s);" +
                        $" {Math.Round(valueToRecalculate * unitsFromMl[3], 2)} teaspoon(s)");
                    break;
                case '3':
                    List<double> unitsFromGlass = product["glass"];
                    Console.WriteLine($"{valueToRecalculate} glass(es) = {Math.Round(valueToRecalculate * unitsFromGlass[0], 2)} gram(s);" +
                        $" {Math.Round(valueToRecalculate * unitsFromGlass[1], 2)} mililiter(s);" +
                        $" {Math.Round(valueToRecalculate * unitsFromGlass[2], 2)} spoon(s);" +
                        $" {Math.Round(valueToRecalculate * unitsFromGlass[3], 2)} teaspoon(s)");
                    break;
                case '4':
                    List<double> unitsFromSpoon = product["spoon"];
                    Console.WriteLine($"{valueToRecalculate} spoon(s) = {Math.Round(valueToRecalculate * unitsFromSpoon[0], 2)} gram(s);" +
                        $" {Math.Round(valueToRecalculate * unitsFromSpoon[1], 2)} mililiter(s);" +
                        $" {Math.Round(valueToRecalculate * unitsFromSpoon[2], 2)} glass(es);" +
                        $" {Math.Round(valueToRecalculate * unitsFromSpoon[3], 2)} teaspoon(s)");
                    break;
                case '5':
                    List<double> unitsFromTeaspoon = product["teaspoon"];
                    Console.WriteLine($"{valueToRecalculate} teaspoon(s) = {Math.Round(valueToRecalculate * unitsFromTeaspoon[0], 2)} gram(s);" +
                        $" {Math.Round(valueToRecalculate * unitsFromTeaspoon[1], 2)} mililiter(s);" +
                        $" {Math.Round(valueToRecalculate * unitsFromTeaspoon[2], 2)} glass(es);" +
                        $" {Math.Round(valueToRecalculate * unitsFromTeaspoon[3], 2)} spoon(s)");
                    break;
                default:
                    Console.WriteLine("\nYou have chosen a wrong unit.");
                    break;
            }
        }
    }
}