using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RecipeCalculator.tests
{
    [TestClass]
    public class UnitTests
    {
        const double DEFAULT_UNIT_SIZE = 1.0;

        [TestMethod]
        public void AddServingShouldIncreaseUnitSize()
        {
            //Arrange
            Ingredient control = new Garlic(null, DEFAULT_UNIT_SIZE);
            Ingredient recipe = new Garlic(null, DEFAULT_UNIT_SIZE);

            //Assert
            Assert.IsTrue(control.Units == DEFAULT_UNIT_SIZE);
            Assert.IsTrue(recipe.Units == DEFAULT_UNIT_SIZE);

            //Act
            recipe.addServing(DEFAULT_UNIT_SIZE);

            //Assert
            Assert.IsTrue(recipe.Units > control.Units);
            Assert.IsTrue(recipe.Units == (DEFAULT_UNIT_SIZE * 2));
        }

        [TestMethod]
        public void SubtractServingCannotMakeSizeNegative()
        {
            //Arrange            
            Ingredient aboveZero = new Lemon(null, DEFAULT_UNIT_SIZE);
            Ingredient atZero = new Garlic(null, DEFAULT_UNIT_SIZE);
            Ingredient belowZero = new Corn(null, DEFAULT_UNIT_SIZE);

            //Assert
            Assert.IsTrue(aboveZero.Units == DEFAULT_UNIT_SIZE);
            Assert.IsTrue(atZero.Units == DEFAULT_UNIT_SIZE);
            Assert.IsTrue(belowZero.Units == DEFAULT_UNIT_SIZE);

            //Act
            aboveZero.subtractServing(DEFAULT_UNIT_SIZE - 0.1);
            atZero.subtractServing(DEFAULT_UNIT_SIZE);
            belowZero.subtractServing(DEFAULT_UNIT_SIZE + 0.1);

            //Assert
            Assert.IsTrue(aboveZero.Units > 0.0);
            Assert.IsTrue(atZero.Units == 0.0);
            Assert.IsTrue(belowZero.Units >= 0.0);
        }

        [TestMethod]
        public void AddIngredientDoesNotRemoveIngredients()
        {
            //Arrange
            IRecipe recipe = new Bacon(null, DEFAULT_UNIT_SIZE);

            //Assert
            bool containsBacon = recipe.printRecipe().ToLower().Contains("bacon");
            Assert.IsTrue(containsBacon);

            //Act
            recipe = new Salt(recipe, DEFAULT_UNIT_SIZE);

            //Assert
            containsBacon = recipe.printRecipe().ToLower().Contains("bacon");
            bool containsSalt = recipe.printRecipe().ToLower().Contains("salt");
            Assert.IsTrue(containsBacon);
            Assert.IsTrue(containsSalt);
        }

        [TestMethod]
        public void TaxNonProduceCumulativeNotZero()
        {
            //Arrange
            Ingredient recipe = new ChickenBreast(null, DEFAULT_UNIT_SIZE);

            //Assert
            double tax = recipe.getTax();
            Assert.IsTrue(tax != 0);

            //Act
            recipe = new ChickenBreast(recipe, DEFAULT_UNIT_SIZE);
            double doubleTax = recipe.getTax();

            //Assert
            Assert.IsTrue(doubleTax != 0);
            Assert.IsTrue(doubleTax == (tax * 2));

            //Cleanup
            recipe.setTaxRate(Constants.DEFAULT_TAX_RATE);
        }

        [TestMethod]
        public void TaxProduceEqualsZero()
        {
            //Arrange
            Ingredient recipe = new Lemon(null, DEFAULT_UNIT_SIZE);
            Ingredient nonProduce = new ChickenBreast(null, DEFAULT_UNIT_SIZE);

            //Assert
            Assert.IsTrue(recipe.getTax() == 0);
            Assert.IsFalse(nonProduce.getTax() == 0);

            //Act
            recipe = new ChickenBreast(recipe, DEFAULT_UNIT_SIZE);

            //Assert
            Assert.IsTrue(recipe.getTax() == nonProduce.getTax());
        }

        [TestMethod]
        public void WellnessDiscountOrganicOnly()
        {
            //Arrange
            Ingredient organic = new Garlic(null, DEFAULT_UNIT_SIZE);
            Ingredient inOrganic = new Corn(null, DEFAULT_UNIT_SIZE);

            //Assert
            Assert.IsTrue(organic.IsOrganic == true);
            Assert.IsFalse(inOrganic.IsOrganic == true);

            //Act
            double organicDiscount = organic.getWellnessDiscount();
            double inOrganicDiscount = inOrganic.getWellnessDiscount();

            //Assert
            Assert.IsTrue(organicDiscount != 0);
            Assert.IsTrue(inOrganicDiscount == 0);
        }

        [TestMethod]
        public void WellnessDiscountShouldNotExceedSubtotal()
        {
            //Arrange
            Ingredient oliveOil = new OliveOil(null, DEFAULT_UNIT_SIZE);

            //Assert
            Assert.IsTrue(oliveOil.getSubtotal() >= oliveOil.getWellnessDiscount());

            //Act
            oliveOil.setWellnessDiscount(1.1);

            //Assert
            Assert.IsTrue(oliveOil.getSubtotal() >= oliveOil.getWellnessDiscount());
        }

        [TestMethod]
        public void DefaultOrganicIngredients()
        {
            //Arrange
            Ingredient garlic = new Garlic(null, DEFAULT_UNIT_SIZE);
            Ingredient oliveOil = new OliveOil(null, DEFAULT_UNIT_SIZE);

            //Assert
            Assert.IsTrue(garlic.IsOrganic);
            Assert.IsTrue(oliveOil.IsOrganic);
        }

        [TestMethod]
        public void IsOrganicPropertyIsChangeable()
        {
            //Arrange
            Ingredient control = new Garlic(null, DEFAULT_UNIT_SIZE);
            Ingredient organic = new Garlic(null, DEFAULT_UNIT_SIZE);

            //Assert
            Assert.IsTrue(organic.IsOrganic == true);

            //Act
            organic.IsOrganic = false;

            //Assert
            Assert.AreNotEqual(control.IsOrganic, organic.IsOrganic);
            Assert.IsFalse(organic.IsOrganic == true);
        }

        [TestMethod]
        public void SubtotalOfSingleIngredient()
        {
            //Arrange
            Ingredient pasta = new Pasta(null, DEFAULT_UNIT_SIZE);

            //Assert
            Assert.AreEqual(pasta.getIngredientSubtotal(), pasta.getSubtotal());

            //Act
            double subTotalExpected = 0.31 * DEFAULT_UNIT_SIZE;

            //Assert
            Assert.AreEqual(subTotalExpected, pasta.getSubtotal());
        }

        [TestMethod]
        public void TaxOfSingleIngredient()
        {
            //Arrange
            Ingredient pasta = new Pasta(null, DEFAULT_UNIT_SIZE);

            //Act
            double pastaRawSubtotal = pasta.getRawSubtotal();
            double taxExpected = Ingredient.RoundUpTax(
                Math.Round(Constants.DEFAULT_TAX_RATE * pastaRawSubtotal, 2)
            );
            double taxActual = pasta.getTax();

            //Assert
            Assert.AreEqual(taxExpected, taxActual);
        }
    }
}
