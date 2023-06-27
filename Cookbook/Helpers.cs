using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook
{
    public static class Helpers
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



    //public class RecipeService ?? co z tym zrobić ??
    //{
    //    public void AddRecipe()
    //    { }
    //    public void RemoveRecipe() 
    //    { }
    //}
    public struct SomeStructure
    {
        private int numberForStructure;
        private string nameOfStructure;

        public SomeStructure(int number, string name)
        {
            numberForStructure = number;
            nameOfStructure = name;
        }
    }
}
