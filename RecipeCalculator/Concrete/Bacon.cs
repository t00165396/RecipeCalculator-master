namespace RecipeCalculator
{
    public class Bacon : Ingredient
    {
        const double DEFAULT_UNIT_COST = 0.24;

        public Bacon(IRecipe inRecipe, double inUnits)
        {
            this.setRecipe(inRecipe);
            this.Units = inUnits;
            this.IsOrganic = false;
            this.UnitPrice = DEFAULT_UNIT_COST;
        }

        public override string ToString()
        {
            return Units + " slice" + (Units == 1.0 ? "" : "s") +
                " of " + (IsOrganic ? "Organic " : "") +
                "Bacon";
        }
    }
}
