namespace RecipeCalculator
{
    public class OliveOil : Ingredient
    {
        const double DEFAULT_UNIT_COST = 1.92;

        public OliveOil(IRecipe inRecipe, double inUnits)
        {
            this.setRecipe(inRecipe);
            this.Units = inUnits;
            this.IsOrganic = true;
            this.UnitPrice = DEFAULT_UNIT_COST;
        }

        public override string ToString()
        {
            return Units + " cup" + (Units == 1.0 ? "" : "s") +
                " of " + (IsOrganic ? "Organic " : "") +
                "Olive Oil";
        }
    }
}
