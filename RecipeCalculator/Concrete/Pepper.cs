namespace RecipeCalculator
{
    public class Pepper : Ingredient
    {
        const double DEFAULT_UNIT_COST = 0.17;

        public Pepper(IRecipe inRecipe, double inUnits)
        {
            this.setRecipe(inRecipe);
            this.Units = inUnits;
            this.IsOrganic = false;
            this.UnitPrice = DEFAULT_UNIT_COST;
        }

        public override string ToString()
        {
            return Units + " teaspoon" + (Units == 1.0 ? "" : "s") +
                " of " + (IsOrganic ? "Organic " : "") +
                "Pepper";
        }
    }
}
