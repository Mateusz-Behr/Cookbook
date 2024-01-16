using Cookbook.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Domain.Entity
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public Dictionary<string, List<double>> ListOfUnits { get; set; }

        public Product(string name, Dictionary<string, List<double>> listOfUnits)
        {
            Name = name;
            ListOfUnits = listOfUnits;
        }
    }
}

  
