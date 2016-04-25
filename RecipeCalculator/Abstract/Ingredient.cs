using System;

namespace RecipeCalculator
{
    public abstract class Ingredient : IRecipe
    {
        //public member vars
        public virtual double Units { get; set; }
        public virtual bool IsOrganic { get; set; }
        public virtual double UnitPrice { get; set; }

        //private member vars
        private static double TaxRateAsFractionOfOne = Constants.DEFAULT_TAX_RATE;
        private static double WellnessDiscountAsFractionOfOne = Constants.DEFAULT_WELLNESS_DISCOUNT;
        public IRecipe Recipe = null;

        //getters
        public virtual double getIngredientSubtotal()
        {
            return UnitPrice * Units;
        }

        public double getRawSubtotal()
        {
            double ingredientSubtotal = getIngredientSubtotal();

            return ingredientSubtotal +
                (Recipe != null ? Recipe.getRawSubtotal() : 0);
        }

        public virtual double getSubtotal()
        {
            double rawSubtotal = getRawSubtotal();
            double significantRawSubtotal = Math.Round(rawSubtotal, 10);
            double rawSubtotalCeiling = (Math.Ceiling(significantRawSubtotal * 100) / 100);

            return Math.Round(rawSubtotalCeiling, 2);
        }

        public virtual double getRawTax()
        {
            double ingredientSubtotal = getIngredientSubtotal();

            return ingredientSubtotal * Ingredient.TaxRateAsFractionOfOne +
                (Recipe != null ? Recipe.getRawTax() : 0);
        }

        public virtual double getTax()
        {
            double rawTax = getRawTax();

            return Math.Round(RoundUpTax(rawTax), 2);
        }

        public static double RoundUpTax(double rawValue)
        {
            bool roundUpRequired = (rawValue % Constants.DEFAULT_TAX_ROUND_UP_MULTIPLE) > 0.0;
            int multiples = ((int) (rawValue / Constants.DEFAULT_TAX_ROUND_UP_MULTIPLE)) + (roundUpRequired ? 1 : 0);

            return multiples * .07;
        }

        public double getRawWellnessDiscount()
        {
            double ingredientDiscount = getIngredientSubtotal() * (IsOrganic ? Ingredient.WellnessDiscountAsFractionOfOne : 0.0);
            double ingredientTotalBeforeDiscount = getIngredientSubtotal();

            return (ingredientDiscount > ingredientTotalBeforeDiscount ? ingredientTotalBeforeDiscount : ingredientDiscount) +
                (Recipe != null ? Recipe.getRawWellnessDiscount() : 0);
        }

        public virtual double getWellnessDiscount()
        {
            double rawWellnessDiscount = getRawWellnessDiscount();

            return Math.Round((Math.Ceiling(rawWellnessDiscount * 100) / 100), 2);
        }

        public double getTotalCost()
        {
            double subTotal = getSubtotal();
            double tax = getTax();
            double wellnessDiscount = getWellnessDiscount();

            return Math.Round((subTotal + tax - wellnessDiscount), 2);
        }

        //setters
        public void setTaxRate(double rateAsFractionOfOne)
        {
            Ingredient.TaxRateAsFractionOfOne = rateAsFractionOfOne;
        }

        public void setWellnessDiscount(double discountAsFractionOfOne)
        {
            Ingredient.WellnessDiscountAsFractionOfOne = discountAsFractionOfOne;
        }

        protected void setRecipe(IRecipe newRecipe)
        {
            this.Recipe = newRecipe;
        }

        //member functions
        public void addServing(double toAdd)
        {
            Units += toAdd;
            return;
        }

        public void subtractServing(double toAdd)
        {
            if (toAdd > Units)
            {
                Units = 0;
            }
            else
            {
                Units -= toAdd;
            }            
            return;
        }

        public string printRecipe()
        {
            return (Recipe != null ? Recipe.printRecipe() + "\n" : "") + ToString();
        }
    }
}
