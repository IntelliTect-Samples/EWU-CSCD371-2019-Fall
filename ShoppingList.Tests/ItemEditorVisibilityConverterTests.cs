using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShoppingList.Tests
{
    [TestClass]
    public class ItemEditorVisibilityConverterTests
    {
        [DataTestMethod]
        public void Convert_ItemNull_ReturnsCollapsed()
        {
            ItemEditorVisibilityConverter converter = new ItemEditorVisibilityConverter();

            string state = (string) converter.Convert(null);

            Assert.AreEqual<string>("Collapsed", state);
        }

        [TestMethod]
        public void Convert_ItemIsItem_ReturnsVisible()
        {
            ItemEditorVisibilityConverter converter = new ItemEditorVisibilityConverter();

            string state = (string) converter.Convert(new Item());

            Assert.AreEqual<string>("Visible", state);
        }
    }
}