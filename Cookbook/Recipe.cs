using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook
{
    public class Recipe
    {
        public static int nextId = 1;
        public static List<int> freeIds = new List<int>();
        public int Id { get; set; }

        public string Name { get; set; }
        public List<string> Ingredients { get; set; }
        public string Instructions { get; set; }
        public string MealType { get; set; }
        public int PreparationTime { get; set; }

    }
}
