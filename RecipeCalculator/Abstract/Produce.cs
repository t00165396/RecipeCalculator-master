namespace RecipeCalculator
{
    public abstract class Produce : Ingredient
    {
        public override sealed double getRawTax()
        {
            return 0 + (Recipe != null ? Recipe.getRawTax() : 0);
        }
    }
}
