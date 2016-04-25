namespace RecipeCalculator
{
    public class Pasta : Ingredient
    {
        const double DEFAULT_UNIT_COST = 0.31;

        public Pasta(IRecipe inRecipe, double inUnits)
        {
            this.setRecipe(inRecipe);
            this.Units = inUnits;
            this.IsOrganic = false;
            this.UnitPrice = DEFAULT_UNIT_COST;
        }

        public override string ToString()
        {
            return Units + " ounce" + (Units == 1.0 ? "" : "s") +
                " of " + (IsOrganic ? "Organic " : "") +
                "Pasta";
        }
    }
}
