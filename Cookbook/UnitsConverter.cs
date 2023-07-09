using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook
{
    public static class UnitsConverter
    {

        // przykład - do przeliczania jednostek
        public static int KgToG(int kgCount)
        {
            return kgCount * 1000;
        }
    }
    public enum RecipeType    //dane słownikowe
    {
        Śniadanie = 1,
        Obiad,
        Kolacja
    }
}
