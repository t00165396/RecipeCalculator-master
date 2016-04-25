namespace RecipeCalculator
{
    public class Lemon : Produce
    {
        const double DEFAULT_UNIT_COST = 2.03;

        public Lemon(IRecipe inRecipe, double inUnits)
        {
            this.setRecipe(inRecipe);
            this.Units = inUnits;
            this.IsOrganic = false;
            this.UnitPrice = DEFAULT_UNIT_COST;
        }

        public override string ToString()
        {
            return Units + (IsOrganic ? "Organic " : " ") +
                "Lemon" + (Units == 1.0 ? "" : "s");
        }
    }
}
