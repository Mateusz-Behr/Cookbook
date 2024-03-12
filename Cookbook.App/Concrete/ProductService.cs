using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Cookbook.App.Abstract;
using Cookbook.App.Common;
using Cookbook.App.Managers;
using Cookbook.Domain.Entity;
using Cookbook.Domain.Helpers;
using Newtonsoft.Json;

namespace Cookbook.App.Concrete
{
    public class ProductService : BaseService<Product>, IProductService
    {
        private const string PRODUCTS_LIST_PATH = "products_list.json";

        public ProductService()
        {
            Initialize();
        }

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
            return chosenUnitNumber switch
            {
                1 => "g",
                2 => "ml",
                3 => "glass",
                4 => "spoon",
                5 => "teaspoon",
                _ => "",
            };
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

        private static Product CreateProduct(string name, Dictionary<string, List<double>> units)
        {
            return new Product(name, units);
        }

        private void Initialize()
        {
            string jsonFile = File.ReadAllText(PRODUCTS_LIST_PATH);
            List<ProductInfo> productsList = JsonConvert.DeserializeObject<List<ProductInfo>>(jsonFile);

            foreach (var product in productsList)
            {
                AddItem(CreateProduct(product.Name, product.Units));
            }
        }
    }
}
