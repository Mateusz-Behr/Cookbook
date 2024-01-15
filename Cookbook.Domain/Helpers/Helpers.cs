using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Domain.Helpers
{
    public class Helpers
    {
        public enum MealType
        {
            Breakfest = 1,
            Lunch,
            Desser,
            Dinner
        }

        public enum UnitType
        {
            Grams = 1,
            Milliliters,
            Glasses,
            Spoons,
            Teaspoons
        }

        public int ConvertToInt(string? inputtedValue)
        {
            try
            {
                int intValue = int.Parse(inputtedValue);
                return intValue;
            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong number format!");
                return -1;
            }
            catch (OverflowException)
            {
                Console.WriteLine("\r\nThe number entered is too large or too small.");
                return -1;
            }
        }

        public double ConvertToDouble(string? inputtedValue)
        {
            try
            {
                double doubleValue = double.Parse(inputtedValue);
                return doubleValue;
            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong number format!");
                return -1;
            }
            catch (OverflowException)
            {
                Console.WriteLine("\r\nThe number entered is too large or too small.");
                return -1;
            }
        }
    } 
}
