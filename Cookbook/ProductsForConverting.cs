using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook
{
    public class ProductsForConverting
    {
        public List<Dictionary<string, List<double>>> listOfProducts;

        public ProductsForConverting()
        {
            listOfProducts = new List<Dictionary<string, List<double>>>();

            Dictionary<string, List<double>> water = new Dictionary<string, List<double>>
            {
                { "g", new List<double> { 1, 0.004, 0.067, 0.2 } },
                { "ml", new List<double> { 1, 0.004, 0.067, 0.2 } },
                { "glass", new List<double> { 250, 250, 16.67, 50 } },
                { "spoon", new List<double> { 15, 15, 0.06, 3 } },
                { "teaspoon", new List<double> { 5, 5, 0.02, 0.33 } },
            };

            Dictionary<string, List<double>> sugar = new Dictionary<string, List<double>>
            {
                { "g", new List<double> { 1.136, 0.005, 0.076, 0.227 } },
                { "ml", new List<double> { 0.88, 0.004, 0.067, 0.2 } },
                { "glass", new List<double> { 220, 250, 16.67, 50 } },
                { "spoon", new List<double> { 13.2, 15, 0.06, 3 } },
                { "teaspoon", new List<double> { 4.4, 5, 0.02, 0.33 } },
            };

            Dictionary<string, List<double>> butter = new Dictionary<string, List<double>>
            {
                { "g", new List<double> { 1.042, 0.004, 0.069, 0.208 } },
                { "ml", new List<double> { 0.96, 0.004, 0.067, 0.2 } },
                { "glass", new List<double> { 240, 250, 16.67, 50 } },
                { "spoon", new List<double> { 14.4, 15, 0.06, 3 } },
                { "teaspoon", new List<double> { 4.8, 5, 0.02, 0.33 } },
            };

            Dictionary<string, List<double>> wheatFlour = new Dictionary<string, List<double>>
            {
                { "g", new List<double> { 1.563, 0.006, 0.104, 0.313 } },
                { "ml", new List<double> { 0.64, 0.004, 0.067, 0.2 } },
                { "glass", new List<double> { 160, 250, 16.67, 50 } },
                { "spoon", new List<double> { 9.6, 15, 0.06, 3 } },
                { "teaspoon", new List<double> { 3.2, 5, 0.02, 0.33 } },
            };

            Dictionary<string, List<double>> oil = new Dictionary<string, List<double>>
            {
                { "g", new List<double> { 1.055, 0.004, 0.064, 0.192 } },
                { "ml", new List<double> { 1.04, 0.004, 0.067, 0.2 } },
                { "glass", new List<double> { 260, 250, 16.67, 50 } },
                { "spoon", new List<double> { 15.6, 15, 0.06, 3 } },
                { "teaspoon", new List<double> { 5.2, 5, 0.02, 0.33 } },
            };

            Dictionary<string, List<double>> cream18 = new Dictionary<string, List<double>>
            {
                { "g", new List<double> { 0.962, 0.004, 0.07, 0.211 } },
                { "ml", new List<double> { 0.948, 0.004, 0.067, 0.2 } },
                { "glass", new List<double> { 237, 250, 16.67, 50 } },
                { "spoon", new List<double> { 14.22, 15, 0.06, 3 } },
                { "teaspoon", new List<double> { 4.74, 5, 0.02, 0.33 } },
            };

            listOfProducts.Add(water);
            listOfProducts.Add(sugar);
            listOfProducts.Add(butter);
            listOfProducts.Add(wheatFlour);
            listOfProducts.Add(oil);
            listOfProducts.Add(cream18);
        }

        public Dictionary<string, List<double>> GetDictionary(int index) 
        {
            if (index >= 0 && index < listOfProducts.Count) 
            { 
                return listOfProducts[index]; 
            }
            else
            {
                throw new IndexOutOfRangeException("\nThere is no product with that index on list.");
            }
        }


    }
}
