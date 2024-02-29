using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Cookbook.App.Common;
using Cookbook.App.Managers;
using Cookbook.Domain.Entity;
using Cookbook.Domain.Helpers;

namespace Cookbook.App.Concrete
{
    public class ProductService : BaseService<Product>
    {

        public ProductService()
        {
            Initialize();
        }

        private const string UNITS_LIST_PATH = "C:\\Users\\behrm\\source\\UnitsToCalculator.json";
        public Dictionary<string, List<double>> GetUnitsListFromChosenProduct(int chosenProduct)
        {

            if (chosenProduct > 0 && chosenProduct <= Items.Count)
            {
                return Items[chosenProduct - 1].ListOfUnits;
            }
            else
            {
                return new Dictionary<string, List<double>>();
            }
        }

        public string GetUnitNameByNumber(int chosenUnitNumber)
        {
            switch (chosenUnitNumber)
            {
                case 1:
                    return "g";
                case 2:
                    return "ml";
                case 3:
                    return "glass";
                case 4:
                    return "spoon";
                case 5:
                    return "teaspoon";
                default:
                    return "";
            }
        }

        public string GetUnitFullName(int chosenUnitNumber)
        {
            Helpers.UnitType unitType = (Helpers.UnitType)chosenUnitNumber;

            return unitType switch
            {
                Helpers.UnitType.Grams => "gram(s)",
                Helpers.UnitType.Milliliters => "mililiter(s)",
                Helpers.UnitType.Glasses => "glass(es)",
                Helpers.UnitType.Spoons => "spoon(s)",
                Helpers.UnitType.Teaspoons => "teaspoon(s)",
                _ => "unknown"
            };
        }

        public List<double> CalculateUnits(double value, Dictionary<string, List<double>> productUnits, string unitName)
        {
            List<double> results = new();

            for (int i = 0; i < productUnits[unitName].Count; i++)
            {
                double result = Math.Round(value * productUnits[unitName][i], 2);
                results.Add(result);
            }

            return results;
        }

        private Product CreateProduct(string name, Dictionary<string, List<double>> units)
        {
            return new Product(name, units);
        }

        private void Initialize()
        {
            List<string> productNames = new() { "Water", "Sugar", "Butter", "WheatFlour", "Oil", "Cream18" };
            Dictionary<string, Dictionary<string, List<double>>> unitsData = FileManager.LoadUnitsFromJson(UNITS_LIST_PATH);

            foreach (var (productName, units) in productNames.Zip(unitsData, (name, unitsDict) => (name, unitsDict.Value)))
            {
                AddItem(CreateProduct(productName, units));
            }
        }
        //    AddItem(CreateProduct("Water", waterUnits));
        //    AddItem(CreateProduct("Sugar", sugarUnits));
        //    AddItem(CreateProduct("Butter", butterUnits));
        //    AddItem(CreateProduct("WheatFlour", wheatFlourUnits));
        //    AddItem(CreateProduct("Oil", oilUnits));
        //    AddItem(CreateProduct("Cream18", cream18Units));
        //}

        //private readonly Dictionary<string, List<double>> waterUnits = new()
        //    {
        //        { "g", new List<double> { 1, 1, 0.004, 0.067, 0.2 } },
        //        { "ml", new List<double> { 1, 1, 0.004, 0.067, 0.2 } },
        //        { "glass", new List<double> { 250, 250, 1, 16.67, 50 } },
        //        { "spoon", new List<double> { 15, 15, 0.06, 1, 3 } },
        //        { "teaspoon", new List<double> { 5, 5, 0.02, 0.33, 1 } },
        //    };

        //private readonly Dictionary<string, List<double>> sugarUnits = new()
        //    {
        //        { "g", new List<double> { 1, 1.136, 0.005, 0.076, 0.227 } },
        //        { "ml", new List<double> { 0.88, 1, 0.004, 0.067, 0.2 } },
        //        { "glass", new List<double> { 220, 250, 1, 16.67, 50 } },
        //        { "spoon", new List<double> { 13.2, 15, 0.06, 1, 3 } },
        //        { "teaspoon", new List<double> { 4.4, 5, 0.02, 0.33, 1 } },
        //    };

        //private readonly Dictionary<string, List<double>> butterUnits = new()
        //    {
        //        { "g", new List<double> { 1, 1.042, 0.004, 0.069, 0.208 } },
        //        { "ml", new List<double> { 0.96, 1, 0.004, 0.067, 0.2 } },
        //        { "glass", new List<double> { 240, 250, 1, 16.67, 50 } },
        //        { "spoon", new List<double> { 14.4, 15, 0.06, 1, 3 } },
        //        { "teaspoon", new List<double> { 4.8, 5, 0.02, 0.33, 1 } },
        //    };

        //private readonly Dictionary<string, List<double>> wheatFlourUnits = new()
        //    {
        //        { "g", new List<double> { 1, 1.563, 0.006, 0.104, 0.313 } },
        //        { "ml", new List<double> { 0.64, 1, 0.004, 0.067, 0.2 } },
        //        { "glass", new List<double> { 160, 250, 1, 16.67, 50 } },
        //        { "spoon", new List<double> { 9.6, 15, 0.06, 1, 3 } },
        //        { "teaspoon", new List<double> { 3.2, 5, 0.02, 0.33, 1 } },
        //    };

        //private readonly Dictionary<string, List<double>> oilUnits = new()
        //    {
        //        { "g", new List<double> { 1, 1.055, 0.004, 0.064, 0.192 } },
        //        { "ml", new List<double> { 1.04, 1, 0.004, 0.067, 0.2 } },
        //        { "glass", new List<double> { 260, 250, 1, 16.67, 50 } },
        //        { "spoon", new List<double> { 15.6, 15, 0.06, 1, 3 } },
        //        { "teaspoon", new List<double> { 5.2, 5, 0.02, 0.33, 1 } },
        //    };

        //private readonly Dictionary<string, List<double>> cream18Units = new()
        //    {
        //        { "g", new List<double> { 1, 0.962, 0.004, 0.07, 0.211 } },
        //        { "ml", new List<double> { 0.948, 1, 0.004, 0.067, 0.2 } },
        //        { "glass", new List<double> { 237, 250, 1, 16.67, 50 } },
        //        { "spoon", new List<double> { 14.22, 15, 0.06, 1, 3 } },
        //        { "teaspoon", new List<double> { 4.74, 5, 0.02, 0.33, 1 } },
        //    };
    }
}
