using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Inheritance.Tests
{
    [TestClass]
    public class FoodTests
    {
        [TestMethod]
        public void Food_EnsureCorrectPrint()
        {
            var food = new Food {Brand = "Brett's Best", Upc = "31415926535"};
            Assert.AreEqual("31415926535 - Brett's Best", food.PrintInfo());
        }
    }
}