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
        private const int MAX_RECIPES = 500;
        private static bool[] usedIds = new bool[MAX_RECIPES];
      
        public int Id { get; set; }

        public string Name { get; set; }
        public List<string> Ingredients { get; set; }
        public string Instructions { get; set; }
        public string MealType { get; set; }
        public int PreparationTime { get; set; }

        public Recipe()  //auto_increment Id
        {
            this.Id = GetFirstUnused();
        }

        public int GetFirstUnused()
        {
            int foundId = -1;
            for(int i = 0; i < MAX_RECIPES; i++)
            {
                if (usedIds[i] == false)
                {
                    foundId = i;
                    usedIds[i] = true;
                    break;
                }
            }
            return foundId;
        }
    }
}
