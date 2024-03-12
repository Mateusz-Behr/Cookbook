using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.App.Abstract
{
    public interface IProductService
    {
        Dictionary<string, List<double>> GetUnitsListFromChosenProduct(int chosenProduct);
        string GetUnitNameByNumber(int chosenUnitNumber);
        string GetUnitFullName(int chosenUnitNumber);
        List<double> CalculateUnits(double value, Dictionary<string, List<double>> productUnits, string unitName);
    }
}
