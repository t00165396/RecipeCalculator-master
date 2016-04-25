namespace RecipeCalculator
{
    public class ChickenBreast : Ingredient
    {
        const double DEFAULT_UNIT_COST = 2.19;

        public ChickenBreast(IRecipe inRecipe, double inUnits)
        {
            this.setRecipe(inRecipe);
            this.Units = inUnits;
            this.IsOrganic = false;
            this.UnitPrice = DEFAULT_UNIT_COST;
        }

        public override string ToString()
        {
            return Units + (IsOrganic ? "Organic " : " ") +
                "Chicken Breast" + (Units == 1.0 ? "" : "s");
        }
    }
}
