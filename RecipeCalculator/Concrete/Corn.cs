namespace RecipeCalculator
{
    public class Corn : Produce
    {
        const double DEFAULT_UNIT_COST = 0.87;

        public Corn(IRecipe inRecipe, double inUnits)
        {
            this.setRecipe(inRecipe);
            this.Units = inUnits;
            this.IsOrganic = false;
            this.UnitPrice = DEFAULT_UNIT_COST;
        }

        public override string ToString()
        {
            return Units + " cup" + (Units == 1.0 ? "" : "s") +
                " of " + (IsOrganic ? "Organic " : "") +
                "Corn";
        }
    }
}
