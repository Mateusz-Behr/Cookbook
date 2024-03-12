using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Domain.Entity
{
    public class ProductInfo
    {
        public string Name { get; set; }
        public Dictionary <string, List<double>> Units { get; set; }
    }
}
