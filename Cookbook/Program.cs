using System;

namespace Cookbook
{
    class Program
    {
        public const string FILE_NAME = "F:\\Cookbook App\\Recipes.xlsx";
        static void Main(string[] args)
        {
            Console.WriteLine("Witaj w aplikacji Książka kucharska.");
            Console.WriteLine("Co chciałbyś dzisiaj zrobić?");
            Console.WriteLine("1. Wyświetl przepisy.");      //alfabetycznie; wg składnika, wg rodzaju, czasu przygotowania etc.//
            Console.WriteLine("2. Dodaj przepis.");
            Console.WriteLine("3. Przelicz wartości kuchenne.");
            Console.WriteLine("Wybierz 1, 2 lub 3.");       //zweryfikować poprawność wyboru; EXIT?//

            string choice = Console.ReadLine();

            Console.WriteLine($"Wybrano: {choice}");     //docelowo - wyświetli "Przepisy", "Dodawanie przepisu", "Przelicznik", nie tylko nr//


            int chosenOption = 0;

            Int32.TryParse(choice, out chosenOption);

            Console.WriteLine("Co chciałbyś dalej zrobić?"); //w zależności od wybranego punktu//

            choice = Console.ReadLine();

            Int32.TryParse(choice,out chosenOption);
        }
    }
}

 
