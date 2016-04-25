namespace RecipeCalculator
{
    public class Garlic : Produce
    {
        const double DEFAULT_UNIT_COST = 0.67;

        public Garlic(IRecipe inRecipe, double inUnits)
        {
            this.setRecipe(inRecipe);
            this.Units = inUnits;
            this.IsOrganic = true;
            this.UnitPrice = DEFAULT_UNIT_COST;
        }

        public override string ToString()
        {
            return Units + " clove" + (Units == 1.0 ? "" : "s") +
                " of " + (IsOrganic ? "Organic " : "") +
                "Garlic";
        }
    }
}
