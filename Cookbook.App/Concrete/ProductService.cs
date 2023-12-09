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

        public int productNextId = 1;
        public List<int> productFreeIds = new List<int>();

        public override int GetFreeId()
        {
            int searchedId;

            if (productFreeIds.Count > 0)
            {
                searchedId = productFreeIds[0];
                productFreeIds.RemoveAt(0);
                return searchedId;
            }
            else
            {
                searchedId = productNextId;
                productNextId++;
                return searchedId;
            }
        }


        public Dictionary<string, List<double>> ChosenProduct(char chosenProductCharKey)
        {
            int chosenProduct = Convert.ToInt32(chosenProductCharKey.ToString());

            if (chosenProduct > 0 && chosenProduct <= Items.Count)
            {
                return Items[chosenProduct - 1].ListOfUnits;
            }
            else
            {
                return new Dictionary<string, List<double>>();
            }
        }

        public string AccesToUnitsList(int chosenUnitNumber)
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

        public string GetUnitName(int chosenUnitNumber)
        {
            
            UnitType unitType = (UnitType)chosenUnitNumber;
            switch (unitType)
            {
                case UnitType.Grams:
                    return "gram(s)";
                case UnitType.Milliliters:
                    return "milililiter(s)";
                case UnitType.Glasses:
                    return "glass(es)";
                case UnitType.Spoons:
                    return "spoon(s)";
                case UnitType.Teaspoons:
                    return "teaspoon(s)";
                default:
                    return "unknown";
            }

        }

        public List<double> CalculateUnits(double value, Dictionary<string, List<double>> product, int chosenUnitNumber)
        {
            string unitName = AccesToUnitsList(chosenUnitNumber);
            List<double> results = new List<double>();

            for (int i = 0; i < product[unitName].Count; i++)
            {
                double result = Math.Round(value * product[unitName][i], 2);
                results.Add(result);
            }

            return results;
        }


        private void Initialize()
        {
            AddItem(new Product(GetFreeId(), "Water", waterUnits));
            AddItem(new Product(GetFreeId(), "Sugar", sugarUnits));
            AddItem(new Product(GetFreeId(), "Butter", butterUnits));
            AddItem(new Product(GetFreeId(), "WheatFlour", wheatFlourUnits));
            AddItem(new Product(GetFreeId(), "Oil", oilUnits));
            AddItem(new Product(GetFreeId(), "Cream18", cream18Units));
        }

        private Dictionary<string, List<double>> waterUnits = new Dictionary<string, List<double>>
            {
                { "g", new List<double> { 1, 1, 0.004, 0.067, 0.2 } },
                { "ml", new List<double> { 1, 1, 0.004, 0.067, 0.2 } },
                { "glass", new List<double> { 250, 250, 1, 16.67, 50 } },
                { "spoon", new List<double> { 15, 15, 0.06, 1, 3 } },
                { "teaspoon", new List<double> { 5, 5, 0.02, 0.33, 1 } },
            };

        private Dictionary<string, List<double>> sugarUnits = new Dictionary<string, List<double>>
            {
                { "g", new List<double> { 1, 1.136, 0.005, 0.076, 0.227 } },
                { "ml", new List<double> { 0.88, 1, 0.004, 0.067, 0.2 } },
                { "glass", new List<double> { 220, 250, 1, 16.67, 50 } },
                { "spoon", new List<double> { 13.2, 15, 0.06, 1, 3 } },
                { "teaspoon", new List<double> { 4.4, 5, 0.02, 0.33, 1 } },
            };

        private Dictionary<string, List<double>> butterUnits = new Dictionary<string, List<double>>
            {
                { "g", new List<double> { 1, 1.042, 0.004, 0.069, 0.208 } },
                { "ml", new List<double> { 0.96, 1, 0.004, 0.067, 0.2 } },
                { "glass", new List<double> { 240, 250, 1, 16.67, 50 } },
                { "spoon", new List<double> { 14.4, 15, 0.06, 1, 3 } },
                { "teaspoon", new List<double> { 4.8, 5, 0.02, 0.33, 1 } },
            };

        private Dictionary<string, List<double>> wheatFlourUnits = new Dictionary<string, List<double>>
            {
                { "g", new List<double> { 1, 1.563, 0.006, 0.104, 0.313 } },
                { "ml", new List<double> { 0.64, 1, 0.004, 0.067, 0.2 } },
                { "glass", new List<double> { 160, 250, 1, 16.67, 50 } },
                { "spoon", new List<double> { 9.6, 15, 0.06, 1, 3 } },
                { "teaspoon", new List<double> { 3.2, 5, 0.02, 0.33, 1 } },
            };

        private Dictionary<string, List<double>> oilUnits = new Dictionary<string, List<double>>
            {
                { "g", new List<double> { 1, 1.055, 0.004, 0.064, 0.192 } },
                { "ml", new List<double> { 1.04, 1, 0.004, 0.067, 0.2 } },
                { "glass", new List<double> { 260, 250, 1, 16.67, 50 } },
                { "spoon", new List<double> { 15.6, 15, 0.06, 1, 3 } },
                { "teaspoon", new List<double> { 5.2, 5, 0.02, 0.33, 1 } },
            };

        private Dictionary<string, List<double>> cream18Units = new Dictionary<string, List<double>>
            {
                { "g", new List<double> { 1, 0.962, 0.004, 0.07, 0.211 } },
                { "ml", new List<double> { 0.948, 1, 0.004, 0.067, 0.2 } },
                { "glass", new List<double> { 237, 250, 1, 16.67, 50 } },
                { "spoon", new List<double> { 14.22, 15, 0.06, 1, 3 } },
                { "teaspoon", new List<double> { 4.74, 5, 0.02, 0.33, 1 } },
            };
    }
}
