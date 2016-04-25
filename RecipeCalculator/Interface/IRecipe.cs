namespace RecipeCalculator
{
    public interface IRecipe
    {
        double getRawSubtotal();

        double getSubtotal();

        double getRawTax();

        double getTax();

        double getRawWellnessDiscount();

        double getWellnessDiscount();

        double getTotalCost();

        string printRecipe();
    }
}
