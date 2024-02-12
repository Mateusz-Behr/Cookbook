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
        private static int lastProductId = 0;
        public string Name { get; set; }
        public Dictionary<string, List<double>> ListOfUnits { get; set; }

        public Product(string name, Dictionary<string, List<double>> listOfUnits)
        {
            Id = ++lastProductId;
            Name = name;
            ListOfUnits = listOfUnits;
        }
    }
}

  
