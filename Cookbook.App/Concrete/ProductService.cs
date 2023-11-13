using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Cookbook.App.Common;
using Cookbook.Domain.Entity;

namespace Cookbook.App.Concrete
{
    public class ProductService : BaseService<Product>
    {
        public ProductService()
        {
            Initialize();
        }

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


        public Dictionary<string, List<double>> ChosenProduct(int chosenProduct)
        {
            switch (chosenProduct)
            {
                case 1:
                    return Items[0].ListOfUnits;
                case 2:
                    return Items[1].ListOfUnits;
                case 3:
                    return Items[2].ListOfUnits;
                case 4:
                    return Items[3].ListOfUnits;
                case 5:
                    return Items[4].ListOfUnits;
                case 6:
                    return Items[5].ListOfUnits;
                default:
                    return new Dictionary<string, List<double>>();
            }
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

        public void RecalculateUnits(char chosenUnit, Dictionary<string, List<double>> product)
        {

            int chosenUnitToCalculate = Convert.ToInt32(chosenUnit.ToString());

            if (chosenUnitToCalculate >= 1 && chosenUnitToCalculate <= 5)
            {
                Console.WriteLine("\nEnter a value:");
                Double.TryParse(Console.ReadLine(), out double valueToRecalculate);
                switch (chosenUnitToCalculate)
                {
                    case 1:
                        List<double> unitsFromG = product["g"];
                        Console.WriteLine($"{valueToRecalculate} gram(s) = {Math.Round(valueToRecalculate * unitsFromG[0], 2)} mililiter(s);" +
                            $" {Math.Round(valueToRecalculate * unitsFromG[1], 2)} glass(es); " +
                            $" {Math.Round(valueToRecalculate * unitsFromG[2], 2)} spoon(s); " +
                            $" {Math.Round(valueToRecalculate * unitsFromG[3], 2)} teaspoon(s)");
                        break;
                    case 2:
                        List<double> unitsFromMl = product["ml"];
                        Console.WriteLine($"{valueToRecalculate} mililiter(s) = {Math.Round(valueToRecalculate * unitsFromMl[0], 2)} gram(s);" +
                            $" {Math.Round(valueToRecalculate * unitsFromMl[1], 2)} glass(es);" +
                            $" {Math.Round(valueToRecalculate * unitsFromMl[2], 2)} spoon(s);" +
                            $" {Math.Round(valueToRecalculate * unitsFromMl[3], 2)} teaspoon(s)");
                        break;
                    case 3:
                        List<double> unitsFromGlass = product["glass"];
                        Console.WriteLine($"{valueToRecalculate} glass(es) = {Math.Round(valueToRecalculate * unitsFromGlass[0], 2)} gram(s);" +
                            $" {Math.Round(valueToRecalculate * unitsFromGlass[1], 2)} mililiter(s);" +
                            $" {Math.Round(valueToRecalculate * unitsFromGlass[2], 2)} spoon(s);" +
                            $" {Math.Round(valueToRecalculate * unitsFromGlass[3], 2)} teaspoon(s)");
                        break;
                    case 4:
                        List<double> unitsFromSpoon = product["spoon"];
                        Console.WriteLine($"{valueToRecalculate} spoon(s) = {Math.Round(valueToRecalculate * unitsFromSpoon[0], 2)} gram(s);" +
                            $" {Math.Round(valueToRecalculate * unitsFromSpoon[1], 2)} mililiter(s);" +
                            $" {Math.Round(valueToRecalculate * unitsFromSpoon[2], 2)} glass(es);" +
                            $" {Math.Round(valueToRecalculate * unitsFromSpoon[3], 2)} teaspoon(s)");
                        break;
                    case 5:
                        List<double> unitsFromTeaspoon = product["teaspoon"];
                        Console.WriteLine($"{valueToRecalculate} teaspoon(s) = {Math.Round(valueToRecalculate * unitsFromTeaspoon[0], 2)} gram(s);" +
                            $" {Math.Round(valueToRecalculate * unitsFromTeaspoon[1], 2)} mililiter(s);" +
                            $" {Math.Round(valueToRecalculate * unitsFromTeaspoon[2], 2)} glass(es);" +
                            $" {Math.Round(valueToRecalculate * unitsFromTeaspoon[3], 2)} spoon(s)");
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nYou have chosen a wrong unit.");
            }
        }

        private void Initialize()
        {
            AddItem(new Product("Water", waterUnits));
            AddItem(new Product("Sugar", sugarUnits));
            AddItem(new Product("Butter", butterUnits));
            AddItem(new Product("WheatFlour", wheatFlourUnits));
            AddItem(new Product("Oil", oilUnits));
            AddItem(new Product("Cream18", cream18Units));
        }

        private Dictionary<string, List<double>> waterUnits = new Dictionary<string, List<double>>
            {
                { "g", new List<double> { 1, 0.004, 0.067, 0.2 } },
                { "ml", new List<double> { 1, 0.004, 0.067, 0.2 } },
                { "glass", new List<double> { 250, 250, 16.67, 50 } },
                { "spoon", new List<double> { 15, 15, 0.06, 3 } },
                { "teaspoon", new List<double> { 5, 5, 0.02, 0.33 } },
            };

        private Dictionary<string, List<double>> sugarUnits = new Dictionary<string, List<double>>
            {
                { "g", new List<double> { 1.136, 0.005, 0.076, 0.227 } },
                { "ml", new List<double> { 0.88, 0.004, 0.067, 0.2 } },
                { "glass", new List<double> { 220, 250, 16.67, 50 } },
                { "spoon", new List<double> { 13.2, 15, 0.06, 3 } },
                { "teaspoon", new List<double> { 4.4, 5, 0.02, 0.33 } },
            };

        private Dictionary<string, List<double>> butterUnits = new Dictionary<string, List<double>>
            {
                { "g", new List<double> { 1.042, 0.004, 0.069, 0.208 } },
                { "ml", new List<double> { 0.96, 0.004, 0.067, 0.2 } },
                { "glass", new List<double> { 240, 250, 16.67, 50 } },
                { "spoon", new List<double> { 14.4, 15, 0.06, 3 } },
                { "teaspoon", new List<double> { 4.8, 5, 0.02, 0.33 } },
            };

        private Dictionary<string, List<double>> wheatFlourUnits = new Dictionary<string, List<double>>
            {
                { "g", new List<double> { 1.563, 0.006, 0.104, 0.313 } },
                { "ml", new List<double> { 0.64, 0.004, 0.067, 0.2 } },
                { "glass", new List<double> { 160, 250, 16.67, 50 } },
                { "spoon", new List<double> { 9.6, 15, 0.06, 3 } },
                { "teaspoon", new List<double> { 3.2, 5, 0.02, 0.33 } },
            };

        private Dictionary<string, List<double>> oilUnits = new Dictionary<string, List<double>>
            {
                { "g", new List<double> { 1.055, 0.004, 0.064, 0.192 } },
                { "ml", new List<double> { 1.04, 0.004, 0.067, 0.2 } },
                { "glass", new List<double> { 260, 250, 16.67, 50 } },
                { "spoon", new List<double> { 15.6, 15, 0.06, 3 } },
                { "teaspoon", new List<double> { 5.2, 5, 0.02, 0.33 } },
            };

        private Dictionary<string, List<double>> cream18Units = new Dictionary<string, List<double>>
            {
                { "g", new List<double> { 0.962, 0.004, 0.07, 0.211 } },
                { "ml", new List<double> { 0.948, 0.004, 0.067, 0.2 } },
                { "glass", new List<double> { 237, 250, 16.67, 50 } },
                { "spoon", new List<double> { 14.22, 15, 0.06, 3 } },
                { "teaspoon", new List<double> { 4.74, 5, 0.02, 0.33 } },
            };
    }
}
