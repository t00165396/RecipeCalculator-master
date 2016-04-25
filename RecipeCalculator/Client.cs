using System;

namespace RecipeCalculator
{
    internal class Client
    {
        static void Main(string[] args)
        {
            //Recipe 1,,,,
            IRecipe recipe1 = null;
            recipe1 = new Garlic(recipe1, 1);
            recipe1 = new Lemon(recipe1, 1);
            recipe1 = new OliveOil(recipe1, (3 / 4.0));
            recipe1 = new Salt(recipe1, (3 / 4.0));
            recipe1 = new Pepper(recipe1, (1 / 2.0));
            Console.Write("Recipe 1" + "\n");
            printTotals(recipe1);

            //Recipe 2
            IRecipe recipe2 = null;
            recipe2 = new Garlic(recipe2, 1);
            recipe2 = new ChickenBreast(recipe2, 4);
            recipe2 = new OliveOil(recipe2, (1 / 2.0));
            recipe2 = new Vinegar(recipe2, (1 / 2.0));
            Console.Write("Recipe 2" + "\n");
            printTotals(recipe2);

            //Recipe 3
            IRecipe recipe3 = null;
            recipe3 = new Garlic(recipe3, 1);
            recipe3 = new Corn(recipe3, 4);
            recipe3 = new Bacon(recipe3, 4);
            recipe3 = new Pasta(recipe3, 8);
            recipe3 = new OliveOil(recipe3, (1 / 3.0));
            recipe3 = new Salt(recipe3, (5 / 4.0));
            recipe3 = new Pepper(recipe3, (3 / 4.0));
            Console.Write("Recipe 3" + "\n");
            printTotals(recipe3);

            //Pause
            Console.ReadLine();
        }

        static void printTotals(IRecipe recipe)
        {
            Console.Write("\n\tTax = $" + recipe.getTax() + "\n");
            Console.Write("\tDiscount = ($" + recipe.getWellnessDiscount() + ")\n");
            Console.Write("\tTotal = $" + recipe.getTotalCost() + "\n\n");
        }
    }
}
