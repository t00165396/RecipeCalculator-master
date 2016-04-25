namespace RecipeCalculator
{
    public class Salt : Ingredient
    {
        const double DEFAULT_UNIT_COST = 0.16;

        public Salt(IRecipe inRecipe, double inUnits)
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
                "Salt";
        }
    }
}
