using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Inheritance.Tests
{
    [TestClass]
    public class FoodTests
    {
        [TestMethod]
        public void FoodPrintInfo_CorrectlyFormatted()
        {
            string upc = "8675309",
                   brand = "SomeBrand";
            var food = new Food() {
                Upc = upc,
                Brand = brand
            };
            Assert.AreEqual(
                $"{brand} - {upc}",
                food.PrintInfo()
            );
        }
    }
}
