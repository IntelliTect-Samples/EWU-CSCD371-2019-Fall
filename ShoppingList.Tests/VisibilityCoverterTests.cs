using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShoppingList.Tests
{
    #pragma warning disable CA1707 // Identifiers should not contain underscores... To allow Underscores in the name

    [TestClass]
    public class VisibilityCoverterTests
    {
        [TestMethod]
        public void Convert_ReturnVisible()
        {
            ShopItem item = new ShopItem("test");
            VisibilityConverter visibility = new VisibilityConverter();

            Assert.AreEqual("Visible", visibility.Convert(item));
        }

        [TestMethod]
        public void Convert_ReturnCollapsed()
        {
            string item = "hello";
            VisibilityConverter visibility = new VisibilityConverter();

            Assert.AreEqual("Collapsed", visibility.Convert(item));
        }
    }
}
